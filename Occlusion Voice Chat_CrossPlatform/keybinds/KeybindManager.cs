using System;
using System.Runtime.InteropServices;

namespace GlobalLowLevelHooks
{
    public class KeybindManager : IDisposable
    {
        public BindManager? CurrentBindManager { get; private set; }

        public KeybindManager()
        {
            // We use the win32 manager to hook onto key binds for now.
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                CurrentBindManager = new Win32BindManager();
            }
            
            
            // On Linux, we use X11 to query the keyboard and get key binds that way.
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                CurrentBindManager = new LinuxBindManager();
            }
            
            // If we've made it this far and CurrentBindManager is null, this operating system does not support key binds and will reflect that in the GUI.
        }
        
        public void EnableKeybinds()
        {
            CurrentBindManager?.SetupBinds();
        }

        public void Dispose()
        {
            CurrentBindManager?.DisposeBinds();
        }
        
        ~KeybindManager()
        {
            Dispose();
        }
    }
}