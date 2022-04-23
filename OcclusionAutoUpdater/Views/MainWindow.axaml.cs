using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ICSharpCode.SharpZipLib.Tar;

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
            PageSlider.Start(MainPage, DownloadPage, true, new CancellationToken());
            
            if (!string.IsNullOrEmpty(App.DownloadLink))
            {
                using (WebClient wc = new WebClient())
                {
                    var exeAssembly = Assembly.GetExecutingAssembly();
                    var entryAssembly = Assembly.GetEntryAssembly();
                    
                    string localPath = AppContext.BaseDirectory;


                    var installerPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/occlusion-release-installer-update.tmp.exe";

                    if (App.GetOperatingSystem() == OperatingSystem.Linux)
                    {
                        // If localPath ends with a /, remove it.
                        if (localPath.EndsWith("/"))
                        {
                            localPath = localPath.Substring(0, localPath.Length - 1);
                        }
                        
                        installerPath = $"{localPath}/occlusion-binaries.tar.gz.tmp";
                    }
                    
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

                    // Close all instances of Occlusion
                    Process[] runningProcesses = Process.GetProcesses();
                    foreach (Process process in runningProcesses)
                    {
                        // process.ProcessName does not get the full name. 
                        // That's why we use the following workaround.
                        if (App.GetOperatingSystem() == OperatingSystem.Mac &&
                            process.MainModule != null &&
                            process.MainModule.ModuleName != null && 
                            process.MainModule.ModuleName == "Occlusion Voice Chat_CrossPlatform")
                        {
                            process.Kill();
                            continue;
                        }
                        
                        
                        if (process.ProcessName == "Occlusion Voice Chat_CrossPlatform")
                        {
                            process.Kill();
                        }
                    }
                    
                    wc.DownloadFileCompleted += (sender, e) =>
                    {
                        OperatingSystem? os = App.GetOperatingSystem();

                        // Once the installer is run, we can exit both the auto updater and occlusion (which should be the assembly that ran us in the first place)
                        if (os != null)
                        {
                            switch (os)
                            {
                                case OperatingSystem.Windows:
                                    // When the file is finished downloading, run it.
                                    Process installer = new Process();
                                    installer.StartInfo.FileName = installerPath;
                                    installer.StartInfo.Arguments = "-updatemode";

                                    installer.Start();
                                    break;
                                    
                                case OperatingSystem.Linux:
                                    // Extract the tar.gz file located at installerPath to a temporary location.
                                    using (FileStream fs = new FileStream(installerPath, FileMode.Open))
                                    {
                                        using (GZipStream gz = new(fs, CompressionMode.Decompress))
                                        {
                                            using (TarArchive tar = TarArchive.CreateInputTarArchive(gz, TarBuffer.DefaultBlockFactor, Encoding.Default))
                                            {
                                                tar.ExtractContents($"{localPath}/../");

                                                string[] files = Directory.GetFiles(
                                                    $"{localPath}/../occlusionlinuxrelease/");

                                                string[] directories = Directory.GetDirectories(
                                                    $"{localPath}/../occlusionlinuxrelease/");
                                                
                                                // Get the path to the currently executing executable
                                                string exePath = $"{localPath}/{exeAssembly.GetName().Name}";
                                                
                                                // Rename the auto updater so that it can essentially overwrite itself.
                                                
                                                MoveFileAndReplace(exePath, exePath + ".bak");
                                                
                                                if (File.Exists(exePath + ".dll"))
                                                    MoveFileAndReplace(exePath + ".dll", exePath + ".dll.bak");
                                                
                                                foreach (string file in files)
                                                {
                                                    FileInfo fi = new(file);

                                                    MoveFileAndReplace(fi, $"{localPath}/../{fi.Name}");
                                                }
                                                
                                                foreach (string dir in directories)
                                                {
                                                    DirectoryInfo di = new(dir);

                                                    MoveDirAndReplace(di, $"{localPath}/../{di.Name}/");
                                                }

                                                
                                                // Try catch to catch IO exceptions.
                                                try
                                                {
                                                    // Chmod the executable so that it can be executed.
                                                    Process chmod = new();
                                                    chmod.StartInfo.FileName = "chmod";
                                                    chmod.StartInfo.Arguments = $"+x \"../Occlusion Voice Chat_CrossPlatform\"";

                                                    chmod.Start();
                                                    chmod.WaitForExit();

                                                    // Execute the executable.
                                                    Process exe = new();
                                                    exe.StartInfo.FileName = $"../Occlusion Voice Chat_CrossPlatform";
                                                
                                                    // Block this thread until the process has started.
                                                    exe.Start();
                                                }
                                                catch (IOException)
                                                {
                                                    // Do nothing... for now. In the future, we need to show a page to the user 
                                                    // that says that the update failed.
                                                }
                                            }
                                        }
                                    }
                                    break;
                                    
                                case OperatingSystem.Mac:
                                    // Extract the tar.gz file located at installerPath to a temporary location.
                                    using (FileStream fs = new FileStream(installerPath, FileMode.Open))
                                    {
                                        using (GZipStream gz = new(fs, CompressionMode.Decompress))
                                        {
                                            using (TarArchive tar = TarArchive.CreateInputTarArchive(gz, TarBuffer.DefaultBlockFactor, Encoding.Default))
                                            {
                                                tar.ExtractContents($"{localPath}/../");

                                                string[] files = Directory.GetFiles(
                                                    $"{localPath}/../occlusionmacbuild/Occlusion Voice Chat.app/Contents/MacOS/");

                                                string[] directories = Directory.GetDirectories(
                                                    $"{localPath}/../occlusionmacbuild/Occlusion Voice Chat.app/Contents/MacOS/");
                                                
                                                // Get the path to the currently executing executable
                                                string exePath = $"{localPath}/{exeAssembly.GetName().Name}";
                                                
                                                // Rename the auto updater so that it can essentially overwrite itself.
                                                
                                                MoveFileAndReplace(exePath, exePath + ".bak");
                                                
                                                if (File.Exists(exePath + ".dll"))
                                                    MoveFileAndReplace(exePath + ".dll", exePath + ".dll.bak");
                                                
                                                foreach (string file in files)
                                                {
                                                    FileInfo fi = new(file);

                                                    MoveFileAndReplace(fi, $"{localPath}/../{fi.Name}");
                                                }
                                                
                                                foreach (string dir in directories)
                                                {
                                                    DirectoryInfo di = new(dir);

                                                    MoveDirAndReplace(di, $"{localPath}/../{di.Name}/");
                                                }

                                                
                                                // Try catch to catch IO exceptions.
                                                
                                                // Chmod the executable so that it can be executed.
                                                
                                                /*Process chmod = new();
                                                chmod.StartInfo.FileName = "chmod";
                                                chmod.StartInfo.Arguments = $"+x \"Occlusion Voice Chat_CrossPlatform\"";

                                                chmod.Start();
                                                chmod.WaitForExit();*/

                                                // user permissions
                                                const int S_IRUSR = 0x100;
                                                const int S_IWUSR = 0x80;
                                                const int S_IXUSR = 0x40;

                                                // group permission
                                                const int S_IRGRP = 0x20;
                                                const int S_IWGRP = 0x10;
                                                const int S_IXGRP = 0x8;

                                                // other permissions
                                                const int S_IROTH = 0x4;
                                                const int S_IWOTH = 0x2;
                                                const int S_IXOTH = 0x1;

                                                const int _0755 =
                                                    S_IRUSR | S_IXUSR | S_IWUSR
                                                    | S_IRGRP | S_IXGRP
                                                    | S_IROTH | S_IXOTH;
                                                
                                                MacOSFunctions.chmod($"{localPath}/../Occlusion Voice Chat_CrossPlatform", _0755);
                                                

                                                // Execute the executable.
                                                Process.Start("open", "-a " +
                                                                      $"\"{localPath}/../Occlusion Voice Chat_CrossPlatform\"");
                                            }
                                        }
                                    }
                                    break;
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
        
        private void MoveFileAndReplace(FileInfo source, string destination)
        {
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            source.MoveTo(destination);
        }
        
        private void MoveFileAndReplace(string source, string destination)
        {
            if (File.Exists(destination))
            {
                File.Delete(destination);
            }

            File.Move(source, destination);
        }
        
        private void MoveDirAndReplace(DirectoryInfo source, string destination)
        {
            if (Directory.Exists(destination))
            {
                Directory.Delete(destination, true);
            }

            source.MoveTo(destination);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
