using System.Runtime.InteropServices;

namespace OcclusionAutoUpdater;

public static class MacOSFunctions
{
    [DllImport("/usr/lib/libSystem.dylib", SetLastError = true)]
    public static extern int chmod(string pathname, int mode);
}