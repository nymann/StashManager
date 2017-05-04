using System.Runtime.InteropServices;

namespace StashManager.Helper
{
    public class Keyboard
    {
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        public bool IsKeyPressed(int nVirtKey)
        {
            int state = GetKeyState(nVirtKey);
            return state == -127 || state == -128;
        }

        [DllImport("user32.dll")]
        public static extern void keybd_event(VirtualKeys key, byte bScan, KeyboardEventFlags eventFlag, int dwExtraInfo);

    }
}