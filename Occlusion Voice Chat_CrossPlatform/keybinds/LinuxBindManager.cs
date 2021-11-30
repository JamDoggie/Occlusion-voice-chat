using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Threading;
using Microsoft.CodeAnalysis;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.platform;
using OcclusionShared.Util;
using X11;
using KeySym = X11.KeySym;
using Xlib = X11.Xlib;

namespace GlobalLowLevelHooks
{
    public class LinuxBindManager : BindManager
    {
        public event EventHandler<UniversalKey>? KeyUp;

        public event EventHandler<UniversalKey>? KeyDown;

        public object PressedKeyLock { get; } = new object();

        public List<UniversalKey> CurrentPressedKeys { get; set; } = new();

        private IntPtr x11Display = IntPtr.Zero;
        
        private List<UniversalKey> _keyCodes = new();

        public LinuxBindManager()
        {
            foreach(Occlusion_Voice_Chat_CrossPlatform.platform.KeySym key in Enum.GetValues(typeof(Occlusion_Voice_Chat_CrossPlatform.platform.KeySym)))
            {
                _keyCodes.Add(new UniversalKey(key.ToString()));
            }
        }
        
        public void SetupBinds()
        {
            Thread x11Thread = new Thread(() => {
                x11Display = Xlib.XOpenDisplay(null);

                Window rootWindow = Xlib.XDefaultRootWindow(x11Display);
                
                List<UniversalKey> previousKeys = new();
                
                while (true)
                {
                    lock (PressedKeyLock)
                    {
                        CurrentPressedKeys.Clear();
                    
                        // Use XQueryKeymap to get the current keys pressed, and populate a list called pressedKeys.
                        byte[] keymap = new byte[32];
                        Occlusion_Voice_Chat_CrossPlatform.platform.Xlib.XQueryKeymap(x11Display, keymap);


                        foreach(Occlusion_Voice_Chat_CrossPlatform.platform.KeySym key in Enum.GetValues(typeof(Occlusion_Voice_Chat_CrossPlatform.platform.KeySym)))
                        {
                            KeyCode code = Xlib.XKeysymToKeycode(x11Display, (KeySym) key);
                        
                            if (key == Occlusion_Voice_Chat_CrossPlatform.platform.KeySym.VoidSymbol)
                                continue;

                            int keycode = (int)code;
                            int keycodeMask = 1 << (keycode % 8);
                            int keymapIndex = keycode / 8;
                            int keymapValue = keymap[keymapIndex];
                        
                            if ((keymapValue & keycodeMask) != 0)
                            {
                                // Add key to the queue called CurrentPressedKeys
                                CurrentPressedKeys.Add(GetKey(key));
                                
                            }

                        }
                        
                        // Use XQueryPointer to get the currently pressed mouse buttons, and populate a list called pressedMouseButtons.
                        Occlusion_Voice_Chat_CrossPlatform.platform.Xlib.XQueryPointer(x11Display, rootWindow, out Window rootReturn, out Window childReturn, out int rootX, out int rootY, out int winX, out int winY, out uint maskReturn);

                        // Iterate through each XPointerMask enum then print to console for each button that is pressed.
                        foreach (PointerButtons mask in Enum.GetValues<PointerButtons>())
                        {
                            if ((maskReturn & (int)mask) != 0)
                            {
                                CurrentPressedKeys.Add(new UniversalKey(mask.ToString()));
                            }
                        }
                        

                        // Check if any keys have been pressed, and invoke an event if so.
                        foreach(UniversalKey key in CurrentPressedKeys)
                        {
                            if (!previousKeys.Contains(key) && CurrentPressedKeys.Contains(key))
                            {
                                Dispatcher.UIThread.InvokeAsync(() => KeyDown?.Invoke(this, key));
                            }
                        }
                        
                        // Check if any keys have been released, and invoke an event if so.
                        foreach(UniversalKey key in previousKeys)
                        {
                            if (!CurrentPressedKeys.Contains(key) && previousKeys.Contains(key))
                            {
                                Dispatcher.UIThread.InvokeAsync(() => KeyUp?.Invoke(this, key));
                            }
                        }
                        
                        // Do this last
                        previousKeys.Clear();
                        foreach(UniversalKey key in CurrentPressedKeys)
                        {
                            previousKeys.Add(key);
                        }
                        
                        
                    }
                    
                    Thread.Sleep(1);
                }
            });

            x11Thread.IsBackground = true;
            x11Thread.Start();
        }

        public UniversalKey GetKey(Occlusion_Voice_Chat_CrossPlatform.platform.KeySym key)
        {
            return _keyCodes.Find(k => k.KeyName == key.ToString());
        }
        
        public void DisposeBinds()
        {
            lock (PressedKeyLock)
            {
                if (x11Display != IntPtr.Zero)
                    Xlib.XCloseDisplay(x11Display);
            }
        }
    }
}