using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Avalonia;
using Avalonia.Threading;
using Microsoft.CodeAnalysis;
using Occlusion_Voice_Chat_CrossPlatform;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using Occlusion_Voice_Chat_CrossPlatform.platform;
using OcclusionShared.Util;
using X11;
using KeyCode = X11.KeyCode;
using KeySym = X11.KeySym;
using Xlib = X11.Xlib;

namespace GlobalLowLevelHooks
{
    public class LinuxBindManager : BindManager
    {
        public event EventHandler<Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode>? KeyUp;

        public event EventHandler<Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode>? KeyDown;

        public object PressedKeyLock { get; } = new object();

        public List<Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode> CurrentPressedKeys { get; set; } = new();

        private IntPtr x11Display = IntPtr.Zero;
        
        public LinuxBindManager()
        {
            
        }

        private Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode GetUniversalKeycode(LinuxKeySym keySym)
        {
            foreach(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode code in Enum.GetValues(typeof(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode)))
            {
                // Get C# attribute using reflection of the enum
                var field = code.GetType().GetField(code.ToString());
                
                if (field != null && 
                    field.GetCustomAttributes(typeof(KeyBackendAttribute), false).FirstOrDefault() is KeyBackendAttribute attribute)
                {
                    if (attribute.LinuxKeyCode == keySym)
                    {
                        return code;
                    }
                }
                
            }

            Console.WriteLine("Could not find keycode for " + keySym);
            
            return Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.INVALID_KEYCODE;
        }
        
        public void SetupBinds()
        {
            Thread x11Thread = new Thread(() => {
                x11Display = Xlib.XOpenDisplay(null);

                Window rootWindow = Xlib.XDefaultRootWindow(x11Display);
                
                List<Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode> previousKeys = new();
                
                while (true)
                {
                    lock (PressedKeyLock)
                    {
                        CurrentPressedKeys.Clear();
                    
                        // Use XQueryKeymap to get the current keys pressed, and populate a list called pressedKeys.
                        byte[] keymap = new byte[32];
                        Occlusion_Voice_Chat_CrossPlatform.platform.Xlib.XQueryKeymap(x11Display, keymap);


                        foreach(LinuxKeySym key in Enum.GetValues(typeof(LinuxKeySym)))
                        {
                            KeyCode code = Xlib.XKeysymToKeycode(x11Display, (KeySym) key);
                        
                            if (key == LinuxKeySym.VoidSymbol)
                                continue;

                            int keycode = (int)code;
                            int keycodeMask = 1 << (keycode % 8);
                            int keymapIndex = keycode / 8;
                            int keymapValue = keymap[keymapIndex];
                        
                            if ((keymapValue & keycodeMask) != 0)
                            {
                                Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode universalKey = GetUniversalKeycode(key);

                                if (!CurrentPressedKeys.Contains(universalKey))
                                {
                                    // Add key to the queue called CurrentPressedKeys
                                    CurrentPressedKeys.Add(universalKey);
                                }
                                
                                
                            }

                        }
                        
                        // Use XQueryPointer to get the currently pressed mouse buttons, and populate a list called pressedMouseButtons.
                        Occlusion_Voice_Chat_CrossPlatform.platform.Xlib.XQueryPointer(x11Display, rootWindow, out Window rootReturn, out Window childReturn, out int rootX, out int rootY, out int winX, out int winY, out uint maskReturn);

                        // Iterate through each XPointerMask enum then print to console for each button that is pressed.
                        foreach (PointerButtons mask in Enum.GetValues<PointerButtons>())
                        {
                            if ((maskReturn & (int)mask) != 0)
                            {
                                switch (mask)
                                {
                                    case PointerButtons.Mouse1:
                                        CurrentPressedKeys.Add(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.MOUSE1);
                                        break;
                                    
                                    // Mouse 2 & 3 are flipped because on X11, mouse 2 is middle mouse while mouse 3 is right mouse.
                                    // On windows however, mouse 2 is right mouse while mouse 3 is middle mouse.
                                    // The latter makes more sense to me thus it is what I picked.
                                    case PointerButtons.Mouse2:
                                        CurrentPressedKeys.Add(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.MOUSE3);
                                        break;
                                    
                                    case PointerButtons.Mouse3:
                                        CurrentPressedKeys.Add(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.MOUSE2);
                                        break;

                                    case PointerButtons.Mouse4:
                                        CurrentPressedKeys.Add(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.MOUSE4);
                                        break;
                                    
                                    case PointerButtons.Mouse5:
                                        CurrentPressedKeys.Add(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode.MOUSE5);
                                        break;
                                }
                            }
                        }
                        

                        // Check if any keys have been pressed, and invoke an event if so.
                        foreach(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode key in CurrentPressedKeys)
                        {
                            if (!previousKeys.Contains(key) && CurrentPressedKeys.Contains(key))
                            {
                                Dispatcher.UIThread.InvokeAsync(() => KeyDown?.Invoke(this, key));
                            }
                        }
                        
                        // Check if any keys have been released, and invoke an event if so.
                        foreach(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode key in previousKeys)
                        {
                            if (!CurrentPressedKeys.Contains(key) && previousKeys.Contains(key))
                            {
                                Dispatcher.UIThread.InvokeAsync(() => KeyUp?.Invoke(this, key));
                            }
                        }
                        
                        // Do this last
                        previousKeys.Clear();
                        foreach(Occlusion_Voice_Chat_CrossPlatform.keybinds.KeyCode key in CurrentPressedKeys)
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