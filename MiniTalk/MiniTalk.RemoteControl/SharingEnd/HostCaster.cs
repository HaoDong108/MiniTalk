using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniTalk.RemoteControl.SharingEnd
{
    public class HostCaster
    {
        struct ConString
        {
            public string conString;
            public bool _isCasting;
        }

        private UdpClient _udpClient = new UdpClient();
        private IPEndPoint _endPoint;//对方接受地址
        private CancellationTokenSource source;

        public HostCaster(IPAddress ip)
        {
            if (ip ==null)
            {
                throw new ArgumentNullException("终结点地址为空");
            }
            _endPoint = new IPEndPoint(ip,29870);
        }

        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="buffs"></param>
        private void SendString(ConString buffs)
        {
            string sen = string.Format("{0}|{1}<~", buffs._isCasting, buffs.conString);
            byte[] buff = Encoding.UTF8.GetBytes(sen);
            _udpClient.Send(buff, buff.Length, _endPoint);
        }

        /// <summary>
        /// 发送一个连接字符串表示连接开始
        /// </summary>
        /// <param name="connStr"></param>
        public void StartCast(string connStr)
        {
            ConString con = new ConString();
            con.conString = connStr;
            con._isCasting = true;
            this.source = new CancellationTokenSource();
            Task.Run(() =>
            {
                while (!this.source.IsCancellationRequested)
                {
                    SendString(con);
                    Thread.Sleep(5000);
                }
                Debug.WriteLine("请求消息发送线程已经取消");
            },this.source.Token);
        }

        /// <summary>
        /// 终止发送线程
        /// </summary>
        public void KillSendTask()
        {
            this.source.Cancel();
        }

        /// <summary>
        /// 发送停止标识符代表连接的结束
        /// </summary>
        public void StopCast()
        {
            ConString con = new ConString();
            con._isCasting = false;
            con.conString = "Stopped";
            SendString(con);
        }
    }
}
