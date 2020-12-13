using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTalk.RemoteControl
{
    internal static class Method
    {
        /// <summary>
        /// 去除数据包结束符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveEndStr(string str, string endStr)
        {
            try
            {
                return str.Remove(str.IndexOf(endStr));
            }
            catch (Exception)
            {
                return str;
            }
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        public static void ShowPrompt(string text, int time = 2000, int len = 15)
        {
            PromptDll.TaskWork.ShowPrompt(text, time, len);
        }

        /// <summary>
        /// 返回一个随机数种子
        /// </summary>
        /// <returns></returns>
        public static int GetRandomSeed()
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }


        [DllImport("user32.dll")]
        private static extern IntPtr GetDC(IntPtr ptr);
        [DllImport("gdi32.dll")]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC")]
        private static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        /// <summary>
        /// 获取真实设置的桌面分辨率大小
        /// </summary>
        public static Size GetSystemDpi()
        {
            IntPtr hdc = GetDC(IntPtr.Zero);
            Size size = new Size();
            size.Width = GetDeviceCaps(hdc, 118);
            size.Height = GetDeviceCaps(hdc, 117);
            ReleaseDC(IntPtr.Zero, hdc);
            return size;
        }

        /// <summary>
        /// 模拟拖动窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        public static void FormeMove(IntPtr hwnd)
        {
           ReleaseCapture();
           SendMessage(hwnd, 0x0112, 0xF010 + 0x0002, 0);
        }
    }
}
