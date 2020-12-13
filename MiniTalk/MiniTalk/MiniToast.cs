using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniTalk.Model;

namespace MiniTalk
{
    public partial class MiniToast : Form
    {
        System.Timers.Timer timer_Hide = new System.Timers.Timer() { Interval = 40 };
        Size screenSzie = Screen.AllScreens[0].WorkingArea.Size;

        private string _senderName;
        private string _text;
        private Image _img;
        private int showtime = 1000;
        Transmission.MesType _icoType;

        /// <summary>
        /// 发送者昵称
        /// </summary>
        public string U_SenderName
        {
            get { return _senderName; }
            set
            {
                _senderName = value;
                this.lb_name.Text = value + ":";
            }
        }

        /// <summary>
        /// 消息内容
        /// </summary>
        public string U_MesText
        {
            get { return _text; }
            set
            {
                _text = value;
                this.lb_text.Text = value;
            }
        }

        /// <summary>
        /// 头像图标
        /// </summary>
        public Image U_Img
        {
            get { return this._img; }
            set
            {
                if (value == null) return;
                this._img = value;
                this.pic_ico.Image = value;
            }
        }

        /// <summary>
        /// 消息类型
        /// </summary>
        public Transmission.MesType U_IcoType
        {
            get
            {
                return _icoType;
            }
            set
            {
                this._icoType = value;
                switch (value)
                {
                    case Transmission.MesType.图片消息:
                        this.lb_text.ForeColor = Color.Yellow;
                        break;
                    case Transmission.MesType.文本消息:
                        this.lb_text.ForeColor = Color.FromArgb(224, 224, 224);
                        break;
                    case Transmission.MesType.文件消息:
                        this.lb_text.ForeColor = Color.FromArgb(0xFF00FF);
                        break;
                    case Transmission.MesType.事件消息:
                        break;
                    default:
                        break;
                }
            }
        }

        public MiniToast()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.DarkTurquoise;
            this.TransparencyKey = this.BackColor;
            this.Location = new Point(this.screenSzie.Width, this.screenSzie.Height - this.Height - 20);
            this.timer_Hide.Elapsed += Timer_Hide_Elapsed;
        }

        protected override void OnShown(EventArgs e)
        {
            this.Translation();
            this.timer_Hide.Start();
        }
        private void Translation()
        {
            var x = this.Left;
            int trg = this.screenSzie.Width - 20;
            while ((this.Left + this.Width) > trg)
            {
                this.Refresh();
                this.Left -= 15;
                if (this.Left + this.Width < trg) this.Left = trg - Width;
                Thread.Sleep(10);
            }
        }

        public void ShiftTop(object sender, ToastAddEventAgs e)
        {
            var t = new Task(() =>
            {
                int y = this.Location.Y;
                for (int i = 1; i <= this.Height + 10; i += 5)
                {
                    try
                    {
                        if (this.IsDisposed) break;
                        this.Top = y - i;
                    }
                    catch (Exception) { break; }
                    Thread.Sleep(20);
                }
            });
            e.tasks.Add(t);
            t.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Color border = Color.FromArgb(0, 0xce, 0xd2);
            Bitmap bmp = DSAPI.图形图像.绘制圆角矩形(this.Size, 30, Color.Black, border);
            g.DrawImage(bmp, Point.Empty);
        }

        private void Timer_Hide_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (this.showtime > 0)
            {
                this.showtime -= 25;
                return;
            }
            if (this.Opacity < 0.05)
            {
                this.Close();
                this.Dispose();
                this.timer_Hide.Dispose();
            }
            this.Opacity -= 0.008;
        }

        private void Layout_Panel_Paint(object sender, PaintEventArgs e)
        {
            Point dp = new Point(this.Width - 40, 5);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            switch (this.U_IcoType)
            {
                case Transmission.MesType.图片消息:
                    e.Graphics.DrawImage(FixedImages.type_img, dp);
                    break;
                case Transmission.MesType.文本消息:
                    e.Graphics.DrawImage(FixedImages.type_text, dp);
                    break;
                case Transmission.MesType.文件消息:
                    e.Graphics.DrawImage(FixedImages.type_file, dp);
                    break;
            }
        }
    }
}
