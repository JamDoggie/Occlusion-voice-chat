using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Buffers.Binary;
using Occlusion_Voice_Chat_CrossPlatform.util;
using Occlusion_voice_chat.Opus;
using System.Numerics;

namespace Occlusion_Voice_Chat_CrossPlatform.HRTF
{
    public class MHRFile
    {
        public HRTFSet HRTFSet { get; set; }

        public bool Stereo { get; set; }

        public FileInfo FileInformation { get; set; }

        public static MHRFile? Parse(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            MHRFile mhrFile = new MHRFile();

            FileInfo file = new FileInfo(filePath);

            mhrFile.FileInformation = file;

            using(FileStream stream = file.OpenRead())
            {
                // Everything here is stored in Little Endian
                EndiannessAwareBinaryReader reader = new EndiannessAwareBinaryReader(stream, EndiannessAwareBinaryReader.Endianness.Little);

                // Version (8 character string)
                string versionNum = "";

                for (int i = 0; i < 8; i++)
                    versionNum += reader.ReadChar();

                if (!versionNum.StartsWith("MinPHR"))
                    throw new FormatException("Wrong file type. Expected a MinPHR01, MinPHR02, or MinPHR03 file.");

                int version = 0;

                if (versionNum.EndsWith("PHR01"))
                {
                    version = 1;
                }
                if (versionNum.EndsWith("PHR02"))
                {
                    version = 2;
                }
                if (versionNum.EndsWith("PHR03"))
                {
                    version = 3;
                }

                // Sampling Rate
                uint samplingRate = reader.ReadUInt32();

                // Bit Depth (0 = 16-bit, 1 = 24-bit)
                byte bitDepth = 0;
                if (version == 2)
                    bitDepth = reader.ReadByte();


                // true = stereo(two channels), false = mono(one channel)
                bool stereo = false;
                if (version >= 2)
                    stereo = reader.ReadByte() != 0 ? true : false;

                mhrFile.Stereo = stereo;

                byte hrirSize = reader.ReadByte();

                byte fdCount = 1;
                if (version >= 2)
                    fdCount = reader.ReadByte();

                if (fdCount < 1 || fdCount > 16)
                    throw new InvalidDataException($"Field count must be between 1(inclusive) and 16(inclusive). Please ensure the file \"{filePath}\" is valid.");

                int hrirCount = 0;

                List<HRTFField> fields = new List<HRTFField>();

                for(int i = 0; i < fdCount; i++)
                {
                    HRTFField field = new HRTFField();
                    field.hrirOffset = hrirCount;

                    field.Distance = 100;
                    if (version >= 2)
                        field.Distance = reader.ReadInt16();

                    if (field.Distance < 50 || field.Distance > 2500)
                        throw new InvalidDataException($"Field distance must be between 50mm(inclusive) and 2500mm(inclusive). Please ensure the file \"{filePath}\" is valid.");

                    byte evCount = reader.ReadByte();

                    field.azCount = new byte[evCount];
                    for(int j = 0; j < evCount; j++)
                    {
                        byte ev = reader.ReadByte();
                        field.azCount[j] = ev;

                        hrirCount += ev;
                    }

                    fields.Add(field);
                }

                // First, create a new HRTF set. This will store a list of elevations(from -90 degrees to 90 degrees, in order),
                // where each elevation stores a list of azimuths (starts from the front, and goes around in a circle clockwise. So basically from 360, to 1 degree clockwise).
                HRTFSet HRTFs = new HRTFSet();
                for (int i = 0; i < fields.Count; i++)
                {
                    HRTFField field = fields[i];
                    // Iterate through elevations
                    for(int j = 0; j < field.azCount.Length; j++)
                    {
                        List<CoeffSet> azimuths = new List<CoeffSet>();
                        byte evCount = field.azCount[j];
                        // Iterate through each azimuth per elevation.
                        for(int k = 0; k < evCount; k++)
                        {
                            CoeffSet set = new CoeffSet();
                            int channels = stereo ? 2 : 1;
                            set.Channels = new double[channels, hrirSize];
                            for(int hr = 0; hr < hrirSize; hr++)
                            {
                                for (int ch = 0; ch < (stereo ? 2 : 1); ch++)
                                {
                                    double coEff;
                                    if (bitDepth == 0)
                                    {
                                        coEff = AudioMath.ClampShortToDouble(reader.ReadInt16());
                                    }
                                    else
                                    {
                                        Int24 sample = ReadInt24(reader);
                                        coEff = AudioMath.ClampInt24ToFloat(sample);
                                    }

                                    set.Channels[ch, hr] = coEff;
                                }
                            }
                            

                            azimuths.Add(set);
                        }
                        field.Elevations.Add(azimuths);
                    }
                    HRTFs.Fields.Add(field);
                }

                // Impulse delays. Basically, when sound travels to your head, it travels slow enough that your brain can subconsciously notice it. 
                // This means if some loud sound happened to your right, your brain will subconsciously notice it hit your right ear drum first, right before it hit the left.
                // This is what impulse delays are for. They tell us how we should delay the sound per ear so that the user gets a more natural experience.

                for (int i = 0; i < fields.Count; i++)
                {
                    HRTFField field = fields[i];
                    // Iterate through elevations
                    for (int j = 0; j < field.azCount.Length; j++)
                    {
                        byte evCount = field.azCount[j];
                        // Iterate through each azimuth per elevation.
                        for (int k = 0; k < evCount; k++)
                        {
                            CoeffSet set = field.Elevations[j][k];
                            int channels = stereo ? 2 : 1;

                            Vector2 delays = new Vector2();

                            for (int ch = 0; ch < channels; ch++)
                            {
                                byte delay = reader.ReadByte();
                                if (ch == 0)
                                    delays.X = delay;
                                if (ch == 1)
                                    delays.Y = delay;

                                if (delay < 0 || delay > 63)
                                    throw new InvalidDataException($"HRIR Delays must be between 0(inclusive) and 63(inclusive) samples. Please ensure the file \"{filePath}\" is valid.");
                            }

                            set.SampleDelay = delays;
                        }
                    }
                }

                mhrFile.HRTFSet = HRTFs;

                return mhrFile;
            }
        }

        /// <summary>
        /// Does a lookup in this file for appropriate HRTFs given the parameters.
        /// </summary>
        /// <param name="elevation"></param>
        /// <param name="azimuth"></param>
        /// <param name="leftFilter"></param>
        /// <param name="rightFilter"></param>
        /// <param name="distance"></param>
        /// <returns>A vector of the IR delays; X for channel one and Y for channel two respectively.</returns>
        public Vector2? GenerateHRTFS(float elevation, float azimuth, ref double[] leftFilter, ref double[] rightFilter, float distance = 2000)
        {
            if (elevation < -90f || elevation > 90f)
                throw new ArgumentOutOfRangeException("Elevation must be from -90 degrees to 90 degrees.");

            float lastFieldDistance = float.MaxValue;
            HRTFField? closestField = null;
            foreach(HRTFField field in HRTFSet.Fields)
            {
                if (Math.Abs(distance - field.Distance) < lastFieldDistance)
                {
                    lastFieldDistance = Math.Abs(distance - field.Distance);
                    closestField = field;
                } 
            }

            // We have found the closest field to the distance we have been given.
            if (closestField != null)
            {
                // Do some math to find the azimuths and elevations we need based on the given values.
                double normalizedAzimuth = NormalizeEulerAngle(azimuth);

                int totalElevations = closestField.Elevations.Count;

                int elevIndexFloor = (int)Math.Floor(((elevation / 90f) + 1) / 2f * totalElevations);
                int elevIndexCeil = (int)Math.Clamp(Math.Ceiling(((elevation / 90f) + 1) / 2f * totalElevations), 0, totalElevations - 1);

                if (elevIndexFloor >= closestField.Elevations.Count)
                    elevIndexFloor = closestField.Elevations.Count - 1;

                List<CoeffSet> azimuthsFloor = closestField.Elevations[elevIndexFloor];
                List<CoeffSet> azimuthsCeil = closestField.Elevations[elevIndexCeil];

                int totalAzimuthsFloor = azimuthsFloor.Count;
                int totalAzimuthsCeil = azimuthsCeil.Count;

                double eF_azimuthDecimal = (normalizedAzimuth / 360f) * (float)totalAzimuthsFloor;
                int eF_azimuthFloorIndex = (int)Math.Floor((normalizedAzimuth / 360f) * (float)totalAzimuthsFloor);
                int eF_azimuthCeilIndex = (int)Math.Ceiling((normalizedAzimuth / 360f) * (float)totalAzimuthsFloor);

                CoeffSet elevFloor_FloorSet = azimuthsFloor[eF_azimuthFloorIndex >= totalAzimuthsFloor ? eF_azimuthFloorIndex - totalAzimuthsFloor : eF_azimuthFloorIndex];
                CoeffSet elevFloor_CeilSet = azimuthsFloor[eF_azimuthCeilIndex >= totalAzimuthsFloor ? eF_azimuthCeilIndex - totalAzimuthsFloor : eF_azimuthCeilIndex];

                // If the filter arrays are the wrong size, recreate them. Otherwise just leave them be.
                if (leftFilter == null || leftFilter.Length != elevFloor_FloorSet.Channels.GetLength(1))
                {
                    leftFilter = new double[elevFloor_FloorSet.Channels.GetLength(1)];
                }

                if (rightFilter == null || rightFilter.Length != elevFloor_FloorSet.Channels.GetLength(1))
                {
                    rightFilter = new double[elevFloor_FloorSet.Channels.GetLength(1)];
                }

                Vector2 delays = new Vector2();

                // Interpolate delays
                Vector2 floorDelays = elevFloor_FloorSet.SampleDelay;
                Vector2 ceilDelays = elevFloor_CeilSet.SampleDelay;

                delays.X = (float)Lerp(floorDelays.X, ceilDelays.X, eF_azimuthDecimal - eF_azimuthFloorIndex);
                delays.Y = (float)Lerp(floorDelays.Y, ceilDelays.Y, eF_azimuthDecimal - eF_azimuthFloorIndex);

                // Channel 1
                for (int i = 0; i < leftFilter.Length; i++)
                {
                    double floorElev_AziFloor = elevFloor_FloorSet.Channels[0, i];
                    double floorElev_AziCeil = elevFloor_CeilSet.Channels[0, i];

                    double elevFloor_Interp = Lerp(floorElev_AziFloor, floorElev_AziCeil, eF_azimuthDecimal - eF_azimuthFloorIndex);

                    leftFilter[i] = elevFloor_Interp;
                }

                // Channel 2 (if available)
                if (elevFloor_FloorSet.Channels.GetLength(0) > 1)
                {
                    for (int i = 0; i < rightFilter.Length; i++)
                    {
                        double floorElev_AziFloor = elevFloor_FloorSet.Channels[1, i];
                        double floorElev_AziCeil = elevFloor_CeilSet.Channels[1, i];

                        double elevFloor_Interp = Lerp(floorElev_AziFloor, floorElev_AziCeil, eF_azimuthDecimal - eF_azimuthFloorIndex);

                        rightFilter[i] = elevFloor_Interp;
                    }
                }
                else
                {
                    // Secondary azimuth. This is for if the HRTFs are mono, meaning we need to grab the azimuth for the left and right ear.
                    if (!Stereo)
                    {
                        double rightAzimuthDecimal = (NormalizeEulerAngle(-normalizedAzimuth) / 360f) * (float)totalAzimuthsFloor;
                        int rightAzimuthIndexFloor = (int)Math.Floor(rightAzimuthDecimal);
                        int rightAzimuthIndexCeil = (int)Math.Ceiling(rightAzimuthDecimal);

                        CoeffSet elevFloor_FloorSetR = azimuthsFloor[rightAzimuthIndexFloor >= totalAzimuthsFloor ? rightAzimuthIndexFloor - totalAzimuthsFloor : rightAzimuthIndexFloor];
                        CoeffSet elevFloor_CeilSetR = azimuthsFloor[rightAzimuthIndexCeil >= totalAzimuthsFloor ? rightAzimuthIndexCeil - totalAzimuthsFloor : rightAzimuthIndexCeil];

                        for (int i = 0; i < rightFilter.Length; i++)
                        {
                            double floorElev_AziFloor = elevFloor_FloorSetR.Channels[0, i];
                            double floorElev_AziCeil = elevFloor_CeilSetR.Channels[0, i];

                            double elevFloor_Interp = Lerp(floorElev_AziFloor, floorElev_AziCeil, (rightAzimuthDecimal - rightAzimuthIndexFloor));

                            rightFilter[i] = elevFloor_Interp;
                        }

                        delays.Y = (float)Lerp(elevFloor_FloorSetR.SampleDelay.Y, elevFloor_CeilSetR.SampleDelay.Y, eF_azimuthDecimal - eF_azimuthFloorIndex);
                    }
                }

                return delays;
            }

            return null;
        }

        double Lerp(double firstFloat, double secondFloat, double by)
        {
            return firstFloat * (1 - by) + secondFloat * by;
        }

        private static double NormalizeEulerAngle(double angle)
        {
            double normalized = angle % 360;
            if (normalized < 0)
                normalized += 360;
            return normalized;
        }

        private static Int24 ReadInt24(BinaryReader reader)
        {
            byte[] bytes = new byte[3];

            for(int i = 0; i < 3; i++)
            {
                bytes[i] = reader.ReadByte();
            }

            return new Int24(bytes, 0);
        }
    }

    public class HRTFSet
    {
        public List<HRTFField> Fields = new();
    }

    public class HRTFField
    {
        public short Distance;
        public byte[] azCount;
        public int hrirOffset = 0;
        public List<List<CoeffSet>> Elevations = new();
    }

    public class CoeffSet
    {
        public double[,] Channels;
        public Vector2 SampleDelay;
    }

    public class EndiannessAwareBinaryReader : BinaryReader
    {
        public enum Endianness
        {
            Little,
            Big,
        }

        private readonly Endianness _endianness = Endianness.Little;

        public EndiannessAwareBinaryReader(Stream input) : base(input)
        {
        }

        public EndiannessAwareBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
        {
        }

        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen) : base(
            input, encoding, leaveOpen)
        {
        }

        public EndiannessAwareBinaryReader(Stream input, Endianness endianness) : base(input)
        {
            _endianness = endianness;
        }

        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, Endianness endianness) :
            base(input, encoding)
        {
            _endianness = endianness;
        }

        public EndiannessAwareBinaryReader(Stream input, Encoding encoding, bool leaveOpen,
            Endianness endianness) : base(input, encoding, leaveOpen)
        {
            _endianness = endianness;
        }

        public override short ReadInt16() => ReadInt16(_endianness);

        public override int ReadInt32() => ReadInt32(_endianness);

        public override long ReadInt64() => ReadInt64(_endianness);

        public override ushort ReadUInt16() => ReadUInt16(_endianness);

        public override uint ReadUInt32() => ReadUInt32(_endianness);

        public override ulong ReadUInt64() => ReadUInt64(_endianness);

        public short ReadInt16(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadInt16LittleEndian(ReadBytes(sizeof(short)))
            : BinaryPrimitives.ReadInt16BigEndian(ReadBytes(sizeof(short)));

        public int ReadInt32(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadInt32LittleEndian(ReadBytes(sizeof(int)))
            : BinaryPrimitives.ReadInt32BigEndian(ReadBytes(sizeof(int)));

        public long ReadInt64(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadInt64LittleEndian(ReadBytes(sizeof(long)))
            : BinaryPrimitives.ReadInt64BigEndian(ReadBytes(sizeof(long)));

        public ushort ReadUInt16(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadUInt16LittleEndian(ReadBytes(sizeof(ushort)))
            : BinaryPrimitives.ReadUInt16BigEndian(ReadBytes(sizeof(ushort)));

        public uint ReadUInt32(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadUInt32LittleEndian(ReadBytes(sizeof(uint)))
            : BinaryPrimitives.ReadUInt32BigEndian(ReadBytes(sizeof(uint)));

        public ulong ReadUInt64(Endianness endianness) => endianness == Endianness.Little
            ? BinaryPrimitives.ReadUInt64LittleEndian(ReadBytes(sizeof(ulong)))
            : BinaryPrimitives.ReadUInt64BigEndian(ReadBytes(sizeof(ulong)));
    }
}
