using System;
using System.IO;
using Concentus.Oggfile;

namespace Occlusion_Voice_Chat_CrossPlatform.audio;

public class AudioStreamBuffer
{
    #region Public Properties
    
    public int Channels { get; private set; } = 2;
    
    /// <summary>
    /// Length from this[0] to the end of the buffer
    /// </summary>
    public int BufferLength { get; private set; }

    /// <summary>
    /// Length from this[0] to the lowest negative index you can go. This is old audio data that has already been mixed in to
    /// whatever it needed to be mixed into, and only so much is stored. PaddingLength is the amount of space that is, accessible via negative indexes.
    /// </summary>
    public int PaddingLength { get; private set; }

    public int AudioQueued => Math.Max(0, QueueOffset);
    #endregion
    
    
    
    #region Private Fields
    
    protected readonly byte[] InternalBuffer;

    /// <summary>
    /// Where we currently are in the queue, relative to this[0]
    /// </summary>
    public int QueueOffset { get; protected set; }
    
    /// <summary>
    /// This should be where our buffer position is centered around. This is the minimum position where
    /// we should read samples from, and the queue offset should be relative to this. Anything before this
    /// (considered the negative indexes) should be treated as old audio, in case we need any sort of audio delay.
    /// </summary>
    protected readonly int _paddingOffset = 0;

    #endregion
    
    // Main constructor
    public AudioStreamBuffer(int bufferLengthMs = 100, int bufferPaddingMs = 100, int channels = 2)
    {
        InternalBuffer = new byte[App.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(bufferLengthMs + bufferPaddingMs), App.samplingRate, Channels)];

        BufferLength = App.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(bufferLengthMs), App.samplingRate, Channels);
        PaddingLength = App.GetSampleSizeInBytes(TimeSpan.FromMilliseconds(bufferPaddingMs), App.samplingRate, Channels);

        _paddingOffset = PaddingLength;
        QueueOffset = 0;

        Channels = channels;
    }
    
    /// <summary>
    /// Attempts to queue a sample into the buffer.
    /// </summary>
    /// <param name="sample"></param>
    /// <returns>
    /// true if the sample was queued, false if the buffer is full. Use a <a href="https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/functional/discards">discard</a> if this information isn't relevant to you.
    /// </returns>
    public virtual bool TryQueueSample(short sample)
    {
        if (QueueOffset + 2 > BufferLength)
            return false;
        
        // Set the current two bytes at _queueOffset to the sample, and increment the queue offset by two.
        this[QueueOffset] = (byte)(sample & 0xFF);
        this[QueueOffset + 1] = (byte)((sample >> 8) & 0xFF);

        QueueOffset += 2;
        
        return true;
    }

    /// <summary>
    /// <p>
    /// Returns the next sample in the queue, silence (0) if there's nothing in the queue, or silence (0) if we're at the end of the buffer.
    /// </p>
    /// </summary>
    /// 
    /// <returns></returns>
    public virtual short GetNextSampleOrSilence(int offset)
    {
        if (offset > BufferLength)
            return 0;

        if (offset < 0)
            return 0;

        short sample = (short)(this[offset] | (this[offset + 1] << 8));

        return sample;
    }

    
    
    /// <summary>
    /// Attempts to move all audio in the queue left by a specified amount of bytes, leaving silence at the end.
    /// </summary>
    /// <param name="amountLeft"></param>
    /// <returns>a bool, true if successful, and false if not.</returns>
    public bool TryMoveAudioLeft(int amountToTheLeft)
    {
        if (amountToTheLeft < 0)
            return false;

        for (int i = 0; i < InternalBuffer.Length; i++)
        {
            if (i + amountToTheLeft >= InternalBuffer.Length)
            {
                InternalBuffer[i] = 0;
                continue;
            }
            
            InternalBuffer[i] = InternalBuffer[i + amountToTheLeft];
        }

        QueueOffset -= amountToTheLeft;

        if (QueueOffset < 0)
            QueueOffset = 0; // This shouldn't happen since we should be going down in increments of 2 (two bytes in a short), but just in case.

        return true;
    }

    /// <summary>
    /// <p>
    /// This operator accesses a buffer that contains both padding audio data for old audio that has already been used,
    /// as well as the audio data that has yet to be mixed out of the buffer. Anytime ExtractNextSampleOrSilence is called,
    /// the audio samples returned go from the main portion of the audio queue to the padding portion of the audio queue.
    /// This padding portion can then be used for audio delay.
    /// </p>
    /// 
    /// <p>
    /// <i>Accessing negative indexes reaches into the padding portion of the buffer, and grabs old audio.</i>
    /// Accessing positive indexes reaches into the main portion of the buffer, and grabs the audio that is waiting
    /// to be mixed out. If you try to grab an index that is outside both the padding and main portions of the buffer,
    /// it will return <b>0</b> (silence).
    /// </p>
    /// </summary>
    /// <param name="index"></param>
    public virtual byte this[int index]
    {
        get
        {
            int arrayOffset = index + _paddingOffset;
            
            if (arrayOffset < InternalBuffer.Length && arrayOffset >= -PaddingLength)
                return InternalBuffer[arrayOffset];

            return 0;
        }
        
        set
        {
            int arrayOffset = index + _paddingOffset;
            
            if (arrayOffset < InternalBuffer.Length && arrayOffset >= -PaddingLength)
                InternalBuffer[arrayOffset] = value;
        }
    }
}