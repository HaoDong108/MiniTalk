using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniTalk
{
    public static class WinAPI
    {
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public const int CS_DropSHADOW = 0x20000;
        public const int GCL_STYLE = (-26);

        public const uint WS_EX_LAYERED = 0x80000;
        public const int WS_EX_TRANSPARENT = 0x20;
        public const int GWL_STYLE = (-16);
        public const int GWL_EXSTYLE = (-20);
        public const int LWA_ALPHA = 0;

        public const int WS_HSCROLL = 0x100000;
        public const int WS_VSCROLL = 0x200000;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        };

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(
         string deviceName, int modeNum, ref DEVMODE devMode);
        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(
           ref DEVMODE devMode, int flags);
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfoA")]
        public static extern Int32 SystemParametersInfo(int uAction, int uParam, StringBuilder lpvParam, int fuWinIni);//////lpvParam要设置成string
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(int vKey);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);


        [DllImport("user32", EntryPoint = "SetWindowLong")]
        public static extern uint SetWindowLong(
        IntPtr hwnd,
        int nIndex,
        uint dwNewLong
        );

        [DllImport("user32", EntryPoint = "GetWindowLong")]
        public static extern uint GetWindowLong(
        IntPtr hwnd,
        int nIndex
        );

        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        public static extern int SetLayeredWindowAttributes(
        IntPtr hwnd,
        int crKey,
        int bAlpha,
        int dwFlags
        );

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr GetActiveWindow();//获得当前活动窗体         

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern IntPtr SetActiveWindow(IntPtr hwnd);//设置活动窗体

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, string lParam);
    }
}
