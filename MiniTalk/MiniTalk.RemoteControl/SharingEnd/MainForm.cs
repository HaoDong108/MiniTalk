using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using RDPCOMAPILib;
using System.Net;

namespace MiniTalk.RemoteControl.SharingEnd
{
    public partial class MainForm : Form
    {
        private RDPSessionClass _rdpSession = new RDPSessionClass();  //主要类
        private HostCaster _hostCaster; //用于发送连接字符串
        private Size ScreenSize = Method.GetSystemDpi(); //屏幕DPI
        private uint time = 0;
        System.Timers.Timer tik = new System.Timers.Timer() { Interval = 1000 };

        private string userName = string.Empty;//控制方名称
        private bool _isRunning = false;//标识是否正在共享
        private bool _isDemonstration = false;//标识是否启用了演示模式
        private bool IsDemonstration
        {
            get
            {
                return _isDemonstration;
            }
            set
            {
                if (_attendee ==null) return;
                _isDemonstration = value;
                if (value)
                {
                    _attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_VIEW;
                    this.lb_State.Text = userName + " 正在观看屏幕演示";
                    this.启用演示模式ToolStripMenuItem.Text = "关闭演示模式";
                    this.notifyIcon1.ShowBalloonTip(1000, "演示模式已启动", "对方现在无法与你的计算机进行交互", ToolTipIcon.Info);
                }
                else
                {
                    _attendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
                    this.lb_State.Text = userName + " 正在控制你的电脑";
                    this.启用演示模式ToolStripMenuItem.Text = "打开演示模式";
                    this.notifyIcon1.ShowBalloonTip(1000, "演示模式已关闭", "对方现在可以操控你的计算机了", ToolTipIcon.Info);
                }
            }
        }

        private IRDPSRAPIAttendee _attendee;//当前连接的用户

        public MainForm(IPAddress endIP,string userName)
        {
            InitializeComponent();
            this.ContrlAuto();
            this.userName = userName;
            this.lb_State.Visible = false;
            this.lb_State.Text ="正在由"+ userName + "操控";

            //订阅连接成功时的事件
            _rdpSession.OnAttendeeConnected += RdpSessionOnOnAttendeeConnected;
            //订阅连接断开时的事件
            _rdpSession.OnAttendeeDisconnected += RdpSessionOnOnAttendeeDisconnected;
            //设置屏幕共享区域
            _rdpSession.SetDesktopSharedRect(0, 0, ScreenSize.Width, ScreenSize.Height);
            tik.Elapsed += Tik_Elapsed;

            _hostCaster = new HostCaster(endIP);
            StartWork();
        }

        public MainForm()
        {
            InitializeComponent();
            this.ContrlAuto();
        }

        #region 事件

        private void Tik_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                this.time++;
                DateTime tim = DateTime.Parse(DateTime.Now.ToString("1970-01-01 00:00:00")).AddSeconds(this.time);
                this.Invoke(new Action(() => { this.lb_Time.Text = tim.ToLongTimeString(); }));
            }
            catch (Exception)
            { }
        }

        private void RdpSessionOnOnAttendeeDisconnected(object pDisconnectInfo)
        {
            this.BeginInvoke(new Action(() =>
            {
                this.Close();
            }));
        }

        private void RdpSessionOnOnAttendeeConnected(object pObjAttendee)
        {
            //获取用户实例
            IRDPSRAPIAttendee pAttendee = pObjAttendee as IRDPSRAPIAttendee;
            pAttendee.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
            this._hostCaster.KillSendTask();
            this.lb_State.Visible = true;
            Debug.WriteLine("连接成功：" + pAttendee.RemoteName + Environment.NewLine);
            this._attendee = pAttendee;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
                this.Close();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void bt_Close_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出远程协助？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bt_Close_MouseEnter(object sender, EventArgs e)
        {
            Size size = this.bt_Close.ImageSize;
            this.bt_Close.ImageSize = new Size(size.Width + 4, size.Height + 4);
        }

        private void bt_Close_MouseLeave(object sender, EventArgs e)
        {
            Size size = this.bt_Close.ImageSize;
            this.bt_Close.ImageSize = new Size(size.Width - 4, size.Width - 4);
        }

        private void HideToNotfyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.notifyIcon1.ShowBalloonTip(1000, "已最小化到托盘", "窗体已隐藏到托盘，若要重新打开请右键单击托盘图标", ToolTipIcon.Info);
        }

        private void 启用演示模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this._attendee ==null)
            {
                MessageBox.Show("没有其他计算机参与本次会话，无法启用演示模式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                return;
            }
            this.IsDemonstration = !this.IsDemonstration;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Method.FormeMove(this.Handle);
        }

        private void lb_Time_MouseDown(object sender, MouseEventArgs e)
        {
            Method.FormeMove(this.Handle);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.StopCast();
            this.tik.Stop();
            this.notifyIcon1.ShowBalloonTip(1000, "共享结束", "远程共享已结束", ToolTipIcon.Info);
            if(!this.IsDisposed)
            this.Dispose();
        }

        #endregion

        private void ContrlAuto()
        {
            double wh = this.Height * 0.64;
            this.bt_Close.ImageSize = new Size((int)wh, (int)wh);
            this.pictureBox1.Size = new Size(this.Height, this.Height);
        }

        /// <summary>
        /// 发送连接串等待连接
        /// </summary>
        private void StartWork()
        {
            this.tik.Start();
            try
            {
                //打开连接
                _rdpSession.Open();

                //创建用于连接的字符串
                IRDPSRAPIInvitation invitation = _rdpSession.Invitations.CreateInvitation("PalmaeTech", "CastGroup", "", 1);

                //广播发送字符串
                _hostCaster.StartCast(invitation.ConnectionString);

                notifyIcon1.Text = "远程协助已启动";
                notifyIcon1.ShowBalloonTip(1000, "远程协助启动成功", "远程协助已启动,请等待对方操控你的电脑", ToolTipIcon.Info);

                this.ShowInTaskbar = false;
                this.Hide();

                _isRunning = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _isRunning = false;
            }
        }

        /// <summary>
        /// 停止传输
        /// </summary>
        private void StopCast()
        {
            if (_isRunning)
            {
                _rdpSession.Close();
                Marshal.ReleaseComObject(_rdpSession);
                if(this._attendee!=null)
                Marshal.ReleaseComObject(_attendee);
                if(_hostCaster!=null) _hostCaster.StopCast();
                _isRunning = false;
            }
        }
    }
}
