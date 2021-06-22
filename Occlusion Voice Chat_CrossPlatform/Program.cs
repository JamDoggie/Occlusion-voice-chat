using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using System;
using System.IO;
using System.Reflection;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    class Program
    {


        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(string[] args)
        {
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;

            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly != null)
            {
                var exePath = Path.GetDirectoryName(entryAssembly.Location);
                if (exePath != null)
                    Directory.SetCurrentDirectory(exePath); // Not really required on windows, but required on mac for some reason or else it tries to use 
                                                            // the home directory for storage which breaks things.
            }


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
