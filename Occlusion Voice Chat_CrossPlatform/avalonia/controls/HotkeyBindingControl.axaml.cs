using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
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

        public List<VKeys> Hotkey = new List<VKeys>();

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

#if !WINDOWS
            Cursor = new Avalonia.Input.Cursor(Avalonia.Input.StandardCursorType.No);
            BindContent.Cursor = new Avalonia.Input.Cursor(Avalonia.Input.StandardCursorType.No);
            HotkeyClearButton.IsEnabled = false;
#endif
        }

        private void BindContent_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
#if WINDOWS
            if (e.Property == ContentPresenter.IsFocusedProperty && e.NewValue is bool val && e.NewValue != e.OldValue)
            {
                FocusBorder.Opacity = val ? 1 : 0;
                UpdateWatermark();
            }
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
#if WINDOWS
            App.HotkeyKeyDownEvent += App_HotkeyKeyDownEvent;
#endif
        }

        private void HotkeyClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
#if WINDOWS
            App.ClearHotKeys();
            Hotkey.Clear();
            UpdateContent();
#endif
            
        }

        private void App_HotkeyKeyDownEvent(VKeys key)
        {
#if WINDOWS
            if (BindContent.IsFocused)
            {
                Hotkey.Clear();
                foreach(VKeys k in App.CurrentKeysPressed)
                {
                    Hotkey.Add(k);
                }

                UpdateContent();
            }
#endif
        }

#if WINDOWS
        public void UpdateWatermark()
        {
            if (Hotkey.Count > 0)
            {
                WatermarkClickText.IsVisible = false;
                return;
            }

            WatermarkClickText.IsVisible = false;
        }
#endif

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

#if WINDOWS
            UpdateWatermark();
#endif
        }
    }
}