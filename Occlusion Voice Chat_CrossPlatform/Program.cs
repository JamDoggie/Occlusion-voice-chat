using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
#if WINDOWS && DEBUG
            Occlusion_voice_chat.ConsoleManager.ShowConsoleWindow();
#endif
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;


            Directory.SetCurrentDirectory(AppContext.BaseDirectory); // Not really required on windows, but required on mac for some reason or else it tries to use 
                                                                     // the home directory for storage which breaks things.
                                                                     
            // Check if linux
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                // Set the working directory to the location of the executable
                if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "occlusion-voice-chat/")))
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "occlusion-voice-chat/"));
                
                Directory.SetCurrentDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "occlusion-voice-chat/"));

                string oldHrtfDir = Path.Combine(AppContext.BaseDirectory, "HRTF sets/");
                string newHrtfDir = Path.Combine(Directory.GetCurrentDirectory(), "HRTF sets/");
                
                string oldResDir = Path.Combine(AppContext.BaseDirectory, "resources/");
                string newResDir = Path.Combine(Directory.GetCurrentDirectory(), "resources/");
                
                // Copy the HRTF sets to the working directory
                if (Directory.Exists(oldHrtfDir))
                {
                    Directory.CreateDirectory(newHrtfDir);
                    foreach(FileInfo file in new DirectoryInfo(oldHrtfDir).GetFiles())
                    {
                        try
                        {
                            file.CopyTo(Path.Combine(newHrtfDir, file.Name));
                        }
                        catch (IOException e)
                        {
                            // File already exists, ignore
                            // We do this instead of a File.Exists check because the file might be in use by another process.
                        }
                    }
                }
                
                // Copy the resources to the working directory
                if (Directory.Exists(oldResDir))
                {
                    Directory.CreateDirectory(newResDir);
                    foreach(FileInfo file in new DirectoryInfo(oldResDir).GetFiles())
                    {
                        try
                        {
                            file.CopyTo(Path.Combine(newResDir, file.Name));
                        }
                        catch (IOException e)
                        {
                            // File already exists, ignore
                        }
                    }
                }
            }

            Console.WriteLine("Current Directory: " + Directory.GetCurrentDirectory() + "!");
            
            
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                string logFile = $"{ex.Message}\n\nSTACK TRACE:\n{ex.StackTrace}";
                System.IO.File.WriteAllText($"occlusioncrashlog-{string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", DateTime.Now)}.txt", logFile);
            }
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();

        
    }
}
