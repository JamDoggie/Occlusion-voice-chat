using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.view_models
{
    public class VoiceChatWindowModel : ReactiveObject
    {
        private string _currentMicIcon = "/resources/occlusion_mic_icon.png";
        public string CurrentMicIcon
        {
            get => _currentMicIcon;

            set => this.RaiseAndSetIfChanged(ref _currentMicIcon, value);
        }

        private string _currentDeafenIcon = "/resources/speaker_unmuted.png";
        public string CurrentDeafenIcon
        {
            get => _currentDeafenIcon;

            set => this.RaiseAndSetIfChanged(ref _currentDeafenIcon, value);
        }
    }
}
