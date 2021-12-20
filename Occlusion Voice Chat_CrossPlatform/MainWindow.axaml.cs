using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using LiteNetLib.Utils;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using Occlusion.NetworkingShared;
using Occlusion_voice_chat.Networking;
using Occlusion_voice_chat.util.json_structs;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using OcclusionShared.NetworkingShared.Packets;
using Avalonia.Diagnostics;
using System.Threading;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Occlusion_Voice_Chat_CrossPlatform.util.json_structs;
using Newtonsoft.Json;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using System.Text.RegularExpressions;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class MainWindow : Window
    {
        public static MainWindow mainWindow;

        #region Controls
        public TextBox NameTextbox;
        public TextBox IpTextbox;
        public TextBox PortTextbox;
        public TextBox CodeTextBox;
        public Button ConnectButton;
        public Grid ErrorMessageGroup;
        public Grid GenericMessageGroup;
        public TextBlock GenericErrorMessage;
        public WrapPanel ServerIconsPanel;
        public Button AddServerButton;
        public Button RemoveServerButton;
        public Image ConnectingLoadingBar;
        public TextBlock ConnectionStatusText;
        public VoiceChatControl VoiceChatWindow;
        #endregion

        private ServerSelection? _currentServerSelection = null;

        public ServerSelection? CurrentServerSelection
        {
            get
            {
                return _currentServerSelection;
            }

            set
            {
                if (!App.Client.IsConnected())
                {
                    _currentServerSelection = value;
                }
            }
        }

        private bool _settingsActive = false;

        public bool SettingsActive
        {
            get
            {
                if (App.Client.IsConnected())
                    return false;
                
                return _settingsActive;
            }

            set
            {
                if (!App.Client.IsConnected())
                {
                    _settingsActive = value;

                    NameTextbox.IsEnabled = value;
                    IpTextbox.IsEnabled = value;
                    PortTextbox.IsEnabled = value;
                    CodeTextBox.IsEnabled = value;
                    ConnectButton.IsEnabled = ShouldConnectBeEnabled();
                }
                else
                {
                    NameTextbox.IsEnabled = false;
                    IpTextbox.IsEnabled = false;
                    PortTextbox.IsEnabled = false;
                    CodeTextBox.IsEnabled = false;
                    ConnectButton.IsEnabled = false;
                }
                
            }
        }
        
        public MainWindow()
        {
            mainWindow = this;

            InitializeComponent();

#if DEBUG
            this.AttachDevTools();
#endif

#if WINDOWS
            uint attr = 19;
            int val = 1;
            int i = App.DwmSetWindowAttribute(PlatformImpl.Handle.Handle, attr, ref val, sizeof(int));
#endif
        }
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            DataContext = new MainWindowViewModel();

            NameTextbox = this.FindControl<TextBox>("NameTextbox");
            IpTextbox = this.FindControl<TextBox>("IpTextbox");
            PortTextbox = this.FindControl<TextBox>("PortTextbox");
            CodeTextBox = this.FindControl<TextBox>("CodeTextBox");
            ConnectButton = this.FindControl<Button>("ConnectButton");
            ErrorMessageGroup = this.FindControl<Grid>("ErrorMessageGroup");
            GenericMessageGroup = this.FindControl<Grid>("GenericMessageGroup");
            GenericErrorMessage = this.FindControl<TextBlock>("GenericErrorMessage");
            ServerIconsPanel = this.FindControl<WrapPanel>("ServerIconsPanel");
            AddServerButton = this.FindControl<Button>("AddServerButton");
            RemoveServerButton = this.FindControl<Button>("RemoveServerButton");
            ConnectingLoadingBar = this.FindControl<Image>("ConnectingLoadingBar");
            ConnectionStatusText = this.FindControl<TextBlock>("ConnectionStatusText");
            VoiceChatWindow = this.FindControl<VoiceChatControl>("VoiceChatWindow");

            AddServerButton.Click += AddServerButtonOnClick;
            RemoveServerButton.Click += RemoveServerButtonOnClick;
            
            NameTextbox.PropertyChanged += NameTextboxOnPropertyChanged;
            IpTextbox.PropertyChanged += IpTextboxOnPropertyChanged;
            PortTextbox.PropertyChanged += PortTextboxOnPropertyChanged;

            CodeTextBox.PropertyChanged += CodeTextBoxOnPropertyChanged;
            
            Closing += MainWindow_Closing;
            Closed += MainWindow_Closed;

                App.Client.PacketRecievedEvent += Client_PacketRecievedEvent;

            ConnectButton.Click += Connect_Click;
            this.FindControl<Button>("ErrorMessageOk").Click += Error_Message_Ok_Click;
            this.FindControl<Button>("GenericMessageOk").Click += Generic_Error_Message_Ok;

            foreach (KeyValuePair<string, Occlusion_voice_chat.util.json_structs.ServerSelection> pair in App.Options
                .Obj.ServerSelections)
            {
                ShowServerListing(pair.Key);
            }

            SettingsActive = false;

            // Load blogs from website
            Task<string> task = HttpGet(App.WebsiteURL + "/api/blogs/filter/;tags=Changelog");

            

            task.ContinueWith((t) => {
                // When the server responds back, add the first changelog blog that's given.
                OcclusionBlog[] blogs = JsonConvert.DeserializeObject<OcclusionBlog[]>(t.Result);

                if (blogs != null && blogs.Length > 0)
                {
                    AddBlogCard(blogs[0]);
                }
            }).ContinueWith((t) =>
            {
                // Once we've added the latest changelog, add all non changelog blogs
                Task<string> task = HttpGet(App.WebsiteURL + "/api/blogs/filter/;tags=!Changelog");

                task.ContinueWith((webTask) =>
                {
                    OcclusionBlog[] blogs = JsonConvert.DeserializeObject<OcclusionBlog[]>(webTask.Result);

                    if (blogs != null && blogs.Length > 0)
                    {
                        for(int i = 0; i < Math.Min(10, blogs.Length); i++)
                        {
                            OcclusionBlog blog = blogs[i];
                            
                            AddBlogCard(blog);
                        }
                    }

                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        this.FindControl<Image>("BlogLoadingBar").IsVisible = false;
                    });
                });
            });
        }

        public async void AddBlogCard(OcclusionBlog blog)
        {
            await Dispatcher.UIThread.InvokeAsync(() =>
              {
                  BlogControl blogControl = new BlogControl();

                  blogControl.ViewModel.Title = blog.Title;
                  blogControl.ViewModel.Subtitle = blog.Subtitle;

                  if (blog.BodyMarkdown.Length > 200)
                      blog.BodyMarkdown = blog.BodyMarkdown[0..200];

                  blogControl.ViewModel.InnerMarkdown = blog.BodyMarkdown;

                  Task<Stream> task = HttpGetStream($"{App.WebsiteURL}/{blog.BackgroundURL}");

                  task.ContinueWith((t) =>
                  {
                      Dispatcher.UIThread.InvokeAsync(() =>
                      {
                          blogControl.CardBorder.Background = new ImageBrush(new Bitmap(t.Result)) { Stretch = Stretch.UniformToFill };
                      });
                  });

                  blogControl.FindControl<Button>("ReadMoreButton").Click += (o, e) => 
                  {
                      OpenUrl($"{App.WebsiteURL}/occlusion/blogs/{blog.FileName}");
                  };

                  this.FindControl<StackPanel>("BlogPanel").Children.Add(blogControl);
              });
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // Hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private static async Task<string> HttpGet(string uri)
        {
            try
            {
                HttpResponseMessage response = await App.HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch
            {
                return string.Empty;
            }
        }

        private static async Task<Stream> HttpGetStream(string uri)
        {
            try
            {
                HttpResponseMessage response = await App.HttpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStreamAsync();
            }
            catch
            {
                return Stream.Null;
            }
        }

        private void CodeTextBoxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                ConnectButton.IsEnabled = ShouldConnectBeEnabled();
            }
        }

        public bool ShouldConnectBeEnabled()
        {
            return int.TryParse(CodeTextBox.Text, out _);
        }
        
        public async void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.Client.IsConnected())
            {
                e.Cancel = true;
                var msBoxStandardWindow = MessageBoxManager.GetMessageBoxStandardWindow(
                    new MessageBoxStandardParams
                    {
                        ButtonDefinitions = ButtonEnum.YesNoCancel,
                        ContentTitle = "Warning",
                        ContentMessage = "Really close the program and disconnect from the server?",
                        Icon = MessageBox.Avalonia.Enums.Icon.Warning,
                        Style = Style.None,

                    });

                var result = await msBoxStandardWindow.ShowDialog(this);
                if (result == ButtonResult.Yes)
                {
                    App.Client.DisconnectClient("", false);
                    Close();
                }
            }
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            
        }

        private void PortTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;

                    if (CurrentServerSelection != null)
                    {
                        if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName,
                            out selection))
                        {
                            if (int.TryParse(PortTextbox.Text, out int port))
                            {
                                selection.Port = port;
                                App.Options.Update();
                            }
                        }
                    }
                }
            }
        }

        private void IpTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;

                    if (CurrentServerSelection != null)
                    {
                        if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName,
                            out selection))
                        {
                            selection.IP = IpTextbox.Text;
                            App.Options.Update();
                        }
                    }
                }
            }
        }

        private void NameTextboxOnPropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == TextBox.TextProperty)
            {
                if (CurrentServerSelection != null && SettingsActive)
                {
                    Occlusion_voice_chat.util.json_structs.ServerSelection selection;
                
                    if (App.Options.Obj.ServerSelections.TryGetValue(CurrentServerSelection.BackingName, out selection) && 
                        !App.Options.Obj.ServerSelections.TryGetValue(NameTextbox.Text, out _))
                    {
                        App.Options.Obj.ServerSelections.Remove(CurrentServerSelection.BackingName);
                        App.Options.Obj.ServerSelections[NameTextbox.Text] = selection;

                        CurrentServerSelection.BackingName = NameTextbox.Text;
                        CurrentServerSelection.NameText.Text = NameTextbox.Text;
                        
                        App.Options.Update();
                    }
                }
            }
            
        }

        private void RemoveServerButtonOnClick(object? sender, RoutedEventArgs e)
        {
            if (CurrentServerSelection != null)
            {
                ServerIconsPanel.Children.Remove(CurrentServerSelection);

                App.Options.Obj.ServerSelections.Remove(CurrentServerSelection.BackingName);
                App.Options.Update();

                SettingsActive = false;
            }
        }

        private void AddServerButtonOnClick(object? sender, RoutedEventArgs e)
        {
            AddNewServerListing(GetNextAvailableServerName());
        }

        public void PopulateServerSettings()
        {
            if (CurrentServerSelection != null)
            {
                SettingsActive = true;

                foreach (KeyValuePair<string, Occlusion_voice_chat.util.json_structs.ServerSelection> pair in App
                    .Options.Obj.ServerSelections)
                {
                    if (pair.Key == CurrentServerSelection.BackingName)
                    {
                        NameTextbox.Text = pair.Key;
                        IpTextbox.Text = pair.Value.IP;
                        PortTextbox.Text = pair.Value.Port.ToString();
                        CodeTextBox.Text = string.Empty;
                    }
                }
            }
            else
            {
                SettingsActive = false;
                NameTextbox.Text = string.Empty;
                IpTextbox.Text = string.Empty;
                PortTextbox.Text = string.Empty;
                CodeTextBox.Text = string.Empty;
            }
        }
        
        public void AddNewServerListing(string name)
        {
            App.Options.Obj.ServerSelections[name] = new Occlusion_voice_chat.util.json_structs.ServerSelection();
            App.Options.Update();

            ShowServerListing(name);
        }

        public void ShowServerListing(string name)
        {
            ServerSelection serverSelection = new ServerSelection();
            serverSelection.BackingName = name;
            serverSelection.NameText.Text = name;
            serverSelection.Margin = new Thickness(10, 10, 10, 10);
            
            ServerIconsPanel.Children.Add(serverSelection);
        }
        
        public string GetNextAvailableServerName()
        {
            int serverIter = 1;

            if (!App.Options.Obj.ServerSelections.TryGetValue("New Server", out _))
                return "New Server";

            while (App.Options.Obj.ServerSelections.TryGetValue("New Server " + serverIter, out _))
            {
                serverIter++;
            }

            return "New Server " + serverIter;
        }
        
        private void Client_PacketRecievedEvent(NetDataReader message, IPacket packet, Client client)
        {
            if (packet is ServerValidationRejected)
            {
                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    ErrorMessageGroup.IsVisible = true;
                });
            }
        }

        public void ShowErrorMessage(string message, string subtitle = "")
        {
            GenericMessageGroup.IsVisible = true;

            GenericErrorMessage.Text = message;
            this.FindControl<TextBlock>("ErrorDetails").Text = subtitle;
        }

        public void Connect_Click(object? sender, RoutedEventArgs e)
        {
            bool portValid = int.TryParse(PortTextbox.Text, out int serverport);
            bool codeValid = int.TryParse(CodeTextBox.Text, out int code);

            if (portValid && codeValid)
                App.Connect(IpTextbox.Text, serverport, code);
        }

        public void Error_Message_Ok_Click(object? sender, RoutedEventArgs e)
        {
            if (ErrorMessageGroup.IsVisible)
                ErrorMessageGroup.IsVisible = false;
        }

        public void Generic_Error_Message_Ok(object? sender, RoutedEventArgs e)
        {
            if (GenericMessageGroup.IsVisible)
                GenericMessageGroup.IsVisible = false;
        }
    }

    public enum DWMWINDOWATTRIBUTE : uint
    {
        NCRenderingEnabled = 1,
        NCRenderingPolicy,
        TransitionsForceDisabled,
        AllowNCPaint,
        CaptionButtonBounds,
        NonClientRtlLayout,
        ForceIconicRepresentation,
        Flip3DPolicy,
        ExtendedFrameBounds,
        HasIconicBitmap,
        DisallowPeek,
        ExcludedFromPeek,
        Cloak,
        Cloaked,
        FreezeRepresentation,
        DarkMode = 19
    }
}
