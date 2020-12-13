using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Diagnostics;
using Override_Control;
using MiniTalk.Net;
using MiniTalk.Logic;
using MiniTalk.Model;
using CCWin.SkinControl;
using System.Net.Sockets;
using System.Collections;
using MiniTalk.RemoteControl;
using System.Text.RegularExpressions;

namespace MiniTalk
{
    /// <summary>
    /// 用户主体交互界面
    /// </summary>
    public partial class Form1 : Form
    {
        DataHandle handle = new DataHandle();

        private UserData _nowUser;
        private UserData _classUser;
        private UserData _myUser;
        private bool _shrink = false;
        private bool _fixsize = false;
        private string newUpdate = "2020-11-25";
        private Rectangle screen = Screen.AllScreens[0].Bounds;
        private ToastQueue toasts = new ToastQueue();
        private Bitmap thumb_Enter = null;
        private Bitmap thumb_Leave = null;
        private List<UserData> ats = new List<UserData>(); //当前输入框@的IP集合
        private int atAllCount = 5; //@全体成员的剩余次数

        public int AtAllCount
        {
            get { return atAllCount; }
            set
            {
                if (value < 0) return;
                atAllCount = value;
            }
        }

        /// <summary>
        /// 当前在线的用户实例
        /// </summary>
        public UserData NowUserData
        {
            get
            {
                return _nowUser;
            }
            set
            {
                _nowUser = value;
                bool isClass = value.IsPub;
                this.pic_NowHead.BackgroundImage = isClass ? Images1.群聊头像 : value.HeadImage;
                this.lb_nowName.Text = value.ToString();
                this.bt_Remote.Visible = !isClass;
                this.showAtList = value.IsPub;
            }
        }

        /// <summary>
        /// 指定窗体是否将聊天视口隐藏
        /// </summary>
        public bool Shrink
        {
            get
            {
                return _shrink;
            }
            set
            {
                if (value == _shrink) return;
                this._shrink = value;
                this.WindowState = FormWindowState.Normal;
                this.MinimumSize = new Size(0, this.MinimumSize.Height);
                this.ShowInTaskbar = !value;
                this.Visible = false;
                if (value) //如果是缩放指令
                {
                    Point p = new Point(this.Location.X + this.panel_left.Width, this.Location.Y);
                    this.FixSize = true;//将窗体大小固定
                    this.Width = 300;//设置宽度
                    this.panel_left.Visible = false;//隐藏聊天视口
                    this.bt_zoom.Image = FixedImages.左箭头;
                    this.toolTip_控件提示.SetToolTip(this.bt_zoom, "展开会话栏");
                    this.Location = new Point(p.X + this.panel_left.Width, p.Y);
                    this.TopMost = true;
                }
                else
                {
                    Point p = this.Location;
                    this.FixSize = false;
                    this.Width = 1100;
                    this.panel_left.Visible = true;
                    this.bt_zoom.Image = FixedImages.右箭头;
                    this.toolTip_控件提示.SetToolTip(this.bt_zoom, "隐藏会话栏");
                    this.Location = new Point(p.X - this.panel_left.Width, p.Y);
                    this.TopMost = false;
                }
                this.MinimumSize = new Size(this.Width, this.MinimumSize.Height);
                this.Visible = true;
            }
        }

        /// <summary>
        /// 指定窗口能否调整大小
        /// </summary>
        public bool FixSize
        {

            get
            {
                return _fixsize;
            }
            set
            {
                this.bt_Max.Enabled = !value;
                _fixsize = value;
            }
        }

        /// <summary>
        /// 指示窗体是否已被隐藏
        /// </summary>
        public bool IsRollin { get; set; }

        public Form1()
        {
            InitializeComponent();
            this._myUser = KeyData.StaticInfo.MyUser;
            this.Opacity = 0;
            this.IsRollin = false;
            this.lb_Name.Text = KeyData.StaticInfo.MyUser.Name;
            this.uC_Expression1.Size = new Size((int)(this.Width * 0.4), (int)(this.Height * 0.47));
            Method.FormShadow(this);
            CheckForIllegalCrossThreadCalls = false;
            //开启双缓冲
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            //全局异常捕捉，出现未处理的异常时会及时发送下线消息避免列表残留
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            //订阅消息接收提醒事件
            KeyData.receiver.ReceiveUserMessageEvent += GotTheMessage;
            KeyData.receiver.ReceivePictureMessageEvent += GotTheMessage;
            KeyData.receiver.ReceiveEventMessageEvent += GotTheMessage;
            KeyData.receiver.ReceiveFileMessageEvent += GotTheMessage;
            KeyData.receiver.ReceiveEventMessageEvent += 事件消息处理;
            KeyData.receiver.ReceivePictureMessageEvent += 图片消息处理;
            KeyData.receiver.ReceiveUserMessageEvent += 普通消息处理;
            KeyData.receiver.ReceiveFileMessageEvent += 文件消息处理;
            KeyData.receiver.UserOnlineAndOfflineEvent += 用户上下线消息处理;
            KeyData.receiver.FileDownloadRequestReceivedEvent += 文件下载请求处理;
            KeyData.receiver.RemoteAssistanceRequestEvent += 远程协助请求处理;
            KeyData.receiver.ReceiveRemoteEchoMessageEvent += 远程协助回送信息处理;
            Transmitters.Sender.OnlineRequestScheduleChange += Sender_OnlineRequestScheduleChange;
            this.ListBox_Online.MouseWheel += ListBox_Online_MouseWheel;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.bs_ListBoxOnline.DataSource = KeyData.Activity.UserStruchOnline;

            //
            //将窗体打开时的默认会话窗口设置为公共聊天频道
            //
            UserData classData = new UserData(KeyData.StaticInfo.MyUser.IP, "公共会话", KeyData.StaticInfo.MyUser.HeadimgName, KeyData.StaticInfo.MyUser.Channel);
            KeyData.StaticInfo.ClassPanel = classData.TalkPanel;//添加到窗体
            this.panel_left.Controls.Add(classData.TalkPanel);
            this.bs_ListBoxOnline.Add(classData);
            this._classUser = classData;
            NowUserData = classData;        //设置活动会话窗体
            classData.TalkPanel.AtUserEvent += TalkPanel_AtUserEvent;

            //toolTip设置
            toolTip_控件提示.SetToolTip(this.picBox_HeadImg, "用户昵称：" + KeyData.StaticInfo.MyUser.Name + "\n" +
                                                  "频道：频道" + KeyData.StaticInfo.MyUser.Channel + "\n" +
                                                        "用户IP:" + KeyData.StaticInfo.MyUser.IP);
            this.toolTip_控件提示.SetToolTip(this.pictureBox3, "开发人员：计应1906 梅浩东\n" +
                                                       "联系方式（QQ）：1083092844\n" +
                                                       "版本号：（NULL）\n" +
                                                       "最后更新时间:" + this.newUpdate + "\n" +
                                                       "备注：若有严重Bug请及时反馈");
            this.notifyIcon1.Visible = true;
            //设置自己的头像
            this.picBox_HeadImg.Image = KeyData.StaticInfo.MyUser.HeadImage;
        }

        private void TalkPanel_AtUserEvent(MS_Label sender, UserData e)
        {
            this.showAtList = false;
            this.txb_input.AppendText("@" + e.Name + " ");
            if (!this.ats.Contains(e)) this.ats.Add(e);
            this.showAtList = true;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //开始监听收到的各种消息
            //KeyData.receiver.StartRead();
            KeyData.receiver.IsOpenTalk = true;
            Transmitters.Sender.SendChannelAll();
            this.timer_ScreenHook.Start();
            new Thread(RollMessage) { IsBackground = true }.Start();
            this.Refresh();
            Task.Run(() =>
            {
                while (this.Opacity != 1)
                {
                    this.Opacity += 0.01;
                    Thread.Sleep(15);
                }
            });
            DateTime now = DateTime.Now;
            string ss = now.Hour >= 6 && now.Hour <= 8 ? "早上好!" : now.Hour >= 9 && now.Hour <= 11 ? "上午好!" : now.Hour >= 12 && now.Hour <= 13 ? "中午好呀!" : now.Hour >= 14 && now.Hour <= 18 ? "下午好!" : "晚上好!";
            this.notifyIcon1.ShowBalloonTip(8000, "一声问候", string.Format("{0}{1},\n这是一款能够支持聊天，传文件/图片以及远程协助的局域网及时通讯软件， 欢迎使用，更多功能描述请右击右下角托盘-关于进行查看。\n", ss, KeyData.StaticInfo.MyUser.Name), ToolTipIcon.Info);
            //AddTestUser();
            this.UpdateScollBarMaxValue();
            this.SetScollBarImg();
        }

        private void AddTestUser()
        {
            new Thread(() =>
            {
                for (int i = 1; i <= 20; i++)
                {
                    UserData user = new UserData("192.168.1." + i, "测试用户" + i, "im" + i, 2);
                    this.Invoke(new Action(() => { this.ListBoxItemsAdd(user); }));
                }

            }).Start();
        }

        #region 消息处理事件

        private void GotTheMessage(Model.Transmission.IMessage data)
        {
            if (data.isPublic)
            {
                if (
                    Options._提醒设置.群消息提醒 &&
                    data.mesType != Transmission.MesType.事件消息 &&
                    Options._提醒设置.右下角浮动提醒 &&
                    Options._提醒设置.悬浮提醒_公共会话悬浮提醒 &&
                    this.Shrink
                    )
                {
                    var mt = new MiniToast();
                    mt.U_Img = Images1.群聊头像;
                    mt.U_MesText = data.message;
                    mt.U_SenderName = data.sender;
                    mt.U_IcoType = data.mesType;
                    this.toasts.Enqueue(mt);
                }
                if (NowUserData.IsPub) return;
                if (Options._提醒设置.群消息提醒) this.RollMesInput(string.Format("{0}在公共会话中有新的{1}", data.sender, data.mesType.ToString()));
                if (Options._提醒设置.群消息红点标注) this._classUser.DrawDot = true;
                this.ListBox_Online.Refresh();
                this._classUser.NewMesCount++;
            }
            else
            {
                if (NowUserData.IP == data.senderIP) return;
                if (data.mesType == Transmission.MesType.事件消息 && !Options._提醒设置.提醒类别_事件消息) return;
                if (data.mesType == Transmission.MesType.图片消息 && !Options._提醒设置.提醒类别_图片消息) return;
                if (data.mesType == Transmission.MesType.文本消息 && !Options._提醒设置.提醒类别_文本消息) return;
                if (data.mesType == Transmission.MesType.文件消息 && !Options._提醒设置.提醒类别_文件消息) return;
                UserData user = Method.GetUser(data.senderIP);
                if (user == null) return;
                user.NewMesCount++;
                user.DrawDot = true;
                this.SendToNew(user);
                if (
                    data.mesType != Transmission.MesType.事件消息 &&
                    Options._提醒设置.右下角浮动提醒 &&
                    Options._提醒设置.悬浮提醒_用户消息悬浮提醒 &&
                    this.Shrink
                    )
                {
                    var mt = new MiniToast();
                    mt.U_Img = user.HeadImage;
                    mt.U_MesText = data.message;
                    mt.U_SenderName = data.sender;
                    mt.U_IcoType = data.mesType;
                    this.toasts.Enqueue(mt);
                }
                this.RollMesInput(string.Format("{0}有新的{1}", Method.GetUser(data.senderIP), data.mesType.ToString()));
                this.ListBox_Online.Refresh();
                if (user.IsTop && Options._提醒设置.置顶者强提醒)
                {
                    if (Options._提醒设置.强提醒模式_对话框)
                    {
                        DialogResult res = MessageBox.Show(string.Format("{0}有新的消息,是否查看", data.sender), "强提醒", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                        if (res == DialogResult.Yes)
                        {
                            if (this.WindowState == FormWindowState.Minimized) this.WindowState = FormWindowState.Normal;
                            this.SetKinetic(user);
                        }
                    }
                    if (Options._提醒设置.强提醒模式_托盘消息)
                    {
                        this.notifyIcon1.ShowBalloonTip(2000, "强提醒", string.Format("{0}有新的消息,请回到主界面查看", data.sender), ToolTipIcon.Info);
                    }
                }
            }
        }

        private void 图片消息处理(Transmission.LocalPicMessage info)
        {
            if (Method.GetUser(info.senderIP).InBlacklist) return;
            try
            {
                info.imgBuff = Method.DecompressByteArray(info.imgBuff);
                Image img = Method.BytesToImage(info.imgBuff);

                ImgMesKey mes = new ImgMesKey()
                {
                    User = Method.GetUser(info.senderIP),
                    Img = img,
                    Type = MsType.网络消息,
                    isPublic = info.isPublic
                };
                this.Invoke(new Action(() =>
                {
                    this.AppendPicMessage(mes);
                }));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("图片消息接收失败\n错误信息:" + ex.Message);
            }
        }

        private void 事件消息处理(Transmission.NetEventMessage data)
        {
            EventMesKey mes = new EventMesKey()
            {
                User = Method.GetUser(data.senderIP),
                Mes = data.message,
                isPublic = data.isPublic
            };
            this.Invoke(new Action(() =>
            {
                this.AppendEventMessage(mes);
            }));
        }

        private void 普通消息处理(Transmission.NetMessage data)
        {
            if (Method.GetUser(data.senderIP).InBlacklist) return;
            if (data.senderIP.Equals(KeyData.StaticInfo.MyUser.IP)) return;
            if (data.ats.Contains(this._myUser.IP) && !data.atAll)
            {
                MiniToast m = new MiniToast();
                m.U_Img = Images1.群聊头像;
                m.U_MesText = data.message;
                m.U_SenderName = data.sender + "@";
                m.U_IcoType = Transmission.MesType.文本消息;
                this.toasts.Enqueue(m);
            }
            if (data.atAll)
            {
                MiniToast m = new MiniToast();
                m.U_Img = Images1.群聊头像;
                m.U_MesText = data.message;
                m.U_SenderName = data.sender + "@all";
                m.U_IcoType = Transmission.MesType.文本消息;
                this.toasts.Enqueue(m);
            }
            TextMesKey value = new TextMesKey()
            {
                Mes = data.message,
                User = Method.GetUser(data.senderIP),
                Type = MsType.网络消息,
                isPublic = data.isPublic
            };
            this.Invoke(new Action(() =>
            {
                this.AppendMessage(value);
            }));
        }

        private void 文件消息处理(Transmission.NetFileData data)
        {
            if (Method.GetUser(data.senderIP).InBlacklist) return;
            this.Invoke(new Action(() =>
            {
                this.AppendFileMes(data);
            }));
        }

        private void 用户上下线消息处理(Transmission.NetUserData data)
        {
            if (data.Channel != KeyData.StaticInfo.MyUser.Channel) return;
            if (data.senderIP.Equals(KeyData.StaticInfo.MyUser.IP)) return;

            if (data.OnlineData)
            {
                UserData userData = new UserData(data.senderIP, data.sender, data.HeadImgID, data.Channel);
                //检测该条消息是否被标识为必须回送
                if (data.forceSendBack) Transmitters.Sender.ReturnOnlineMessage(IPAddress.Parse(data.senderIP));//向目标主机回送一条上线消息

                string st;
                if (Options.用户管理.备注设置.GetName(userData.IP, out st)) userData.Remarks = st;

                if (Options.用户管理.黑名单管理.Contains(userData.IP)) userData.InBlacklist = true;

                //遍历本地在线用户集合,检测用户是否已经存在
                for (int i = 1; i < KeyData.Activity.UserStruchOnline.Count; i++)
                {
                    if (KeyData.Activity.UserStruchOnline[i].IP.Equals(data.senderIP))
                    {
                        UserData us = KeyData.Activity.UserStruchOnline[i];
                        if (data.sender == us.Name && data.HeadImgID == us.HeadimgName) return;
                        this.RemoveUser(data.senderIP);
                        break;
                    }
                }
                if (!KeyData.Activity.PublicIPAddress.Contains(IPAddress.Parse(userData.IP))) KeyData.Activity.PublicIPAddress.Add(IPAddress.Parse(userData.IP));//将用户添加到在线用户地址池
                this.bs_ListBoxOnline.Add(userData);
                Transmitters.Sender.ReturnOnlineMessage(IPAddress.Parse(data.senderIP));//向目标主机回送一条上线消息
            }
            else
            {
                this.RemoveUser(data.senderIP);
            }
            this.UpdateLableCount();
        }

        List<string> netRemoteIps = new List<string>();
        private void 远程协助请求处理(Transmission.NetRemoteInfo info)
        {
            if (netRemoteIps.Contains(info.senderIP)) return;
            if (Options.用户管理.黑名单管理.Contains(info.senderIP)) return;
            if (Entrance.ConStae)
            {
                Transmitters.Sender.SendReturnMes(info.senderIP, false, info.IsCoon, "该设备已被控制");
                return;
            }
            netRemoteIps.Add(info.senderIP);
            DialogResult res = MessageBox.Show(info.message, string.Format("来自{0}的请求", info.sender), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            netRemoteIps.Remove(info.senderIP);
            if (res == DialogResult.Yes)
            {
                Transmitters.Sender.SendReturnMes(info.senderIP, true, info.IsCoon);
                Thread td = new Thread(() =>
                {
                    if (info.IsCoon) Entrance.Controlled(IPAddress.Parse(info.senderIP), info.sender);

                    else Entrance.Control(IPAddress.Parse(info.senderIP), info.sender);

                    Debug.WriteLine("远程控制线程以安全退出");
                }) { IsBackground = true };
                if (!info.IsCoon) td.SetApartmentState(ApartmentState.STA);
                td.Start();
            }
            else
            {
                Transmitters.Sender.SendReturnMes(info.senderIP, false, info.IsCoon, "用户主动拒绝");
            }
        }

        private void 远程协助回送信息处理(Transmission.NetRemoteRetInfo info)
        {
            string mes = info.isSucc ? info.sender + " 同意了你的远程请求!" : info.sender + " 拒绝了你的远程请求!";
            if (info.added.Trim().Length > 0)
            {
                mes += "\n附加信息:" + info.added;
            }
            Method.ShowPrompt(mes, 2000, 30);
            if (!info.isSucc) return;
            Thread td = new Thread(() =>
            {
                if (info.isCoon)
                {
                    Entrance.Control(IPAddress.Parse(info.senderIP), info.sender);
                }
                else
                {
                    Entrance.Controlled(IPAddress.Parse(info.senderIP), info.sender);
                }
                Debug.WriteLine("远程控制线程以安全退出");
            }) { IsBackground = true };
            if (info.isCoon)
                td.SetApartmentState(ApartmentState.STA);
            td.Start();
        }

        private void 文件下载请求处理(Transmission.NetFileRequest info)
        {
            if (!File.Exists(info.filePath))
            {
                Transmitters.Sender.SendFileRequestRet(info.senderIP, "请求的文件已不存在,可能终端已将其删除", info.identification, false);
                return;
            }
            if (Method.FileIsUsing(info.filePath))
            {
                Transmitters.Sender.SendFileRequestRet(info.senderIP, "请求的文件被终端其他进程占用", info.identification, false);
                return;
            }
            new Thread(() =>
            {
                Transmission.NetFileRequest nr = info;
                semp.Wait();
                if (!SocketAdd(nr))
                {
                    semp.Release();
                    return;
                }
                SendTask(nr.filePath);
                tables.Remove(nr.filePath);
                FileLock.Exit(nr.filePath);
                Debug.WriteLine("释放了一个文件锁");
                semp.Release();
                Debug.WriteLine(string.Format("剩余{0}个并行空槽可用", semp.CurrentCount));
            }) { IsBackground = true }.Start();
        }

        Hashtable tables = new Hashtable();

        SemaphoreSlim semp = new SemaphoreSlim(3);

        private bool SocketAdd(Transmission.NetFileRequest info)
        {
            if (tables.ContainsKey(info.filePath))
            {
                if (FileLock.TryLock(info.filePath))
                {
                    return SocketAdd(info);
                }
                else
                {
                    return false;
                }
            }
            try
            {
                Socket sok = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sok.Connect(new IPEndPoint(IPAddress.Parse(info.senderIP), info.conProt));
                if (sok != null) this.tables.Add(info.filePath, sok);
                return true;
            }
            catch (Exception ex)
            {
                if (tables.ContainsKey(info.filePath)) tables.Remove(info.filePath);
                Debug.WriteLine("文件发送连接用户对象时失败，错误信息:" + ex.Message);
                return false;
            }
        }

        private void SendTask(string path)
        {
            using (FileStream read = new FileStream(path, FileMode.Open))
            {
                int everyReadlen = 1024 * 1024;
                long fileSize = read.Length;
                Socket socket = tables[path] as Socket;
                long tolen = 0;

                byte[] tBuff = new byte[everyReadlen];
                long dc = 0;//当次接收
                long jb = 0;//局部接收
                try
                {
                    do
                    {
                        do
                        {
                            dc = read.Read(tBuff, 0, tBuff.Length);
                            jb += dc;
                        } while (jb != everyReadlen && dc != 0);
                        socket.Send(tBuff, 0, int.Parse(jb.ToString()), SocketFlags.None);
                        tolen += jb;
                        jb = 0;
                    } while (tolen != fileSize);

                    Debug.WriteLine("文件发送完毕");
                }
                catch (Exception)
                {
                    (tables[path] as Socket).Close();
                }
            }
        }

        static class FileLock
        {
            static List<string> list = new List<string>();
            static readonly object objlock = new object();
            public static bool TryLock(string key)
            {
                int times = 0;
                while (list.Contains(key))
                {
                    if (times >= 9000)
                    {
                        return false;
                    }
                    Thread.Sleep(500);
                    times += 500;
                }
                lock (objlock)
                    list.Add(key);
                return true;
            }

            public static void Exit(string key)
            {
                if (list.Contains(key))
                {
                    lock (objlock)
                        list.Remove(key);
                }
            }
        }

        #endregion

        #region 窗体功能按钮点击事件
        //
        //聊天视口缩放按钮
        //
        private void bt_zoom_Click(object sender, EventArgs e)
        {
            this.Shrink = !Shrink;
        }
        //
        //推广按钮
        //
        private void bt_Adv_Click(object sender, EventArgs e)
        {
            new DrivingSchool().ShowDialog();
        }
        //
        //"发送"按钮
        //
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Send();
        }
        //
        //"清空"按钮
        //
        private void Button2_Click(object sender, EventArgs e)
        {
            this.ClearChat();
        }
        //
        //文件发送按钮
        //
        private void Bt_SendFile_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "所有文件 (*.*)|*.*";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SendFileInfo(this.openFileDialog1.FileName);
            }
        }
        //
        //图片发送按钮
        //
        private void picbox_SendImg_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "(*.jpg、*.jpeg、*.png、*.bmp、*.ico、*.gif) | *.jpg;*.jpeg;*.png;*.bmp;*.ico;*.gif";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.SendPicInfo(Image.FromFile(this.openFileDialog1.FileName));
            }
        }
        //
        //MiniTalk.RemoteControl按钮
        //
        private void pictureBox_Remote_Click(object sender, EventArgs e)
        {
            string ip = NowUserData.IP;
            DialogResult result = MessageBox.Show("是否申请控制对方电脑?否则申请对方控制我方电脑\n点击取消退出", "提示", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                Transmitters.Sender.SendRemoteRequest(ip, true);
            }
            if (result == DialogResult.No)
            {
                Transmitters.Sender.SendRemoteRequest(ip, false);
            }
        }
        //
        //表情发送按钮
        //
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            this.InsertExpression();
        }
        //
        //刷新列表按钮
        //
        private void picRefresh_Click(object sender, EventArgs e)
        {
            //向范围内主机重发上线消息
            Transmitters.Sender.SendChannelAll(true);
            Task.Run(() =>
            {
                this.bt_Ref.NormlBack = FixedImages.冷却;
                this.bt_Ref.Enabled = false;
                Thread.Sleep(10000);
                this.bt_Ref.Enabled = true;
                this.bt_Ref.NormlBack = FixedImages.刷新;
            });
        }

        Form formInstall = null;
        //
        //设置按钮系列事件
        //
        private void pic_setup_Click(object sender, EventArgs e)
        {
            if (this.formInstall != null)
            {
                this.formInstall.BringToFront();
                return;
            }
            var f = new Form_Install();
            this.formInstall = f;
            f.Show();
            f.Disposed += (s, e2) => { this.formInstall = null; };
        }
        //
        //点击输入框时切换为搜狗输入法
        //
        private void TextBox1_Click(object sender, EventArgs e)
        {
            this.label_watermark.Visible = false;
            InputLanguageCollection langs = InputLanguage.InstalledInputLanguages;
            foreach (InputLanguage lang in langs)
            {
                if (lang.LayoutName.Contains("搜狗拼音"))
                {
                    InputLanguage.CurrentInputLanguage = lang;
                }
            }
        }
        //
        //水印标签被点击时消失
        //
        private void label_watermark_Click(object sender, EventArgs e)
        {
            this.label_watermark.Visible = false;
            this.txb_input.Focus();
        }
        //
        //托盘图标双击事件
        //
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.IsRollin = false;
            if (this.Top <= 0) this.Top = 1;
            this.TopMost = true;
            this.TopMost = false;
        }
        //
        //托盘关于按钮
        //
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mes = "产品名称:MiniTalk\n" +
                "开发者：计应1906-梅浩东\n" +
                "软件版本：??\n" +
                "最后更新时间:" + this.newUpdate + "\n" +
                "项目创建时间:2019-11-8\n" +
                "功能描述:\n\n" +
                "1.基本聊天:\n" +
                "1.1:输入@能够选择@对象,@全体次数用完后其他用户不再接收到全体提醒\n" +
                "1.2:点击表情即可插入表情到气泡，发送后即可看见,由于分辨率原因,1920*1080才能完整显示表情\n" +
                "1.3:Ctrl+Alt+S 能够屏幕截图,只能保存到剪切板，然后即可在输入框粘贴发送(不能大于3M)\n\n" +
                "2.文件发送:\n" +
                "2.1:文件发送只能发送单个文件,若有多个请压缩发送\n" +
                "2.2:输入框支持粘贴文件,粘贴后直接发送\n" +
                "2.3:出于性能和学校机房配置考虑,公共回话只能发送小于10MB的文件,私人会话无限制\n\n" +
                "3.其他功能:\n" +
                "3.1:有多个同时在线用户时支持点击放大镜根据ip/备注/昵称模糊查找\n" +
                "3.2:窗口支持点击三角箭头折叠/展开,折叠后将窗体拖到屏幕上方自动隐藏\n" +
                "3.4:右击用户在线栏展开用户管理功能菜单,支持IP备注(备注后只要该IP上线依然显示其备注),加入黑名单和用户置顶\n" +
                "3.5:私人会话界面点击下方显示器图标即可点对点远程协助,隔空帮忙再也不是梦,支持主动帮助以及被动请求 \n"+
                "因为我在自己电脑上开发所以窗口偏大,但在高分辨率屏幕上刚好合适";

            MessageBox.Show(mes, "MiniTalk软件信息");
        }
        //
        //最大化按钮
        //
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.bt_Max.BackgroundImage = FixedImages.还原;
                this.toolTip_控件提示.SetToolTip(this.bt_Max, "还原");
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.bt_Max.BackgroundImage = FixedImages.最大化;
                this.toolTip_控件提示.SetToolTip(this.bt_Max, "最大化");
            }
        }

        //
        //列表查询
        //
        private void bt_select_Click(object sender, EventArgs e)
        {
            if (this.txb_SelectInput.Text.Trim().Length == 0) return;
            this.panel_Result.Visible = true;
            this.UserSelect(this.txb_SelectInput.Text);
        }
        #endregion

        #region 托盘右键菜单
        private void toolStrip_ShowMain_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        private void ToolStrip_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 设置窗体控制事件
        //
        //点击任务栏图标实现最大和最小化
        //
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | 0x00020000;   // 最小化
                return cp;
            }
        }
        //
        //窗口拖动
        //
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Method.FormMove(this.Handle);
        }
        //
        //窗体关闭
        //
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!closeFlg)
            {
                e.Cancel = true;
                return;
            }
            var res = MessageBox.Show("确定退出程序吗？所有会话记录将会丢失。", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res != DialogResult.OK)
            {
                e.Cancel = true;
                this.closeFlg = false;
                return;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            this.notifyIcon1.Visible = false;
            //关闭前向范围内所有主机发送一条退出消息
            Transmitters.Sender.CloseSend(KeyData.Activity.PublicIPAddress);
            try
            {
                KeyData.receiver.Dispose();
                this.Controls.Clear();
                this.Dispose();
            }
            catch (Exception)
            {
                Application.Exit();
            }
        }

        //
        //在线列表查询按钮
        //
        private void bt_Search_Click(object sender, EventArgs e)
        {
            this.panel_Result.Visible = !this.panel_Result.Visible;
        }
        //
        //结果面板关闭按钮
        //
        private void bt_resultClose_Click(object sender, EventArgs e)
        {
            this.panel_Result.Visible = false;
            this.txb_SelectInput.Text = "";
        }

        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bt_Max_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.bt_Max.NormlBack = FixedImages.最大化;
                this.bt_Max.MouseBack = FixedImages.最大化_被选中;
                this.bt_Max.DownBack = FixedImages.最大化;
                this.toolTip_控件提示.SetToolTip(this.bt_Max, "最大化");
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.bt_Max.NormlBack = FixedImages.还原;
                this.bt_Max.MouseBack = FixedImages.还原_被选中;
                this.bt_Max.DownBack = FixedImages.还原;
                this.toolTip_控件提示.SetToolTip(this.bt_Max, "向下还原");
                this.WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        #region 支持改变窗体大小
        private const int Guying_HTLEFT = 10;
        private const int Guying_HTRIGHT = 11;
        private const int Guying_HTTOP = 12;
        private const int Guying_HTTOPLEFT = 13;
        private const int Guying_HTTOPRIGHT = 14;
        private const int Guying_HTBOTTOM = 15;
        private const int Guying_HTBOTTOMLEFT = 0x10;
        private const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (this.FixSize)
            {
                base.WndProc(ref m);
                return;
            }
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF, (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else
                            m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else
                            m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201://鼠标左键按下的消息
                    m.Msg = 0x00A1;//更改消息为非客户区按下鼠标
                    m.LParam = IntPtr.Zero; //默认值
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内
                    base.WndProc(ref m);
                    break;
                case 0x0112:
                    if ((int)m.WParam == 0xF060)
                    {
                        this.closeFlg = true;
                    }
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        #endregion

        #region 右键菜单
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txb_input.Text = null;
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        private void 插入表情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.InsertExpression();
        }

        private void 发送ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Send();
        }

        //
        //右键菜单-置顶 
        //
        private void ts_Topping_Click(object sender, EventArgs e)
        {
            if (this.ts_Topping.Text == "置顶")
            {
                this.SendTop(this.ListBox_Online.SelectedIndex);
            }
            else
            {
                this.SendLast(this.ListBox_Online.SelectedIndex);
            }
            this.ListBox_Online.Refresh();
        }

        //
        //右键菜单-屏蔽此人
        //
        private void ts_Shield_Click(object sender, EventArgs e)
        {
            if (this.ts_Shield.Text == "屏蔽此人")
            {
                this.ListBox_Online.NowSelectUser.InBlacklist = true;
                Options.用户管理.黑名单管理.Add(this.ListBox_Online.NowSelectUser.IP);
            }
            else
            {
                this.ListBox_Online.NowSelectUser.InBlacklist = false;
                Options.用户管理.黑名单管理.Remote(this.ListBox_Online.NowSelectUser.IP);
            }
        }

        private void ts_TextRek_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cms_在线列表.Close();
            }
        }
        #endregion

        #region 其他事件
        static bool isshow = false;
        private void timer_ScreenHook_Tick(object sender, EventArgs e)
        {
            if (Options._常规设置.快捷截图 &&
                WinAPI.GetAsyncKeyState((int)Keys.LControlKey) != 0 &&
                WinAPI.GetAsyncKeyState((int)Keys.Menu) != 0 &&
                WinAPI.GetAsyncKeyState((int)Keys.S) != 0 &&
                !isshow)
            {
                var f = new ScreenShots(Method.GetScreenImg());
                isshow = true;
                f.ShowDialog();
                f.Dispose();
                isshow = false;
                if (f.OverSave)
                    this.notifyIcon1.ShowBalloonTip(2000, "截图已保存", "截图已保存在剪切板,可在输入框粘贴发送", ToolTipIcon.Info);
            }
            if (panel_At.Visible)
            {
                if (WinAPI.GetAsyncKeyState((int)Keys.Up) + WinAPI.GetAsyncKeyState((int)Keys.Down) != 0)
                {
                    this.txb_input.SelectionStart = this.endStart;
                }
            }

            this.Rollin();
            this.Rollout();
        }

        private void Sender_OnlineRequestScheduleChange(int value)
        {
            this.Pbar_schedule.Value = value;
            //this.Pbar_schedule.Visible = value > 0 && value <= 255;
            if (!this.Pbar_schedule.Visible) this.Refresh();
        }

        private void cms_在线列表_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (this.ts_TextRek.Text == ListBox_Online.NowSelectUser.Name || string.IsNullOrEmpty(ts_TextRek.Text.Trim())) return;
            KeyData.Activity.UserStruchOnline[ListBox_Online.SelectedIndex].Remarks = this.ts_TextRek.Text;
            Options.用户管理.备注设置.Add(new IPRemarks(ListBox_Online.NowSelectUser.IP, this.ts_TextRek.Text));
            this.SetKinetic(KeyData.Activity.UserStruchOnline[ListBox_Online.SelectedIndex]);
        }

        private void cms_在线列表_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.ListBox_Online.NowSelectUser == null || this.ListBox_Online.NowSelectUser.IsPub || this.ListBox_Online.NowHoverIndex < 0)
            {
                e.Cancel = true;
                return;
            }
            this.ts_Topping.Text = ListBox_Online.NowSelectUser.IsTop ? "取消置顶" : "置顶";
            this.ts_Shield.Text = ListBox_Online.NowSelectUser.InBlacklist ? "取消屏蔽" : "屏蔽此人";
            this.ts_TextRek.Text = ListBox_Online.NowSelectUser.ToString();
        }

        private void txb_SelectInput_TextChanged(object sender, EventArgs e)
        {
            this.UserSelect(this.txb_SelectInput.Text.Trim());
        }

        private void ListBox_Select_Result_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = this.ListBox_Select_Result.SelectedIndex;
            if (index < 0) return;
            this.SetKinetic(this.ListBox_Select_Result.Items[index].Tag as UserData);
        }

        private void panel_Result_Leave(object sender, EventArgs e)
        {
            this.panel_Result.Visible = false;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.pic_NowHead.Left = (this.Width - this.ListBox_Online.Width) / 2 - 100;
            this.lb_nowName.Left = this.pic_NowHead.Left + this.pic_NowHead.Width + 10;

            //this.ControlAutoSize();
        }

        //
        //异常关闭前的善后处理
        //
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Transmitters.Sender.CloseSend(KeyData.Activity.PublicIPAddress);
            MessageBox.Show("有未经处理的异常,程序被迫终止！看到此消息请联系开发人员。\n" + "异常数据：\n" + e.ExceptionObject, "异常终止", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(-1);
        }
        //
        //更改会话框时重置新消息数，以及设置文件发送可用性
        //
        private void ListBox_Online_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = this.ListBox_Online.SelectedIndex;
            if (selectIndex < 0)
            {
                return;
            }
            UserData data = this.ListBox_Online.NowSelectUser;
            if (data.DrawDot)
            {
                data.DrawDot = false;
                this.ListBox_Online.Refresh();
            }
            //设置该索引为活动用户,并设置对应会话控件
            this.SetKinetic(data);
            this.ListBox_Online.Refresh();
        }
        //
        //控件失去焦点时显示水印
        //
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (this.txb_input.Text.Length == 0)
            {
                this.label_watermark.Visible = true;
            }
            this.AcceptButton = null;
            if (!this.listBox_Ats.Focused)
                this.panel_At.Visible = false;
        }
        //
        //文件拖动到聊天输入框触发文件发送事件
        //
        private void TextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (!path.Contains("."))
            {
                Method.ShowPrompt("若要发送请先将该文件夹压缩!", 2000);
                return;
            }
            string ext = Path.GetExtension(path).Trim('.');
            if (ext == "jpg" || ext == "bmp" || ext == "png" || ext == "jpeg")
            {
                this.SendPicInfo(Image.FromFile(path));
            }
            else
            {
                this.SendFileInfo(path);
            }
        }
        private void TextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Link;
            else e.Effect = DragDropEffects.None;
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            this.uC_Expression1.Visible = false;
            this.label_watermark.Visible = false;
            this.AcceptButton = this.bt_Send;
        }

        private void panel_left_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //绘制上下渐变线条
            Point p1 = new Point(this.txb_input.Location.X, this.txb_input.Location.Y - 5);
            Point p2 = new Point(this.txb_input.Width / 2, p1.Y);
            int cha = p1.Y - this._classUser.TalkPanel.Height - 2;
            LinearGradientBrush b = new LinearGradientBrush(Point.Empty, new Point(p2.X - p1.X, 0), Color.Transparent, Color.DarkTurquoise);
            Pen pen = new Pen(b);
            e.Graphics.DrawLine(pen, p1, p2);
            e.Graphics.DrawLine(pen, new Point(p1.X, cha), new Point(p2.X, cha));

            b = new LinearGradientBrush(Point.Empty, new Point(p2.X - p1.X, 0), Color.DarkTurquoise, Color.Transparent);
            pen = new Pen(b);
            Point p3 = new Point(this.txb_input.Width, p1.Y);
            e.Graphics.DrawLine(pen, p2, p3);
            e.Graphics.DrawLine(pen, new Point(p2.X, cha), new Point(p3.X, cha));

            //绘制左上角花纹
            pen = new Pen(Brushes.DarkTurquoise);
            Point es = new Point(140, 0);
            Point en = new Point(es.X, es.Y + 30);
            e.Graphics.DrawLine(pen, es, en);
            e.Graphics.FillEllipse(Brushes.DarkTurquoise, new Rectangle(new Point(en.X - 5, en.Y), new Size(10, 10)));


            es = new Point(160, 0);
            en = new Point(es.X, es.Y + 50);
            e.Graphics.DrawLine(pen, es, en);
            e.Graphics.FillEllipse(Brushes.DarkTurquoise, new Rectangle(new Point(en.X - 5, en.Y), new Size(10, 10)));

            es = new Point(180, 0);
            en = new Point(es.X, es.Y + 30);
            e.Graphics.DrawLine(pen, es, en);
            e.Graphics.FillEllipse(Brushes.DarkTurquoise, new Rectangle(new Point(en.X - 5, en.Y), new Size(10, 10)));
        }

        private void panel_left_MouseDown(object sender, MouseEventArgs e)
        {
            Method.FormMove(this.Handle);
        }

        private void ListBox_Online_MouseClick(object sender, MouseEventArgs e)
        {
            int index = this.ListBox_Online.IndexFromPoint(e.Location);
            if (index < 0) return;
            this.ListBox_Online.SelectedIndex = index;
            this.ListBox_Online_SelectedIndexChanged(this.bs_ListBoxOnline, new EventArgs());
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            Point p = this.Location;
            if (p.X < 0) this.Left = 0;
            if (p.X + this.Width > screen.Width) this.Left = screen.Width - this.Width;
            if (p.Y > this.screen.Height - 100) this.Top = screen.Height - 100;
        }

        private void ListBox_Online_MouseWheel(object sender, MouseEventArgs e)
        {
            this.scrollBar_Online.Wheel(e);
            this.ListBox_Online.Invalidate();
        }

        private void ListBox_Online_SizeChanged(object sender, EventArgs e)
        {
            this.UpdateScollBarMaxValue();
        }

        private void scrollBar_Online_MouseEnter(object sender, EventArgs e)
        {
            this.scrollBar_Online.ImageThumb = this.thumb_Enter;
        }

        private void scrollBar_Online_MouseLeave(object sender, EventArgs e)
        {
            this.scrollBar_Online.ImageThumb = this.thumb_Leave;
        }

        int inputStart = -1;
        int endStart = 0;
        bool showAtList = true;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string text = this.txb_input.Text;
            if (text.Length == 0)
            {
                this.panel_At.Visible = false;
                return;
            }
            this.label_watermark.Visible = false;
            if (!this.showAtList)
            {
                return;
            }
            int ist = this.txb_input.SelectionStart;
            this.endStart = this.txb_input.SelectionStart;
            //判断插入点前一个字符是否为@，如是则设置@起始索引
            if (ist > 0 && text[ist - 1] == '@') this.inputStart = ist - 1;
            else
            {
                //否则向左查找出距离光标最近一位@
                int i = ist - 1;
                if (i < 0) return;
                for (; i > 0; i--) if (text[i] == '@') break;
                if (text[i] == '@') this.inputStart = i;
                else this.inputStart = -1;

                //若不是以@开头且间隔上一个@超过6位则返回
                if (this.inputStart >= 0 && (ist - this.inputStart) > 6)
                {
                    this.panel_At.Visible = false;
                    return;
                }
            }
            //如果@起始索引有效则显示@栏,否则重置
            if (this.inputStart >= 0 && this.inputStart < text.Length && text[this.inputStart] == '@')
            {
                //计算@起始索引与当前插入点的长度,并将其截取
                string sub = text.Substring(this.inputStart, (this.txb_input.SelectionStart - this.inputStart));
                if (sub.Contains(" "))
                {
                    this.panel_At.Visible = false;
                    this.inputStart = -1;
                    return;
                }
                this.SelectAtUser(sub);
            }
            else
            {
                this.panel_At.Visible = false;
                this.inputStart = -1;
                return;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                this.Paste();
            }
            if (this.listBox_Ats.Visible)
            {
                try
                {
                    if (e.KeyCode == Keys.Down)
                    {
                        int next = this.listBox_Ats.SelectedIndex + 1;
                        this.listBox_Ats.SelectedIndex = (next >= this.listBox_Ats.Items.Count) ? 0 : next;
                    }
                    if (e.KeyCode == Keys.Up)
                    {
                        int next = this.listBox_Ats.SelectedIndex - 1;
                        this.listBox_Ats.SelectedIndex = (next < 0) ? this.listBox_Ats.Items.Count - 1 : next;
                    }
                    if (e.KeyCode == Keys.Enter)
                    {
                        InsertAtName();
                    }
                    if (e.KeyCode == Keys.Escape)
                    {
                        this.panel_At.Visible = false;
                    }
                }
                catch (Exception)
                { }
            }
        }

        #endregion

        #region 私有方法
        /// <summary>
        /// 查找匹配@用户
        /// </summary>
        /// <param name="text"></param>
        private void SelectAtUser(string text)
        {
            this.listBox_Ats.Items.Clear();

            if (text == "@")
            {
                SkinListBoxItem t = new SkinListBoxItem();
                t.Tag = this._classUser;
                t.Text = " 全体成员(剩余" + this.atAllCount + ")";
                t.Image = Method.ResizeImage(Images1.群聊头像, new Size(30, 30));
                this.listBox_Ats.Items.Add(t);

                foreach (var user in KeyData.Activity.UserStruchOnline)
                {
                    if (user.IsPub) continue;

                    SkinListBoxItem it = new SkinListBoxItem();
                    it.Tag = user;
                    it.Text = " " + user.Name;
                    it.Image = Method.ResizeImage(user.HeadImage, new Size(30, 30));
                    this.listBox_Ats.Items.Add(it);
                }
            }
            else
            {
                text = text.Trim('@');
                IEnumerable<UserData> res = from user in KeyData.Activity.UserStruchOnline
                                            where (user.Name.Contains(text) || user.Remarks.Contains(text)) && !user.IsPub
                                            select user;

                foreach (UserData user in res)
                {
                    SkinListBoxItem it = new SkinListBoxItem();
                    it.Tag = user;
                    it.Text = " " + user.Name;
                    it.Image = Method.ResizeImage(user.HeadImage, new Size(30, 30));
                    this.listBox_Ats.Items.Add(it);
                }
            }
            if (this.listBox_Ats.Items.Count > 0)
            {
                this.listBox_Ats.SelectedIndex = 0;
                this.panel_At.Visible = true;
            }
            else
            {
                this.panel_At.Visible = false;
            }
        }

        /// <summary>
        /// 向输入框插入@用户名
        /// </summary>
        private void InsertAtName()
        {
            int sels = this.txb_input.SelectionStart;
            UserData data = this.listBox_Ats.Items[this.listBox_Ats.SelectedIndex].Tag as UserData;
            string rm = this.txb_input.Text.Remove(this.inputStart, sels - this.inputStart);
            string ist = rm.Insert(this.inputStart, "@" + (data.IsPub ? "全体成员" : data.Name) + " ");
            this.showAtList = false;
            this.txb_input.Text = ist;
            this.showAtList = true;
            this.panel_At.Visible = false;
            this.txb_input.SelectionStart = this.txb_input.Text.Length;
            if (!this.ats.Contains(data)) this.ats.Add(data);
        }

        /// <summary>
        /// 修正@对象,并返回是否@了全体成员
        /// </summary>
        private bool ReviseAts(string text)
        {
            List<UserData> list = new List<UserData>();
            list.AddRange(this.ats.ToArray());
            foreach (UserData u in ats)
            {
                if (!text.Contains("@" + (u.IsPub ? "全体成员" : u.Name) + " "))
                {
                    list.Remove(u);
                }
            }
            ats = list;
            bool flg = false;
            if (ats.Contains(this._classUser))
            {
                flg = (this.AtAllCount--) > 0;
                if (!flg) Method.ShowPrompt("@全体成员 次数已用尽,成员将不会被提示", 1500);
                ats.Remove(this._classUser);
            }
            return flg;
        }

        private bool sendLock = false;

        /// <summary>
        /// 发送文本框内消息
        /// </summary>
        private void Send()
        {
            if (sendLock)
            {
                Method.ShowPrompt("每两秒只能发送一次", 1000);
                return;
            }
            if (txb_input.Text.Trim().Length <= 0)
            {
                txb_input.Text = null;
                return;
            }
            string text = this.txb_input.Text;
            //如果输入内容不合法则进行修改
            if (Method.Audit(text)) text = "我是个智障";
            TextMesKey value = new TextMesKey()
            {
                Mes = text,
                User = NowUserData,
                Type = MsType.本地消息,
                isPublic = false
            };
            this.AppendMessage(value);
            //var mt = new MiniToast();
            //mt.Img = this._classUser.HeadImage;
            //mt.MesText = text;
            //mt.SenderName = KeyData.StaticInfo.MyUser.Name;
            //mt.IcoType = Transmission.MesType.文本消息;
            //this.toasts.Enqueue(mt);
            bool atAll = this.ReviseAts(text);
            if (NowUserData.IP == KeyData.StaticInfo.MyUser.IP) Transmitters.Sender.SendTo(text, atAll, this.ats);
            else Transmitters.Sender.SendTo(NowUserData.IP, text);
            this.txb_input.Text = null;
            this.txb_input.Focus();
            this.sendLock = true;
            new Thread(() => { Thread.Sleep(2000); this.sendLock = false; }) { IsBackground = true }.Start();
        }

        /// <summary>
        /// 打开表情框
        /// </summary>
        private void InsertExpression()
        {
            this.uC_Expression1.BringToFront();
            this.uC_Expression1.SetBox(this.txb_input);
            this.uC_Expression1.Visible = true;
        }

        /// <summary>
        /// 清空聊天记录
        /// </summary>
        private void ClearChat()
        {
            if (MessageBox.Show("确认清空当前聊天记录吗？", "清空聊天记录", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                NowUserData.TalkPanel.ClearAll();
            }
        }

        /// <summary>
        /// 粘贴操作
        /// </summary>
        private void Paste()
        {
            // GetDataObject获取当前剪贴板上的数据
            IDataObject data = Clipboard.GetDataObject();

            if (data.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap map = data.GetData(DataFormats.Bitmap) as Bitmap;
                this.SendPicInfo(map);
            }
            if (data.GetDataPresent(DataFormats.FileDrop))
            {
                string path = ((System.Array)data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
                string ext = Path.GetExtension(path).Trim('.');
                if (ext == "jpg" || ext == "bmp" || ext == "png" || ext == "jpeg" || ext == "gif")
                {
                    this.SendPicInfo(Image.FromFile(path));
                }
                else
                {
                    this.SendFileInfo(path);
                }
            }
        }

        bool closeFlg = false;
        private new void Close()
        {
            closeFlg = true;
            base.Close();
        }

        /// <summary>
        /// 查找包含信息的用户添加到查找列表中
        /// </summary>
        /// <param name="text"></param>
        private void UserSelect(string text)
        {
            ListBox_Select_Result.Items.Clear();
            if (text.Length == 0) return;
            foreach (var user in KeyData.Activity.UserStruchOnline)
            {
                if (user.IsPub) continue;
                if (user.IP.Contains(text) || user.Name.Contains(text) || user.Remarks.Contains(text))
                {
                    SkinListBoxItem it = new SkinListBoxItem();
                    it.Tag = user;
                    it.Text = string.Format("昵称:{0}\n备注:{1}\nIP:{2}", user.Name, user.Remarks, user.IP);
                    it.Image = Method.ResizeImage(user.HeadImage, new Size(40, 40));
                    ListBox_Select_Result.Items.Add(it);
                }
            }
        }

        /// <summary>
        /// 滚出窗体
        /// </summary>
        private void Rollout()
        {
            if (!IsRollin) return;
            Point p = MousePosition;
            var rc = new Rectangle(lastPoint, new Size(300, 30));
            if (!rc.Contains(p)) return;
            this.Pbar_schedule.Visible = false;
            Animation.窗体动画.Enter_Animate(this.Handle, Animation.Enter_Animations.自上向下滑动, 600);
            IsRollin = false;
            this.Pbar_schedule.Visible = true;
            this.Refresh();
        }

        Point lastPoint = Point.Empty;//鼠标离开时控件的最后头部位置
        /// <summary>
        /// 滚入窗体
        /// </summary>
        private void Rollin()
        {
            if (this.WindowState == FormWindowState.Minimized) return;
            if (Control.MouseButtons == MouseButtons.Left) return;
            if (!this.Shrink) return;
            if (IsRollin) return;
            if (this.Location.Y > 0) return;

            var rc = this.ClientRectangle;
            rc.X = this.Location.X;
            rc.Y = 0;
            if (rc.Contains(MousePosition)) return;
            lastPoint = rc.Location;
            Thread.Sleep(1000);
            if (rc.Contains(MousePosition)) return;
            IsRollin = true;
            this.Pbar_schedule.Visible = false;
            Animation.窗体动画.Leave_Animate(this.Handle, Animation.Leave_Animations.自下向上滑动, 600);
            this.Pbar_schedule.Visible = true;
        }

        /// <summary>
        /// 更新在线列表滚动条控件最大值
        /// </summary>
        public void UpdateScollBarMaxValue()
        {
            this.scrollBar_Online.Maximum = this.ListBox_Online.Items.Count;
            this.scrollBar_Online.ThumbHeight = this.ListBox_Online.Height / this.ListBox_Online.ItemHeight;
            this.scrollBar_Online.Visible = this.ListBox_Online.Items.Count * this.ListBox_Online.ItemHeight > this.ListBox_Online.Height;
        }

        private void SetScollBarImg()
        {
            Size size = new Size(16, this.scrollBar_Online.Height - 30);
            Bitmap[] bps = new Bitmap[2];

            Bitmap bmp_Thumb_Enter = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp_Thumb_Enter))
            {
                Rectangle rc = new Rectangle(5, 5, 7, size.Height - 10);
                SolidBrush bsh = new SolidBrush(Color.FromArgb(0, 206, 209));
                g.FillRectangle(bsh, rc);
            }
            Bitmap bmp_Thumb_Leave = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp_Thumb_Leave))
            {
                Rectangle rc = new Rectangle(5, 5, 7, size.Height - 10);
                SolidBrush bsh = new SolidBrush(Color.FromArgb(150, 0, 206, 209));
                g.FillRectangle(bsh, rc);
            }
            this.thumb_Enter = bmp_Thumb_Enter;
            this.thumb_Leave = bmp_Thumb_Leave;
            this.scrollBar_Online.ImageThumb = bmp_Thumb_Leave;


            size = new Size(16, 16);
            Bitmap bmp_Up = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp_Up))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                Point[] ps = new Point[]
                 {
                     new Point(8, 3),
                     new Point(3, 13),
                     new Point(13, 13),
                 };
                SolidBrush b = new SolidBrush(Color.FromArgb(150, 0, 206, 209));
                g.FillPolygon(b, ps);
            }
            this.scrollBar_Online.ImageUpArrow = bmp_Up;


            Bitmap bmp_Down = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp_Down))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                Point[] ps = new Point[]
                {
              new Point(3, 3),
              new Point(13, 3),
              new Point(8, 13),
                };
                SolidBrush b = new SolidBrush(Color.FromArgb(150, 0, 206, 209));
                g.FillPolygon(b, ps);
            }
            this.scrollBar_Online.ImageDownArrow = bmp_Down;

        }

        /// <summary>
        /// 刷新在线人数
        /// </summary>
        private void UpdateLableCount()
        {
            this.label_count.Text = "———————在线人数(" + (KeyData.Activity.UserStruchOnline.Count - 1) + ")人————————";
        }

        //滚动消息队列
        public CBlockQueue<string> ts = new CBlockQueue<string>();

        /// <summary>
        /// 等待滚动消息并执行
        /// </summary>
        private void RollMessage()
        {
            while (true)
            {
                string text = ts.Dequeue();
                int startTop = this.myPanel1.Height + this.lb_Roll.Height + 1;
                int endTop = -(this.lb_Roll.Height + 1);
                int sleepTop = this.myPanel1.Height - 24;
                this.lb_Roll.Text = text;
                for (int i = startTop; i > endTop; i -= 1)
                {
                    this.lb_Roll.Top = i;
                    if (i == sleepTop)
                    {
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Thread.Sleep(30);
                    }
                }
            }
        }
        #endregion

        private void panel_At_VisibleChanged(object sender, EventArgs e)
        {
            if (this.panel_At.Visible)
            {
                this.endStart = this.txb_input.SelectionStart;
                this.panel_At.BringToFront();
                this.AcceptButton = null;
            }
            else
            {
                this.AcceptButton = this.bt_Send;
            }
        }

        private void txb_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13) e.Handled = true;
            if (this.panel_At.Visible)
            {
                if ((int)e.KeyChar == (int)Keys.Down || (int)e.KeyChar == (int)Keys.Up) e.Handled = true;
            }
        }

        private void listBox_Ats_Click(object sender, EventArgs e)
        {
            if (this.listBox_Ats.SelectedIndex < 0) return;
            this.InsertAtName();
        }
    }
}