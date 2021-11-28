using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Avalonia.Input;
using OcclusionShared.Util;

namespace GlobalLowLevelHooks
{
    public interface BindManager
    {
        public object PressedKeyLock { get; }
        
        List<UniversalKey> CurrentPressedKeys { get; set; }

        event EventHandler<UniversalKey> KeyDown;
        
        event EventHandler<UniversalKey> KeyUp;
        
        void SetupBinds();
        
        /// <summary>
        /// IMPORTANT: This method is called by the <see cref="BindManager"/> class. Do not call it directly.
        /// </summary>
        void DisposeBinds();
    }
}