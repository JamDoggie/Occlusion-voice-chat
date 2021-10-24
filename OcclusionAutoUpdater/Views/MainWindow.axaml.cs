using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;

namespace OcclusionAutoUpdater.Views
{
    public partial class MainWindow : Window
    {
        #region Controls
        public Button RemindButton { get; set; }
        public Button UpdateButton { get; set; }
        public PageSlide PageSlider { get; set; }
        public Grid MainPage { get; set; }
        public Grid DownloadPage { get; set; }
        public ProgressBar DownloadBar { get; set; }
        public TextBlock ProgressText { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

#if WINDOWS
            uint attr = 19;
            int val = 1;
            int i = App.DwmSetWindowAttribute(PlatformImpl.Handle.Handle, attr, ref val, sizeof(int));
#endif

            RemindButton = this.FindControl<Button>("RemindButton");
            UpdateButton = this.FindControl<Button>("UpdateButton");
            PageSlider = this.FindResource("PageSlider") as PageSlide;
            MainPage = this.FindControl<Grid>("MainPage");
            DownloadPage = this.FindControl<Grid>("DownloadPage");
            DownloadBar = this.FindControl<ProgressBar>("DownloadBar");
            ProgressText = this.FindControl<TextBlock>("ProgressText");


            RemindButton.Click += RemindButton_Click;
            UpdateButton.Click += UpdateButton_Click;
        }

        private void UpdateButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            PageSlider.Start(MainPage, DownloadPage, true);


            if (!string.IsNullOrEmpty(App.DownloadLink))
            {
                using (WebClient wc = new WebClient())
                {
                    var installerPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\occlusion-release-installer-update.tmp.exe";

                    wc.DownloadFileAsync(new Uri(App.DownloadLink), installerPath);

                    // Progress bar
                    wc.DownloadProgressChanged += (sender, e) =>
                    {
                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            DownloadBar.Value = ((float)e.BytesReceived / (float)e.TotalBytesToReceive);
                            ProgressText.Text = $"{(int)(((float)e.BytesReceived / (float)e.TotalBytesToReceive) * 100)}% | {(int)(e.BytesReceived / 1000000)} / {(int)(e.TotalBytesToReceive / 1000000)} MB";
                        });
                    };

                    wc.DownloadFileCompleted += (sender, e) =>
                    {
                        // When the file is finished downloading, run it.
                        Process installer = new Process();
                        installer.StartInfo.FileName = installerPath;
                        installer.StartInfo.Arguments = "-updatemode";

                        installer.Start();

                        // Once the installer is run, we can exit both the auto updater and occlusion (which should be the assembly that ran us in the first place)
                        var exeAssembly = Assembly.GetEntryAssembly();
                        var entryAssembly = Assembly.GetExecutingAssembly();

                        // Close Occlusion
                        Process[] runningProcesses = Process.GetProcesses();
                        foreach (Process process in runningProcesses)
                        {
                            if (process.ProcessName == "Occlusion Voice Chat_CrossPlatform")
                            {
                                process.Kill();
                            }
                        }

                        if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
                        {
                            lifetime.Shutdown();
                        }
                    };
                }
            }
        }

        private void RemindButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (Avalonia.Application.Current.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime lifetime)
            {
                lifetime.Shutdown();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
