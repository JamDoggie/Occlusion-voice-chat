#nullable enable

using Lidgren.Network;
using mrousavy;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using Occlusion_voice_chat.Mojang;
using Occlusion_voice_chat.Networking;
using Occlusion_voice_chat.Opus;
using Occlusion_voice_chat.util;
using Occlusion_voice_chat.util.json_structs;
using Occlusion_voice_chat.wpf.controls;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using OcclusionShared.Util;
using SdlSharp;
using SdlSharp.Sound;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Occlusion_voice_chat
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static AudioDevice RecordingDevice;

        public static MixChannel PlaybackChannel;

        public static AudioDevice PlaybackDevice;

        public static AudioSpec finalSettingsMic;

        public static AudioSpec finalSettingsSpeaker;

        public static bool RecordingSwitching = false;

        private byte[] queuedMicrophoneAudio;

        private int currentMicQueueOffset = 0;

        public const int samplingRate = 48000;

        private int queueLength = 0;

        public OpusCodec mainCodec = new OpusCodec();

        #region janky region for changing the input and output devices across threads safely
        // Janky threading stuff, this is for changing the audio device from the UI thread.
        private static object _inputDeviceLock = new object();

        private static string? _newInputDevice = null;
        public static string? NewInputDevice
        {
            get
            {
                lock(_inputDeviceLock)
                {
                    return _newInputDevice;
                }
            }

            set
            {
                lock(_inputDeviceLock)
                {
                    _newInputDevice = value;
                }
            }
        }

        private static object _outputDeviceLock = new object();

        private static string? _newOutputDevice = null;
        public static string? NewOutputDevice
        {
            get
            {
                lock (_outputDeviceLock)
                {
                    return _newOutputDevice;
                }
            }

            set
            {
                lock (_outputDeviceLock)
                {
                    _newOutputDevice = value;
                }
            }
        }


        // Volume controls
        private static object _inputVolumeLock = new object();

        private static float _inputVolume = 1f;
        public static float InputVolume
        {
            get
            {
                lock (_inputVolumeLock)
                {
                    return _inputVolume;
                }
            }

            set
            {
                lock (_inputVolumeLock)
                {
                    _inputVolume = value;
                }
            }
        }

        private static object _outputVolumeLock = new object();

        private static float _outputVolume = 1f;
        public static float OutputVolume
        {
            get
            {
                lock (_outputVolumeLock)
                {
                    return _outputVolume;
                }
            }

            set
            {
                lock (_outputVolumeLock)
                {
                    _outputVolume = value;
                }
            }
        }


        private static object _micMutedLock = new object();
        private static bool _micMuted = false;

        public static bool MicMuted
        {
            get
            {
                lock(_micMutedLock)
                {
                    return _micMuted;
                }
            }

            set
            {
                lock (_micMutedLock)
                {
                    _micMuted = value;
                }
            }
        }

        private static object _deafenedLock = new object();
        private static bool _deafened = false;

        public static bool Deafened
        {
            get
            {
                lock (_deafenedLock)
                {
                    return _deafened;
                }
            }

            set
            {
                lock (_deafenedLock)
                {
                    _deafened = value;
                }
            }
        }

        private static object _voiceActivityLock = new object();
        private static float _voiceActivity = 0;

        public static float VoiceActivity
        {
            get
            {
                lock (_voiceActivityLock)
                {
                    return _voiceActivity;
                }
            }

            set
            {
                lock (_voiceActivityLock)
                {
                    _voiceActivity = value;
                }
            }
        }
        #endregion

        public static ConcurrentList<VoiceUser> Users = new ConcurrentList<VoiceUser>();

        public static VoiceChatWindow VoiceChatWindow = new VoiceChatWindow();

        public static JsonFile<OptionsJson> Options { get; set; } = new JsonFile<OptionsJson>("occlusion_options.json", new OptionsJson());

        private static Client _client = new Client();
        public static Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        public App()
        {
            ConsoleManager.ShowConsoleWindow();

            Client.PacketRecievedEvent += Client_PacketRecievedEvent;
            Console.WriteLine($"The entry point thread is {Thread.CurrentThread.ManagedThreadId}");
            InitSound();

            PlayerCache.RetrieveCacheFile();

            InputVolume = Options.Obj.InputVolume;
            OutputVolume = Options.Obj.OutputVolume;
            VoiceActivity = Options.Obj.VoiceActivity;
        }

        private void Client_PacketRecievedEvent(NetIncomingMessage message, IPacket packet, Client client)
        {
            if (packet is ServerUserConnectedPacket userConnectedPacket)
            {
                foreach (KeyValuePair<int, string> id in userConnectedPacket.idsToAdd)
                {
                    if (GetUserById(id.Key) == null)
                    {
                        var voiceUser = new VoiceUser()
                        {
                            id = id.Key,
                            MCUUID = id.Value,
                            codec = new OpusCodec()
                        };

                        voiceUser.MicQueue = new byte[GetSampleSizeInBytes(TimeSpan.FromMilliseconds(500), samplingRate, 1)];

                        voiceUser.codec.SetFrameSize(20);
                        voiceUser.codec.SetApplication(Concentus.Enums.OpusApplication.OPUS_APPLICATION_VOIP);
                        
                        Users.Add(voiceUser);

                        // Add user to grid on UI
                        Dispatcher.Invoke(() =>
                        {
                            if (VoiceChatWindow != null && VoiceChatWindow.IsOpen)
                            {
                                VoiceChatWindow.AddPlayer(id.Value, id.Key);
                            }
                        });
                    }
                }
            }

            if (packet is ServerVoiceDataPacket voiceDataPacket)
            {
                if (GetUserById(voiceDataPacket.ID) != null)
                {
                    AudioChunk chunk = GetUserById(voiceDataPacket.ID).codec.Decompress(voiceDataPacket.VoiceData);

                    // Audio has been converted to stereo, now queue it.
                    // We amplify an extra time over all the audio equally to account for distance volume.
                    // Then, we amplify one last time for the input master volume.
                    byte[] decompressedAudio = chunk.Amplify(OutputVolume).Amplify(GetUserById(voiceDataPacket.ID).ClientVolume).GetDataAsBytes();

                    Span<byte> span = decompressedAudio;

                    // Queue the audio to be played
                    GetUserById(voiceDataPacket.ID).QueueAudio(span);

                    GetUserById(voiceDataPacket.ID).Pan = voiceDataPacket.Pan;
                    GetUserById(voiceDataPacket.ID).DistanceVolume = voiceDataPacket.Volume;
                }
            }

            if (packet is ServerConnectedPacket)
            {
                // We've successfully verified and connected ourselves.
                Client.ConnectionVerified = true;

                Dispatcher.Invoke(() =>
                {
                    VoiceChatWindow.Show();
                    VoiceChatWindow.OpenAudioSettings();
                });
            }

            if (packet is ServerUserLeftPacket userLeft)
            {
                if (VoiceChatWindow != null && VoiceChatWindow.IsOpen)
                {
                    Dispatcher.Invoke(() =>
                    {
                        PlayerIcon icon = VoiceChatWindow.GetPlayerIconByUUID(userLeft.UUID);

                        if (icon != null)
                            VoiceChatWindow.RemovePlayerIcon(icon);
                    });

                    Users.Remove(GetUserByUUID(userLeft.UUID));
                }
            }
        }

        public void InitSound()
        {
            Native.SDL_InitSubSystem(Subsystems.Audio);

            if (!Audio.CaptureDevices.Contains(Options.Obj.InputDevice))
            {
                Options.Obj.InputDevice = "Default";
            }

            if (!Audio.NonCaptureDevices.Contains(Options.Obj.OutputDevice))
            {
                Options.Obj.OutputDevice = "Default";
            }

            // If the input device is null, it uses the system default mic.
            string? inputDevice = null;
            if (Options.Obj.InputDevice != "Default")
                inputDevice = Options.Obj.InputDevice;

            string? outputDevice = null;
            if (Options.Obj.OutputDevice != "Default")
                outputDevice = Options.Obj.OutputDevice;



            Console.WriteLine(Options.Obj.InputDevice);

            Console.WriteLine(Options.Obj.OutputDevice);


            queueLength = GetSampleSizeInBytes(TimeSpan.FromMilliseconds(20), samplingRate, 1);


            // Audio Recorder
            AudioSpec wantedSettingsMic = new AudioSpec(samplingRate, AudioFormat.Signed16Bit, 1, 0, (ushort)(queueLength / 4), 0, micCallback, 0);
            RecordingDevice = Audio.Open(inputDevice, true, wantedSettingsMic, out finalSettingsMic, AudioAllowChange.None);

            // Speaker output
            AudioSpec wantedSettingsSpeaker = new AudioSpec(samplingRate, AudioFormat.Signed16Bit, 2, 0, 4096, 0, speakerCallback, 0);
            PlaybackDevice = Audio.Open(outputDevice, false, wantedSettingsSpeaker, out finalSettingsSpeaker, AudioAllowChange.None);


            queuedMicrophoneAudio = new byte[queueLength];

            mainCodec.SetApplication(Concentus.Enums.OpusApplication.OPUS_APPLICATION_VOIP);
            mainCodec.SetFrameSize(20);

            RecordingDevice.Unpause();
            PlaybackDevice.Unpause();
        }

        void speakerCallback(Span<byte> stream, nint userdata)
        {
            // Ensure this current chunk of audio data starts as silence.
            for (int i = 0; i < stream.Length; i++)
                stream[i] = 0;

            foreach (VoiceUser user in Users)
            {
                user.MixMicIntoSpanAndCutQueue(ref stream);
            }

            // Change output volume based on global volume slider
            short[] shorts = AudioMath.BytesToShorts(stream.ToArray());
            for (int i = 0; i < shorts.Length; i++)
            {
                shorts[i] = (short)Math.Clamp(shorts[i] * OutputVolume, short.MinValue, short.MaxValue);
            }

            byte[] newBytes = AudioMath.ShortsToBytes(shorts);
            for (int i = 0; i < stream.Length; i++)
            {
                stream[i] = newBytes[i];
            }

            // Microphone volume bar
            AudioChunk chunk = new AudioChunk(stream.ToArray(), samplingRate);
            Dispatcher.Invoke(() =>
            {
                if (VoiceChatWindow != null && VoiceChatWindow.IsLoaded && PlaybackDevice.Status == AudioStatus.Playing)
                {
                    VoiceChatWindow.SpeakerDecibalMeter.Value = Math.Clamp(chunk.Volume(), 0, 3000);

                    if (VoiceChatWindow.AudioSettingsOpen)
                    {
                        VoiceChatWindow.SpeakerDecibalMeter.Value = Math.Clamp(chunk.Volume(), 0, 3000);
                    }
                }
            });

            // Silence audio if we're deafened. We still calculate the mix though so that we can show the gray decibal bar.
            if (Deafened)
                for (int i = 0; i < stream.Length; i++)
                    stream[i] = 0;



            // We can change audio input here as well because this is on the sdl thread.
            if (NewInputDevice != null && RecordingDevice != null)
            {
                string? newDevice = NewInputDevice;
                if (newDevice == "Default")
                    newDevice = null;

                RecordingDevice.ClearQueuedAudio();
                RecordingDevice.Pause();
                RecordingDevice.Dispose();
                RecordingDevice = Audio.Open(newDevice, true, finalSettingsMic, out _, AudioAllowChange.None);
                RecordingDevice.Unpause();

                NewInputDevice = null;
            }
        }

        private short _residualVoiceVolume = 0;

        void micCallback(Span<byte> stream, nint userdata)
        {
            if (RecordingDevice != null && Client.IsConnected())
            {
                if (stream.Length > 0)
                {
                    // Microphone volume bar
                    AudioChunk rawChunk = new AudioChunk(stream.ToArray(), samplingRate);

                    rawChunk = rawChunk.Amplify(InputVolume);

                    AudioChunk chunk = new AudioChunk(stream.ToArray(), samplingRate);

                    chunk = chunk.Amplify(InputVolume);

                    var volume = chunk.Volume();

                    if (volume > _residualVoiceVolume)
                        _residualVoiceVolume = (short)volume;

                    // If our total volume is under the voice activity threshold, just set it all to silence.
                    if (_residualVoiceVolume <= VoiceActivity)
                    {
                        for (int i = 0; i < chunk.DataLength; i++)
                        {
                            chunk.Data[i] = 0;
                        }
                    }

                    

                    Console.WriteLine(InputVolume);

                    byte[] newBytes = chunk.GetDataAsBytes();
                    
                    for(int i = 0; i < stream.Length; i++)
                    {
                        stream[i] = newBytes[i];
                    }

                    Dispatcher.Invoke(() =>
                    {
                        if (VoiceChatWindow != null && VoiceChatWindow.IsLoaded && RecordingDevice.Status == AudioStatus.Playing)
                        {
                            VoiceChatWindow.MicDecibalMeter.Value = Math.Clamp(rawChunk.Volume(), 0, 3000) * VoiceChatWindow.InputVolumeSlider.Value;

                            if (VoiceChatWindow.AudioSettingsOpen)
                            {
                                VoiceChatWindow.SettingsMicMeter.Value = Math.Clamp(rawChunk.Volume(), 0, 3000) * VoiceChatWindow.InputVolumeSlider.Value;
                            }
                        }
                    });


                    // Fill the buffer until it's full
                    if (currentMicQueueOffset + 1 >= queueLength)
                    {
                        if (!MicMuted)
                        {
                            // Buffer is full, time to do what we need to do with the audio.

                            // First we encode the audio with Opus so it's small enough to send over the network
                            byte[] compressedAudio = mainCodec.Compress(new AudioChunk(queuedMicrophoneAudio, samplingRate));

                            // Now we send the compressed audio data to the server
                            ClientVoiceDataPacket voiceDataPacket = new ClientVoiceDataPacket();
                            voiceDataPacket.VoiceData = compressedAudio;
                            Client.SendMessage(voiceDataPacket, NetDeliveryMethod.UnreliableSequenced);
                        }

                        currentMicQueueOffset = 0;
                    }

                    // Buffer is not full, fill in the data we just got from the microphone into it.
                    for (int i = 0; i < stream.Length; i++)
                    {
                        if (currentMicQueueOffset < queuedMicrophoneAudio.Length)
                        {
                            queuedMicrophoneAudio[currentMicQueueOffset] = stream[i];
                            currentMicQueueOffset++;
                        }
                    }

                    double speed = Math.Abs((int)_residualVoiceVolume - ((int)VoiceActivity - 30)) / 25;
                    _residualVoiceVolume -= (short)Math.Clamp(speed, short.MinValue, short.MaxValue);
                    
                    Console.WriteLine(_residualVoiceVolume);
                }
            }

            // We can change audio output here as well because this is on the sdl thread.
            if (NewOutputDevice != null && PlaybackDevice != null)
            {
                string? newDevice = NewOutputDevice;
                if (newDevice == "Default")
                    newDevice = null;

                PlaybackDevice.ClearQueuedAudio();
                PlaybackDevice.Pause();
                PlaybackDevice.Dispose();
                PlaybackDevice = Audio.Open(newDevice, false, finalSettingsSpeaker, out _, AudioAllowChange.None);
                PlaybackDevice.Unpause();

                NewOutputDevice = null;
            }
        }

        public static VoiceUser GetUserById(int id)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.id == id)
                    return user;
            }

            return null;
        }

        public static VoiceUser GetUserByUUID(string uuid)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.MCUUID == uuid)
                    return user;
            }

            return null;
        }

        public static int GetSampleSizeInBytes(
            TimeSpan duration,
            int sampleRate,
            int channels
        )
        {
            return (int)(
                duration.TotalSeconds *
                sampleRate *
                channels *
                16 // 16-bit PCM
            ) / 8; // Divide by 8 because we need to convert from bits to bytes.
        }

        public static void Connect(string ip, int port, int verificationCode)
        {
            // Client thread
            // We call connect on a seperate thread so the client is essentially "started" on another thread,
            // giving it space to run it's message loop without halting the ui thread.
            new Thread(() =>
            {
                if (verificationCode >= 0)
                {
                    Client.Connect(ip, port, verificationCode);
                }
            }).Start();
        }
    }
}
