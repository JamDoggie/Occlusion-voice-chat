using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Lidgren.Network;
using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using Occlusion_voice_chat.Networking;
using Occlusion_voice_chat.Opus;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using OpusDotNet;
using SdlSharp;
using SdlSharp.Sound;

namespace Occlusion_voice_chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Storyboard errorFadeAnim = new Storyboard();

        public static MainWindow mainWindow { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ConsoleManager.ShowConsoleWindow();

            App.Client.PacketRecievedEvent += Client_PacketRecievedEvent;

            mainWindow = this;
        }

        private void Client_PacketRecievedEvent(NetIncomingMessage message, IPacket packet, Client client)
        {
            if (packet is ServerValidationRejected)
            {
                Dispatcher.Invoke(() =>
                {
                    ErrorMessageGroup.Visibility = Visibility.Visible;
                    var storyBoard = (Storyboard)FindResource("ErrorMessageAnim");

                    if (storyBoard != null)
                        storyBoard.Begin(ErrorMessageGroup, true);
                });
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        public void ShowErrorMessage(string message)
        {
            GenericMessageGroup.Visibility = Visibility.Visible;
            var storyBoard = (Storyboard)FindResource("GenericMessageGroupAnim");

            if (storyBoard != null)
                storyBoard.Begin(GenericMessageGroup, true);

            GenericErrorMessage.Text = message;
        }

        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            bool portValid = int.TryParse(PortTextbox.Text, out int serverport);
            bool codeValid = int.TryParse(CodeTextBox.Text, out int code);

            if (portValid && codeValid)
                App.Connect(IpTextbox.Text, serverport, code);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ErrorMessageGroup.Visibility == Visibility.Visible)
                ErrorMessageGroup.Visibility = Visibility.Hidden;
        }

        private void Error_Message_Ok(object sender, RoutedEventArgs e)
        {
            if (GenericMessageGroup.Visibility == Visibility.Visible)
                GenericMessageGroup.Visibility = Visibility.Hidden;
        }
    }
}
