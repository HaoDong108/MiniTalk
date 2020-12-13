using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTalk.Model
{
    /// <summary>
    /// 添加图片消息时的必要参数类
    /// </summary>
    public class ImgMesKey
    {
        public ImgMesKey(){}
        public ImgMesKey(UserData user,Image img,MsType type,bool isPub)
        {
            this.User = user;
            this.Img = img;
            this.Type = type;
            this.isPublic = isPub;
        }

        public UserData User { get; set; }
        public Image Img { get; set; }
        public MsType Type { get; set; }
        public bool isPublic { get; set; }
    }

    /// <summary>
    /// 添加事件消息时的必要参数类
    /// </summary>
    public class EventMesKey
    {
        public EventMesKey() { }
        public EventMesKey(UserData user, string mes, bool isPub)
        {
            this.User = user;
            this.Mes = mes;
            this.isPublic = isPub;
        }

        public UserData User { get; set; }
        public string Mes { get; set; }
        public bool isPublic { get; set; }
    }

    /// <summary>
    /// 添加文本消息时的必要参数类
    /// </summary>
    public class TextMesKey
    {
        public TextMesKey() { }
        public TextMesKey(UserData user, string mes,MsType type, bool isPub)
        {
            this.User = user;
            this.Mes = mes;
            this.Type = type;
            this.isPublic = isPub;
        }

        public UserData User { get; set; }
        public string Mes { get; set; }
        public MsType Type { get; set; }
        public bool isPublic { get; set; }
    }
}
