using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class MainWindowViewModel : ReactiveObject
    {
        public string BuildNumber
        {
            get
            {
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                DateTime buildDate = new DateTime(2000, 1, 1)
                                        .AddDays(version.Build).AddSeconds(version.Revision * 2);
                string displayableVersion = $"{version} ({buildDate})";

                return displayableVersion;
            }
        }
    }
}
