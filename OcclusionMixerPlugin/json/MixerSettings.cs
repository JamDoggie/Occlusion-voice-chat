using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace OcclusionMixerPlugin.json;

public class MixerSettings
{
    public List<MixerSound> SoundFiles = new();
    
    public float SoundVolume { get; set; } = 1;
    
    public float PreviewVolume { get; set; } = 1;

    public List<string> StopSoundBind { get; set; } = new();
}

public class MixerSound
{
    public string Path { get; set; }

    public List<string> KeyBind { get; set; } = new();

    public override string ToString()
    {
        // Normalize all slashes in Path to forward slashes
        string normalizedPath = Path.Replace('\\', '/');
        
        // Split string by slashes, then get the last part
        string[] pathParts = normalizedPath.Split('/');
        
        // Get the last part of the path
        string fileName = pathParts[pathParts.Length - 1];
        
        // Remove the file extension
        string fileNameWithoutExtension = fileName[..^5];
        
        return fileNameWithoutExtension;
    }
}