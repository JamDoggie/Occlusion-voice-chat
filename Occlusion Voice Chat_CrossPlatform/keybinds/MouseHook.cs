﻿using System;
using System.Runtime.InteropServices;
using System.Diagnostics;
using static GlobalLowLevelHooks.WindowsKeyboardHook;

namespace GlobalLowLevelHooks
{
    /// <summary>
    /// Class for intercepting low level Windows mouse hooks.
    /// </summary>
    public class MouseHook
    {
        /// <summary>
        /// Internal callback processing function
        /// </summary>
        private delegate IntPtr MouseHookHandler(int nCode, IntPtr wParam, IntPtr lParam);
        private MouseHookHandler hookHandler;

        /// <summary>
        /// Function to be called when defined even occurs
        /// </summary>
        /// <param name="mouseStruct">MSLLHOOKSTRUCT mouse structure</param>
        public delegate void MouseHookCallback(VKeys key);

        #region Events
        public event MouseHookCallback KeyDown;
        public event MouseHookCallback KeyUp;
        #endregion

        /// <summary>
        /// Low level mouse hook's ID
        /// </summary>
        private IntPtr hookID = IntPtr.Zero;

        /// <summary>
        /// Install low level mouse hook
        /// </summary>
        /// <param name="mouseHookCallbackFunc">Callback function</param>
        public void Install()
        {
            hookHandler = HookFunc;
            hookID = SetHook(hookHandler);
        }

        /// <summary>
        /// Remove low level mouse hook
        /// </summary>
        public void Uninstall()
        {
            if (hookID == IntPtr.Zero)
                return;

            UnhookWindowsHookEx(hookID);
            hookID = IntPtr.Zero;
        }

        /// <summary>
        /// Destructor. Unhook current hook
        /// </summary>
        ~MouseHook()
        {
            Uninstall();
        }

        /// <summary>
        /// Sets hook and assigns its ID for tracking
        /// </summary>
        /// <param name="proc">Internal callback function</param>
        /// <returns>Hook ID</returns>
        private IntPtr SetHook(MouseHookHandler proc)
        {
            using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(module.ModuleName), 0);
        }

        /// <summary>
        /// Callback function
        /// </summary>
        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            // parse system messages
            if (nCode >= 0)
            {
                MSLLHOOKSTRUCT mouseStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));


                // Left Button
                if (KeyDown != null)
                    if (MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                        KeyDown(VKeys.LBUTTON);

                if (KeyUp != null)
                    if (MouseMessages.WM_LBUTTONUP == (MouseMessages)wParam)
                        KeyUp(VKeys.LBUTTON);

                // Right Button
                if (KeyDown != null)
                    if (MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
                        KeyDown(VKeys.RBUTTON);

                if (KeyUp != null)
                    if (MouseMessages.WM_RBUTTONUP == (MouseMessages)wParam)
                        KeyUp(VKeys.RBUTTON);

                // Middle Button
                if (KeyDown != null)
                    if (MouseMessages.WM_MBUTTONDOWN == (MouseMessages)wParam)
                        KeyDown(VKeys.MBUTTON);

                if (KeyUp != null)
                    if (MouseMessages.WM_MBUTTONUP == (MouseMessages)wParam)
                        KeyUp(VKeys.MBUTTON);

                // This tells us, if we're hitting an extra mouse button, whether it's Mouse4 or Mouse5
                var mouseInf = mouseStruct.mouseData >> 16;

                // X Button (Mouse 4 & Mouse 5)
                if (KeyDown != null)
                    if (MouseMessages.WM_XBUTTONDOWN == (MouseMessages)wParam)
                    {
                        KeyDown(mouseInf == 1 ? VKeys.XBUTTON1 : VKeys.XBUTTON2);
                    }

                if (KeyUp != null)
                    if (MouseMessages.WM_XBUTTONUP == (MouseMessages)wParam)
                    {
                        KeyUp(mouseInf == 1 ? VKeys.XBUTTON1 : VKeys.XBUTTON2);
                    }
            }
            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        #region WinAPI
        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_XBUTTONDOWN = 0x020b,
            WM_XBUTTONUP = 0x020c
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            MouseHookHandler lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion
    }
}
