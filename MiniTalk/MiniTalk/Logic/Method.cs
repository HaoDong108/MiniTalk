using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Newtonsoft.Json;
using System.Drawing.Imaging;
using System.IO.Compression;
using MiniTalk.Model;
using MiniTalk.Net;

namespace MiniTalk
{
    /// <summary>
    /// 全局公用方法
    /// </summary>
    public static class Method
    {
        public const double GB = 1024 * 1024 * 1024;//GB的B的基数
        public const double MB = 1024 * 1024;       //MB的B的基数
        public const double KB = 1024;              //KB的B的基数

        /// <summary>
        /// 字符串合法性审判
        /// </summary>
        /// <param name="text">用于审判的字符串</param>
        public static bool Audit(string text)
        {
            bool flg = false;
            if (text.Contains("浩东"))
            {
                string[] strs = new string[]
                {
                    "狗","屎","丑","憨","傻","吃翔","矮","猪","死","妈","儿","孙","贱","脸","病","脑",
                    "短","针","挫","煞笔","沙比","啥比","鸡","几把","基","智","障","日","废","肥",
                    "姨","吊","吊小","草","操","二百五","250","便秘","大便","粪","阳痿",
                    "肾虚","沙雕","NM","nm","sb","白痴","笨蛋","犊子"
                };
                foreach (String item in strs)
                {
                    if (text.Contains(item)) flg = true;
                }
                if (text.Contains("s") && text.Contains("b")) flg = true;
                if ((text.Contains("n") && text.Contains("m"))|| (text.Contains("N") && text.Contains("M"))) flg = true;
                return flg;
            }
            return false;
        }

        /// <summary>
        /// 检测目录磁盘剩余大小是否大于指定文件大小
        /// </summary>
        /// <returns>true：磁盘剩余大小大于文件大小  false:小于文件大小</returns>
        public static bool DiskDete(string saveDirectory, long fileSize)
        {
            string diskName = saveDirectory.Substring(0, saveDirectory.IndexOf(':'));
            //如果目标磁盘剩余空间小于文件大小+100Mb则返回false
            if (new DriveInfo(diskName).AvailableFreeSpace <= (fileSize + (1024 * 1024 * 100)))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 模拟拖动窗体
        /// </summary>
        /// <param name="hwnd">窗体句柄</param>
        public static void FormMove(IntPtr hwnd)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(hwnd, 0x0112, 0xF010 + 0x0002, 0);
        }

        /// <summary>
        /// 设置窗体阴影
        /// </summary>
        /// <param name="hwnd"></param>
        public static void FormShadow(Form f)
        {
            if (f.FormBorderStyle != FormBorderStyle.None) return;
            IntPtr hwnd = f.Handle;
            WinAPI.SetClassLong(hwnd,WinAPI. GCL_STYLE, WinAPI.GetClassLong(hwnd, WinAPI.GCL_STYLE) | WinAPI.CS_DropSHADOW); 
        }

        /// <summary>
        /// 判断文件件是否被占用
        /// </summary>
        /// <param name="path">文件路径</param>
        public static bool FileIsUsing(string path)
        {
            FileInfo info = new FileInfo(path);
            FileStream stream = null;
            try
            {
                stream = info.Open(FileMode.Open, FileAccess.Read);
            }
            catch (IOException ex)
            {
                return true;
            }
            stream.Close();
            stream.Dispose();
            return false;
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

        /// <summary>
        /// 返回在线列表所对应IP地址的索引，若无返回-1
        /// </summary>
        /// <param name="ip">ip地址</param>
        public static int GetUserIndex(string ip)
        {
            for (int i = 0; i < KeyData.Activity.UserStruchOnline.Count; i++)
            {
                if (KeyData.Activity.UserStruchOnline[i].IP == ip)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 根据IP地址返回用户对象
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <returns>用户对象</returns>
        public static UserData GetUser(string ip)
        {
            foreach (var item in KeyData.Activity.UserStruchOnline)
            {
                if (item.IP.Equals(ip))
                {
                    return item;
                }
            }

            Debug.WriteLine("没有找到用户："+ip);
            return null;
        }

        /// <summary>
        /// 遍历用户数据表返回所对应IP用户头像
        /// </summary>
        /// <param name="ip">ip地址</param>
        /// <returns>头像图</returns>
        public static Image GetHeadImage(string ip)
        {
            foreach (UserData item in KeyData.Activity.UserStruchOnline)
            {
                if (item.IP.Equals(ip))
                {
                    return item.HeadImage;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取当前屏幕图像
        /// </summary>
        /// <returns></returns>
        public static Bitmap GetScreenImg()
        {
            var size = GetSystemDpi();
            Bitmap bmp = new Bitmap(size.Width, size.Height,PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(Point.Empty, Point.Empty, size);
            g.Dispose();
            return bmp;
        }

        /// <summary>
        /// 获取真实设置的桌面分辨率大小
        /// </summary>
        public static Size GetSystemDpi()
        {
            IntPtr hdc =WinAPI.GetDC(IntPtr.Zero);
            Size size = new Size();
            size.Width = WinAPI.GetDeviceCaps(hdc, 118);
            size.Height = WinAPI.GetDeviceCaps(hdc, 117);
            WinAPI.ReleaseDC(IntPtr.Zero, hdc);
            return size;
        }

        /// <summary>
        /// 指定类型的端口是否已经被使用了
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="istcp">是否为tcp端口，否则为udp端口</param>
        /// <returns>true:已经被占用</returns>
        public static bool PortInUse(int port, bool istcp)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipendpoints = istcp ? properties.GetActiveTcpListeners() : properties.GetActiveUdpListeners();
            foreach (var item in ipendpoints)
            {
                if (item.Port == port)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 去除数据报的结束标记
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <returns></returns>
        public static string RemoveEndstrString(string str)
        {
            if (!str.Contains("<~")) return null;
            int re = str.IndexOf("<~");
            return str.Substring(0, re);
        }

        /// <summary>
        /// 从资源文件中读取一个资源格式("im"+编号)
        /// </summary>
        /// <param name="resFile">文件名，不含后缀</param>
        /// <returns>返回一个资源 读取失败返回NULL</returns>
        public static Image ReadHeadImage(string resName)
        {
            try
            {
                Assembly myAssembly;
                myAssembly = Assembly.GetExecutingAssembly();
                System.Resources.ResourceManager rm = new
                  System.Resources.ResourceManager("MiniTalk.HeadImages", myAssembly);
                return rm.GetObject(resName) as Image;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// 从资源文件获取一个表情
        /// </summary>
        /// <param name="resName">文件名，不含后缀</param>
        /// <returns>返回一个资源 读取失败返回NULL</returns>
        public static Image ReadExpressionImage(string resName)
        {
            try
            {
                Assembly myAssembly;
                myAssembly = Assembly.GetExecutingAssembly();
                System.Resources.ResourceManager rm = new
                  System.Resources.ResourceManager("MiniTalk.ExpressionImages", myAssembly);
                return rm.GetObject(resName) as Image;
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        /// <summary>
        /// 使用图片查看器查看图片
        /// </summary>
        /// <param name="img"></param>
        public static void ShowImage(Image img)
        {
            Image_Show show = new Image_Show();
            show.SetImage(img);
            show.Show();
        }

        /// <summary>
        /// 设置窗体具有鼠标穿透效果
        /// </summary>
        /// <param name="flag">true穿透，false不穿透</param>
        public static void SetPenetrate(IntPtr hand, bool flag = true)
        {
            uint style = WinAPI.GetWindowLong(hand, WinAPI.GWL_EXSTYLE);
            if (flag)
                WinAPI.SetWindowLong(hand, WinAPI.GWL_EXSTYLE, style | WinAPI.WS_EX_TRANSPARENT | WinAPI.WS_EX_LAYERED);
            else
                WinAPI.SetWindowLong(hand, WinAPI.GWL_EXSTYLE, style & ~(WinAPI.WS_EX_TRANSPARENT | WinAPI.WS_EX_LAYERED));
            WinAPI.SetLayeredWindowAttributes(hand, 0, 100, WinAPI.LWA_ALPHA);
        }

        /// <summary>
        /// 图片转字节
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static byte[] ImageToBytes(Image image)
        {
            ImageFormat format = image.RawFormat;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg);
                byte[] buffer = new byte[ms.Length];
                //Image.Save()会改变MemoryStream的Position，需要重新Seek到Begin
                ms.Seek(0, SeekOrigin.Begin);
                ms.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// 字节转图片
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static Image BytesToImage(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream(buffer);
            Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// 设置图片大小
        /// </summary>
        /// <param name="imgToResize">要更改的原图片</param>
        /// <param name="size">要修改的大小</param>
        /// <returns></returns>
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            //获取图片宽度
            int sourceWidth = imgToResize.Width;
            //获取图片高度
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //计算宽度的缩放比例
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //计算高度的缩放比例
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //期望的宽度
            int destWidth = (int)(sourceWidth * nPercent);
            //期望的高度
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //绘制图像
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        /// <summary>
        /// 压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] CompressByteArray(byte[] inputBytes)
        {
            using (MemoryStream outStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(outStream, CompressionMode.Compress, true))
                {
                    zipStream.Write(inputBytes, 0, inputBytes.Length);
                    zipStream.Close(); //很重要，必须关闭，否则无法正确解压
                    return outStream.ToArray();
                }
            }
        }

        /// <summary>
        /// 解压缩字节数组
        /// </summary>
        /// <param name="str"></param>
        public static byte[] DecompressByteArray(byte[] inputBytes)
        {
            using (MemoryStream inputStream = new MemoryStream(inputBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    using (GZipStream zipStream = new GZipStream(inputStream, CompressionMode.Decompress))
                    {
                        zipStream.CopyTo(outStream);
                        zipStream.Close();
                        return outStream.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// 向用户显示提示信息
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <param name="time">持续时间</param>
        /// <param name="len">指定每行的字符上限,如果为"NULL"则默认每行最多为15个字符</param>
        public static void ShowPrompt(string message, int time = 2000, int len = 15)
        {
            PromptDll.TaskWork.ShowPrompt(message, time, len);
        }

        /// <summary>
        /// 将单位为B的字节的大小转换为相应最大单位大小
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string Unit_Conversion(long number)
        {
            if (number >= GB)
            {
                return (number / GB).ToString("f2") + "GB";
            }
            else if (number >= MB && number < GB)
            {
                return (number / MB).ToString("f2") + "MB";
            }
            else if (number >= KB && number < MB)
            {
                return (number / KB).ToString("f2") + "KB";
            }
            else
            {
                return number.ToString() + "B";
            }
        }

        /// <summary>
        /// 数据校验类
        /// </summary>
        public static class CRC8
        {
            private static byte[] CRC8Table = new byte[] {
            0,94,188,226,97,63,221,131,194,156,126,32,163,253,31,65,
            157,195,33,127,252,162,64,30, 95,1,227,189,62,96,130,220,
            35,125,159,193,66,28,254,160,225,191,93,3,128,222,60,98,
            190,224,2,92,223,129,99,61,124,34,192,158,29,67,161,255,
            70,24,250,164,39,121,155,197,132,218,56,102,229,187,89,7,
            219,133,103,57,186,228,6,88,25,71,165,251,120,38,196,154,
            101,59,217,135,4,90,184,230,167,249,27,69,198,152,122,36,
            248,166,68,26,153,199,37,123,58,100,134,216,91,5,231,185,
            140,210,48,110,237,179,81,15,78,16,242,172,47,113,147,205,
            17,79,173,243,112,46,204,146,211,141,111,49,178,236,14,80,
            175,241,19,77,206,144,114,44,109,51,209,143,12,82,176,238,
            50,108,142,208,83,13,239,177,240,174,76,18,145,207,45,115,
            202,148,118,40,171,245,23,73,8,86,180,234,105,55,213,139,
            87,9,235,181,54,104,138,212,149,203, 41,119,244,170,72,22,
            233,183,85,11,136,214,52,106,43,117,151,201,74,20,246,168,
            116,42,200,150,21,75,169,247,182,232,10,84,215,137,107,53 };

            /// <summary>
            /// 返回校验结果字节
            /// </summary>
            /// <returns></returns>
            public static byte CRC(byte[] buffer)
            {
                return CRC(buffer, 0, buffer.Length);
            }

            /// <summary>
            /// 返回数据是否出现错误
            /// </summary>
            /// <param name="buffer"></param>
            /// <returns></returns>
            public static bool DataIsError(byte[] buffer)
            {
                return !(CRC(buffer) == default(byte));
            }

            /// <summary>
            /// 返回校验结果字节
            /// </summary>
            /// <returns></returns>
            public static byte CRC(byte[] buffer, int off, int len)
            {
                byte crc = 0;
                if (buffer == null)
                {
                    throw new ArgumentNullException("buffer");
                }
                if (off < 0 || len < 0 || off + len > buffer.Length)
                {
                    throw new ArgumentOutOfRangeException();
                }

                for (int i = off; i < len; i++)
                {
                    crc = CRC8Table[crc ^ buffer[i]];
                }
                return crc;
            }
        }

        /// <summary>
        /// 网络相关处理类
        /// </summary>
        public static class Net
        {
            static Dictionary<string, byte[][]> dataTemp = new Dictionary<string, byte[][]>(); //存储临时数据包数据，用于重发

            /// <summary>
            /// 获取分片udp数据集合
            /// </summary>
            /// <param name="source">原数据包</param>
            /// <param name="blockSize">块大小</param>
            /// <returns></returns>
            public static List<byte[]> DataFragme(byte[] source, int blockSize = 50000)
            {
                List<byte[]> list = new List<byte[]>();
                string key = DateTime.Now.ToString("yyyyMMddhhmmssff");//单任务唯一标识
                byte[] keyBuff = Encoding.UTF8.GetBytes(key);
                int bls = source.Length / blockSize;
                //计算包个数
                if (source.Length % blockSize != 0)
                {
                    bls++;
                }
                byte[] blocks = BitConverter.GetBytes(bls);
                byte[] id = BitConverter.GetBytes(0);


                //报头序列约定:单任务标识,id,包分组数

                byte[] headBuff = new byte[24];
                keyBuff.CopyTo(headBuff, 0);
                id.CopyTo(headBuff, 16);
                blocks.CopyTo(headBuff, 20);

                list.Add(headBuff);

                if (source.Length < blockSize)
                {
                    id = BitConverter.GetBytes(1);//该包编号
                    byte[] len = BitConverter.GetBytes(source.Length + 1);
                    byte[] overBuff = new byte[source.Length + 25];
                    keyBuff.CopyTo(overBuff, 0);
                    id.CopyTo(overBuff, keyBuff.Length);
                    len.CopyTo(overBuff, keyBuff.Length + id.Length);
                    source.CopyTo(overBuff, 24);
                    byte crc = CRC8.CRC(source);
                    overBuff[overBuff.Length - 1] = crc;
                    list.Add(overBuff);
                    return list;
                }

                //子报头序列约定:单任务标识,id,子包有效数据长度
                int block = 0;
                for (int i = 1; block != source.Length; i++)
                {
                    byte[] bys = source.Take(block + blockSize).Skip(block).ToArray();//当次分块数据
                    block += bys.Length;
                    id = BitConverter.GetBytes(i);//该包编号
                    byte[] len = BitConverter.GetBytes(bys.Length + 1);//包长度
                    byte[] overBuff = new byte[bys.Length + 25];

                    //CRC校验位附加
                    byte crc = CRC8.CRC(bys);
                    byte[] temp = new byte[bys.Length + 1];
                    bys.CopyTo(temp, 0);
                    temp[temp.Length - 1] = crc;
                    bys = temp;

                    keyBuff.CopyTo(overBuff, 0);
                    id.CopyTo(overBuff, keyBuff.Length);
                    len.CopyTo(overBuff, keyBuff.Length + id.Length);
                    bys.CopyTo(overBuff, 24);

                    list.Add(overBuff);
                }
                if (!dataTemp.ContainsKey(key))
                {
                    dataTemp.Add(key, list.ToArray());
                }
                StartWaitRequest(key);
                return list;
            }

            /// <summary>
            /// 开始一个线程等待接收重发申请
            /// </summary>
            /// <param name="key"></param>
            private static void StartWaitRequest(string key)
            {
                Task.Run(() =>
                {
                    Action<Model.Transmission.NetRetransmis> action = new Action<Model.Transmission.NetRetransmis>((obj) =>
                    {
                        if (obj.packKey != key) return;
                        if (!dataTemp.ContainsKey(obj.packKey)) return;
                        if (obj.packid>=dataTemp[obj.packKey].Length)return;

                        Debug.WriteLine(string.Format("重发了一个包,key:{0},id:{1}", key, obj.packid));
                        byte[] by = dataTemp[obj.packKey][obj.packid];
                        Transmitters.Sender.SendPack(obj.senderIP, by);
                    });
                    KeyData.receiver.PacketResendRequestReceivedEvent += action; 
                    Thread.Sleep(5000);
                    KeyData.receiver.PacketResendRequestReceivedEvent -= action;
                    dataTemp.Remove(key);
                    Debug.WriteLine(string.Format("包{0}的重发等待线程结束", key));
                });
            }

            /// <summary>
            /// 返回一个随机可用的端口号
            /// </summary>
            public static int GetRanPort()
            {
                int result = 0;
                Random ran = new Random(GetRandomSeed());
                do
                {
                    result = ran.Next(10000, 60000);
                } while (PortInUse(result, true));

                return result;
            }

            /// <summary>
            /// 返回一个实例化并绑定后后的Tcp套接字,指定端口
            /// </summary>
            /// <returns></returns>
            public static Socket GetTcpSocket(IPEndPoint endPoint)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Bind(endPoint);
                return socket;
            }

            /// <summary>
            /// 返回一个实例化后的Tcp套接字,随机端口
            /// </summary>
            /// <returns></returns>
            public static Socket GetTcpSocket(IPAddress ip)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(ip, GetRanPort());
                socket.Bind(endPoint);
                return socket;
            }

            /// <summary>
            /// 返回一个实例化后的Udp套接字,指定端口
            /// </summary>
            /// <returns></returns>
            public static Socket GetUdpSocket(IPEndPoint endPoint)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.Bind(endPoint);
                return socket;
            }

            /// <summary>
            /// 返回一个实例化后的Udp套接字,随机端口
            /// </summary>
            /// <returns></returns>
            public static Socket GetUdpSocket(IPAddress ip)
            {
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            Label:
                IPEndPoint endPoint = new IPEndPoint(ip, GetRanPort());
                try
                {
                    socket.Bind(endPoint);
                }
                catch (Exception)
                {
                    goto Label;
                }
                return socket;
            }

            /// <summary>
            /// 获得一个终端地址
            /// </summary>
            public static IPEndPoint GetIPEndPoint(string ip, int prot)
            {
                return new IPEndPoint(IPAddress.Parse(ip), prot);
            }

            /// <summary>
            /// 获得一个终端地址
            /// </summary>
            public static IPEndPoint GetIPEndPoint(IPAddress ip, int prot)
            {
                return new IPEndPoint(ip, prot);
            }
        }

        /// <summary>
        /// JsonString处理类
        /// </summary>
        public static class Json
        {
            /// <summary>
            /// 返回基本数据序列化信息
            /// </summary>
            /// <returns></returns>
            public static string GetNetInfoJson()
            {
                Model.Transmission.NetInfo info = new Transmission.NetInfo();
                info.sender= KeyData.StaticInfo.MyUser.Name;
                info.senderIP= KeyData.StaticInfo.MyUser.IP;
                info.typeID = Model.Transmission.NET_INFOID;
                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回序列化后的Json消息文件
            /// </summary>
            /// <param name="message">消息内容</param>
            /// <param name="isPublic">是否为公共消息</param>
            /// <returns>Json文件字符串</returns>
            public static string GetNetMessageJson(string message,bool atAll,List<string> ats=null)
            {
                Model.Transmission.NetMessage mes = new Model.Transmission.NetMessage();
                mes.message = message;
                mes.sender = KeyData.StaticInfo.MyUser.Name;
                mes.senderIP = KeyData.StaticInfo.MyUser.IP;
                mes.ats = ats==null?new List<string>():ats;
                mes.atAll = atAll;
                Model.Transmission.NetInfo info = mes;
                info.typeID = Model.Transmission.NET_MESSAGEID;
                info.JsonString = JsonConvert.SerializeObject(mes);
                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回序列化后的Json远程协助请求数据
            /// </summary>
            public static string GetRemoteJson(string message, bool isCoon)
            {
                Model.Transmission.NetRemoteInfo info = new Model.Transmission.NetRemoteInfo();
                info.sender = KeyData.StaticInfo.MyUser.Name;
                info.senderIP = KeyData.StaticInfo.MyUser.IP;
                info.IsCoon = isCoon;
                info.message = message;
                Model.Transmission.NetInfo nf = info;
                nf.typeID = Model.Transmission.NET_REMOTEINFOID;
                nf.JsonString = JsonConvert.SerializeObject(info);
                return JsonConvert.SerializeObject(nf);
            }

            /// <summary>
            /// 返回序列化后的Json用户数据文件
            /// </summary>
            /// <param name="isOnlineMessage"></param>
            /// <returns></returns>
            public static string GetNetUserDataJson(bool isOnlineMessage, bool sendBackFlag)
            {
                Model.Transmission.NetUserData user = new Model.Transmission.NetUserData();
                user.Channel = KeyData.StaticInfo.MyUser.Channel;
                user.HeadImgID = KeyData.StaticInfo.MyUser.HeadimgName;
                user.senderIP = KeyData.StaticInfo.MyUser.IP;
                user.sender = KeyData.StaticInfo.MyUser.Name;
                user.OnlineData = isOnlineMessage;
                user.forceSendBack = sendBackFlag;
                Model.Transmission.NetInfo info = user;
                info.JsonString = JsonConvert.SerializeObject(user);
                info.typeID = Model.Transmission.NET_USERDATAID;

                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回一个序列化后的Json文件信息
            /// </summary>
            public static string GetNetFileDataJson(string filePath)
            {
                FileInfo finfo = new FileInfo(filePath);
                long filelen = finfo.Length;
                string fileName = System.IO.Path.GetFileName(filePath);
               Model.Transmission.NetFileData fileData = new Model.Transmission.NetFileData();
                fileData.fileLen = filelen.ToString();
                fileData.filename = fileName;
                fileData.senderFilePath = filePath;
                fileData.sender = KeyData.StaticInfo.MyUser.Name;
                fileData.senderIP = KeyData.StaticInfo.MyUser.IP;
                Model.Transmission.NetInfo info = fileData;
                info.typeID = Model.Transmission.NET_FILEDATAID;
                info.JsonString = JsonConvert.SerializeObject(fileData);

                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 远程协助返回消息
            /// </summary>
            /// <param name="message"></param>
            /// <param name="isSucc"></param>
            /// <param name="sendProt"></param>
            /// <returns></returns>
            public static string GetRemoteRetJson(string added,bool isSucc,bool isCoon)
            {
                Model.Transmission.NetRemoteRetInfo ret = new Model.Transmission.NetRemoteRetInfo();
                ret.isSucc = isSucc;
                ret.isCoon = isCoon;
                ret.sender = KeyData.StaticInfo.MyUser.Name;
                ret.senderIP = KeyData.StaticInfo.MyUser.IP;
                ret.added = added;
                Model.Transmission.NetInfo info = ret;
                info.typeID = Model.Transmission.NET_RETURNINFOID;
                info.JsonString = JsonConvert.SerializeObject(ret);

                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 文件下载请求消息
            /// </summary>
            /// <param name="path"></param>
            /// <param name="id"></param>
            /// <returns></returns>
            public static string GetFileRequestJson(string path, string id, int prot)
            {
                Model.Transmission. NetFileRequest f1 = new Model.Transmission.NetFileRequest();
                f1.filePath = path;
                f1.identification = id;
                f1.sender = KeyData.StaticInfo.MyUser.Name;
                f1.senderIP = KeyData.StaticInfo.MyUser.IP;
                f1.conProt = prot;
                Model.Transmission.NetInfo info = f1;
                info.JsonString = JsonConvert.SerializeObject(f1);
                info.typeID = Model.Transmission.NET_FILEREQUEST;
                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回文件下载状态反回信息
            /// </summary>
            /// <param name="staeStr"></param>
            /// <param name="id"></param>
            /// <param name="isSucc"></param>
            /// <returns></returns>
            public static string GetFileRequestRetJson(string staeStr, string id, bool isSucc)
            {
                Model.Transmission.NetFileRequestRet f = new Model.Transmission.NetFileRequestRet();
                f.sender = KeyData.StaticInfo.MyUser.Name;
                f.senderIP = KeyData.StaticInfo.MyUser.IP;
                f.staeMessage = staeStr;
                f.identification = id;
                f.isSucc = isSucc;
                Model.Transmission.NetInfo info = f;
                info.JsonString = JsonConvert.SerializeObject(f);
                info.typeID = Model.Transmission.NET_FILEREQUESTRET;
                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回事件消息Json字符串
            /// </summary>
            /// <returns></returns>
            public static string GetEventMessageJson(string mes)
            {
                Model.Transmission.NetEventMessage f = new Model.Transmission.NetEventMessage();
                f.sender = KeyData.StaticInfo.MyUser.Name;
                f.senderIP = KeyData.StaticInfo.MyUser.IP;
                f.message = mes;
                Model.Transmission.NetInfo info = f;
                info.typeID = Model.Transmission.NET_EVENTMESSAGE;
                info.JsonString = JsonConvert.SerializeObject(f);
                return JsonConvert.SerializeObject(info);
            }

            /// <summary>
            /// 返回包重发申请Json字符串
            /// </summary>
            /// <param name="packKey"></param>
            /// <param name="packid"></param>
            /// <returns></returns>
            public static string GetRetransmis(string packKey, int packid)
            {
                Model.Transmission.NetRetransmis f = new Model.Transmission.NetRetransmis();
                f.sender = KeyData.StaticInfo.MyUser.Name;
                f.senderIP = KeyData.StaticInfo.MyUser.IP;
                f.packid = packid;
                f.packKey = packKey;
                Model.Transmission.NetInfo info = f;
                info.typeID = Model.Transmission.NET_RETRANSMIS;
                info.JsonString = JsonConvert.SerializeObject(f);
                return JsonConvert.SerializeObject(info);
            }
        }
    }
}
