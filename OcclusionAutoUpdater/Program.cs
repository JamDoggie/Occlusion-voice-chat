using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using Octokit;
using System;
using System.Diagnostics;
using System.Reflection;

namespace OcclusionAutoUpdater
{
    class Program
    {
        public static void Main(string[] args)
        {
            AppDomain currentDomain = default(AppDomain);
            currentDomain = AppDomain.CurrentDomain;
            // Handler for unhandled exceptions.
            currentDomain.UnhandledException += CurrentDomain_UnhandledException;

            // Initialization code. Don't use any Avalonia, third-party APIs or any
            // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
            // yet and stuff might break.
            BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                var stackTrace = new StackTrace(ex, true);
                var frame = stackTrace.GetFrame(stackTrace.FrameCount-1);

                // Get entry assembly and executing assembly
                var entryAssembly = Assembly.GetEntryAssembly();
                var executingAssembly = Assembly.GetExecutingAssembly();

                string logFile = $"{ex.Message}\n\nSTACK TRACE:\n{ex.StackTrace}\n\nLine number: {frame.GetFileLineNumber()}\n\n File: {frame.GetFileName()}";
                System.IO.File.WriteAllText($"occlusionautoupdatercrashlog-{string.Format("{0:yyyy-MM-dd_HH-mm-ss-fff}", DateTime.Now)}.txt", logFile);
            }
        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}
