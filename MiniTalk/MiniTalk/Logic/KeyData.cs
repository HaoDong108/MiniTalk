using MiniTalk.Net;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using MiniTalk.Class;
using MiniTalk.Model;

namespace MiniTalk
{
    /// <summary>
    /// 全局关键数据
    /// </summary>
    public static class KeyData
    {
        /// <summary>
        /// 本地静态数据
        /// </summary>
        public static class StaticInfo
        {
            /// <summary>
            /// 本地用户信息
            /// </summary>
            public static UserData MyUser = null;

            /// <summary>
            /// 公共会话的会话窗口控件
            /// </summary>
            public static TalkPanel ClassPanel = null;
        }

        /// <summary>
        /// 程序在运行过程中必要的参数属性
        /// </summary>
        public static class Activity
        {
            private static UserData _nowUser;
            /// <summary>
            /// 频段内用户所有用户的地址池
            /// </summary>
            public static List<IPAddress> PublicIPAddress = new List<IPAddress>();


            /// <summary>
            /// 在线用户实例
            /// </summary>
            public static List<UserData> UserStruchOnline { get; private set; } 

            static Activity()
            {
                UserStruchOnline = new List<UserData>();
            }
        }
        /// <summary>
        /// 主窗体
        /// </summary>
        public static Form1 form1;     //主会话窗口

        public static Transmitters.Receiver receiver = new Transmitters.Receiver();
    }
}
