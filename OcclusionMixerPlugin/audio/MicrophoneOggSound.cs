using Concentus.Oggfile;
using Concentus.Structs;
using JetBrains.Annotations;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.audio;
using Occlusion_voice_chat_CrossPlatform.plugin.api;

namespace OcclusionMixerPlugin.audio;

public class MicrophoneOggSound  : SoundEffect
{

    protected readonly AudioStreamBuffer AudioBuffer;

    protected Stream? OggInStream;
    protected OpusOggReadStream? OggIn;
    protected readonly OpusDecoder? Decoder;
    
    protected readonly Thread? DecoderThread;
    
    protected readonly object QueueLock = new object();

    private bool _queueThreadRunning = true;

    private bool _filePreloaded = false;
    
    private string _filePath;
    
    public MicrophoneOggSound(string filePath, float volume, bool loop = false, int decoderChannels = 1, bool 
    filePreloaded = false) : base (volume)
    {
        Loop = loop;

        _filePreloaded = filePreloaded;

        _filePath = filePath;
        
        // Catch any sort of exception relating to loading the file and only soft fail.
        try
        {
            if (!filePreloaded)
            {
                OggInStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            }
            else
            {
                OggInStream = new MemoryStream(File.ReadAllBytes(filePath));
            }
        }
        catch (IOException e)
        {
            Console.WriteLine($"Could not load sound from file: {filePath}.\nException Details: {e.Message}");

            OggInStream = null;
        }

        // Only create the Opus decoder if we have a valid stream
        if (OggInStream != null)
        {
            //Track track = new(OggInStream, ".opus");
            
            Decoder = OpusDecoder.Create(App.samplingRate, decoderChannels);
            OggIn = new OpusOggReadStream(Decoder, OggInStream);
        
            AudioBuffer = new AudioStreamBuffer(channels: decoderChannels);
            
            AudioAPI.HookProcessMicrophoneInputEvent(MixAudioIntoMic);
            
            DecoderThread = new Thread(DecodeAudio)
            {
                IsBackground = true
            };
        
            DecoderThread.Start();
        }
    }

    protected int SpanSize; // In bytes

    protected short[]? DecodedAudio;

    public void MixAudioIntoMic(Span<byte> span)
    {
        // We treat this method as if it's polling, because it basically is.
        // This is called an amount of times per second according to the size of the chunks our audio output uses.
        // Since opus files are usually split into frame times of around 20ms, this shouldn't be an issue.

        if (SpanSize == 0)
        {
            SpanSize = span.Length;
        }

        if (OggInStream == null)
            return;
        
        if (IsPlaying)
        {
            lock(QueueLock)
            {
                // Now, if we queued anything, play it.
                if (AudioBuffer.AudioQueued > 0)
                {
                    for (int i = 0; i < span.Length; i += 2)
                    {
                        short sample = AudioBuffer.GetNextSampleOrSilence(i);

                        short spanSample = (short)(span[i] | (span[i + 1] << 8));

                        short finalValue = (short)Math.Clamp((sample * Volume) + spanSample, short.MinValue, short.MaxValue);

                        // Write the final value back to the span
                        span[i] = (byte)(finalValue & 0xFF);
                        span[i + 1] = (byte)((finalValue >> 8) & 0xFF);
                    }

                    _ = AudioBuffer.TryMoveAudioLeft(span.Length);
                }
            }
        }
    }
    
    public override void MixAudioIntoSpan(ref Span<byte> span)
    {
        // Do nothing
    }

    
    protected void DecodeAudio()
    {
        while(_queueThreadRunning)
        {
            if (OggIn == null)
                break;
            
            lock(QueueLock)
            {
                // First, check if we need to queue in audio data. There should always be at least one audio frame in the buffer at a time
                // to avoid stutters.
                while (AudioBuffer.AudioQueued < SpanSize)
                {
                    if (!OggIn.HasNextPacket)
                    {
                        if (OggIn.CanSeek && Loop)
                        {
                            // Seeking doesn't work, so we'll just restart the stream for now.
                            OggIn = new OpusOggReadStream(Decoder, OggInStream);
                        }
                        else
                        {
                            Stop();
                            break;
                        }
                    }

                    OggIn.DecodeNextPacket(ref DecodedAudio);

                    if (DecodedAudio != null)
                    {
                        for (int i = 0; i < DecodedAudio.Length; i++)
                        {
                            AudioBuffer.TryQueueSample(DecodedAudio[i]);
                        }
                    }
                }
            }

            Thread.Sleep(1);
        }
    }
    
    ~MicrophoneOggSound()
    {
        OggInStream?.Dispose();
        _queueThreadRunning = false;
    }
}