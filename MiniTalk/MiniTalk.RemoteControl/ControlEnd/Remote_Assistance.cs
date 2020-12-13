using AxRDPCOMAPILib;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTalk.RemoteControl.ControlEnd
{
    public partial class Remote_Assistance : Form
    {
        private bool _isConnected = false;
        private HostFinder _hostFinder;
        /// <summary>
        /// 标识是否连接成功
        /// </summary>
        private bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                if (value)
                {
                    this.lb_Wait.Visible = false;
                }
                else
                {
                    this.lb_Wait.Visible = true;
                }
            }
        }

        public Remote_Assistance(IPAddress otip,string userName)
        {
            InitializeComponent();
            this.ContrlAuto();
            CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Maximized;
            this.lb_UserName.Text = userName;
            this.Text = "远程协助-" + userName;
            _hostFinder = new HostFinder(otip);
            _hostFinder.HostFound += HostFinderOnHostFound;
            _hostFinder.ConnectionTimeOut += _hostFinder_ConnectionTimeOut;
            _hostFinder.StartFind();

            axRDPViewer1.OnConnectionEstablished += AxRdpViewer1OnOnConnectionEstablished;
            axRDPViewer1.OnConnectionFailed += AxRdpViewer1OnOnConnectionFailed;
            axRDPViewer1.OnConnectionTerminated += AxRdpViewer1OnOnConnectionTerminated;
        }

        public Remote_Assistance()
        {
            InitializeComponent();
            this.ContrlAuto();
            CheckForIllegalCrossThreadCalls = false;
            this.WindowState = FormWindowState.Maximized;
        }

        //连接超时时触发
        private void _hostFinder_ConnectionTimeOut(EventArgs obj)
        {
            IsConnected = false;
            notifyIcon1.ShowBalloonTip(3000, "连接超时", "远程桌面连接超时", ToolTipIcon.Error);
            this.Close();
        }

        //连接结束时触发
        private void AxRdpViewer1OnOnConnectionTerminated(object sender, _IRDPSessionEvents_OnConnectionTerminatedEvent irdpSessionEventsOnConnectionTerminatedEvent)
        {
            _isConnected = false;
            this.Invoke(new Action(() =>
            {
                this.Close();
            }));
        }

        //连接失败触发 
        private void AxRdpViewer1OnOnConnectionFailed(object sender, EventArgs eventArgs)
        {
            IsConnected = false;
            notifyIcon1.ShowBalloonTip(1000, "连接失败", "远程桌面连接失败,程序退出", ToolTipIcon.Error);
            this.Close();
        }

        //连接成功触发
        private void AxRdpViewer1OnOnConnectionEstablished(object sender, EventArgs eventArgs)
        {
            IsConnected = true;
            this.Invoke(new Action(() =>
            {
                this.TopMost = true;
                this.WindowState = FormWindowState.Maximized;
                this.Hide();
                this.Show();
                notifyIcon1.ShowBalloonTip(1000, "连接成功", "远程桌面控制端连接成功", ToolTipIcon.Info);
            }));
        }

        //收到连接字符串触发
        private void HostFinderOnHostFound(object sender, HostFoundEventArgs args)
        {
            try
            {
                if (args.IsCasting) //如果同意了连接请求
                {
                    if (!_isConnected) //如果当前状态为非连接状态
                    {
                        axRDPViewer1.SmartSizing = true;
                        axRDPViewer1.Connect(args.ConnectionString, Environment.UserName, "");
                    }
                }
                else
                {
                    if (_isConnected)
                    {
                        notifyIcon1.ShowBalloonTip(1000, "连接失败", args.Additionalinfo, ToolTipIcon.Info);
                        axRDPViewer1.Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception:" + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.axRDPViewer1.Disconnect();
            this.notifyIcon1.ShowBalloonTip(1000, "远程控制已结束", "本次远程控制已经结束！", ToolTipIcon.Info);
            base.OnFormClosing(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            this.axRDPViewer1.Size = this.Size;
            this.panel_Menu.Left = this.Width / 2 - (panel_Menu.Width / 2);
            this.lb_Wait.Left = (this.Width - this.lb_Wait.Width) / 2;
            this.lb_Wait.Top = (this.Height - this.lb_Wait.Height) / 2-50;
        }

        #region 浮动菜单
        bool hasBorder=false;
        bool isPull=false;
        private void bt_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_ShowBorder_Click(object sender, EventArgs e)
        {
            if (hasBorder)
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = FormBorderStyle.None;
                hasBorder = false;
                this.SetVisibleCore(false);
                this.bt_ShowBorder.Image = Images.窗口模式;
                this.toolTip1.SetToolTip(this.bt_ShowBorder, "窗口模式");
                this.SetVisibleCore(true);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                hasBorder = true;
                this.bt_ShowBorder.Image = Images.全屏副本;
                this.toolTip1.SetToolTip(this.bt_ShowBorder, "全屏模式");
                this.Location = new Point(0, 0);
            }
        }

        private void bt_Pull_Click(object sender, EventArgs e)
        {
            if (isPull)
            {
                isPull = false;
                this.panel_Menu.Top = -(this.panel_Menu.Height-this.bt_Pull.Height)+2;
                this.bt_Pull.Image = Images.下拉;
            }
            else
            {
                isPull =true;
                this.panel_Menu.Top = 0;
                this.bt_Pull.Image = Images.上拉;
            }
        }
        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 最小化
                return cp;
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 最小化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void 最大化ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void ContrlAuto()
        {
            double wh = this.panel_Menu.Height * 0.62;
            this.bt_ShowBorder.ImageSize = new Size((int)wh, (int)wh);
            this.bt_Close.ImageSize = this.bt_ShowBorder.ImageSize;
        }
    }
}
