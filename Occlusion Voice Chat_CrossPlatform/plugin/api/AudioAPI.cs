using System;
using System.Collections.Generic;

namespace Occlusion_voice_chat_CrossPlatform.plugin.api;

public static class AudioAPI
{
    public delegate void ProcessAudioOutputDelegate(Span<byte> data);

    public delegate void ProcessMicrophoneInputDelegate(Span<byte> data);
    
    public static readonly List<ProcessAudioOutputDelegate> ProcessAudioOutputCallbacks = new List<ProcessAudioOutputDelegate>();

    public static readonly List<ProcessAudioOutputDelegate> ProcessPostAudioOutputCallbacks = new List<ProcessAudioOutputDelegate>();
    
    public static readonly List<ProcessMicrophoneInputDelegate> ProcessMicrophoneInputCallbacks = new List<ProcessMicrophoneInputDelegate>();
    
    /// <summary>
    /// Hook onto this event if you would like to process the final audio output.
    /// This is called *before* deafening is applied and audio output volume is calculated.
    /// Use span[i] to access the audio data, and make sure to mix it yourself by adding the audio samples and clipping.
    /// </summary>
    /// <param name="function"></param>
    public static void HookProcessAudioOutputEvent(ProcessAudioOutputDelegate function)
    {
        ProcessAudioOutputCallbacks.Add(function);
    }
    
    /// <summary>
    /// Hook onto this event if you would like to process the final audio output after deafening has been applied and volume has been calculated.
    /// The sound you mix here will be the volume you set it as, so it is recommended to apply volume yourself here.
    /// Use span[i] to access the audio data, and make sure to mix it yourself by adding the audio samples and clipping.
    /// </summary>
    /// <param name="function"></param>
    public static void HookProcessPostAudioOutputEvent(ProcessAudioOutputDelegate function)
    {
        ProcessPostAudioOutputCallbacks.Add(function);
    }
    
    /// <summary>
    /// Hook onto this event if you would like to modify the client's current microphone input before it is sent to the server.
    /// Use span[i] to modify the audio data, and mix audio using addition or another method if needed.
    /// </summary>
    /// <param name="function"></param>
    public static void HookProcessMicrophoneInputEvent(ProcessMicrophoneInputDelegate function)
    {
        ProcessMicrophoneInputCallbacks.Add(function);
    }
    
}
