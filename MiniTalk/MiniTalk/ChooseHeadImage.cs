using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using  CCWin.SkinControl;
using Override_Control;

namespace MiniTalk
{
    public partial class ChooseHeadImage : Form
    {
        MyPanel panel1;

        public Image SelectImage { get; private set; } 
        public string SelectImageName { get; private set; } 

        public ChooseHeadImage()
        {
            InitializeComponent();
            Method.FormShadow(this);
            SelectImage= HeadImages.im1;
            SelectImageName= "im1";
            Thread.CurrentThread.IsBackground = true;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.panel1 = this.GetPanel();
            this.panel1.Location = new Point(0, 0);
            this.panel1.AutoSize = true;
            this.panel1.ControlAdded += Panel1_ControlAdded;
            this.panel_Panent.Controls.Add(this.panel1);
            this.bt_Confirm.Image = HeadImages.im1;
            this.Refresh();
        }

        private void ChooseHeadImage_Load(object sender, EventArgs e)
        {
            this.panel1.Width = this.panel_Panent.Width;
            this.AddImageToPanel();
            Animation.窗体动画.Enter_Animate(this.Handle, Animation.Enter_Animations.自左向右滑动, 600);
            this.ControlAutoSize();
        }

        private void ControlAutoSize()
        {
            this.panel1.Size = new Size((int)(Width * 0.86), (int)(Height * 0.73));
            this.bt_Confirm.Left = (this.Width / 2) - (this.bt_Confirm.Width / 2);
            this.panel_Panent.Left = (this.Width / 2) - (this.panel_Panent.Width / 2);
            this.vScrollBar1.Left = this.panel_Panent.Location.X + this.panel_Panent.Width;
            this.vScrollBar1.Top = this.panel_Panent.Top;
            this.vScrollBar1.Size = new Size(20, this.panel_Panent.Height);
            int btimgwh = (int)(this.bt_Confirm.Height * 0.784);
            this.bt_Confirm.ImageSize = new Size(btimgwh, btimgwh);
        }

        /// <summary>
        /// 初始化头像集合
        /// </summary>
        private void AddImageToPanel()
        {
            int x = 0;
            int y = 0;
            PictureBox pic;
            int cs = this.panel1.Width / 60;
            int yu = this.panel1.Width % 60 / 2;
            x = yu;
            for (int i = 1; i <=73; i++)
            {
                string name = "im" + (i);
                Point point = new Point(x, y);
                Image image = Method.ReadHeadImage(name);
                pic = this.GetPicBox(name, point, image);
                if ((i) % cs == 0)
                {
                    x = yu;
                    y += pic.Height+20;
                }
                else
                {
                    x += pic.Size.Width+10;
                }
                this.panel1.Controls.Add(pic);
                image = null;
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        /// <summary>
        /// 生成图片框
        /// </summary>
        /// <param name="name">控件名</param>
        /// <param name="point">控件坐标</param>
        /// <param name="image">控件图片</param>
        /// <returns></returns>
        private PictureBox GetPicBox(string name, Point point, Image image)
        {
            PictureBox pic = new PictureBox
            {
                Name = name,
                BackgroundImage = image,
                Location = point,
                BackColor = Color.Transparent,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(50, 50),
                Margin = new Padding(20),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.None,
                Visible = true
            };
            pic.MouseEnter += Pic_MouseEnter;
            pic.MouseLeave += Pic_MouseLeave;
            pic.Click += Pic_Click;

            return pic;
        }

        /// <summary>
        /// 生成面板
        /// </summary>
        /// <returns></returns>
        private MyPanel GetPanel()
        {
            Size size = new Size(550,360);
            Point p = new Point(35, 70);
            MyPanel panel = new MyPanel
            {
                BackColor = Color.FromArgb(22,24,28),
                Location= p,
                Size=size,
                Padding = new Padding(0, 0, 0, 10)
            };
            return panel;
        }
        #region 事件块
        /*
         * 头像鼠标事件
         */
        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            this.SelectImageName = pic.Name;
            this.SelectImage = pic.BackgroundImage;
            this.bt_Confirm.Image = pic.BackgroundImage;
        }
        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Size = new Size(pic.Width - 10, pic.Height - 10);
            pic.Location = new Point(pic.Location.X + 5, pic.Location.Y + 5);
            pic.BringToFront();
        }
        private void Pic_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Size = new Size(pic.Width + 10, pic.Height + 10);
            pic.Location = new Point(pic.Location.X - 5, pic.Location.Y - 5);
        }
       
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Method.FormMove(this.Handle);
        }

        /*
         * 杂项处理事件
         */ 
        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.panel1.Top = -this.vScrollBar1.Value;
        }
        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            this.vScrollBar1.Maximum = this.panel1.Height - this.panel_Panent.Height;
        }
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int val = 0;
            this.panel1.BeginInvoke(new Action(() =>
            {
                if ((int)Math.Abs(this.vScrollBar1.Value - val) > 30)
                {
                    this.panel1.Refresh();
                    val = this.vScrollBar1.Value;
                }
            }
            ));
        }
        private void ChooseHeadImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Animation.窗体动画.Leave_Animate(this.Handle, Animation.Leave_Animations.自右向左滑动, 600);
        }

        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            SkinButton bt = sender as SkinButton;
            Size s = bt.Size;
            Size size = bt.ImageSize;
            Animation.窗体动画.Leave_Animate(this.Handle, Animation.Leave_Animations.自右向左滑动, 500);
            this.Close();

        }

        private void ChooseHeadImage_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Brushes.DarkTurquoise);

            //绘制顶部装饰线条
            Point p1 = new Point(5, 36);
            Point p2 = new Point(pictureBox1.Left-40,p1.Y);
            Point p3 = new Point(this.pictureBox1.Left, this.pictureBox1.Top + this.pictureBox1.Height-10);
            Point pext = new Point(p3.X + 7, p3.Y); 
            Point[] ps1 = new Point[] { p1, p2, p3,pext };
            e.Graphics.DrawLines(pen, ps1);
            
            Point p4 = new Point(p3.X + pictureBox1.Width, p3.Y);
            Point p5 = new Point(pictureBox1.Right + 40, p2.Y);
            Point p6 = new Point(this.Width - 5, p1.Y);
            pext = new Point(p4.X - 9, p4.Y);
            Point[] ps2 = new Point[] {pext,p4, p5, p6 };
            e.Graphics.DrawLines(pen, ps2);

            //绘制按钮装饰线条
            Point b1 = new Point(5,this.bt_Confirm.Top+35);
            Point b2 = new Point(bt_Confirm.Location.X, b1.Y);
            e.Graphics.DrawLine(pen, b1, b2);

            Point b3 = new Point(bt_Confirm.Location.X + bt_Confirm.Width, b2.Y);
            Point b4 = new Point(this.Width-5 + bt_Confirm.Width, b2.Y);
            e.Graphics.DrawLine(pen, b3, b4);
        }

        private void bt_Small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
        /*
        * 绑定鼠标滚轮
        */
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int v = 30;
            try
            {
                if (e.Delta > 0)
                {
                    if (vScrollBar1.Value - v < 0)
                    {
                        vScrollBar1.Value = 0;
                    }
                    this.vScrollBar1.Value -= v;
                }
                if (e.Delta < 0)
                {
                    if (vScrollBar1.Value + v > vScrollBar1.Maximum)
                    {
                        vScrollBar1.Value = vScrollBar1.Maximum;
                    }
                    this.vScrollBar1.Value += v;
                }
            }
            catch (Exception)
            {}
            base.OnMouseWheel(e);
        }
        #endregion

        private void panel_Panent_SizeChanged(object sender, EventArgs e)
        {
            if (this.panel1 != null)
            {
                
            }
        }
    }
}
