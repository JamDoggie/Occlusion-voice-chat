using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class BlogViewModel : ReactiveObject
    {
        private string _title = "...";
        public string Title
        {
            get => _title;

            set => this.RaiseAndSetIfChanged(ref _title, value);
        }

        private string _subtitle = "...";
        public string Subtitle
        {
            get => _subtitle;

            set => this.RaiseAndSetIfChanged(ref _subtitle, value);
        }

        private string _innerMarkdown = "# This is test markdown";
        public string InnerMarkdown
        {
            get => _innerMarkdown;

            set => this.RaiseAndSetIfChanged(ref _innerMarkdown, value);
        }
    }
}
