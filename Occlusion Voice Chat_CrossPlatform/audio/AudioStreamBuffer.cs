using System.IO;
using Concentus.Oggfile;

namespace Occlusion_Voice_Chat_CrossPlatform.audio;

public class OggAudioBuffer : AudioBuffer
{
    private readonly OpusOggReadStream _stream;

    public OggAudioBuffer(OpusOggReadStream stream, FileStream opusFileStream, int bufferLengthMs = 60, int 
    bufferPaddingMs = 100, int 
    channels = 2) : base(bufferLengthMs, bufferPaddingMs, channels)
    {
        _stream = stream;
    }

    /// <summary>
    /// Returns the next sample from the buffer, or silence if there is no queued audio; after which, all audio
    /// in the buffer is moved to the left.
    /// </summary>
    /// <returns></returns>
    public override short ExtractNextSample()
    {
        if (_stream.CurrentTime >= _stream.TotalTime) 
            return 0;
        
        _stream.Read(_sampleBytes, 0, 2);

        // Convert from bytes to short
        short sample = (short)((_sampleBytes[0]) << 0);
        sample += (short)((_sampleBytes[1]) << 8);

        // Move all audio in the buffer to the left, cutting off the leftmost sample, and adding silence to the right.
        for (int i = 0; i < InternalBuffer.Length; i += 2)
        {
            // check if at the end of the buffer, and if so, add silence to the right.
            if (i + 3 >= InternalBuffer.Length)
            {
                InternalBuffer[i] = 0;
                InternalBuffer[i + 1] = 0;
            }
            else
            {
                InternalBuffer[i] = InternalBuffer[i + 2];
                InternalBuffer[i + 1] = InternalBuffer[i + 3];
            }
        }
        
        // Finally, move the offset to the left.
        QueueOffset -= 2;
        
        if (QueueOffset < 0)
            QueueOffset = _paddingOffset;
        
        return sample;
    }
    
    /// <summary>
    /// Attempts to queue a sample into the buffer.
    /// </summary>
    /// <param name="sample"></param>
    /// <returns>
    /// true if the sample was queued, false if the buffer is full. Use a discard <b>(_ = [value])</b> if this information isn't relevant to you.
    /// </returns>
    public override bool TryQueueSample(short sample)
    {
        if (QueueOffset + 2 <= InternalBuffer.Length)
        {
            InternalBuffer[QueueOffset] = (byte)(sample & 0xFF);
            InternalBuffer[QueueOffset + 1] = (byte)((sample >> 8) & 0xFF);
            
            QueueOffset += 2;

            return true;
        }

        return false;
    }

    // Remember: always make sure to dispose your streams!
    ~OggAudioBuffer()
    {
        
    }
}