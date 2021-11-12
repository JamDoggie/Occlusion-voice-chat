using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using OcclusionAutoUpdater.ViewModels;
using OcclusionAutoUpdater.Views;
using OcclusionVersionControl;
using Octokit;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OcclusionAutoUpdater
{
    public class App : Avalonia.Application
    {
        #region WindowsOnly
#if WINDOWS
        /// <summary>
        /// This function is used in Occlusion currently only to change the window title bar to black.
        /// This function is not imported on any other platform besides Windows.
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="attr"></param>
        /// <param name="attrValue"></param>
        /// <param name="attrSize"></param>
        /// <returns></returns>
        [DllImport("dwmapi.dll", PreserveSig = true)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, uint attr, ref int attrValue, int attrSize);
#endif
        #endregion

        /// <summary>
        /// The client to be used for Github API calls using Octokit.
        /// </summary>
        public static GitHubClient Github { get; set; } = new GitHubClient(new ProductHeaderValue("OcclusionAutoUpdater"));

        public static string DownloadLink { get; set; } = string.Empty;

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            var versionTask = NewerVersionAvailable();
            versionTask.ContinueWith(async (b) =>
            {
                bool shouldUpdate = await b;

                if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
                {
                    // If we don't need to update, just don't even bother.
                    if (!shouldUpdate)
                    {
                        lifetime.Shutdown();
                    }
                    else
                    // We are out of date. Open a window asking the user if they want to update.
                    {
                        lifetime.MainWindow.IsVisible = true;
                    }
                }
            });
        }
        public static async Task<bool> NewerVersionAvailable()
        {
            if (Github != null)
            {
                var releases = await Github.Repository.Release.GetAll("jamdoggie", "Occlusion-voice-chat");
                var latestRelease = releases?[0];

                if (latestRelease != null && int.TryParse(latestRelease.TagName, out int versionNum))
                {
                    if (versionNum > OcclusionVersion.VersionNumber)
                    {
                        foreach(ReleaseAsset asset in latestRelease.Assets)
                        {
                            OperatingSystem? os = GetOperatingSystem();
                            
                            switch(os)
                            {
                                case OperatingSystem.Windows:
                                    if (asset.ContentType == "x-msdownload")
                                    {
                                        DownloadLink = asset.BrowserDownloadUrl;
                                        return true;
                                    }
                                    break;
                                case OperatingSystem.Mac:
                                    if (asset.ContentType == "application/gzip" && asset.Name.StartsWith("occlusion-mac-x64-binaries"))
                                    {
                                        DownloadLink = asset.BrowserDownloadUrl;
                                        return true;
                                    }
                                    break;
                                case OperatingSystem.Linux:
                                    // If statement to check if the asset ContentType is tar.gz
                                    if (asset.ContentType == "application/gzip" && asset.Name.StartsWith("occlusion-linux-x64-binaries"))
                                    {
                                        DownloadLink = asset.BrowserDownloadUrl;
                                        return true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
            return false;
        }
        
        // Method that gets the current operating system and returns an enum.
        public static OperatingSystem? GetOperatingSystem()
        {
            var os = Environment.OSVersion;
            var platform = os.Platform;

            switch (platform)
            {
                case PlatformID.Win32NT:
                    return OperatingSystem.Windows;
                case PlatformID.Unix:
                    return OperatingSystem.Linux;
                case PlatformID.MacOSX:
                    return OperatingSystem.Mac;
                default:
                    return null;
            }
        }
        
        
        
        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                { 
                    DataContext = new MainWindowViewModel(),
                    IsVisible = false
                };
            }
            base.OnFrameworkInitializationCompleted();
        }
    }
    
    // Enum that represents an operating system
    public enum OperatingSystem
    {
        Windows,
        Mac,
        Linux
    }
}
