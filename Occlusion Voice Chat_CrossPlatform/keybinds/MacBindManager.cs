using System;
using System.Collections.Generic;
using System.Threading;
using Avalonia.Threading;
using GlobalLowLevelHooks;
using Occlusion_Voice_Chat_CrossPlatform.platform;
using X11;
using KeySym = X11.KeySym;
using Xlib = X11.Xlib;

namespace Occlusion_Voice_Chat_CrossPlatform.keybinds
{
    public class MacBindManager : BindManager
    {
        public event EventHandler<KeyCode>? KeyUp;

        public event EventHandler<KeyCode>? KeyDown;

        public object PressedKeyLock { get; } = new object();

        public List<KeyCode> CurrentPressedKeys { get; set; } = new();

        public void SetupBinds()
        {
            Thread coreGraphicsThread = new Thread(() => {
                
            });

            coreGraphicsThread.IsBackground = true;
            coreGraphicsThread.Start();
        }

        public void DisposeBinds()
        {
            lock (PressedKeyLock)
            {
                
            }
        }
    }
}