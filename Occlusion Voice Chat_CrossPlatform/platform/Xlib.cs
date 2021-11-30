using System;
using System.Runtime.InteropServices;
using X11;
using Status = Avalonia.X11.Status;

namespace Occlusion_Voice_Chat_CrossPlatform.platform
{
    public static class Xlib
    {
        public const string X11Import = "libX11.so.6";
        
        [DllImport(X11Import)]
        public static extern IntPtr XOpenDisplay(string display_name);

        [DllImport(X11Import)]
        public static extern Status XNextEvent(IntPtr display, IntPtr event_return);
        
        [DllImport(X11Import)]
        public static extern Status XGrabKey(IntPtr display, int keycode, KeyButtonMask modifiers, Window grab_window, 
            bool owner_events, GrabMode pointer_mode, GrabMode keyboard_mode);
        
        
        [DllImport(X11Import)]
        public static extern Status XChangeWindowAttributes(IntPtr display, Window w, SetWindowValuemask value_mask, ref XSetWindowAttributes attributes);
        
        [DllImport(X11Import)]
        public static extern void XQueryKeymap(IntPtr display, byte[] keys_return);
        
        [DllImport(X11Import)]
        public static extern bool XQueryPointer(IntPtr display, Window w, out Window root_return, out Window child_return, out int root_x_return, out int root_y_return, out int win_x_return, out int win_y_return, out uint mask_return);
        
        [DllImport(X11Import)]
        public static extern Status XGetKeyboardMapping(IntPtr display, byte first_keycode, int keycode_count, out int keysyms_per_keycode_return);
        
        [DllImport(X11Import)]
        public static extern Status XDisplayKeycodes(IntPtr display, out int min_keycode_return, out int max_keycode_return);
        
    }

    [Flags]
    public enum SetWindowValuemask
    {
        BackPixmap = (1 << 0),
        BackPixel = (1 << 1),
        BorderPixmap = (1 << 2),
        BorderPixel = (1 << 3),
        BitGravity = (1 << 4),
        WinGravity = (1 << 5),
        BackingStore = (1 << 6),
        BackingPlanes = (1 << 7),
        BackingPixel = (1 << 8),
        SaveUnder = (1 << 9),
        EventMask = (1 << 10),
        DoNotPropagate = (1 << 11),
        OverrideRedirect = (1 << 12),
        Colormap = (1 << 13),
        Cursor = (1 << 14)
    }
    
}