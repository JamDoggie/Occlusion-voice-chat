using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;
using Occlusion_voice_chat_CrossPlatform.plugin;
using Avalonia.Dialogs;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class SettingsPageModel : ReactiveObject
    {
        public ObservableCollection<string> HRTFFilters { get; set; } = new ObservableCollection<string>();

        // Whether or not this platform supports keybinds.
        public bool UnsupportedPlatform => App.KeybindManager.CurrentBindManager == null;

        public bool PluginsEmpty 
        {
            get
            {
                return PluginManager.Plugins.Count == 0;
            }
        }

        public SettingsPageModel()
        {
            RefreshListBox();
        }

        public void OpenPluginFolder()
        {
            string folderPath = PluginManager.DefaultPluginFolder;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            
            // Using Avalonia, open this folder in the default file explorer in a cross platform way.
            // Maybe abstract this out later.
            OpenBrowser(folderPath);
        }
        
        public static void OpenBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // If no associated application/json MimeType is found xdg-open opens retrun error
                // but it tries to open it anyway using the console editor (nano, vim, other..)
                ShellExec($"xdg-open {url}", waitForExit: false);
            }
            else
            {
                using (Process process = Process.Start(new ProcessStartInfo
                       {
                           FileName = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ? url : "open",
                           Arguments = RuntimeInformation.IsOSPlatform(OSPlatform.OSX) ? $"\"{url}\"" : "",
                           CreateNoWindow = true,
                           UseShellExecute = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                       }));
            }
            
        }
        
        private static void ShellExec(string cmd, bool waitForExit = true)
        {
            var escapedArgs = Regex.Replace(cmd, "(?=[`~!#&*()|;'<>])", "\\")
                .Replace("\"", "\\\\\\\"");

            using (var process = Process.Start(
                       new ProcessStartInfo
                       {
                           FileName = "/bin/sh",
                           Arguments = $"-c \"{escapedArgs}\"",
                           RedirectStandardOutput = true,
                           UseShellExecute = false,
                           CreateNoWindow = true,
                           WindowStyle = ProcessWindowStyle.Hidden
                       }
                   ))
            {
                if (waitForExit)
                {
                    process.WaitForExit();
                }
            }
        }
        
        public void RefreshListBox()
        {
            HRTFFilters.Clear();

            try
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                DirectoryInfo dir = new DirectoryInfo($"{Directory.GetCurrentDirectory()}/HRTF sets/");
                FileInfo[] sets = dir.GetFiles();

                for (int i = 0; i < sets.Length; i++)
                {
                    if (i != 0 && sets[i].Name.Contains("MIT-48000"))
                    {
                        SwapValues(sets, i, 0);
                        break;
                    }
                }

                foreach (FileInfo s in sets)
                {
                    if (s.Name.EndsWith(".mhr"))
                    {
                        HRTFFilters.Add(s.Name);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Failed to load HRTF Filters:\n{e.Message}");
            }
        }

        private static void SwapValues<T>(T[] source, long index1, long index2)
        {
            T temp = source[index1];
            source[index1] = source[index2];
            source[index2] = temp;
        }
    }
}
