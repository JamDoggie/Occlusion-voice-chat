using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;

namespace Occlusion_Voice_Chat_CrossPlatform
{
    public class ServerSelection : UserControl
    {
        #region Controls
        public Button SelectionButton;
        public TextBlock NameText;
        #endregion
        
        public string BackingName { get; set; }
        
        public ServerSelection()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            SelectionButton = this.FindControl<Button>("SelectionButton");
            NameText = this.FindControl<TextBlock>("NameText");
            

            SelectionButton.Click += SelectionButtonOnClick;
        }

        private void SelectionButtonOnClick(object? sender, RoutedEventArgs e)
        {
            MainWindow.mainWindow.CurrentServerSelection = this;
            
            // Selection colors
            foreach (IControl control in MainWindow.mainWindow.ServerIconsPanel.Children)
            {
                if (control is ServerSelection selection)
                {
                    //selection.SelectionButton.Background = new SolidColorBrush(Color.FromRgb(69,69,82));
                    selection.SelectionButton.Classes.Remove("selected");
                }
            }

            //SelectionButton.Background = new SolidColorBrush(Color.FromRgb(79, 79, 94));
            SelectionButton.Classes.Add("selected");
            
            MainWindow.mainWindow.PopulateServerSettings();
        }
    }
}