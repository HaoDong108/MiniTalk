using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTalk.Model
{
    /// <summary>
    /// 单个用户实例
    /// </summary>
    public class UserData
    {
        private string name = string.Empty;
        private string remarks = string.Empty;
        private string headimgName = string.Empty;
        private TalkPanel talkPanel=null;

        public UserData(string ip, string name, string imgName, int channel)
        {
            this.IP = ip;
            this.name = name;
            this.HeadimgName = imgName;
            this.Channel = channel;
        }

        /// <summary>
        /// 用户头像变动时触发
        /// </summary>
        public event Action<UserData, Image> HeadImageChange;
        /// <summary>
        /// 用户昵称改变时触发
        /// </summary>
        public event Action<UserData, string> UserNameChange;

        /// <summary>
        /// 用户IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                if (value != this.name) this.UserNameChange(this, this.name);
            }
        }

        /// <summary>
        /// 用户备注昵称,若无则返回昵称
        /// </summary>
        public string Remarks
        {
            get
            {
                return this.remarks == string.Empty ? Name : this.remarks;
            }
            set
            {
                if (value == Name) return;
                remarks = value;
            }
        }

        /// <summary>
        /// 标识该用户是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 标识是否为公共会话控件
        /// </summary>
        public bool IsPub
        {
            get
            {
                return IP.Equals(KeyData.StaticInfo.MyUser.IP) && Name.Equals("公共会话");
            }
        }

        /// <summary>
        /// 标识该用户是否已被列入黑名单
        /// </summary>
        public bool InBlacklist { get; set; }

        /// <summary>
        /// 标识该用户是否应当标注红点
        /// </summary>
        public bool DrawDot { get; set; }

        /// <summary>
        /// 用户频道
        /// </summary>
        public int Channel { get; private set; }

        /// <summary>
        /// 该用户未查看的新消息数
        /// </summary>
        public int NewMesCount { get; set; }

        /// <summary>
        /// 用户头像
        /// </summary>
        public Image HeadImage { get; private set; }

        /// <summary>
        /// 与该用户的会话控件
        /// </summary>
        public TalkPanel TalkPanel
        {
            get
            {
                if (this.talkPanel==null)
                {
                    this.talkPanel = MakeTalkPanel();
                }
                return this.talkPanel;
            }
        }

        /// <summary>
        /// 用户头像键值
        /// </summary>
        public string HeadimgName
        {
            get
            {
                return this.headimgName;
            }
            set
            {
                if (value != this.headimgName && this.headimgName.Length > 0)
                {
                    if (this.HeadImageChange != null) this.HeadImageChange.Invoke(this, HeadImage);
                }

                HeadImage = Method.ReadHeadImage(value);
                this.headimgName = value;
            }
        }

        /// <summary>
        /// 转换为用户昵称
        /// </summary>
        public override string ToString()
        {
            return this.Remarks == string.Empty ? Name : this.Remarks;
        }

        /// <summary>
        ///返回一个新的会话版控件
        /// </summary>
        private TalkPanel MakeTalkPanel()
        {
            int x = KeyData.form1.txb_input.Location.X;
            int y = KeyData.form1.Pbar_schedule.Location.Y-5;
            int w = KeyData.form1.txb_input.Width;
            int h = KeyData.form1.txb_input.Location.Y - y-5;
            TalkPanel talkPanel = new TalkPanel(new Point(x, y), new Size(w, h),this);
            talkPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            talkPanel.Name = this.IP;
            return talkPanel;
        }
    }
}
