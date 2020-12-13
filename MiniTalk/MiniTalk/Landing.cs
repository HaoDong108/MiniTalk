using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using MiniTalk.Net;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Threading;

namespace MiniTalk
{
    public partial class Landing : Form
    {
        int BoxIndex;//当前的频道索引
        string ip = string.Empty;
        string userName = string.Empty;
        int channel = 0;
        string imgid = "im1";

        public Landing()
        {
            InitializeComponent();
            Method.FormShadow(this);
            CheckForIllegalCrossThreadCalls = false;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            KeyData.receiver.UserOnlineAndOfflineEvent += Receiver_UserOnlineAndOfflineEvent;
            Transmitters.Sender.GetNumberOver += Sender_GetNumberOver;
        }

        private void Landing_Load(object sender, EventArgs e)
        {
            IPAddress[] ips = Dns.GetHostAddresses(Dns.GetHostName());
            IPAddress localIp = ips[ips.Length - 1];
            this.ip = localIp.ToString();
            label5.Text = localIp.ToString();
          
            //获取所在网段
            string[] strs = this.ip.Split('.');
            //根据ip地址选择默认的频段
            int temp = int.Parse(strs[strs.Length - 1]);
            if (temp >= 0 && temp <= 50) { comboBox1.SelectedIndex = 0; }
            else if (temp > 50 && temp <= 100) { comboBox1.SelectedIndex = 1; }
            else if (temp > 100 && temp <= 155) { comboBox1.SelectedIndex = 2; }
            else if (temp > 155 && temp <= 200) { comboBox1.SelectedIndex = 3; }
            else { comboBox1.SelectedIndex = 4; }
            this.channel = comboBox1.SelectedIndex+1;//绑定频道
            this.BoxIndex = comboBox1.SelectedIndex;

            Model.UserData data = new Model.UserData(localIp.ToString(), "", "im1", this.channel);
            KeyData.StaticInfo.MyUser = data;

            //将输入法设置为搜狗输入法
            InputLanguageCollection langs = InputLanguage.InstalledInputLanguages;
            foreach (InputLanguage lang in langs)
            {
                if (lang.LayoutName.Contains("搜狗拼音"))
                {
                    InputLanguage.CurrentInputLanguage = lang;
                }
            }

            this.pictureBox1.BackgroundImage = HeadImages.im1;
            this.RandName();
            Animation.窗体动画.Enter_Animate(this.Handle, Animation.Enter_Animations.自下向上滑动, 600);
            KeyData.receiver.StartRead();
            Transmitters.Sender.SendAllTestInfo();
        }

        /// <summary>
        /// 随机一个昵称
        /// </summary>
        private void RandName()
        {
            string[] names = new string[]
            {
                "小沙雕",
                "浩东我男神",
                "带刺的菊花",
                "浩东贼帅",
                "晨光苏醒、",
                "凉城听暖",
                "阿狸先森ˇ",
                "七色彩虹",
                "今听雨×",
                "-海蔚蓝",
                "似梦の年华",
                "喵小白",
                "沫花似锦丶",
                "孤海未蓝",
                "清风欲叶",
                "扑流萤",
                "向阳°",
                "玫瑰花香",
                "爸爸们好",
                "木头脸",
                "●﹏向日葵°",
                "小奶鹅",
                "小宇宙",
                "阿珍爱上阿强",
                "依古比古",
                "唔西迪西",
                "玛卡巴卡",
                "汤姆布利柏",
                "小点点",
                "蔡徐坤",
            };
            this.textBox1.Text = names[new Random().Next(0, names.Length)];
        }
         
        /*
         * 头像选择
         */ 

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Animation.窗体动画.Leave_Animate(this.Handle, Animation.Leave_Animations.自右向左滑动, 600);
            this.Hide();
            ChooseHeadImage form = new ChooseHeadImage();
            form.ShowDialog();
            Animation.窗体动画.Enter_Animate(this.Handle, Animation.Enter_Animations.自左向右滑动, 600);
            this.Show();
            this.pictureBox1.BackgroundImage = form.SelectImage;
            this.imgid = form.SelectImageName;
            this.Refresh();
            form.Dispose();
        }
        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }
        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.BorderStyle = BorderStyle.None;
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            this.label6.Text = this.textBox1.Text;
        }

        #region 窗体控制

        /*
         * 点击任务栏图标实现最大和最小化
         */
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

        /*
         * 实现窗体被能鼠标拖动
         */
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Method.FormMove(this.Handle);
        }

        #endregion

        private void bt_Start_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text=="公共会话")
            {
                MessageBox.Show("名称不合法", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (this.textBox1.Text.Contains("@"))
            {
                MessageBox.Show("名称不能包含特殊字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox1.Text.Length > 6)
            {
                MessageBox.Show("昵称长度不能超过6个字符", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox1.Text.Trim() == "")
            {
                textBox1.Text = null;
                MessageBox.Show("昵称不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (Method.Audit(this.textBox1.Text))
            {
                textBox1.Text = "大家都是我爸";
            }
            textBox1.Text = textBox1.Text.Replace(" ", "");
            this.channel = comboBox1.SelectedIndex + 1;//绑定频道
            this.userName = textBox1.Text;//绑定昵称

            KeyData.StaticInfo.MyUser = new Model.UserData(this.ip, this.userName, this.imgid, this.channel);
            KeyData.receiver.UserOnlineAndOfflineEvent -= Receiver_UserOnlineAndOfflineEvent;
            Transmitters.Sender.StopSendAllTest();
            KeyData.form1 = new Form1();
            this.Hide();
            KeyData.form1.ShowDialog();
            this.Close();
            this.Dispose();
        }

        private void Landing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Brushes.DarkTurquoise);
            Point p1 = new Point(0, 50);
            Point p2 = new Point(p1.X + 170, p1.Y);
            Point p3 = new Point(p2.X + 20, p2.Y - 10);
            Point p4 = new Point(this.Width, p3.Y);
            Point[] points = new Point[] { p1, p2, p3, p4 };
            e.Graphics.DrawLines(pen, points);
        }

        private void bt_Small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        List<string> ips = new List<string>();
        private int c1, c2, c3, c4, c5;
        private void Receiver_UserOnlineAndOfflineEvent(Model.Transmission.NetUserData e)
        {
            if (ips.Contains(e.senderIP)) return;
            this.Invoke(new Action(() =>
            {
                switch (e.Channel)
                {
                    case 1: this.comboBox1.Items[0] = "频道一 (" + (++c1) + "人)"; break;
                    case 2: this.comboBox1.Items[1] = "频道二 (" + (++c2) + "人)"; break;
                    case 3: this.comboBox1.Items[2] = "频道三 (" + (++c3) + "人)"; break;
                    case 4: this.comboBox1.Items[3] = "频道四 (" + (++c4) + "人)"; break;
                    case 5: this.comboBox1.Items[4] = "频道五 (" + (++c5) + "人)"; break;
                }
                ips.Add(e.senderIP);
            }));
        }

        private void Sender_GetNumberOver(EventArgs obj)
        {
            this.Invoke(new Action(() => { this.lb_stae.Text = "统计完成"; }));
        }

        protected override void OnClosed(EventArgs e)
        {
            if (!KeyData.receiver.IsDisposes) KeyData.receiver.Dispose();
        }
    }
}
