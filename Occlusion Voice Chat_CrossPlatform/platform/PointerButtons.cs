using System;

namespace Occlusion_Voice_Chat_CrossPlatform.platform
{
    [Flags]
    public enum PointerButtons
    {
        Mouse1 = 1<<8, // 0x00000100
        Mouse2 = 1<<9, // 0x00000200
        Mouse3 = 1<<10, // 0x00000400
        Mouse4 = 1<<11, // 0x00000800
        Mouse5 = 1<<12, // 0x00001000
    }
    
}