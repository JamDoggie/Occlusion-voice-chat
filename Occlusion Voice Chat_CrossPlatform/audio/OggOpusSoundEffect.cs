using System;
using System.IO;
using Concentus.Oggfile;
using Concentus.Structs;

namespace Occlusion_Voice_Chat_CrossPlatform.audio;

public class OpusSoundEffect : SoundEffect
{
    public override float Volume { get; set; }

    public override bool IsPlaying { get; internal set; } = false;

    protected AudioStreamBuffer _audioBuffer;

    protected 
    
    public OpusSoundEffect(float volume, string filePath) : base(volume)
    {
        _audioBuffer = new AudioStreamBuffer();
        FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            
        OpusDecoder decoder = OpusDecoder.Create(App.samplingRate, channels);
        OpusOggReadStream oggIn = new OpusOggReadStream(decoder, fileStream);
    }

    public override void Play()
    {
        base.Play();
    }

    public override void Pause()
    {
        base.Pause();
    }
    
    public override void Stop()
    {
        base.Stop();
    }

    public override void MixAudioIntoSpan(ref Span<byte> destination)
    {
        base.MixAudioIntoSpan(ref destination);
    }
}