using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace MiniTalk.RemoteControl.ControlEnd
{
    //收到连接字符串触发
    public class HostFoundEventArgs : EventArgs
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// 是否同意了连接请求
        /// </summary>
        public bool IsCasting { get; set; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string Additionalinfo { get; set; }

        public HostFoundEventArgs(bool isCasting, string connectionString, string errorMes)
        {
            IsCasting = isCasting;
            this.ConnectionString = connectionString;
        }
    }

    public class HostFinder
    {
        public event EventHandler<HostFoundEventArgs> HostFound;
        public event Action<EventArgs> ConnectionTimeOut;

        private UdpClient _udpClient;
        private IPEndPoint _otherEndPoint;//对方终端地址
        bool isTimeOut = true;

        public HostFinder(IPAddress otherIP)
        {
            this._otherEndPoint = new IPEndPoint(otherIP, 29870);
        }

        public void StartFind()
        {
            _udpClient = new UdpClient(29870);
            new Thread(() =>
            {
                Task t = Task.Run(new Action(ReceiverCallBack));
                t.Wait(7000);
                if (isTimeOut&& this.ConnectionTimeOut!=null)
                {
                    this.ConnectionTimeOut.Invoke(new EventArgs());
                }
                _udpClient.Close();
                _udpClient = null;
            })
            { IsBackground = true }.Start();
        }

        private void ReceiverCallBack()
        {
            IPEndPoint end = new IPEndPoint(IPAddress.Any, 45142);
            try
            {
                byte[] data = _udpClient.Receive(ref end);
                string str = Method.RemoveEndStr(Encoding.UTF8.GetString(data), "<~");
                var vals = str.Split('|');
                if (vals.Length != 2)
                {
                    OnHostFound(new HostFoundEventArgs(false, vals[1], "网络异常,请重试!"));
                    this.isTimeOut = false;
                    return;
                }
                bool isCasting = false;
                if (bool.TryParse(vals[0], out isCasting))
                {
                    OnHostFound(new HostFoundEventArgs(isCasting, vals[1], isCasting ? null : "连接请求被拒绝"));
                    this.isTimeOut = false;
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        protected virtual void OnHostFound(HostFoundEventArgs e)
        {
            if(HostFound!=null) HostFound.Invoke(this, e);
        }
    }
}
