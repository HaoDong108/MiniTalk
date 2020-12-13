using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using MiniTalk.Custom_Control;
using MiniTalk.Model;
using MiniTalk.Net;

namespace MiniTalk
{
    public partial class MS_Label : UserControl
    {
        UserData user;  //控件所属用户
        bool We;        //气泡归属   
        bool inPub = false; //表示当前控件是否处于公共会话内
        string ti = "💼"; //表情占位符
        Font font = new Font("微软雅黑", 10, FontStyle.Regular, GraphicsUnit.Point);
        RichTextBox tbx = null;
        FileMes fmes = null;
        PictureBox picmes = null;
        List<Image> images = new List<Image>(); //表情序列集合
        SkinVScrollBar scroll;

        /// <summary>
        /// 当用户被@时触发
        /// </summary>
        public event Action<MS_Label, UserData> AtUserEvent;

        /// <summary>
        /// 消息控件构造器
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="we">是否为本地消息</param>
        /// <param name="width">容器宽度</param>
        /// <param name="showtime">是否显示时间</param>
        /// <param name="data">绑定的用户</param>
        /// <param name="scroll">绑定的父级滚动条</param>
        public MS_Label(bool we,bool inPub, UserData data, SkinVScrollBar bar)
        {
            this.user = data;
            this.inPub = inPub;
            this.We = we;
            this.scroll = bar;
            InitializeComponent();
            this.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left;
            CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);

            this.lb_nowTime.Location = new Point(0, 0);
            this.lb_Name.Location = new Point(this.HeadImage.Width + 22, 12);
            this.lb_Name.Visible = !we;
            this.lb_Name.TextAlign = ContentAlignment.MiddleLeft;
            //设置头像
            this.HeadImage.BackgroundImage = we ? KeyData.StaticInfo.MyUser.HeadImage : this.user.HeadImage;
            //设置昵称
            this.lb_Name.Text = data.ToString();
            //设置时间显示标签
            this.lb_nowTime.Text = "——（" + DateTime.Now.ToShortTimeString() + "）——";
        }

        #region 对外接口
        /// <summary>
        /// 设置消息内容
        /// </summary>
        public void SetText(string message, bool showtime)
        {
            //获得气泡
            this.tbx = this.GetRichTextBox(message, this.We);
            //将表情占位符情替换为表情
            this.InsertExp(this.tbx);
            this.images.Clear();
            //添加到主体中
            this.Controls.Add(tbx);
            SetLocation_Mes();
            this.Height = this.tbx.Location.Y + this.tbx.Height + 20;
            this.Controls.Remove(this.label1);
            this.lb_nowTime.Visible = showtime;
        }

        /// <summary>
        /// 插入文件消息(本地)
        /// </summary>
        /// <param name="path"></param>
        public void SetLocalFileMes(string path, bool showtime)
        {
            this.fmes = new FileMes(user.IP);
            fmes.SetInfo(path);
            fmes.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            SetLocation_File();
            this.Height = fmes.Location.Y + fmes.Height + 10;
            this.Controls.Remove(this.label1);
            this.Controls.Add(fmes);
            this.lb_nowTime.Visible = showtime;
        }

        /// <summary>
        /// 插入文件消息(网络)
        /// </summary>
        /// <param name="path"></param>
        public void SetNetFileMes(Transmission.NetFileData data, bool showtime, bool ispubmes)
        {
            fmes = new FileMes(user.IP);
            fmes.SetInfo(data);
            fmes.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            SetLocation_File();
            this.Height = fmes.Location.Y + fmes.Height + 10;
            this.Controls.Remove(this.label1);
            this.Controls.Add(fmes);
            this.lb_nowTime.Visible = showtime;
            fmes.FileDownLoadOver += (end, filename) =>
            {
                string mes = string.Format("{0}接收了文件\"{1}\"", KeyData.StaticInfo.MyUser.Name, filename);
                if (ispubmes)
                {
                    Transmitters.Sender.SendEventMessageToAll(mes);
                }
                else
                {
                    Transmitters.Sender.SendEventMessage(end, mes);
                }
            };
        }

        /// <summary>
        /// 插入图片消息
        /// </summary>
        /// <param name="image"></param>
        /// <param name="showtime"></param>
        public void SetPicMessage(Image image, bool showtime)
        {
            this.Controls.Remove(this.label1);
            this.picmes = GetPicBox(image);
            SetLocation_Pic();
            this.Height = this.picmes.Location.Y + this.picmes.Height + 10;
            this.Controls.Add(picmes);
            this.lb_nowTime.Visible = showtime;
        }

        /// <summary>
        /// 设置指定范围文本格式
        /// </summary>m>
        public void SetFontFormat(int start, int len, Font font, Color color)
        {
            if (this.tbx == null) return;
            if (this.tbx.Text.Length < len) len = this.tbx.Text.Length;
            this.tbx.Select(start, len);
            this.tbx.SelectionColor = color;
            this.tbx.SelectionFont = font;
        }

        #endregion
        /// <summary>
        /// 绘制气泡
        /// </summary>
        private void MS_Label_Paint(object sender, PaintEventArgs e)
        {
            if (this.tbx == null) return;
            this.Draw_MsBack(e.Graphics,
            this.tbx.Location.X - (10 / 2 + 5),
            this.tbx.Location.Y - 10 / 2,
            this.tbx.Width,
            this.tbx.Height,
            10,
            this.We
            );
        }

        /// <summary>
        /// 绘制聊天气泡圆角边框
        /// </summary>
        /// <param name="g">进行绘制的画笔</param>
        /// <param name="brush">绘制的颜色</param>
        /// <param name="X">气泡坐标X</param>
        /// <param name="Y">气泡坐标Y</param>
        /// <param name="W">气泡宽度</param>
        /// <param name="H">气泡高度</param>
        /// <param name="d">圆角直径</param>
        /// <param name="We">是否为我方气泡</param>
        private void Draw_MsBack(Graphics g, int X, int Y, int W, int H, int d, bool We)
        {
            Brush brush;
            if (We)
            {
                brush = Brushes.DeepSkyBlue;
            }
            else
            {
                brush = Brushes.White;
            }
            //指定消除锯齿
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //规制圆角
            g.FillEllipse(brush, X, Y, d, d);                      //左上
            g.FillEllipse(brush, (X + W), Y, d, d);                //右上
            g.FillEllipse(brush, X, (Y + H + 3), d, d);            //左下
            g.FillEllipse(brush, (X + W), (Y + H + 3), d, d);      //右下
            //绘制边缘方块
            g.FillRectangle(brush, X, Y + (d / 2), d, H + 3);      //左侧
            g.FillRectangle(brush, (X + W), Y + (d / 2), d, H + 3);//右侧
            g.FillRectangle(brush, (X + (d / 2)), Y, W, d);        //上侧
            g.FillRectangle(brush, (X + (d / 2)), Y + H + 3, W, d);//下侧
            //绘制文字区域方块
            g.FillRectangle(brush, X + d, Y + d, W - d, H - d);
            //绘制气泡拖尾
            Point[] points;
            if (We)//判断拖尾方向
            {
                Point p1 = new Point(X + (W + d), Y + (d - 5));
                Point p2 = new Point(X + (W + d), Y + (d + 5));
                Point p3 = new Point(X + (W + d + 10), Y + (d - 8));
                points = new Point[] { p1, p2, p3 };
            }
            else
            {
                Point p1 = new Point(X, Y + (d - 5));
                Point p2 = new Point(X, Y + (d + 5));
                Point p3 = new Point(X - 10, Y + (d - 8));
                points = new Point[] { p1, p2, p3 };
            }
            g.FillPolygon(brush, points);
        }

        /// <summary>
        /// 返回内容框
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="we">是否为本地消息</param>
        /// <returns></returns>
        private RichTextBox GetRichTextBox(string message, bool we)
        {
            RichTextBox tbx = new RichTextBox
            {
                BorderStyle = BorderStyle.None,
                Font = this.font,
                MaximumSize = new Size(500, 1000),
                WordWrap = true,
                Height = 5
            };

            tbx.MouseWheel += RichtexBox_MouseWheel;
            tbx.MouseUp += RichtexBox_MouseUp;
            tbx.MouseDown += RichtexBox_MouseDown;

            tbx.BackColor = we ? Color.DeepSkyBlue : Color.White;
            tbx.ForeColor = we ? Color.White : Color.Black;

            tbx.ScrollBars = RichTextBoxScrollBars.None;
            tbx.WordWrap = true;
            this.SetFormat(ref tbx, message);
            this.Controls.Remove(label1);
            return tbx;
        }

        //设置选中文本框内容时，鼠标拖出会话框外的自动拖放
        bool isUp = true;
        private void RichtexBox_MouseDown(object sender, MouseEventArgs e)
        {
            isUp = false;
            RichTextBox box = sender as RichTextBox;
            var cancel = new CancellationTokenSource(30000);
            if (box.TextLength > 50)
            {
                Task.Run(new Action(() =>
                {
                    while (!isUp && !cancel.IsCancellationRequested)
                    {
                        if (KeyData.form1.txb_input.PointToClient(Control.MousePosition).Y >= -10)
                        {
                            try
                            {
                                this.scroll.Value += 10;
                            }
                            catch (Exception)
                            { }
                        }
                        if (KeyData.form1.txb_input.PointToClient(Control.MousePosition).Y <= -(KeyData.form1.ListBox_Online.Height - 120))
                        {
                            try
                            {
                                this.scroll.Value -= 10;
                            }
                            catch (Exception)
                            { }
                        }
                        Thread.Sleep(20);
                    }
                    Debug.WriteLine("自动拖放线程成功退出");
                }), cancel.Token);
            }
        }
        private void RichtexBox_MouseUp(object sender, MouseEventArgs e)
        {
            isUp = true;
        }

        // 在文本框内滑动鼠标滚轮时联动父级滚动条
        private void RichtexBox_MouseWheel(object sender, MouseEventArgs e)
        {
            int v = 50;
            try
            {
                if (e.Delta > 0)
                {
                    if (scroll.Value - v < scroll.Minimum)
                    {
                        scroll.Value = scroll.Minimum;
                    }
                    this.scroll.Value -= v;
                }
                if (e.Delta < 0)
                {
                    if (scroll.Value + v > scroll.Maximum)
                    {
                        scroll.Value = scroll.Maximum;
                    }
                    this.scroll.Value += v;
                }
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 设置调整内容控件的大小
        /// </summary>
        /// <param name="rich"></param>
        /// <param name="str">文本内容</param>
        private void SetFormat(ref RichTextBox rich, string str)
        {
            //❤🍀🍎☎🔥👽🎒
            label1.Font = rich.Font;
            //将表情占位符替换为与表情基本等宽的字符

            Regex rx = new Regex(@"<[0-9]{1,2}>");
            while (rx.IsMatch(str))
            {
                Match m = rx.Match(str);
                string text = m.Value;
                int num = int.Parse(text.Trim('<').Trim('>'));
                str = str.Remove(m.Index, m.Length);
                str = str.Insert(m.Index, ti);
                if (num <= 70 && num > 0)
                this.images.Add(this.We ? Method.ReadExpressionImage("b" + num) : Method.ReadExpressionImage("w" + num));
            }

            label1.Text = str;
            rich.Text = str;
            rich.Size = new Size(label1.Width, rich.Lines.Length > 1 ? label1.Height + 15 : label1.Height);

            if (this.inPub)
            {
                Regex re = new Regex(@"\@.{1,6} ");
                for (int i = 0; i < rich.Lines.Length; i++)
                {
                    //获取<i行的文本字符总数
                    int bits = 0;
                    for (int j = 0; j < i; j++) bits += rich.Lines[j].Length;

                    foreach (Match ms in re.Matches(rich.Lines[i]))
                    {
                        rich.Select(i > 0 ? ms.Index + bits + i : ms.Index, ms.Length);
                        rich.SelectionFont = new Font("微软雅黑", 10, FontStyle.Bold, GraphicsUnit.Point);
                        rich.SelectionColor = this.We ? Color.Yellow : Color.DeepSkyBlue;
                    }
                }
            }
            Debug.WriteLine("行数:" + rich.Lines.Length);
        }

        /// <summary>
        /// 返回装载图片的图片控件
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        private PictureBox GetPicBox(Image image)
        {
            PictureBox box = new PictureBox();
            box.BackgroundImage = image;
            box.BorderStyle = BorderStyle.None;
            box.MinimumSize = new Size(100, 100);
            box.SizeMode = PictureBoxSizeMode.Zoom;
            box.BackgroundImageLayout = ImageLayout.Zoom;
            box.MaximumSize = new Size(400, 700);
            box.Size = GetProportion(image.Size);
            box.Cursor = Cursors.Hand;
            box.Image = DSAPI.图形图像.绘制圆角矩形(box.Size, 20, Color.Transparent, Color.Transparent, Color.Black, 10);
            this.toolTip1.SetToolTip(box, "点击查看图片");
            box.MouseEnter += (sender, e) => { box.BorderStyle = BorderStyle.FixedSingle; };
            box.MouseLeave += (sender, e) => { box.BorderStyle = BorderStyle.None; };
            box.Click += (sender, e) => { Method.ShowImage(image); };
            box.Paint += (sender, e) =>
            {
                e.Graphics.DrawImage(FixedImages.放大, new Point(box.Width - 40, box.Height - 40));
            };
            return box;
        }

        /// <summary>
        /// 获得最佳尺寸
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Size GetProportion(Size size)
        {
            if (size.Width <= 200 && size.Height <= 200)
            {
                return size;
            }
            int w = size.Width;
            int h = size.Height;
            float tage = 1f;
            while (w >= 200 && h >= 200)
            {
                w = int.Parse((size.Width * tage).ToString("f0"));
                h = int.Parse((size.Height * tage).ToString("f0"));
                tage -= 0.05f;
            }

            return new Size(w, h);
        }

        /// <summary>
        /// 将控件中的指定字符转换为表情
        /// </summary>
        /// <param name="rich">传入Myrichtextbox</param>
        private void InsertExp(RichTextBox rich)
        {
            Image img;
            rich.ReadOnly = false;
            for (int i = 0; i < images.Count; i++)
            {
                img = Method.ResizeImage(images[i], new Size(22, 22));
                IDataObject data = new DataObject();
                data.SetData(img);
                Clipboard.SetDataObject(data, false);//将图片放在剪贴板中
                rich.Select(rich.Text.IndexOf(ti), ti.Length);
                rich.Paste();//粘贴数据
            }
            Clipboard.Clear();
            rich.ReadOnly = true;
            img = null;
        }

        // 点击用户头像时跳转到其会话界面
        private void HeadImage_Click(object sender, MouseEventArgs e)
        {
            if (We || e.Button != MouseButtons.Left) return;
            if (!KeyData.Activity.UserStruchOnline.Contains(this.user))
            {
                Method.ShowPrompt("该用户已下线!");
                return;
            }
            KeyData.form1.SetKinetic(this.user);
        }

        /// <summary>
        /// 设置头像坐标
        /// </summary>
        private void SetLocation_Head()
        {
            if (We) this.HeadImage.Location = new Point(this.Width - this.HeadImage.Width - 10, 10);
            else this.HeadImage.Location = new Point(10, 10);
        }

        /// <summary>
        /// 设置消息框坐标
        /// </summary>
        private void SetLocation_Mes()
        {
            if (this.tbx == null) return;
            if (this.We)
            {
                if (this.tbx != null)
                    this.tbx.Location = new Point(
                                 this.HeadImage.Location.X - this.tbx.Width - 15,
                                 this.HeadImage.Location.Y + 30);
            }
            else
            {
                //设置气泡相对坐标
                if (this.tbx != null)
                    this.tbx.Location = new Point(
                        this.HeadImage.Location.X + this.HeadImage.Width + 25,
                        this.HeadImage.Location.Y + 30);
            }

        }

        /// <summary>
        /// 设置文件框坐标
        /// </summary>
        private void SetLocation_File()
        {
            if (this.fmes == null) return;
            if (this.We)
            {
                fmes.Location = new Point(
                this.HeadImage.Location.X - fmes.Width - 15,
                this.HeadImage.Location.Y + 30);
            }
            else
            {
                fmes.Location = new Point(
               this.HeadImage.Location.X + this.HeadImage.Width + 25,
               this.HeadImage.Location.Y + 30);
            }

        }

        /// <summary>
        /// 设置图像消息坐标
        /// </summary>
        private void SetLocation_Pic()
        {
            if (this.picmes == null) return;
            if (this.We)
            {
                picmes.Location = new Point(
                this.HeadImage.Location.X - picmes.Width - 15,
                this.HeadImage.Location.Y + 30);
            }
            else
            {
                picmes.Location = new Point(
                this.HeadImage.Location.X + this.HeadImage.Width + 25,
                this.HeadImage.Location.Y + 30);
            }
        }

        private void MS_Label_SizeChanged(object sender, EventArgs e)
        {
            SetLocation_Head();
            SetLocation_Mes();
            SetLocation_File();
            SetLocation_Pic();
        }

        private void ts_Atbtn_Click(object sender, EventArgs e)
        {
            if (this.AtUserEvent != null)
            {
                this.AtUserEvent(this, this.user);
            }
        }

        private void cts_头像右击_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.We||!this.inPub) e.Cancel = true;
        }
    }
}
