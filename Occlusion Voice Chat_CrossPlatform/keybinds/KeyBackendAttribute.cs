using Occlusion_Voice_Chat_CrossPlatform.platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GlobalLowLevelHooks.WindowsKeyboardHook;

namespace Occlusion_Voice_Chat_CrossPlatform.keybinds
{
    public class KeyBackendAttribute : Attribute
    {
        public LinuxKeySym LinuxKeyCode { get; }

        public VKeys WindowsKeyCode { get; }

        public KeyBackendAttribute(LinuxKeySym linuxKeyCode, VKeys windowsKeyCode)
        {
            LinuxKeyCode = linuxKeyCode;
            WindowsKeyCode = windowsKeyCode;
        }
    }
}
