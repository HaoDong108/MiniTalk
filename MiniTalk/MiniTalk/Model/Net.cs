using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTalk.Model
{
    /// <summary>
    /// 网络传输类
    /// </summary>
    public static class Transmission
    {
        public const int NET_INFOID = 0;
        public const int NET_FILEDATAID = 1;
        public const int NET_MESSAGEID = 2;
        public const int NET_REMOTEINFOID = 3;
        public const int NET_RETURNINFOID = 4;
        public const int NET_USERDATAID = 5;
        public const int NET_FILEREQUEST = 6;
        public const int NET_FILEREQUESTRET = 7;
        public const int NET_EVENTMESSAGE = 8;
        public const int NET_RETRANSMIS = 9;
        public const int NET_TESTINFOID = 10;


        public enum MesType
        {
           图片消息,
           文本消息,
           文件消息,
           事件消息
        }

        public interface IMessage
        {
            bool isPublic { get; set; }
            string senderIP { get; set; }
            string sender { get; set; }
            string message { get; set; }
            MesType mesType { get; }
        }

        /// <summary>
        /// 网络消息类的基类
        /// </summary>
        public class NetInfo
        { 
            /// <summary>
            /// 发送者昵称
            /// </summary>
            public virtual string sender { get; set; }
            /// <summary>
            /// 发送者IP
            /// </summary>
            public virtual string senderIP { get; set; }

            /// <summary>
            /// 标识的类型ID
            /// </summary>
            public int typeID { get; set; }

            /// <summary>
            /// 具体Json字符串
            /// </summary>
            public string JsonString { get; set; }
            
        }

        /// <summary>
        /// 文件消息类
        /// </summary>
        public class NetFileData : NetInfo,IMessage
        {
            /// <summary>
            /// 文件大小(字节)
            /// </summary>
            public string fileLen { get; set; }
            /// <summary>
            /// 文件名
            /// </summary>
            public string filename { get; set; }
            /// <summary>
            /// 发送者的文件路径
            /// </summary>
            public string senderFilePath { get; set; }
            /// <summary>
            /// 是否为公共会话频道消息
            /// </summary>
            public bool isPublic { get; set; }
            /// <summary>
            /// 消息类型
            /// </summary>
            public MesType mesType { get; private set; } 

            public override string sender { get; set; }
            public override string senderIP { get; set; }
            public string message { get; set; }

            public NetFileData()
            {
                mesType = MesType.文件消息;
                message = "文件:[" + filename + "]";
            }
        }

        /// <summary>
        /// 消息类
        /// </summary>
        public class NetMessage : NetInfo,IMessage
        {
            /// <summary>
            /// 消息类型,标识是否为公共消息
            /// </summary>
            public bool isPublic { get; set; }
            /// <summary>
            /// 消息内容
            /// </summary>
            public string message { get; set; }

            /// <summary>
            /// 当前消息At的IP集合
            /// </summary>
            public List<string> ats { get; set; }

            /// <summary>
            /// 是否at了全体成员
            /// </summary>
            public bool atAll { get; set; }

            /// <summary>
            /// 消息类型
            /// </summary>
            public MesType mesType { get; private set; } 

            public override string sender { get; set; }
            public override string senderIP { get; set; }

            

           public NetMessage()
            {
                mesType=MesType.文本消息;
            }
        }

        /// <summary>
        /// 图片消息类
        /// </summary>
        public class LocalPicMessage : IMessage
        {
            /// <summary>
            /// 发送者
            /// </summary>
            public string sender { get; set; }
            /// <summary>
            /// 发送者IP
            /// </summary>
            public string senderIP { get; set; }
            /// <summary>
            /// 是否为公共消息
            /// </summary>
            public bool isPublic { get; set; }
            /// <summary>
            /// 图片数据包
            /// </summary>
            public byte[] imgBuff { get; set; }
            /// <summary>
            /// 消息类型
            /// </summary>
            public MesType mesType { get; private set; }
            public string message { get; set; }

            public LocalPicMessage()
            {
                mesType = MesType.图片消息;
                message = "[图片]";
            }
        }

        /// <summary>
        /// 事件消息类
        /// </summary>
        public class NetEventMessage : NetInfo, IMessage
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }
            /// <summary>
            /// 消息类型
            /// </summary>
            public MesType mesType { get; private set; }
            /// <summary>
            /// 标识是否将其插入公共聊天窗口
            /// </summary>
            public bool isPublic { get; set; }
            /// <summary>
            /// 事件消息内容
            /// </summary>
            public string message { get; set; }

            public NetEventMessage()
            {
                mesType = MesType.事件消息;
            }
        }

        /// <summary>
        /// 远程协助请求消息类
        /// </summary>
        public class NetRemoteInfo : NetInfo
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }

            /// <summary>
            /// true标识为主动控制请求,false标识为受控请求
            /// </summary>
            public bool IsCoon { get; set; }
            /// <summary>
            /// 附加消息
            /// </summary>
            public string message { get; set; }
        }

        /// <summary>
        /// 信息返回类
        /// </summary>
        public class NetRemoteRetInfo : NetInfo
        {
            /// <summary>
            /// 标识是否连接成功
            /// </summary>
            public bool isSucc { get; set; }

            /// <summary>
            /// 标识是否为主动请求
            /// </summary>
            public bool isCoon { get; set; }

            /// <summary>
            /// 附加信息
            /// </summary>
            public string added { get; set; }

            public override string sender { get; set; }
            public override string senderIP { get; set; }
        }

        /// <summary>
        /// 用户数据信息类
        /// </summary>
        public class NetUserData : NetInfo
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }

            /// <summary>
            /// 标识是否为上线消息，否则为下线消息
            /// </summary>
            public bool OnlineData { get; set; }
            /// <summary>
            /// 指示该条消息是否必须回送,但不代表为false就不会回送
            /// </summary>
            public bool forceSendBack { get; set; }
            /// <summary>
            /// 用户头像ID
            /// </summary>
            public string HeadImgID { get; set; }
            /// <summary>
            /// 用户频道
            /// </summary>
            public int Channel { get; set; }
        }

        /// <summary>
        /// 文件发起请求类
        /// </summary>
        public class NetFileRequest : NetInfo
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }
            /// <summary>
            /// 请求的文件存储位置
            /// </summary>
            public string filePath { get; set; }
            /// <summary>
            /// 监听的端口
            /// </summary>
            public int conProt { get; set; }
            /// <summary>
            /// 发起请求的对象标识符
            /// </summary>
            public string identification { get; set; }
        }

        /// <summary>
        /// 文件请求信息回送
        /// </summary>
        public class NetFileRequestRet : NetInfo
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }
            /// <summary>
            /// 返回的状态信息
            /// </summary>
            public string staeMessage { get; set; }
            /// <summary>
            /// 标识本次传输是否成功
            /// </summary>
            public bool isSucc { get; set; }
            /// <summary>
            /// 发起请求的对象标识符
            /// </summary>
            public string identification { get; set; }
        }

       

        /// <summary>
        /// 包重发申请类
        /// </summary>
        public class NetRetransmis: NetInfo
        {
            public override string sender { get; set; }
            public override string senderIP { get; set; }
            /// <summary>
            /// 单任务标识
            /// </summary>
            public string packKey { get; set; }
            /// <summary>
            /// 包id
            /// </summary>
            public int packid { get; set; }
        }

       
    }
}
