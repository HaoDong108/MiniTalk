using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Drawing;
using System.Net;
using MiniTalk.RemoteControl.ControlEnd;
using MiniTalk.RemoteControl.SharingEnd;
using System.Windows.Forms;

namespace MiniTalk.RemoteControl
{
    public static class Entrance
    {
        /// <summary>
        /// 当前是否已经受控
        /// </summary>
        public static bool ConStae { get; private set; }

        /// <summary>
        /// 被控模式
        /// </summary>
        /// <param name="otherIP">控制方IP地址</param>
        public static void Controlled(IPAddress otherIP,string otherName)
        {
            try
            {
                MainForm form = new MainForm(otherIP, otherName);
                ConStae = true;
                Application.Run(form);
            }
            catch (Exception ex)
            {
                ConStae = false;
                MessageBox.Show(
                    "远程协助模块出现一个异常:\n" +
                    "异常信息:\n" + ex.Message,"意外的错误"
                    ,MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            finally
            {
                ConStae = false;
            }
        }

        /// <summary>
        /// 主控模式
        /// </summary>
        /// <param name="userip">共享方IP地址</param>
        public static void Control(IPAddress userip,string userName)
        {
            Remote_Assistance form = new Remote_Assistance(userip,userName);
            Application.Run(form);
        }

        static Entrance()
        {
            ConStae = false;
        }
    }
}
