using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;
using Occlusion_Voice_Chat_CrossPlatform.HRTF;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Timers;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class SettingsPage : UserControl
    {
        public ToggleSwitch HRTFSwitch { get; set; }

        public SmoothScrollViewer SettingsScroller { get; set; }

        public ListBox HRTFFilterList { get; set; }

        public Grid AudioSettingsGroup { get; set; }

        public Grid MainSettingsGrid { get; set; }

        public Button HRTFImportButton { get; set; }

        public Button HRTFMuteButton { get; set; }

        public Border HRTFIconSlash { get; set; }

        public Border HRTFBackground { get; set; }
        
        public Border HRTFDot { get; set; }

        public Avalonia.Controls.Slider AzimuthSlider { get; set; }

        public Avalonia.Controls.Slider ElevationSlider { get; set; }


        private bool HRTFRotating { get; set; } = true;
        public SettingsPage()
        {
            DataContext = new SettingsPageModel();

            InitializeComponent();

            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 16;
            timer.Start();

            AudioSettingsGroup = this.FindControl<Grid>("AudioSettingsGroup");
            HRTFSwitch = this.FindControl<ToggleSwitch>("HRTFSwitch");
            HRTFFilterList = this.FindControl<ListBox>("HRTFFilterList");
            MainSettingsGrid = this.FindControl<Grid>("MainSettingsGrid");
            SettingsScroller = this.FindControl<SmoothScrollViewer>("SettingsScroller");
            HRTFMuteButton = this.FindControl<Button>("HRTFMuteButton");
            HRTFIconSlash = this.FindControl<Border>("HRTFIconSlash");
            HRTFBackground = this.FindControl<Border>("HRTFBackground");
            HRTFDot = this.FindControl<Border>("HRTFDot");
            AzimuthSlider = this.FindControl<Avalonia.Controls.Slider>("AzimuthSlider");
            ElevationSlider = this.FindControl<Avalonia.Controls.Slider>("ElevationSlider");
            HRTFImportButton = this.FindControl<Button>("HRTFImportButton");

            foreach (string s in HRTFFilterList.Items)
            {
                if (HRTF.HRTF.CurrentHRTFFile != null && s == HRTF.HRTF.CurrentHRTFFile.FileInformation.Name)
                {
                    HRTFFilterList.SelectedItem = s;
                }
            }

            HRTFFilterList.SelectionChanged += HRTFFilterList_SelectionChanged;

            HRTFSwitch.Click += HRTFSwitch_Click;

            HRTFMuteButton.Click += HRTFMuteButton_Click;

            AzimuthSlider.PropertyChanged += AzimuthSlider_PropertyChanged;

            ElevationSlider.PropertyChanged += ElevationSlider_PropertyChanged;

            HRTFImportButton.Click += HRTFImportButton_Click;

            this.FindControl<ToggleSwitch>("AutoRotate").Click += SettingsPage_Click; 
        }

        private async void HRTFImportButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var MHRFilter = new FileDialogFilter() { Name="OpenAL Soft HRTF Data" };
            MHRFilter.Extensions = new List<string>() { "mhr" };

            OpenFileDialog fileDialog = new OpenFileDialog()
            {
                Title = "Choose an MHR file",
                Filters = new List<FileDialogFilter>() { MHRFilter }
            };

            fileDialog.AllowMultiple = true;

            string[] paths = await fileDialog.ShowAsync(MainWindow.mainWindow);

            if (paths.Length > 0)
            {
                foreach(string s in paths)
                {
                    FileInfo info = new FileInfo(s);

                    if (info.Exists)
                    {
                        Assembly assembly = Assembly.GetExecutingAssembly();
                        File.Copy(s, $"{Path.GetDirectoryName(assembly.Location)}/HRTF sets/{info.Name}", true);
                    }
                }

                if (DataContext is SettingsPageModel model)
                {
                    model.RefreshListBox();
                }
            }
        }

        private void HRTFFilterList_SelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                if (e.AddedItems[0] is string name)
                {
                    Assembly assembly = Assembly.GetExecutingAssembly();
                    string? path = $"{Path.GetDirectoryName(assembly.Location)}/HRTF sets/{name}";
                    if (File.Exists(path))
                    {
                        HRTF.HRTF.CurrentHRTFFile = MHRFile.Parse(path);
                        App.Options.Obj.CurrentHRTFSet = name;
                        App.Options.Update();
                    }
                }
            }

            // This resets the HRTF filters so they update in the preview sound effect.
            App.HRTFPreview.Azimuth = App.HRTFPreview.Azimuth;
            App.HRTFPreview.Elevation = App.HRTFPreview.Elevation;
        }

        private void AzimuthSlider_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Avalonia.Controls.Slider.ValueProperty)
            {
                App.HRTFPreview.Azimuth = (float)AzimuthSlider.Value;

                if (HRTFDot.RenderTransform is TranslateTransform transform)
                {
                    transform.X = Math.Sin(ConvertDegreesToRadians(App.HRTFPreview.Azimuth)) * (HRTFBackground.Width / 2);
                    transform.Y = -Math.Cos(ConvertDegreesToRadians(App.HRTFPreview.Azimuth)) * (HRTFBackground.Width / 2);
                }
            }
        }

        private void ElevationSlider_PropertyChanged(object? sender, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.Property == Avalonia.Controls.Slider.ValueProperty)
            {
                App.HRTFPreview.Elevation = (float)ElevationSlider.Value;
            }
        }

        private void SettingsPage_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (this.FindControl<ToggleSwitch>("AutoRotate").IsChecked != null)
                HRTFRotating = this.FindControl<ToggleSwitch>("AutoRotate").IsChecked.Value;

            AzimuthSlider.IsEnabled = !HRTFRotating;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (HRTFRotating)
            {
                App.HRTFPreview.Azimuth += 0.6f;

                if (App.HRTFPreview.Azimuth >= 180)
                    App.HRTFPreview.Azimuth = -180;

                Dispatcher.UIThread.InvokeAsync(() => {
                    if (HRTFDot.RenderTransform is TranslateTransform transform)
                    {
                        transform.X = Math.Sin(ConvertDegreesToRadians(App.HRTFPreview.Azimuth)) * (HRTFBackground.Width / 2);
                        transform.Y = -Math.Cos(ConvertDegreesToRadians(App.HRTFPreview.Azimuth)) * (HRTFBackground.Width / 2);

                        AzimuthSlider.Value = App.HRTFPreview.Azimuth;
                    }
                });
            }
            
            
        }

        private static double ConvertRadiansToDegrees(double radians)
        {
            double degrees = (180 / Math.PI) * radians;
            return (degrees);
        }

        private static double ConvertDegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        private void HRTFMuteButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            App.HRTFPreview.Muted = !App.HRTFPreview.Muted;

            HRTFIconSlash.Width = App.HRTFPreview.Muted ? 35 : 0;
        }

        private void HRTFSwitch_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            if (HRTFSwitch.IsChecked != null)
                App.Options.Obj.UseHRTF = HRTFSwitch.IsChecked.Value;

            App.Options.Update();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
