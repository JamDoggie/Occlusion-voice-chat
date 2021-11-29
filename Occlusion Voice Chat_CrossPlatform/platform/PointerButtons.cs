using System;

namespace Occlusion_Voice_Chat_CrossPlatform.platform
{
    [Flags]
    public enum PointerButtons
    {
        Button1Mask = 1<<8, // 0x00000100
        Button2Mask = 1<<9, // 0x00000200
        Button3Mask = 1<<10, // 0x00000400
        Button4Mask = 1<<11, // 0x00000800
        Button5Mask = 1<<12, // 0x00001000
    }
    
}