using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Occlusion_Voice_Chat_CrossPlatform.keybinds;
using OcclusionShared.Util;

namespace GlobalLowLevelHooks
{
    public class Win32BindManager : BindManager
    {
        public object PressedKeyLock { get; } = new object();

        public List<KeyCode> CurrentPressedKeys { get; set; } = new();

        public WindowsKeyboardHook WindowsKeyboardHook = new WindowsKeyboardHook();

        public MouseHook mouseHook = new MouseHook();

        private List<KeyCode> _keyCodes = new();
        
        // Events
        public event EventHandler<KeyCode>? KeyUp;
        public event EventHandler<KeyCode>? KeyDown;

        private KeyCode GetUniversalKeycode(WindowsKeyboardHook.VKeys keySym)
        {
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                // Get C# attribute using reflection of the enum
                var field = code.GetType().GetField(code.ToString());
                
                if (field != null && 
                    field.GetCustomAttributes(typeof(KeyBackendAttribute), false).FirstOrDefault() is KeyBackendAttribute attribute)
                {
                    if (attribute.WindowsKeyCode == keySym)
                    {
                        return code;
                    }
                }
                
            }

            Console.WriteLine("Could not find keycode for " + keySym);
            
            return KeyCode.INVALID_KEYCODE;
        }

        public void SetupBinds()
        {
            if (!Design.IsDesignMode) // Odd behavior occurs when trying to initialize hotkey stuff from design mode. I should really switch to Raw Input at some point, instead of this win32 jank.
            {
                WindowsKeyboardHook.KeyDown += KeyboardHook_KeyDown;
                WindowsKeyboardHook.KeyUp += KeyboardHook_KeyUp;
                mouseHook.KeyDown += KeyboardHook_KeyDown;
                mouseHook.KeyUp += KeyboardHook_KeyUp;
                
                void KeyboardHook_KeyDown(WindowsKeyboardHook.VKeys key)
                {
                    if (!CurrentPressedKeys.Contains(GetUniversalKeycode(key)))
                    {
                        CurrentPressedKeys.Add(GetUniversalKeycode(key));
                        KeyDown.Invoke(this, GetUniversalKeycode(key));
                    }
                }

                void KeyboardHook_KeyUp(WindowsKeyboardHook.VKeys key)
                {
                    CurrentPressedKeys.Remove(GetUniversalKeycode(key));
                    KeyUp.Invoke(this, GetUniversalKeycode(key));
                }

                WindowsKeyboardHook.Install();
                mouseHook.Install();

                KeyUp += (o, k) => { };
                KeyDown += (o, k) => { };
            }
        }

        public void DisposeBinds()
        {
            WindowsKeyboardHook?.Uninstall();
            mouseHook?.Uninstall();
        }
    }
}