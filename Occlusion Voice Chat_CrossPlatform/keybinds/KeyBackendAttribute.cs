using Occlusion_Voice_Chat_CrossPlatform.platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GlobalLowLevelHooks.KeyboardHook;

namespace Occlusion_Voice_Chat_CrossPlatform.keybinds
{
    public class KeyBackendAttribute : Attribute
    {
        public LinuxKeySym LinuxKeyCode { get; private set; }

        public VKeys WindowsKeyCode { get; private set; }

        
    }
}
