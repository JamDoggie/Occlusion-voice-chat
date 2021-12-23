using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Avalonia.Input;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using OcclusionShared.Util;

namespace GlobalLowLevelHooks
{
    public interface BindManager
    {
        public object PressedKeyLock { get; }
        
        List<KeyCode> CurrentPressedKeys { get; set; }

        event EventHandler<KeyCode> KeyDown;
        
        event EventHandler<KeyCode> KeyUp;
        
        void SetupBinds();
        
        /// <summary>
        /// IMPORTANT: This method is called by the <see cref="BindManager"/> class. Do not call it directly.
        /// </summary>
        void DisposeBinds();
    }
}