using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Override_Control;

namespace MiniTalk.Custom_Control
{
    public partial class UC_Expression : UserControl
    {
        MyPanel panel1;//子面板
        TextBox box;
        public UC_Expression()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.panel1 = this.GetPanel();
            this.panel1.Location = new Point(0, 0);
            this.panel1.AutoSize = true;
            this.panel1.ControlAdded += Panel1_ControlAdded;
            this.panel_Parent.Controls.Add(this.panel1);

            this.AddImageToPanel();
        }

        /// <summary>
        /// 设置关联输入框
        /// </summary>
        /// <param name="box"></param>
        public void SetBox(TextBox box)
        {
            this.box = box;
            this.start = box.SelectionStart;
        }

        private void ControlAutoSize()
        {
            this.panel_Parent.Left = (this.Width - panel_Parent.Width) / 2;
            this.vScrollBar1.Left = this.panel_Parent.Left + this.panel_Parent.Width;
            this.vScrollBar1.Top = this.panel_Parent.Top;
            this.vScrollBar1.Size = new Size(15, this.panel_Parent.Height);
        }

        /// <summary>
        /// 初始化头像集合
        /// </summary>
        private void AddImageToPanel()
        {
            int x = 10;
            int y = 10;
            PictureBox pic;
            for (int i = 1; i <= 70; i++)
            {
                string name = "w" + (i);
                Point point = new Point(x, y);
                Image image = Method.ReadExpressionImage(name);
                pic = this.GetPicBox(name, point, image);
                this.toolTip1.SetToolTip(pic, "<" + i + ">");
                if ((i) % 9 == 0)
                {
                    x = 10;
                    y += pic.Height + 10;
                }
                else
                {
                    x += pic.Size.Width + 10;
                }
                this.panel1.Controls.Add(pic);
                image = null;
            }
        }

        /// <summary>
        /// 生成控件面板
        /// </summary>
        /// <returns></returns>
        private MyPanel GetPanel()
        {
            MyPanel panel = new MyPanel
            {
                BackColor = System.Drawing.Color.White,
                BorderStyle = System.Windows.Forms.BorderStyle.None,
                Location = new System.Drawing.Point(100, 55),
                Size = this.panel_Parent.Size,
                Padding = new Padding(0, 0, 0, 10)
            };
            return panel;
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
                Size = new Size(30, 30),
                Cursor = Cursors.Hand,
                BorderStyle = BorderStyle.None,
                Visible = true
            };
            pic.MouseEnter += Pic_MouseEnter;
            pic.MouseLeave += Pic_MouseLeave;
            pic.Click += Pic_Click;

            return pic;
        }

        int start;
        private void Pic_Click(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            string text = this.toolTip1.GetToolTip(pic);
            this.box.Text = this.box.Text.Insert(this.start, text);
            this.start += text.Length;
        }
        private void Pic_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Location = new Point(pic.Location.X + 3, pic.Location.Y + 3);
            pic.Size = new Size(pic.Width - 6, pic.Height - 6);
            pic.BringToFront();
        }
        private void Pic_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Location = new Point(pic.Location.X - 3, pic.Location.Y - 3);
            pic.Size = new Size(pic.Width + 6, pic.Height + 6);
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
            { }
            base.OnMouseWheel(e);
        }


        /*
         * 其他
         */
        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            this.vScrollBar1.Maximum = this.panel1.Height - this.panel_Parent.Height;
        }
        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.panel1.Top = -this.vScrollBar1.Value;
        }

        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
