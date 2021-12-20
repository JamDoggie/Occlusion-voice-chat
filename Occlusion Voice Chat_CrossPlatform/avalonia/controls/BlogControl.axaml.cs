using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public partial class BlogControl : UserControl
    {
        public BlogViewModel ViewModel { get; set; } = new BlogViewModel();

        public Border CardBorder { get; set; }

        public BlogControl()
        {
            InitializeComponent();
            DataContext = ViewModel;

            CardBorder = this.FindControl<Border>("CardBorder");
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
