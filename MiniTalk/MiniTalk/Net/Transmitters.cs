using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using MiniTalk.Class;
using MiniTalk.Model;

namespace MiniTalk.Net
{
    public static class Transmitters
    {
        const int sendProt_Pub = 2456;
        const int sendProt_Pri = 2157;
        const int mrPort = 1906;
        const int infoPort = 1434;
        const int picmesPort = 13823;

        /// <summary>
        /// 消息发送类
        /// </summary>
        public static class Sender
        {
            static Socket sendSoket_Pub;
            static Socket sendSoket_Pri;

            /// <summary>
            /// 数据包的结束标记，用于分割有效数据
            /// </summary>
            const string EndStr = "<~";                         //发送数据的结束符

            private static bool OnlineRadioIsBeingExecuted { get; set; }

            /// <summary>
            /// 上线请求发送进度事件
            /// </summary>
            public static event Action<int> OnlineRequestScheduleChange;

            /// <summary>
            /// 统计广播发送完毕时触发
            /// </summary>
            public static event Action<EventArgs> GetNumberOver;

            static Sender()
            {
                OnlineRadioIsBeingExecuted = false;
                sendSoket_Pub = Method.Net.GetUdpSocket(new IPEndPoint(IPAddress.Any, sendProt_Pub));
                sendSoket_Pri = Method.Net.GetUdpSocket(new IPEndPoint(IPAddress.Any, sendProt_Pri));
                sendSoket_Pri.SendBufferSize = 51000;
            }

            /// <summary>
            /// 向指定的终端发送信息
            /// </summary>
            /// <param name="sendto">目标主机Point</param>
            /// <param name="message">本次要发送的消息</param>
            public static void SendTo(string ip, string message)
            {
                IPEndPoint end = Method.Net.GetIPEndPoint(ip, mrPort);
                byte[] buff = Encoding.UTF8.GetBytes(Method.Json.GetNetMessageJson(message,false) + EndStr);
                sendSoket_Pri.SendTo(buff, end);
            }

            /// <summary>
            /// 向范围内所有主机发送消息
            /// </summary>
            /// <param name="sendtos">目标主机群ListPoint</param>
            /// <param name="message">本次要发送的消息</param>
            public static void SendTo(string message,bool atAll ,List<UserData> ats=null)
            {
                Task.Run(() =>
                {
                    List<string> ips = new List<string>();
                    if (ats != null && ats.Count>0)
                    {
                        foreach (var item in ats) ips.Add(item.IP);
                    }
                    
                    byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json. GetNetMessageJson(message,atAll,ips) + EndStr);
                    foreach (var item in KeyData.Activity.PublicIPAddress)
                    {
                        if (item.ToString().Equals(KeyData.StaticInfo.MyUser.IP))
                        {
                            continue;
                        }
                        sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(item, mrPort));
                    }
                });
            }

            /// <summary>
            /// 将图片发送到单个节点
            /// </summary>
            /// <param name="ip"></param>
            /// <param name="img"></param>
            public static void SendImgTo(string ip, Image img)
            {
                IPEndPoint end = Method.Net.GetIPEndPoint(ip, picmesPort);
                byte[] imgBuffer = Method.ImageToBytes(img);
                imgBuffer = Method.CompressByteArray(imgBuffer);
                List<byte[]> list = Method.Net. DataFragme(imgBuffer);
                foreach (byte[] sdbuf in list)
                {
                    sendSoket_Pri.SendTo(sdbuf, end);
                    if (sdbuf.Length == 24)
                    {
                        Thread.Sleep(10);
                    }
                }
            }

            /// <summary>
            /// 将图片消息发送到同频道内各个节点
            /// </summary>
            /// <param name="ips"></param>
            /// <param name="img"></param>
            public static void SendImgToAll(Image img)
            {
                byte[] imgBuffer = Method.ImageToBytes(img);
                imgBuffer = Method.CompressByteArray(imgBuffer);
                byte[] lenBuff = BitConverter.GetBytes(imgBuffer.Length);
                List<byte[]> list = Method.Net.DataFragme(imgBuffer);
                Task.Run(() => 
                {
                    foreach (IPAddress ip in KeyData.Activity.PublicIPAddress)
                    {
                        IPEndPoint end = Method.Net.GetIPEndPoint(ip, picmesPort);
                        foreach (byte[] sdbuf in list)
                        {
                            sendSoket_Pub.SendTo(sdbuf, end);
                            if (sdbuf.Length == 24)
                            {
                                Thread.Sleep(5);
                            }
                        }
                    }
                });
            }

            /// <summary>
            /// 发送用户消息
            /// </summary>
            /// <param name="ip"></param>
            public static void SendUserData(string ip)
            {
                byte[] by = Encoding.UTF8.GetBytes(Method.Json.GetNetUserDataJson(true, false) + EndStr);
                IPEndPoint en = new IPEndPoint(IPAddress.Parse(ip), infoPort);
                sendSoket_Pri.SendTo(by, en);
            }


            static bool  flg = true;
            /// <summary>
            /// 发送测试请求到所有频道
            /// </summary>
            public static void SendAllTestInfo()
            {
                string json = Method.Json.GetNetInfoJson()+EndStr;
                byte[] by = Encoding.UTF8.GetBytes(json);
                string[] ipd = KeyData.StaticInfo.MyUser.IP.Split('.');
                
                new Thread(() =>
                {
                    for (int i = 0; i <= 255&&flg; i++)
                    {
                        string ip = ipd[0] + "." + ipd[1] + "." + ipd[2] + "." + i;
                        if (ip.Equals(KeyData.StaticInfo.MyUser.IP)) continue;
                        IPEndPoint end = new IPEndPoint(IPAddress.Parse(ip), infoPort);
                        sendSoket_Pub.SendTo(by, end);
                    }
                    if (GetNumberOver != null) GetNumberOver(new EventArgs());
                })
                { IsBackground = true }.Start();
            }

            /// <summary>
            /// 中断发送测试请求
            /// </summary>
            public static void StopSendAllTest()
            {
                flg = false;
            }

            /// <summary>
            /// 向网段内所有主机发送用户频段信息
            /// </summary>  
            public static void SendChannelAll(bool sendBack = false)
            {
                if (OnlineRadioIsBeingExecuted) return;
                byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json.GetNetUserDataJson(true, sendBack) + EndStr);
                string[] ipd = KeyData.StaticInfo.MyUser.IP.Split('.');
                new Thread(() =>
                {
                    OnlineRadioIsBeingExecuted = true;
                    for (int i = 0; i <= 255; i++)
                    {
                        string ip = ipd[0] + "." + ipd[1] + "." + ipd[2] + "." + i;
                        if (ip.Equals(KeyData.StaticInfo.MyUser.IP))
                        {
                            continue;
                        }
                        try
                        {
                            sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(IPAddress.Parse(ip), infoPort));
                            if(OnlineRequestScheduleChange!=null) OnlineRequestScheduleChange.Invoke(i + 1);
                        }
                        catch (Exception)
                        {
                            OnlineRadioIsBeingExecuted = false;
                            Debug.WriteLine("SendMessage:网络环境出现异常");
                            MessageBox.Show("网络连接异常!请检查网络环境后重试！", "网络异常", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            break;
                        }
                    }
                    OnlineRadioIsBeingExecuted = false;
                })
                { IsBackground = true }.Start();
            }

            /// <summary>
            /// 发送文件信息
            /// </summary>
            public static void SendFileMessage(string ip, string path)
            {
                IPEndPoint endPoint = Method.Net.GetIPEndPoint(ip, mrPort);
                byte[] buff = Encoding.UTF8.GetBytes(Method.Json.GetNetFileDataJson(path) + EndStr);
                sendSoket_Pri.SendTo(buff, endPoint);
            }

            /// <summary>
            /// 发送事件消息
            /// </summary>
            public static void SendEventMessage(string ip, string mes)
            {
                IPEndPoint endPoint = Method.Net.GetIPEndPoint(ip, mrPort);
                string data = Method.Json.GetEventMessageJson(mes);
                byte[] buff = Encoding.UTF8.GetBytes(data + EndStr);
                sendSoket_Pri.SendTo(buff, endPoint);
            }

            /// <summary>
            /// 多播事件消息
            /// </summary>
            /// <param name="mes"></param>
            public static void SendEventMessageToAll(string mes)
            {
                Task.Run(() =>
                {
                    byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json.GetEventMessageJson(mes) + EndStr);
                    foreach (var item in KeyData.Activity.PublicIPAddress)
                    {
                        if (item.ToString().Equals(KeyData.StaticInfo.MyUser.IP))
                        {
                            continue;
                        }
                        sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(item, mrPort));
                    }
                });
            } 

            /// <summary>
            /// 发送文件下载请求
            /// </summary>
            public static void SendFileRequest(string ip, string path, string id, int prot)
            {
                IPEndPoint end = Method.Net.GetIPEndPoint(ip, infoPort);
                byte[] buff = Encoding.UTF8.GetBytes(Method.Json.GetFileRequestJson(path, id, prot) + EndStr);
                sendSoket_Pub.SendTo(buff, end);
            }

            /// <summary>
            /// 发送下载状态信息
            /// </summary>
            public static void SendFileRequestRet(string ip, string sateMes, string id, bool isSucc)
            {
                IPEndPoint end = Method.Net.GetIPEndPoint(ip, infoPort);
                byte[] buff = Encoding.UTF8.GetBytes(Method.Json.GetFileRequestRetJson(sateMes, id, isSucc) + EndStr);
                sendSoket_Pub.SendTo(buff, end);
            }

            /// <summary>
            /// 多播文件消息
            /// </summary>
            /// <param name="path"></param>
            public static void SendFileData(string path)
            {
                Task.Run(() =>
                {
                    byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json.GetNetFileDataJson(path) + EndStr);
                    foreach (var item in KeyData.Activity.PublicIPAddress)
                    {
                        if (item.ToString().Equals(KeyData.StaticInfo.MyUser.IP))
                        {
                            continue;
                        }
                        sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(item,mrPort));
                    }
                });
            }

            /// <summary>
            /// 返回对请求消息的处理结果
            /// </summary>
            /// <param name="screen"></param>
            /// <param name="isSucc"></param>
            public static void SendReturnMes(string ip,bool isSucc,bool isCoon,string added="")
            {
                IPEndPoint end = new IPEndPoint(IPAddress.Parse(ip), infoPort);
                string str = Method.Json. GetRemoteRetJson(added,isSucc,isCoon) + EndStr;
                byte[] buff = Encoding.UTF8.GetBytes(str);
                sendSoket_Pub.SendTo(buff, end);
            }

            /// <summary>
            /// 发送远程协助连接请求
            /// </summary>
            /// <param name="ip"></param>
            /// <param name="isCoon"></param>
            public static void SendRemoteRequest(string ip,bool isCoon)
            {
                string mes = string.Empty;
                IPEndPoint end = Method.Net.GetIPEndPoint(ip, infoPort);
                if (isCoon)
                {
                    mes = string.Format("“{0}”请求控制你的电脑，是否接受?", KeyData.StaticInfo.MyUser.Name);
                }
                else
                {
                    mes = string.Format("“{0}”请求你控制他的电脑，是否接受?", KeyData.StaticInfo.MyUser.Name);
                }
                string jstr = Method.Json. GetRemoteJson(mes, isCoon)+EndStr;
                byte[] buff = Encoding.UTF8.GetBytes(jstr);
                sendSoket_Pri.SendTo(buff,end);
            }

            /// <summary>
            /// 向范围内所有用户发送一条下线消息，用户受到消息后会将其从在线列表中抹除
            /// </summary>
            /// <param name="ips">要发送到的地址群</param>
            public static void CloseSend(List<IPAddress> ips)
            {
                byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json.GetNetUserDataJson(false, false) + EndStr);
                foreach (var item in ips)
                {
                    if (item.ToString().Equals(KeyData.StaticInfo.MyUser.IP))
                    {
                        continue;
                    }
                    sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(item, infoPort));
                }
            }

            /// <summary>
            /// 发送包重发请求
            /// </summary>
            public static void SendRetRan(string ip, string packKey, int packid)
            {
                byte[] sendBuff = Encoding.UTF8.GetBytes(Method.Json.GetRetransmis(packKey, packid) + EndStr);
                sendSoket_Pub.SendTo(sendBuff, Method.Net.GetIPEndPoint(ip, infoPort));
            }

            /// <summary>
            /// 回送单包
            /// </summary>
            /// <param name="ip"></param>
            /// <param name="buff"></param>
            public static void SendPack(string ip, byte[] buff)
            {
                sendSoket_Pub.SendTo(buff, Method.Net.GetIPEndPoint(ip, picmesPort));
            }

            /// <summary>
            /// 单点回送上线消息
            /// </summary>
            /// <param name="ip">指定回送到的ip地址</param>
            public static void ReturnOnlineMessage(IPAddress ip)
            {
                byte[] bytetemp = Encoding.UTF8.GetBytes(Method.Json.GetNetUserDataJson(true, false) + EndStr);
                sendSoket_Pub.SendTo(bytetemp, new IPEndPoint(ip, infoPort));
            }
        }

        /// <summary>
        /// 消息接收类
        /// </summary>
        public class Receiver:IDisposable
        {
            #region 成员参数和事件声明
            private Thread thread1;
            private Thread thread2;
            private Thread thread3;

            private Socket messageSocket;
            private Socket infoSocket;
            private Socket picSocket;


            /// <summary>
            /// 收到用户上下线广播时触发
            /// </summary>
            public event Action<Model.Transmission.NetUserData> UserOnlineAndOfflineEvent;
            /// <summary>
            /// 收到普通消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetMessage> ReceiveUserMessageEvent;
            /// <summary>
            /// 收到文件消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetFileData> ReceiveFileMessageEvent;
            /// <summary>
            /// 收到远程协助请求时触发
            /// </summary>
            public event Action<Model.Transmission.NetRemoteInfo> RemoteAssistanceRequestEvent;
            /// <summary>
            /// 收到远程协助类回送消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetRemoteRetInfo> ReceiveRemoteEchoMessageEvent;
            /// <summary>
            /// 收到文件下载请求消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetFileRequest> FileDownloadRequestReceivedEvent;
            /// <summary>
            /// 收到文件传输回送任务状态信息消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetFileRequestRet> ReceiveFileTransferStatusInformationEvent;
            /// <summary>
            /// 收到事件消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetEventMessage> ReceiveEventMessageEvent;
            /// <summary>
            /// 收到图片信息时触发
            /// </summary>
            public event Action<Model.Transmission.LocalPicMessage> ReceivePictureMessageEvent;
            /// <summary>
            /// 收到包重发请求消息时触发
            /// </summary>
            public event Action<Model.Transmission.NetRetransmis> PacketResendRequestReceivedEvent;
            #endregion

            /// <summary>
            /// 指示该对象是否已被释放
            /// </summary>
            public bool IsDisposes { get; private set; }

            /// <summary>
            /// 指示是否已启动聊天窗口
            /// </summary>
            public bool IsOpenTalk { get; set; }

            Dictionary<string, ImagePack> Buffers = new Dictionary<string, ImagePack>();

            /// <summary>
            /// 消息接受处理模块类
            /// </summary>
            public Receiver()
            {
                this.IsDisposes = false;
                this.IsOpenTalk = false;
                //声明套接字
                messageSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                infoSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                picSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

                //绑定端口
                messageSocket.Bind(new IPEndPoint(IPAddress.Any, mrPort));
                infoSocket.Bind(new IPEndPoint(IPAddress.Any, infoPort));
                picSocket.Bind(new IPEndPoint(IPAddress.Any, picmesPort));

                //实例化消息接收线程
                thread1 = new Thread(ReceiveNetMessage);
                thread1.SetApartmentState(ApartmentState.STA);
                thread2 = new Thread(ReceiveNetUserData);
                thread3 = new Thread(RectivePicMessage);


                //设置线程属性并启动
                thread1.IsBackground = true;
                thread2.IsBackground = true;
                thread3.IsBackground = true;
            }

            /// <summary>
            /// 开始运行消息处理线程
            /// </summary>
            public void StartRead()
            {
                thread1.Start();
                thread2.Start();
                thread3.Start();
            }

            /// <summary>
            /// 停止所有消息线程
            /// </summary>
            private void StopAll()
            {
                this.messageSocket.Close();
                this.infoSocket.Close();
                this.picSocket.Close();
                this.thread1.Abort();
                this.thread2.Abort();
                this.thread3.Abort();
            }

            /// <summary>
            /// 接受用户消息
            /// </summary>
            private void ReceiveNetMessage()
            {
                byte[] bytes = new byte[2048];
                EndPoint endPoint = new IPEndPoint(IPAddress.Any, 44478);
                while (true)
                {
                    try
                    {
                        this.messageSocket.ReceiveFrom(bytes, ref endPoint);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                    
                    IPEndPoint end = endPoint as IPEndPoint;

                    string message = Method.RemoveEndstrString(Encoding.UTF8.GetString(bytes));
                    if (null == message) continue;
                    if (end.Address.ToString().Equals(KeyData.StaticInfo.MyUser.IP)) continue;
                    try
                    {
                        Model.Transmission.NetInfo info = JsonConvert.DeserializeObject<Model.Transmission.NetInfo>(message);
                        switch (info.typeID)
                        {
                            case Model.Transmission.NET_MESSAGEID:
                                Model.Transmission.NetMessage data1 = JsonConvert.DeserializeObject<Model.Transmission.NetMessage>(info.JsonString);
                                data1.isPublic = end.Port == sendProt_Pub;
                                if(this.ReceiveUserMessageEvent!=null) this.ReceiveUserMessageEvent.Invoke(data1);
                                break;
                            case Model.Transmission.NET_EVENTMESSAGE:
                                Model.Transmission.NetEventMessage data2 = JsonConvert.DeserializeObject<Model.Transmission.NetEventMessage>(info.JsonString);
                                data2.isPublic = end.Port == sendProt_Pub;
                                if (this.ReceiveEventMessageEvent != null) this.ReceiveEventMessageEvent.Invoke(data2);
                                break;
                            case Model.Transmission.NET_FILEDATAID:
                                Model.Transmission.NetFileData data = JsonConvert.DeserializeObject<Model.Transmission.NetFileData>(info.JsonString);
                                data.isPublic = end.Port == sendProt_Pub;
                                data.message = "文件:[" + data.filename + "]";
                                if (this.ReceiveFileMessageEvent != null) ReceiveFileMessageEvent.Invoke(data);
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            /// <summary>
            /// 接收各种请求信息
            /// </summary>
            private void ReceiveNetUserData()
            {
                byte[] bytetemp = new byte[1024];
                EndPoint userEndpoint = new IPEndPoint(IPAddress.Any, 0);
                while (true)
                {
                    try
                    {
                        //接收消息
                        infoSocket.ReceiveFrom(bytetemp, ref userEndpoint);
                    }
                    catch (Exception)
                    {
                        break;
                    }
                   
                    IPEndPoint end = userEndpoint as IPEndPoint;

                    string message = Method.RemoveEndstrString(Encoding.UTF8.GetString(bytetemp));
                    if (null == message) continue;
                    if (end.Address.ToString().Equals(KeyData.StaticInfo.MyUser.IP)) continue;
                    try
                    {
                        Model.Transmission.NetInfo info = JsonConvert.DeserializeObject<Model.Transmission.NetInfo>(message);
                        switch (info.typeID)
                        {
                            case Model.Transmission.NET_REMOTEINFOID:
                                Model.Transmission.NetRemoteInfo data2 = JsonConvert.DeserializeObject<Model.Transmission.NetRemoteInfo>(info.JsonString);
                                if(RemoteAssistanceRequestEvent!=null) RemoteAssistanceRequestEvent.Invoke(data2);
                                break;
                            case Model.Transmission.NET_USERDATAID:
                                Model.Transmission.NetUserData data3 = JsonConvert.DeserializeObject<Model.Transmission.NetUserData>(info.JsonString);
                                if(UserOnlineAndOfflineEvent!=null) UserOnlineAndOfflineEvent.Invoke(data3);
                                break;
                            case Model.Transmission.NET_RETURNINFOID:
                                Model.Transmission.NetRemoteRetInfo data4 = JsonConvert.DeserializeObject<Model.Transmission.NetRemoteRetInfo>(info.JsonString);
                                if(ReceiveRemoteEchoMessageEvent!=null) ReceiveRemoteEchoMessageEvent.Invoke(data4);
                                break;
                            case Model.Transmission.NET_FILEREQUEST:
                                Model.Transmission.NetFileRequest data5 = JsonConvert.DeserializeObject<Model.Transmission.NetFileRequest>(info.JsonString);
                                if(FileDownloadRequestReceivedEvent!=null) FileDownloadRequestReceivedEvent.Invoke(data5);
                                break;
                            case Model.Transmission.NET_FILEREQUESTRET:
                                Model.Transmission.NetFileRequestRet data6 = JsonConvert.DeserializeObject<Model.Transmission.NetFileRequestRet>(info.JsonString);
                                if (ReceiveFileTransferStatusInformationEvent != null) ReceiveFileTransferStatusInformationEvent.Invoke(data6);
                                break;
                            case Model.Transmission.NET_RETRANSMIS:
                                Model.Transmission.NetRetransmis data7 = JsonConvert.DeserializeObject<Model.Transmission.NetRetransmis>(info.JsonString);
                                if(PacketResendRequestReceivedEvent!=null) PacketResendRequestReceivedEvent.Invoke(data7);
                                break;
                            case Model.Transmission.NET_INFOID:
                                if (!this.IsOpenTalk) break;
                                Sender.SendUserData(end.Address.ToString());
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
            }

            /// <summary>
            /// 接收图片消息
            /// </summary>
            private void RectivePicMessage()
            {
                try
                {
                    byte[] reBuff = new byte[51000];
                    EndPoint endPoint = new IPEndPoint(IPAddress.Any, 44564);
                    while (true)
                    {
                        this.picSocket.ReceiveFrom(reBuff, ref endPoint);
                        IPEndPoint end = endPoint as IPEndPoint;
                        string senderIP = end.Address.ToString();
                        if (senderIP == KeyData.StaticInfo.MyUser.IP)
                        {
                            continue;
                        }
                        bool isPublic = (end.Port == sendProt_Pub);
                        HeadBuff head = GetHead(reBuff);
                        if (!Buffers.ContainsKey(head.packKey) && head.packid == 0)
                        {
                            ImagePack pack = new ImagePack(head.packKey, head.len, senderIP, isPublic);
                            pack.DownOver += Pack_DownOver;
                            pack.TimeOut += Pack_TimeOut;
                            Buffers.Add(head.packKey, pack);
                        }
                        else
                        {
                            byte[] soures = new byte[head.len];
                            Array.Copy(reBuff, 24, soures, 0, head.len);
                            Buffers[head.packKey].AddPack(head.packid, soures);
                        }
                    }
                }
                catch (Exception)
                { }
            }

            private void Pack_TimeOut(ImagePack sender)
            {
                if (Buffers.ContainsKey(sender.Key))
                {
                    this.Buffers.Remove(sender.Key);
                }
            }

            private void Pack_DownOver(ImagePack sender, byte[] overBuff)
            {
                Model.Transmission.LocalPicMessage mes = new Model.Transmission.LocalPicMessage()
                {
                    imgBuff = overBuff,
                    isPublic = sender.isPublic,
                    senderIP = sender.senderIP,
                    sender = Method.GetUser(sender.senderIP).Name
                };
               if (ReceivePictureMessageEvent!=null)  ReceivePictureMessageEvent.Invoke(mes);
                this.Buffers.Remove(sender.Key);
            }

            /// <summary>
            /// 返回包头信息
            /// </summary>
            /// <param name="buff"></param>
            /// <returns></returns>
            private HeadBuff GetHead(byte[] buff)
            {
                byte[] key = new byte[16];
                byte[] id = new byte[4];
                byte[] len = new byte[4];
                Array.Copy(buff, 0, key, 0, 16);
                Array.Copy(buff, 16, id, 0, 4);
                Array.Copy(buff, 20, len, 0, 4);
                HeadBuff head = new HeadBuff()
                {
                    packKey = Encoding.UTF8.GetString(key),
                    packid = BitConverter.ToInt32(id, 0),
                    len = BitConverter.ToInt32(len, 0)
                };
                return head;
            }

            struct HeadBuff
            {
                public string packKey;
                public int packid;
                public int len;
            }

            public void Dispose()
            {
                this.StopAll();
                this.IsDisposes = true;
            }
        }
    }
}

