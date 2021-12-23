using GlobalLowLevelHooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Occlusion_Voice_Chat_CrossPlatform.platform;

namespace Occlusion_Voice_Chat_CrossPlatform.keybinds
{
    public enum KeyCode
    {
        INVALID_KEYCODE,
        // Mouse buttons are handled separately on linux, so braille is used as a placeholder.
        [KeyBackend(LinuxKeySym.braille_dots_56, WindowsKeyboardHook.VKeys.LBUTTON)]
        MOUSE1,     // Left mouse button
        [KeyBackend(LinuxKeySym.braille_dots_57, WindowsKeyboardHook.VKeys.RBUTTON)]
        MOUSE2,     // Right mouse button
        [KeyBackend(LinuxKeySym.braille_dots_58, WindowsKeyboardHook.VKeys.MBUTTON)]
        MOUSE3,     // Middle mouse button (three-button mouse)
        [KeyBackend(LinuxKeySym.braille_dots_567, WindowsKeyboardHook.VKeys.XBUTTON1)]
        MOUSE4,    // X1 mouse button
        [KeyBackend(LinuxKeySym.braille_dots_568, WindowsKeyboardHook.VKeys.XBUTTON2)]
        MOUSE5,    // X2 mouse button
        
        [KeyBackend(LinuxKeySym.Cancel, WindowsKeyboardHook.VKeys.CANCEL)]
        CANCEL,      // Control-break processing
        
        //                  0x07   // Undefined
        
        [KeyBackend(LinuxKeySym.BackSpace, WindowsKeyboardHook.VKeys.BACK)]
        BACKSPACE,        // BACKSPACE key
        
        [KeyBackend(LinuxKeySym.Tab, WindowsKeyboardHook.VKeys.TAB)]
        TAB,         // TAB key
        //                  0x0A-0x0B,  // Reserved
        [KeyBackend(LinuxKeySym.Clear, WindowsKeyboardHook.VKeys.CLEAR)]
        CLEAR,       // CLEAR key
        [KeyBackend(LinuxKeySym.Return, WindowsKeyboardHook.VKeys.RETURN)]
        RETURN,      // ENTER key
        //                  0x0E-0x0F, // Undefined
        [KeyBackend(LinuxKeySym.Shift_L, WindowsKeyboardHook.VKeys.SHIFT)]
        SHIFT,       // SHIFT key
        [KeyBackend(LinuxKeySym.Control_L, WindowsKeyboardHook.VKeys.CONTROL)]
        CONTROL,     // CTRL key
        [KeyBackend(LinuxKeySym.Alt_L, WindowsKeyboardHook.VKeys.MENU)]
        MENU,        // ALT key
        [KeyBackend(LinuxKeySym.Pause, WindowsKeyboardHook.VKeys.PAUSE)]
        PAUSE,       // PAUSE key
        [KeyBackend(LinuxKeySym.Caps_Lock, WindowsKeyboardHook.VKeys.CAPITAL)]
        CAPSLOCK,     // CAPS LOCK key
        
        [KeyBackend(LinuxKeySym.Escape, WindowsKeyboardHook.VKeys.ESCAPE)]
        ESCAPE,      // ESC key
        [KeyBackend(LinuxKeySym.space, WindowsKeyboardHook.VKeys.SPACE)]
        SPACE,       // SPACEBAR
        [KeyBackend(LinuxKeySym.PageUp, WindowsKeyboardHook.VKeys.PRIOR)]
        PAGEUP,       // PAGE UP key
        [KeyBackend(LinuxKeySym.PageDown, WindowsKeyboardHook.VKeys.NEXT)]
        PAGEDOWN,        // PAGE DOWN key
        [KeyBackend(LinuxKeySym.End, WindowsKeyboardHook.VKeys.END)]
        END,         // END key
        [KeyBackend(LinuxKeySym.Home, WindowsKeyboardHook.VKeys.HOME)]
        HOME,        // HOME key
        [KeyBackend(LinuxKeySym.Left, WindowsKeyboardHook.VKeys.LEFT)]
        LEFT,        // LEFT ARROW key
        [KeyBackend(LinuxKeySym.Up, WindowsKeyboardHook.VKeys.UP)]
        UP,          // UP ARROW key
        [KeyBackend(LinuxKeySym.Right, WindowsKeyboardHook.VKeys.RIGHT)]
        RIGHT,       // RIGHT ARROW key
        [KeyBackend(LinuxKeySym.Down, WindowsKeyboardHook.VKeys.DOWN)]
        DOWN,        // DOWN ARROW key
        [KeyBackend(LinuxKeySym.Select, WindowsKeyboardHook.VKeys.SELECT)]
        SELECT,      // SELECT key
        [KeyBackend(LinuxKeySym.Print, WindowsKeyboardHook.VKeys.PRINT)]
        PRINT,       // PRINT key
        [KeyBackend(LinuxKeySym.Execute, WindowsKeyboardHook.VKeys.EXECUTE)]
        EXECUTE,     // EXECUTE key
        [KeyBackend(LinuxKeySym.XK_3270_PrintScreen, WindowsKeyboardHook.VKeys.SNAPSHOT)]
        SNAPSHOT,    // PRINT SCREEN key
        [KeyBackend(LinuxKeySym.Insert, WindowsKeyboardHook.VKeys.INSERT)]
        INSERT,      // INS key
        [KeyBackend(LinuxKeySym.Delete, WindowsKeyboardHook.VKeys.DELETE)]
        DELETE,      // DEL key
        [KeyBackend(LinuxKeySym.Help, WindowsKeyboardHook.VKeys.HELP)]
        HELP,        // HELP key
        [KeyBackend(LinuxKeySym.Number_0, WindowsKeyboardHook.VKeys.KEY_0)]
        KEY_0,       // 0 key
        [KeyBackend(LinuxKeySym.Number_1, WindowsKeyboardHook.VKeys.KEY_1)]
        KEY_1,       // 1 key
        [KeyBackend(LinuxKeySym.Number_2, WindowsKeyboardHook.VKeys.KEY_2)]
        KEY_2,       // 2 key
        [KeyBackend(LinuxKeySym.Number_3, WindowsKeyboardHook.VKeys.KEY_3)]
        KEY_3,       // 3 key
        [KeyBackend(LinuxKeySym.Number_4, WindowsKeyboardHook.VKeys.KEY_4)]
        KEY_4,       // 4 key
        [KeyBackend(LinuxKeySym.Number_5, WindowsKeyboardHook.VKeys.KEY_5)]
        KEY_5,       // 5 key
        [KeyBackend(LinuxKeySym.Number_6, WindowsKeyboardHook.VKeys.KEY_6)]
        KEY_6,       // 6 key
        [KeyBackend(LinuxKeySym.Number_7, WindowsKeyboardHook.VKeys.KEY_7)]
        KEY_7,       // 7 key
        [KeyBackend(LinuxKeySym.Number_8, WindowsKeyboardHook.VKeys.KEY_8)]
        KEY_8,       // 8 key
        [KeyBackend(LinuxKeySym.Number_9, WindowsKeyboardHook.VKeys.KEY_9)]
        KEY_9,       // 9 key
        //                  0x3A-0x40, // Undefined
        [KeyBackend(LinuxKeySym.a, WindowsKeyboardHook.VKeys.KEY_A)]
        KEY_A,       // A key
        [KeyBackend(LinuxKeySym.b, WindowsKeyboardHook.VKeys.KEY_B)]
        KEY_B,       // B key
        [KeyBackend(LinuxKeySym.c, WindowsKeyboardHook.VKeys.KEY_C)]
        KEY_C,       // C key
        [KeyBackend(LinuxKeySym.d, WindowsKeyboardHook.VKeys.KEY_D)]
        KEY_D,       // D key
        [KeyBackend(LinuxKeySym.e, WindowsKeyboardHook.VKeys.KEY_E)]
        KEY_E,       // E key
        [KeyBackend(LinuxKeySym.f, WindowsKeyboardHook.VKeys.KEY_F)]
        KEY_F,       // F key
        [KeyBackend(LinuxKeySym.g, WindowsKeyboardHook.VKeys.KEY_G)]
        KEY_G,       // G key
        [KeyBackend(LinuxKeySym.h, WindowsKeyboardHook.VKeys.KEY_H)]
        KEY_H,       // H key
        [KeyBackend(LinuxKeySym.i, WindowsKeyboardHook.VKeys.KEY_I)]
        KEY_I,       // I key
        [KeyBackend(LinuxKeySym.j, WindowsKeyboardHook.VKeys.KEY_J)]
        KEY_J,       // J key
        [KeyBackend(LinuxKeySym.k, WindowsKeyboardHook.VKeys.KEY_K)]
        KEY_K,       // K key
        [KeyBackend(LinuxKeySym.l, WindowsKeyboardHook.VKeys.KEY_L)]
        KEY_L,       // L key
        [KeyBackend(LinuxKeySym.m, WindowsKeyboardHook.VKeys.KEY_M)]
        KEY_M,       // M key
        [KeyBackend(LinuxKeySym.n, WindowsKeyboardHook.VKeys.KEY_N)]
        KEY_N,       // N key
        [KeyBackend(LinuxKeySym.o, WindowsKeyboardHook.VKeys.KEY_O)]
        KEY_O,       // O key
        [KeyBackend(LinuxKeySym.p, WindowsKeyboardHook.VKeys.KEY_P)]
        KEY_P,       // P key
        [KeyBackend(LinuxKeySym.q, WindowsKeyboardHook.VKeys.KEY_Q)]
        KEY_Q,       // Q key
        [KeyBackend(LinuxKeySym.r, WindowsKeyboardHook.VKeys.KEY_R)]
        KEY_R,       // R key
        [KeyBackend(LinuxKeySym.s, WindowsKeyboardHook.VKeys.KEY_S)]
        KEY_S,       // S key
        [KeyBackend(LinuxKeySym.t, WindowsKeyboardHook.VKeys.KEY_T)]
        KEY_T,       // T key
        [KeyBackend(LinuxKeySym.u, WindowsKeyboardHook.VKeys.KEY_U)]
        KEY_U,       // U key
        [KeyBackend(LinuxKeySym.v, WindowsKeyboardHook.VKeys.KEY_V)]
        KEY_V,       // V key
        [KeyBackend(LinuxKeySym.w, WindowsKeyboardHook.VKeys.KEY_W)]
        KEY_W,       // W key
        [KeyBackend(LinuxKeySym.x, WindowsKeyboardHook.VKeys.KEY_X)]
        KEY_X,       // X key
        [KeyBackend(LinuxKeySym.y, WindowsKeyboardHook.VKeys.KEY_Y)]
        KEY_Y,       // Y key
        [KeyBackend(LinuxKeySym.z, WindowsKeyboardHook.VKeys.KEY_Z)]
        KEY_Z,       // Z key
        [KeyBackend(LinuxKeySym.MultiKey, WindowsKeyboardHook.VKeys.LWIN)]
        OEM_KEY_LEFT,        // Left Windows key or other OEM menu key
        [KeyBackend(LinuxKeySym.MultiKey, WindowsKeyboardHook.VKeys.RWIN)]
        OEM_KEY_RIGHT,        // Right Windows key (Natural keyboard)
        [KeyBackend(LinuxKeySym.bracketleft, WindowsKeyboardHook.VKeys.OEM_4)]
        L_BRACKET,
        [KeyBackend(LinuxKeySym.bracketright, WindowsKeyboardHook.VKeys.OEM_6)]
        R_BRACKET,
        [KeyBackend(LinuxKeySym.semicolon, WindowsKeyboardHook.VKeys.OEM_1)]
        SEMICOLON,
        [KeyBackend(LinuxKeySym.apostrophe, WindowsKeyboardHook.VKeys.OEM_7)]
        APOSTROPHE,
        [KeyBackend(LinuxKeySym.grave, WindowsKeyboardHook.VKeys.OEM_3)]
        GRAVE,
        [KeyBackend(LinuxKeySym.comma, WindowsKeyboardHook.VKeys.OEM_COMMA)]
        COMMA,
        [KeyBackend(LinuxKeySym.period, WindowsKeyboardHook.VKeys.OEM_PERIOD)]
        PERIOD,
        [KeyBackend(LinuxKeySym.slash, WindowsKeyboardHook.VKeys.OEM_2)]
        SLASH,
        [KeyBackend(LinuxKeySym.hyphen, WindowsKeyboardHook.VKeys.OEM_MINUS)]
        HYPHEN,
        [KeyBackend(LinuxKeySym.equal, WindowsKeyboardHook.VKeys.OEM_PLUS)]
        EQUAL,
        //                  0x5E, // Reserved
        [KeyBackend(LinuxKeySym.KP_Insert, WindowsKeyboardHook.VKeys.NUMPAD0)]
        NUMPAD0,     // Numeric keypad 0 key
        [KeyBackend(LinuxKeySym.KP_End, WindowsKeyboardHook.VKeys.NUMPAD1)]
        NUMPAD1,     // Numeric keypad 1 key
        [KeyBackend(LinuxKeySym.KP_Down, WindowsKeyboardHook.VKeys.NUMPAD2)]
        NUMPAD2,     // Numeric keypad 2 key
        [KeyBackend(LinuxKeySym.KP_Page_Down, WindowsKeyboardHook.VKeys.NUMPAD3)]
        NUMPAD3,     // Numeric keypad 3 key
        [KeyBackend(LinuxKeySym.KP_Left, WindowsKeyboardHook.VKeys.NUMPAD4)]
        NUMPAD4,     // Numeric keypad 4 key
        [KeyBackend(LinuxKeySym.KP_Begin, WindowsKeyboardHook.VKeys.NUMPAD5)]
        NUMPAD5,     // Numeric keypad 5 key
        [KeyBackend(LinuxKeySym.KP_Right, WindowsKeyboardHook.VKeys.NUMPAD6)]
        NUMPAD6,     // Numeric keypad 6 key
        [KeyBackend(LinuxKeySym.KP_Home, WindowsKeyboardHook.VKeys.NUMPAD7)]
        NUMPAD7,     // Numeric keypad 7 key
        [KeyBackend(LinuxKeySym.KP_Up, WindowsKeyboardHook.VKeys.NUMPAD8)]
        NUMPAD8,     // Numeric keypad 8 key
        [KeyBackend(LinuxKeySym.KP_Page_Up, WindowsKeyboardHook.VKeys.NUMPAD9)]
        NUMPAD9,     // Numeric keypad 9 key
        [KeyBackend(LinuxKeySym.KP_Multiply, WindowsKeyboardHook.VKeys.MULTIPLY)]
        MULTIPLY,    // Multiply key
        [KeyBackend(LinuxKeySym.KP_Add, WindowsKeyboardHook.VKeys.ADD)]
        ADD,         // Add key
        [KeyBackend(LinuxKeySym.KP_Separator, WindowsKeyboardHook.VKeys.SEPARATOR)]
        SEPARATOR,   // Separator key
        [KeyBackend(LinuxKeySym.KP_Subtract, WindowsKeyboardHook.VKeys.SUBTRACT)]
        SUBTRACT,    // Subtract key
        [KeyBackend(LinuxKeySym.KP_Decimal, WindowsKeyboardHook.VKeys.DECIMAL)]
        DECIMAL,     // Decimal key
        [KeyBackend(LinuxKeySym.KP_Divide, WindowsKeyboardHook.VKeys.DIVIDE)]
        DIVIDE,      // Divide key
        [KeyBackend(LinuxKeySym.F1, WindowsKeyboardHook.VKeys.F1)]
        F1,          // F1 key
        [KeyBackend(LinuxKeySym.F2, WindowsKeyboardHook.VKeys.F2)]
        F2,          // F2 key
        [KeyBackend(LinuxKeySym.F3, WindowsKeyboardHook.VKeys.F3)]
        F3,          // F3 key
        [KeyBackend(LinuxKeySym.F4, WindowsKeyboardHook.VKeys.F4)]
        F4,          // F4 key
        [KeyBackend(LinuxKeySym.F5, WindowsKeyboardHook.VKeys.F5)]
        F5,          // F5 key
        [KeyBackend(LinuxKeySym.F6, WindowsKeyboardHook.VKeys.F6)]
        F6,          // F6 key
        [KeyBackend(LinuxKeySym.F7, WindowsKeyboardHook.VKeys.F7)]
        F7,          // F7 key
        [KeyBackend(LinuxKeySym.F8, WindowsKeyboardHook.VKeys.F8)]
        F8,          // F8 key
        [KeyBackend(LinuxKeySym.F9, WindowsKeyboardHook.VKeys.F9)]
        F9,          // F9 key
        [KeyBackend(LinuxKeySym.F10, WindowsKeyboardHook.VKeys.F10)]
        F10,         // F10 key
        [KeyBackend(LinuxKeySym.F11, WindowsKeyboardHook.VKeys.F11)]
        F11,         // F11 key
        [KeyBackend(LinuxKeySym.F12, WindowsKeyboardHook.VKeys.F12)]
        F12,         // F12 key
        [KeyBackend(LinuxKeySym.F13, WindowsKeyboardHook.VKeys.F13)]
        F13,         // F13 key
        [KeyBackend(LinuxKeySym.F14, WindowsKeyboardHook.VKeys.F14)]
        F14,         // F14 key
        [KeyBackend(LinuxKeySym.F15, WindowsKeyboardHook.VKeys.F15)]
        F15,         // F15 key
        [KeyBackend(LinuxKeySym.F16, WindowsKeyboardHook.VKeys.F16)]
        F16,         // F16 key
        [KeyBackend(LinuxKeySym.F17, WindowsKeyboardHook.VKeys.F17)]
        F17,         // F17 key  
        [KeyBackend(LinuxKeySym.F18, WindowsKeyboardHook.VKeys.F18)]
        F18,         // F18 key  
        [KeyBackend(LinuxKeySym.F19, WindowsKeyboardHook.VKeys.F19)]
        F19,         // F19 key  
        [KeyBackend(LinuxKeySym.F20, WindowsKeyboardHook.VKeys.F20)]
        F20,         // F20 key  
        [KeyBackend(LinuxKeySym.F21, WindowsKeyboardHook.VKeys.F21)]
        F21,         // F21 key  
        [KeyBackend(LinuxKeySym.F22, WindowsKeyboardHook.VKeys.F22)]
        F22,         // F22 key, (PPC only) Key used to lock device.
        [KeyBackend(LinuxKeySym.F23, WindowsKeyboardHook.VKeys.F23)]
        F23,         // F23 key  
        [KeyBackend(LinuxKeySym.F24, WindowsKeyboardHook.VKeys.F24)]
        F24,         // F24 key  
        //                  0x88-0X8F,  // Unassigned
        [KeyBackend(LinuxKeySym.NumLock, WindowsKeyboardHook.VKeys.NUMLOCK)]
        NUMLOCK,     // NUM LOCK key
        [KeyBackend(LinuxKeySym.ScrollLock, WindowsKeyboardHook.VKeys.SCROLL)]
        SCROLL,      // SCROLL LOCK key
        //                  0x92-0x96,  // OEM specific
        //                  0x97-0x9F,  // Unassigned
        [KeyBackend(LinuxKeySym.Shift_L, WindowsKeyboardHook.VKeys.LSHIFT)]
        LSHIFT,      // Left SHIFT key
        [KeyBackend(LinuxKeySym.Shift_R, WindowsKeyboardHook.VKeys.RSHIFT)]
        RSHIFT,      // Right SHIFT key
        [KeyBackend(LinuxKeySym.Control_L, WindowsKeyboardHook.VKeys.LCONTROL)]
        LCONTROL,    // Left CONTROL key
        [KeyBackend(LinuxKeySym.Control_R, WindowsKeyboardHook.VKeys.RCONTROL)]
        RCONTROL,    // Right CONTROL key
        [KeyBackend(LinuxKeySym.Alt_L, WindowsKeyboardHook.VKeys.LMENU)]
        LEFTALT,       // Left MENU key
        [KeyBackend(LinuxKeySym.Alt_R, WindowsKeyboardHook.VKeys.RMENU)]
        RIGHTALT,       // Right MENU key
        [KeyBackend(LinuxKeySym.XK_3270_Play, WindowsKeyboardHook.VKeys.PLAY)]
        PLAY,        // Play key
    }
    
}
