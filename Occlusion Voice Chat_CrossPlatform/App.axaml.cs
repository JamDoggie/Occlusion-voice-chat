#nullable enable
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using LiteNetLib;

using Occlusion.NetworkingShared;
using Occlusion.NetworkingShared.Packets;
using Occlusion_voice_chat;
using Occlusion_voice_chat.Mojang;
using Occlusion_voice_chat.Networking;
using Occlusion_voice_chat.Opus;
using Occlusion_voice_chat.util;
using Occlusion_voice_chat.util.json_structs;
using Occlusion_Voice_Chat_CrossPlatform.avalonia;
using OcclusionShared.NetworkingShared;
using OcclusionShared.NetworkingShared.Packets;
using OcclusionShared.Util;
using SdlSharp;
using SdlSharp.Sound;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

#if WINDOWS
using GlobalLowLevelHooks;
using static GlobalLowLevelHooks.KeyboardHook;
#endif

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class App : Avalonia.Application
    {
        public static AudioDevice RecordingDevice;

        public static AudioDevice PlaybackDevice;

        public static AudioSpec finalSettingsMic;

        public static AudioSpec finalSettingsSpeaker;

        public static bool RecordingSwitching = false;

        private static bool _enableVoiceIconMeterOnClients = true;
        public static bool EnableVoiceIconMeterOnClients
        {
            get => _enableVoiceIconMeterOnClients;
            set
            {
                _enableVoiceIconMeterOnClients = value;

                if (!_enableVoiceIconMeterOnClients)
                {
                    foreach(VoiceUser user in Users)
                    {
                        if(!user.IsLocalClient)
                        {
                            user.IsTalking = false;
                        }
                    }
                }
            }
        }

        private byte[] queuedMicrophoneAudio;

        private int currentMicQueueOffset = 0;

        public const int samplingRate = 48000;

        private int queueLength = 0;

        public OpusCodec mainCodec = new OpusCodec();

        #region region for changing the input and output devices across threads safely
        public static string? NewInputDevice { get; set; } = null;

        public static string? NewOutputDevice { get; set; } = null;


        // Volume controls
        public static float InputVolume { get; set; } = 1f;

        public static float OutputVolume { get; set; } = 1f;

        public static bool MicMuted { get; set; }

        public static bool Deafened { get; set; }

        public static float VoiceActivity { get; set; }
        #endregion

        public static ConcurrentList<VoiceUser> Users = new ConcurrentList<VoiceUser>();

        public static VoiceChatWindow VoiceChatWindow { get; set; }

        public static JsonFile<OptionsJson> Options { get; set; } = new JsonFile<OptionsJson>("occlusion_options.json", new OptionsJson());

        public static object AudioInfoRetrieveLock = new object();

        private static Client _client = new Client();
        public static Client Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }

        #region WindowsOnly
#if WINDOWS
        /// <summary>
        /// This function is used in Occlusion currently only to change the window title bar to black.
        /// This function is not imported on any other platform.
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

#if WINDOWS
        public static KeyboardHook keyboardHook = new KeyboardHook();

        public delegate void HotkeyKeyUpEventDelegate(VKeys key);
        public static event HotkeyKeyUpEventDelegate HotkeyKeyUpEvent;

        public delegate void HotkeyKeyDownEventDelegate(VKeys key);
        public static event HotkeyKeyUpEventDelegate HotkeyKeyDownEvent;

        public static List<VKeys> CurrentKeysPressed = new List<VKeys>();

        public static void ClearHotKeys()
        {
            CurrentKeysPressed.Clear();
        }
#endif

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);

            Console.WriteLine(Assembly.GetEntryAssembly().Location);

            Client.PacketRecievedEvent += Client_PacketRecievedEvent;
            Console.WriteLine($"The entry point thread is Thread #{Thread.CurrentThread.ManagedThreadId} ({Thread.CurrentThread.ManagedThreadId.ToString("X")})");
            InitSound();
            
            PlayerCache.RetrieveCacheFile();

            InputVolume = Options.Obj.InputVolume;
            OutputVolume = Options.Obj.OutputVolume;
            VoiceActivity = Options.Obj.VoiceActivity;

#if WINDOWS

            keyboardHook.KeyDown += KeyboardHook_KeyDown;
            keyboardHook.KeyUp += KeyboardHook_KeyUp;

            

            void KeyboardHook_KeyDown(VKeys key)
            {
                if (!CurrentKeysPressed.Contains(key))
                {
                    CurrentKeysPressed.Add(key);
                    HotkeyKeyDownEvent.Invoke(key);
                }
            }

            void KeyboardHook_KeyUp(VKeys key)
            {
                CurrentKeysPressed.Remove(key); 
                HotkeyKeyUpEvent.Invoke(key);
            }

            keyboardHook.Install();

            HotkeyKeyUpEvent += (k) => { };
            HotkeyKeyDownEvent += (k) => { };


            // Auto updater
            string autoUpdaterPath = "OcclusionAutoUpdater.exe";

            if (File.Exists(autoUpdaterPath))
            {
                // If the auto updater exists, run it.
                Process autoUpdater = new Process();
                autoUpdater.StartInfo.FileName = autoUpdaterPath;

                autoUpdater.Start();
            }
#endif
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow();
            }

            base.OnFrameworkInitializationCompleted();

            VoiceChatWindow = new VoiceChatWindow();
        }

        private void Client_PacketRecievedEvent(NetPacketReader message, IPacket packet, Client client)
        {
            if (packet is ServerUserConnectedPacket userConnectedPacket)
            {
                foreach (KeyValuePair<int, string> id in userConnectedPacket.idsToAdd)
                {
                    if (GetUserById(id.Key) == null)
                    {
                        var voiceUser = new VoiceUser()
                        {
                            id = id.Key,
                            MCUUID = id.Value,
                            codec = new OpusCodec()
                        };

                        if (voiceUser.id == client.verificationCode)
                        {
                            voiceUser.IsLocalClient = true;
                        }
                        
                        voiceUser.InitializeArrays();

                        voiceUser.codec.SetFrameSize(20);
                        voiceUser.codec.SetApplication(Concentus.Enums.OpusApplication.VOIP);

                        Users.Add(voiceUser);

                        // Add user to grid on UI
                        Dispatcher.UIThread.InvokeAsync(() =>
                        {
                            if (VoiceChatWindow != null && VoiceChatWindow.IsOpen)
                            {
                                VoiceChatWindow.AddPlayer(id.Value, id.Key);
                            }
                        });
                    }
                }
            }

            if (packet is ServerVoiceDataPacket voiceDataPacket)
            {
                var user = GetUserById(voiceDataPacket.ID);

                if (user != null)
                {
                    AudioChunk chunk = user.codec.Decompress(voiceDataPacket.VoiceData);

                    // Audio has been converted to stereo, now queue it.
                    // We amplify an extra time over all the audio equally to account for distance volume.
                    // Then, we amplify one last time for the input master volume.
                    byte[] decompressedAudio = chunk.Amplify(OutputVolume).Amplify(user.ClientVolume).GetDataAsBytes();

                    Span<byte> span = decompressedAudio;

                    // Queue the audio to be played
                    user.QueueAudio(span);

                    user.Pan = voiceDataPacket.Pan;
                    user.DistanceVolume = voiceDataPacket.Volume;
                }
            }

            if (packet is ServerConnectedPacket connectedPacket)
            {
                // We've successfully verified and connected ourselves.
                Client.ConnectionVerified = true;

                Dispatcher.UIThread.InvokeAsync(() =>
                {
                    VoiceChatWindow.Show();
                });
            }

            if (packet is ServerUserLeftPacket userLeft)
            {
                if (VoiceChatWindow != null && VoiceChatWindow.IsOpen)
                {
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        PlayerIcon icon = VoiceChatWindow.GetPlayerIconByUUID(userLeft.UUID);

                        if (icon != null)
                            VoiceChatWindow.RemovePlayerIcon(icon);
                    });

                    Users.Remove(GetUserByUUID(userLeft.UUID));
                }
            }
        }

        public void InitSound()
        {
            Native.SDL_InitSubSystem(Subsystems.Audio);

            if (!Audio.CaptureDevices.Contains(Options.Obj.InputDevice))
            {
                Options.Obj.InputDevice = "Default";
            }
            
            if (!Audio.NonCaptureDevices.Contains(Options.Obj.OutputDevice))
            {
                Options.Obj.OutputDevice = "Default";
            }

            // If the input device is null, it uses the system default mic.
            string? inputDevice = null;
            if (Options.Obj.InputDevice != "Default")
                inputDevice = Options.Obj.InputDevice;

            string? outputDevice = null;
            if (Options.Obj.OutputDevice != "Default")
                outputDevice = Options.Obj.OutputDevice;



            Console.WriteLine(Options.Obj.InputDevice);

            Console.WriteLine(Options.Obj.OutputDevice);


            queueLength = GetSampleSizeInBytes(TimeSpan.FromMilliseconds(20), samplingRate, 1);


            // Audio Recorder
            AudioSpec wantedSettingsMic = new AudioSpec(samplingRate, AudioFormat.Signed16Bit, 1, 0, (ushort)(queueLength / 2), 0, micCallback, 0);
            RecordingDevice = Audio.Open(inputDevice, true, wantedSettingsMic, out finalSettingsMic, AudioAllowChange.None);

            // Speaker output
            AudioSpec wantedSettingsSpeaker = new AudioSpec(samplingRate, AudioFormat.Signed16Bit, 2, 0, (ushort)((queueLength / 2) * 2), 0, speakerCallback, 0);
            PlaybackDevice = Audio.Open(outputDevice, false, wantedSettingsSpeaker, out finalSettingsSpeaker, AudioAllowChange.None);


            queuedMicrophoneAudio = new byte[queueLength];

            mainCodec.SetApplication(Concentus.Enums.OpusApplication.VOIP);
            mainCodec.SetFrameSize(20);

            RecordingDevice.Unpause();
            PlaybackDevice.Unpause();
        }

        void speakerCallback(Span<byte> stream, nint userdata)
        {
            // Ensure this current chunk of audio data starts as silence.
            for (int i = 0; i < stream.Length; i++)
                stream[i] = 0;

            foreach (VoiceUser user in Users)
            {
                user.MixMicIntoSpanAndCutQueue(ref stream);
            }

            // Change output volume based on global volume slider
            short[] shorts = AudioMath.BytesToShorts(stream.ToArray());
            for (int i = 0; i < shorts.Length; i++)
            {
                shorts[i] = (short)Math.Clamp(shorts[i] * OutputVolume, short.MinValue, short.MaxValue);
            }

            byte[] newBytes = AudioMath.ShortsToBytes(shorts);
            for (int i = 0; i < stream.Length; i++)
            {
                stream[i] = newBytes[i];
            }

            // Microphone volume bar
            AudioChunk chunk = new AudioChunk(stream.ToArray(), samplingRate);
            Dispatcher.UIThread.InvokeAsync(() =>
            {
                if (VoiceChatWindow != null && VoiceChatWindow.IsOpen && PlaybackDevice.Status == AudioStatus.Playing)
                {
                    VoiceChatWindow.SpeakerDecibalMeter.Value = Math.Clamp(chunk.Volume(), 0, 3000);

                    if (VoiceChatWindow.AudioSettingsOpen)
                    {
                        ProgressBarAnimationExtensions.SetValue(VoiceChatWindow.SettingsSpeakerMeter, Math.Clamp(chunk.Volume(), 0, 3000));
                    }
                }
            });

            // Silence audio if we're deafened. We still calculate the mix earlier though so that we can show the gray decibal bar.
            if (Deafened)
                for (int i = 0; i < stream.Length; i++)
                    stream[i] = 0;



            // We can change audio input here as well because this is on the sdl thread.
            
            if (NewInputDevice != null && RecordingDevice != null)
            {

                string? newDevice = NewInputDevice;
                if (newDevice == "Default")
                    newDevice = null;

                RecordingDevice.ClearQueuedAudio();
                RecordingDevice.Pause();
                RecordingDevice.Dispose();
                RecordingDevice = Audio.Open(newDevice, true, finalSettingsMic, out _, AudioAllowChange.None);
                RecordingDevice.Unpause();

                NewInputDevice = null;
                
                
            }
            
        }

        private short _residualVoiceVolume = 0;

        void micCallback(Span<byte> stream, nint userdata)
        {
            if (RecordingDevice != null && Client.IsConnected())
            {
                if (stream.Length > 0)
                {
                    // Microphone volume bar
                    AudioChunk rawChunk = new AudioChunk(stream.ToArray(), samplingRate);

                    rawChunk = rawChunk.Amplify(InputVolume);

                    AudioChunk chunk = new AudioChunk(stream.ToArray(), samplingRate);

                    chunk = chunk.Amplify(InputVolume);

                    var volume = chunk.Volume();

                    if (volume > _residualVoiceVolume)
                        _residualVoiceVolume = (short)volume;

                    bool isTalking = true;
                        
                    // If our total volume is under the voice activity threshold, just set it all to silence.
                    if (_residualVoiceVolume <= VoiceActivity)
                    {
                        for (int i = 0; i < chunk.DataLength; i++)
                        {
                            chunk.Data[i] = 0;
                        }

                        isTalking = false;
                    }

                    // Set voice activity variable that controls the animation on our player icon.
                    foreach (VoiceUser user in Users)
                    {
                        if (user.IsLocalClient)
                        {
                            user.IsTalking = isTalking;
                        }
                    }
                        

                    byte[] newBytes = chunk.GetDataAsBytes();

                    for (int i = 0; i < stream.Length; i++)
                    {
                        stream[i] = newBytes[i];
                    }
                    
                    Dispatcher.UIThread.InvokeAsync(() =>
                    {
                        if (VoiceChatWindow != null && VoiceChatWindow.IsOpen && RecordingDevice.Status == AudioStatus.Playing)
                        {
                            VoiceChatWindow.MicDecibalMeter.Value = Math.Clamp(rawChunk.Volume(), 0, 3000) * VoiceChatWindow.InputVolumeSlider.Value;

                            if (VoiceChatWindow.AudioSettingsOpen)
                            {
                                VoiceChatWindow.SettingsMicMeter.Value = Math.Clamp(rawChunk.Volume(), 0, 3000) * VoiceChatWindow.InputVolumeSlider.Value;
                            }
                        }
                    });


                    // Fill the buffer until it's full
                    if (currentMicQueueOffset + 1 >= queueLength)
                    {
                        if (!MicMuted)
                        {
                            // Buffer is full, time to do what we need to do with the audio.

                            // First we encode the audio with Opus so it's small enough to send over the network
                            byte[] compressedAudio = mainCodec.Compress(new AudioChunk(queuedMicrophoneAudio, samplingRate));

                            // Now we send the compressed audio data to the server
                            ClientVoiceDataPacket voiceDataPacket = new ClientVoiceDataPacket();
                            voiceDataPacket.VoiceData = compressedAudio;
                            Client.SendMessage(voiceDataPacket, DeliveryMethod.Unreliable);
                        }

                        currentMicQueueOffset = 0;
                    }

                    // Buffer is not full, fill in the data we just got from the microphone into it.
                    for (int i = 0; i < stream.Length; i++)
                    {
                        if (currentMicQueueOffset < queuedMicrophoneAudio.Length)
                        {
                            queuedMicrophoneAudio[currentMicQueueOffset] = stream[i];
                            currentMicQueueOffset++;
                        }
                    }

                    double speed = Math.Abs((int)_residualVoiceVolume - ((int)VoiceActivity - 30)) / 25;
                    _residualVoiceVolume -= (short)Math.Clamp(speed * 4, short.MinValue, short.MaxValue);
                }
            }

            // We can change audio output here as well because this is on the sdl thread.
            if (NewOutputDevice != null && PlaybackDevice != null && NewInputDevice == null && RecordingDevice == null)
            {
                string? newDevice = NewOutputDevice;
                if (newDevice == "Default")
                    newDevice = null;

                PlaybackDevice.ClearQueuedAudio();
                PlaybackDevice.Pause();
                PlaybackDevice.Dispose();
                PlaybackDevice = Audio.Open(newDevice, false, finalSettingsSpeaker, out _, AudioAllowChange.None);
                PlaybackDevice.Unpause();

                NewOutputDevice = null;
                    
            }
            
        }

        public static VoiceUser GetUserById(int id)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.id == id)
                    return user;
            }

            return null;
        }

        public static VoiceUser GetUserByUUID(string uuid)
        {
            foreach (VoiceUser user in Users)
            {
                if (user.MCUUID == uuid)
                    return user;
            }

            return null;
        }

        public static int GetSampleSizeInBytes(
            TimeSpan duration,
            int sampleRate,
            int channels
        )
        {
            return (int)(
                duration.TotalSeconds *
                sampleRate *
                channels *
                16 // 16-bit PCM
            ) / 8; // Divide by 8 because we need to convert from bits to bytes.
        }

        public static void Connect(string ip, int port, int verificationCode)
        {
            // Client thread
            // We call connect on a seperate thread so the client is essentially "started" on another thread,
            // giving it space to run it's message loop without halting the ui thread.
            var clientThread = new Thread(() =>
            {
                if (verificationCode >= 0)
                {
                    Client.Connect(ip, port, verificationCode);
                }
            });

            clientThread.IsBackground = true;

            clientThread.Start();
        }
    }
}
