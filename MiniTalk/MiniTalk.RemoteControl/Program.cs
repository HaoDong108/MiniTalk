using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniTalk.RemoteControl.SharingEnd;
using MiniTalk.RemoteControl.ControlEnd;

namespace MiniTalk.RemoteControl
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Remote_Assistance());
        }
    }
}
