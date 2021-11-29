using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using GlobalLowLevelHooks;
using static GlobalLowLevelHooks.KeyboardHook;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class HotkeyBindingControl : UserControl
    {
        #region Controls
        public TextBlock ContentText { get; set; }

        public Button HotkeyClearButton { get; set; }
        
        public Border FocusBorder { get; set; }

        public ContentPresenter BindContent { get; set; }

        public TextBlock WatermarkClickText { get; set; }
        #endregion

        public List<UniversalKey> Hotkey = new List<UniversalKey>();

        #region events
        public delegate void HotkeyPressedDelegate();
        public event HotkeyPressedDelegate HotkeyPressed;

        public delegate void HotkeyReleasedDelegate();
        public event HotkeyReleasedDelegate HotkeyReleased;

        public delegate void HotkeyChangedDelegate(List<UniversalKey> newHotkey);
        public event HotkeyChangedDelegate HotkeyChanged;
        #endregion

        public HotkeyBindingControl()
        {
            InitializeComponent();

            ContentText = this.FindControl<TextBlock>("ContentText");
            HotkeyClearButton = this.FindControl<Button>("HotkeyClearButton");
            FocusBorder = this.FindControl<Border>("FocusBorder");
            BindContent = this.FindControl<ContentPresenter>("BindContent");
            WatermarkClickText = this.FindControl<TextBlock>("WatermarkClickText");

            HotkeyClearButton.Click += HotkeyClearButton_Click;
            BindContent.PropertyChanged += BindContent_PropertyChanged;


            // If our current platform does not support key binds, show that in the GUI.
            if (App.KeybindManager.CurrentBindManager == null)
            {
                Cursor = new Avalonia.Input.Cursor(Avalonia.Input.StandardCursorType.No);
                BindContent.Cursor = new Avalonia.Input.Cursor(Avalonia.Input.StandardCursorType.No);
                HotkeyClearButton.IsEnabled = false;
            }
        }

        private void BindContent_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (App.KeybindManager.CurrentBindManager != null && e.Property == ContentPresenter.IsFocusedProperty && e.NewValue is bool val && e.NewValue != e.OldValue)
            {
                FocusBorder.Opacity = val ? 1 : 0;
                UpdateWatermark();
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            if (App.KeybindManager.CurrentBindManager != null)
            {
                App.KeybindManager.CurrentBindManager.KeyDown += App_HotkeyKeyDownEvent;
                App.KeybindManager.CurrentBindManager.KeyUp += App_HotkeyKeyUpEvent;
            }
            
        }


        private void HotkeyClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (App.KeybindManager.CurrentBindManager != null)
            {
                Hotkey.Clear();
                UpdateContent();
            }
        }

        private bool isPressed = false;

        private void App_HotkeyKeyDownEvent(object? sender, UniversalKey key)
        {
            
            if (App.KeybindManager.CurrentBindManager != null)
            {
                lock (App.KeybindManager.CurrentBindManager.PressedKeyLock)
                {
                    if (MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                        if (BindContent.IsFocused && BindContent.IsPointerOver)
                        {
                            Hotkey.Clear();
                            foreach (UniversalKey k in App.KeybindManager.CurrentBindManager.CurrentPressedKeys)
                            {
                                Hotkey.Add(k);
                            }

                            UpdateContent();
                        }
                        else
                        {
                            if (Hotkey.Count > 0 && HotkeyPressed != null && Hotkey.Contains(key))
                            {
                                // Pass along the hotkey
                                if (App.KeybindManager.CurrentBindManager.CurrentPressedKeys.Count < Hotkey.Count)
                                    return;

                                int matchingKeys = 0;

                                foreach (UniversalKey k in App.KeybindManager.CurrentBindManager.CurrentPressedKeys)
                                {
                                    if (Hotkey.Contains(k))
                                        matchingKeys++;
                                }

                                if (matchingKeys == Hotkey.Count)
                                {
                                    HotkeyPressed();

                                    isPressed = true;
                                }
                            }
                        }
                }
            }
        }

        private void App_HotkeyKeyUpEvent(object? sender, UniversalKey key)
        {
            if (MainWindow.mainWindow.VoiceChatWindow.IsOpen)
                if (!BindContent.IsFocused || !BindContent.IsPointerOver)
                {
                    if (Hotkey.Count > 0 && HotkeyReleased != null && isPressed && Hotkey.Contains(key))
                    {
                        // Pass along the hotkey
                        HotkeyReleased();

                        isPressed = false;
                    }
                }
        }
        
        public void UpdateWatermark()
        {
            if (Hotkey.Count > 0)
            {
                WatermarkClickText.IsVisible = false;
                return;
            }

            WatermarkClickText.IsVisible = true;
        }

        public void UpdateContent()
        {
            ContentText.Text = string.Empty;

            for (int i = 0; i < Hotkey.Count; i++)
            {
                if (i > 0)
                {
                    ContentText.Text = ContentText.Text + " + ";
                }

                ContentText.Text = ContentText.Text + Hotkey[i];
            }

            List<UniversalKey> newHotkey = new List<UniversalKey>();

            foreach (UniversalKey key in Hotkey)
                newHotkey.Add(key);

            if (HotkeyChanged != null)
                HotkeyChanged(newHotkey);
            
            UpdateWatermark();
        }
    }
}
