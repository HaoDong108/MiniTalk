using Override_Control;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniTalk
{
    public partial class ScreenShots : Form
    {
        MyPanel panel_Select;
        MyPanel panel_Meng;

        /// <summary>
        /// 指示是否成功保存截图至剪切板
        /// </summary>
        public bool OverSave { get; set; }

        public ScreenShots(Bitmap bmp)
        {
            InitializeComponent();
            this.OverSave = false;
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImage = bmp;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            MyPanel panel = new MyPanel();
            panel.Name = "panel_Select";
            panel.Size = new Size(1, 1);
            panel.Visible = false;
            panel.BackColor = Color.Transparent;
            panel.Parent = this;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            MyPanel m = new MyPanel();
            m.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            m.Dock = System.Windows.Forms.DockStyle.Fill;
            m.Location = new System.Drawing.Point(0, 0);
            m.Name = "panel1";
            m.Size = new System.Drawing.Size(1007, 574);
            m.TabIndex = 0;
            m.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            m.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            m.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            m.Cursor = Cursors.Cross;

            this.Controls.Add(panel);
            this.Controls.Add(m);
            panel.BringToFront();
            this.panel_Select = panel;
            this.panel_Meng = m;
        }

        bool mouseDown = false;
        Point dp = Point.Empty; //按下时鼠标坐标
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            dp = new Point(e.X, e.Y);
            this.panel_Select.Visible = true;
            this.panel_Select.Location = dp;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
            //this.panel_Select.Visible = false;
            if (this.panel_Select.Width == 1 && this.panel_Select.Width == 1)
            {
                return;
            }
            this.SaveSelectRect(new Rectangle(this.panel_Select.Location, this.panel_Select.Size));
            this.Close();
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mouseDown) return;
            if (e.X < dp.X && e.Y >= dp.Y) this.panel_Select.Location = new Point(e.X, dp.Y);
            if (e.X > dp.X && e.Y <= dp.Y) this.panel_Select.Location = new Point(dp.X, e.Y);
            if (e.X < dp.X && e.Y < dp.Y) this.panel_Select.Location = e.Location;
            this.panel_Select.Width = Math.Abs(e.X - dp.X) - 2;
            this.panel_Select.Height = Math.Abs(e.Y - dp.Y) - 2;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (mouseDown)
                {
                    this.panel_Select.Size = new Size(1, 1);
                    this.mouseDown = false;
                    this.panel_Select.Visible = false;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void SaveSelectRect(Rectangle re)
        {
            if (re.Width <= 10 || re.Height <= 10)
            {
                MessageBox.Show("选择区域过小,保存失败");
                return;
            }
            Bitmap bmp = this.BackgroundImage as Bitmap;
            Bitmap res = new Bitmap(re.Width, re.Height);
            Graphics g = Graphics.FromImage(res);
            g.DrawImage(bmp.Clone(re, System.Drawing.Imaging.PixelFormat.Format24bppRgb), Point.Empty);
            g.Dispose();
            Clipboard.SetImage(res);
            this.panel_Select.BackgroundImage = res;
            this.panel_Meng.Visible = false;
            this.BackgroundImage = null;
            this.panel_Select.Location = new Point((this.Width - this.panel_Select.Width) / 2, (this.Height - this.panel_Select.Height) / 2);
            this.OverSave = true;
        }
    }
}
