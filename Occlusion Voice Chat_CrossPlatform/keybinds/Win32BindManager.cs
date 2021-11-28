using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using OcclusionShared.Util;

namespace GlobalLowLevelHooks
{
    public class Win32BindManager : BindManager
    {
        public object PressedKeyLock { get; } = new object();

        public List<UniversalKey> CurrentPressedKeys { get; set; } = new();

        public KeyboardHook keyboardHook = new KeyboardHook();

        public MouseHook mouseHook = new MouseHook();

        private List<UniversalKey> _keyCodes = new();
        
        // Events
        public event EventHandler<UniversalKey>? KeyUp;
        public event EventHandler<UniversalKey>? KeyDown;

        public Win32BindManager()
        {
            // Create list of platform-agnostic keys
            foreach(KeyboardHook.VKeys key in Enum.GetValues(typeof(KeyboardHook.VKeys)))
            {
                _keyCodes.Add(new UniversalKey(key.ToString()));
            }
        }

        public void SetupBinds()
        {
            if (!Design.IsDesignMode) // Odd behavior occurs when trying to initialize hotkey stuff from design mode. I should really switch to Raw Input at some point, instead of this win32 jank.
            {
                keyboardHook.KeyDown += KeyboardHook_KeyDown;
                keyboardHook.KeyUp += KeyboardHook_KeyUp;
                mouseHook.KeyDown += KeyboardHook_KeyDown;
                mouseHook.KeyUp += KeyboardHook_KeyUp;
                
                void KeyboardHook_KeyDown(KeyboardHook.VKeys key)
                {
                    if (!CurrentPressedKeys.Contains(GetKey(key)))
                    {
                        CurrentPressedKeys.Add(GetKey(key));
                        KeyDown.Invoke(this, GetKey(key));
                    }
                }

                void KeyboardHook_KeyUp(KeyboardHook.VKeys key)
                {
                    CurrentPressedKeys.Remove(GetKey(key));
                    KeyUp.Invoke(this, GetKey(key));
                }

                keyboardHook.Install();
                mouseHook.Install();

                KeyUp += (o, k) => { };
                KeyDown += (o, k) => { };
            }
        }

        public void DisposeBinds()
        {
            keyboardHook?.Uninstall();
            mouseHook?.Uninstall();
        }

        public UniversalKey GetKey(KeyboardHook.VKeys key)
        {
            return _keyCodes.Find(k => k.KeyName == key.ToString());
        }
    }
}