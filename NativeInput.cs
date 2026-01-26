
using System;
using System.Runtime.InteropServices;
namespace KeepAwakeApp
{
    public static class NativeInput
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public uint type; // 0 = INPUT_MOUSE, 1 = INPUT_KEYBOARD, 2 = INPUT_HARDWARE
            public MOUSEINPUT mi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;   // dùng cho wheel, XBUTTON
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // Optionally, lấy vị trí chuột hiện tại
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT { public int X; public int Y; }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);

        // Optional: kiểm tra phím/chuột đang được nhấn để tránh click nhầm
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        public const uint INPUT_MOUSE = 0;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const uint MOUSEEVENTF_WHEEL = 0x0800;
        public const uint MOUSEEVENTF_XDOWN = 0x0100;
        public const uint MOUSEEVENTF_XUP = 0x0200;
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;

        // Con lăn: 120 = 1 notch (tick). Dương = scroll lên, âm = scroll xuống.
        public const int WHEEL_DELTA = 120;

    }
}
