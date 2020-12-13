using MiniTalk.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MiniTalk
{
    public enum MsType
    {
        本地消息,
        网络消息
    }
    public partial class TalkPanel : UserControl
    {
        int a_y = 0;   //当前控件的应当位置
        bool showtime; //判断当前是否应当显示消息发送时间
        bool _scLock = true;
        UserData master;

        /// <summary>
        /// 标识是否锁定滚动条以保证视图永远在最下方
        /// </summary>
        bool ScrollLock
        {
            get
            {
                return _scLock;
            }
            set
            {
                _scLock = value;
                if (value)
                {
                    this.bt_NewMs.Visible = false;
                    this.scrollBar1.Value = this.scrollBar1.Maximum;
                    this.NewMessageCount = 0;
                }
            }
        }

        /// <summary>
        /// 滚动条为非锁定状态时最下方的新消息数
        /// </summary>m
        int NewMessageCount
        {
            get
            {
                return this.master.NewMesCount;
            }
            set
            {
                this.master.NewMesCount = value;
                this.bt_NewMs.Text = "有" + value + "条新消息";
            }
        }

        public event Action<MS_Label, UserData> AtUserEvent;

        public TalkPanel(Point point, Size size,UserData master)
        {
            InitializeComponent();
            this.master = master;
            CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.panel_sub.Parent = this;
            this.panel_sub.Height = this.Height;
            this.Location = point;
            this.Size = size;
            this.BackColor = this.panel_sub.BackColor;
            this.scrollBar1.Left = this.Width - this.scrollBar1.Width;
            this.scrollBar1.XTheme.MdlButtonTheme.ColorTable.ForeColorNormal = Color.DarkTurquoise;
            this.scrollBar1.XTheme.MdlButtonTheme.ColorTable.ForeColorPressed = Color.DarkTurquoise;
            this.scrollBar1.XTheme.MdlButtonTheme.ColorTable.ForeColorHover = Color.DarkTurquoise;
            this.scrollBar1.XTheme.MdlButtonTheme.ColorTable.ForeColorDisabled = Color.DarkTurquoise;
            this.MouseEnter += (sender, e) => { this.Focus(); };
            this.Padding = new System.Windows.Forms.Padding(0, 0, scrollBar1.Width, 0);
            this.bt_NewMs.Parent = this;
            this.timer1.Interval = (Options._常规设置.消息发送时间提示间隔 * 60) * 1000;
            this.showtime = true;
            this.timer1.Start();
        }

        #region 对外接口
        /// <summary>
        /// 添加一条会话记录
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="name">用户名</param>
        /// <param name="headImg">头像</param>
        /// <param name="type">气泡类型</param>
        public void AppendText(string message, UserData data, MsType type)
        {
            MS_Label mS_Label;
            //判断消息所属
            if (type == MsType.本地消息)
            {
                mS_Label = new MS_Label(true,this.master.IsPub,data, this.scrollBar1);
                ScrollLock = true;
            }
            else
            {
                mS_Label = new MS_Label(false, this.master.IsPub, data, this.scrollBar1);
                this.NewMessageCount++;
            }
            mS_Label.Width = this.panel_sub.Width - 5;
            mS_Label.SetText(message, this.showtime);
            AddControl(mS_Label);
        }

        /// <summary>
        /// 添加一条本地文件信息
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        public void AppendFileMes(string path, UserData data)
        {
            this.ScrollLock = true;
            MS_Label mS_Label;
            mS_Label = new MS_Label(true, this.master.IsPub, data, this.scrollBar1);
            mS_Label.Width = this.panel_sub.Width - 5;
            mS_Label.SetLocalFileMes(path, this.showtime);
            AddControl(mS_Label);
        }

        /// <summary>
        /// 添加一条网络文件信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="data"></param>
        public void AppendFileMes(Transmission.NetFileData info, UserData data,bool isPub)
        {
            MS_Label mS_Label;
            mS_Label = new MS_Label(false, this.master.IsPub, data, this.scrollBar1);
            mS_Label.Width = this.panel_sub.Width - 5;
            mS_Label.SetNetFileMes(info, this.showtime, isPub);
            this.NewMessageCount++;
            AddControl(mS_Label);
        }

        /// <summary>
        /// 添加一条事件提示
        /// </summary>
        /// <param name="text"></param>
        public void AppendEventMessage(string text)
        {
            this.NewMessageCount++;
            Label lb = GetLabel(text);
            AddControl(lb);
        }

        /// <summary>
        /// 添加一条图片消息
        /// </summary>
        /// <param name="image"></param>
        /// <param name="type"></param>
        public void AppendPicMessage(Image image, UserData data, MsType type)
        {
            bool we = type == MsType.本地消息;
            if (type == MsType.网络消息)
            {
                this.NewMessageCount++;
            }
            MS_Label lb = new MS_Label(we, this.master.IsPub, data, this.scrollBar1);
            lb.Width = this.panel_sub.Width - 5;
            lb.SetPicMessage(image, this.showtime);
            AddControl(lb);
        }

        /// <summary>
        /// 清除所有会话记录
        /// </summary>
        public void ClearAll()
        {
            this.ScrollLock = true;
            this.panel_sub.Controls.Clear();
            this.a_y = 0;
            this.panel_sub.Size = new Size(this.Width - this.scrollBar1.Width, this.Height);
            this.scrollBar1.Maximum = 0;
            this.scrollBar1.Value = 0;
            this.bt_NewMs.Visible = false;
        }
        #endregion

        private void AddControl(Control control)
        {
            if(control is MS_Label)
            {
                (control as MS_Label).AtUserEvent += (sender, e) => { this.AtUserEvent(sender, e); };
            }
            try { 
                this.panel_sub.Controls.Add(control);
            }catch(Exception ex)
            {
                Method.ShowPrompt("由于某些原因,消息添加失败!\n附加信息:"+ex.Message,1000,30);
            }
        }

        /// <summary>
        /// 返回事件label
        /// </summary>
        private Label GetLabel(string text)
        {
            Label lb = new Label();
            lb.Size = new Size(this.Width, 50);
            //lb.BorderStyle = BorderStyle.FixedSingle;
            lb.AutoSize = false;
            lb.TextAlign = ContentAlignment.MiddleCenter;
            lb.Font = new Font("微软雅黑", 9, FontStyle.Regular);
            lb.Text = "◊◦ " + text + " ◦◊";
            lb.BackColor = Color.Transparent;
            lb.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            lb.ForeColor = Color.Aquamarine;
            return lb;
        }

        /// <summary>
        /// 防面板大小溢出处理
        /// </summary>
        private void SizeOverflow_Processing()
        {
            int max_h = 0;
            foreach (Control item in this.panel_sub.Controls)
            {
                item.Location = new Point(0, item.Location.Y - this.scrollBar1.Minimum);
                if (item.Location.Y + item.Height > max_h)
                {
                    max_h = item.Location.Y + item.Height;
                }
            }
            this.scrollBar1.Maximum -= this.scrollBar1.Minimum;
            this.panel_sub.Size = new Size(this.panel_sub.Width, max_h);
            this.a_y = max_h;
            this.scrollBar1.Minimum = 0;
            this.scrCha = 0;
        }

        /// <summary>
        /// 滚动条绑定鼠标滚轮
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int v = 50;
            try
            {
                if (e.Delta > 0)
                {
                    if (scrollBar1.Value - v < scrollBar1.Minimum)
                    {
                        scrollBar1.Value = scrollBar1.Minimum;
                    }
                    this.scrollBar1.Value -= v;
                }
                if (e.Delta < 0)
                {
                    if (scrollBar1.Value + v > scrollBar1.Maximum)
                    {
                        scrollBar1.Value = scrollBar1.Maximum;
                    }
                    this.scrollBar1.Value += v;
                }
            }
            catch (Exception)
            { }
            base.OnMouseWheel(e);
        }

        int scrCha = 0;
        /// <summary>
        /// 添加控件时调整滚动条最大值并删除位于最大值之外的消息控件
        /// </summary>
        private void Panel1_ControlAdded(object sender, ControlEventArgs e)
        {
            e.Control.Location = new Point(0, a_y); //设置消息控件坐标位置
            a_y += e.Control.Height;//设置下一消息控件的坐标位置

            if (e.Control.Location.Y+e.Control.Height>this.panel_sub.Height)
            {
                this.panel_sub.MaximumSize = new Size(this.panel_sub.Width, e.Control.Location.Y + e.Control.Height);
                this.panel_sub.Height = this.panel_sub.MaximumSize.Height;
            }
            this.showtime = false;
            if (!this.timer1.Enabled) this.timer1.Start();
            this.scrollBar1.Maximum = (this.panel_sub.Height - this.Height);

            //若滚动条锁定属性为true则将滚动条置底
            if (this.ScrollLock) this.scrollBar1.Value = this.scrollBar1.Maximum;
            
            //弱滚动条处于锁定状态且底部有新消息则显示提示回到底部按钮
            if (!this.ScrollLock && this.NewMessageCount > 0)
            {
                this.bt_NewMs.Visible = true;
                bt_NewMs.BringToFront();
            }

            //对超出历史最大消息数限制的进行处理
            while (this.panel_sub.Controls.Count > Options._常规设置.历史消息保存数)
            {
                this.scrCha += this.panel_sub.Controls[0].Height;
                this.panel_sub.Controls[0].Dispose();
            }
            //如果面板大小过大则进行处理
            if (this.a_y > 10000000)
            {
                this.SizeOverflow_Processing();
            }
        }

        /// <summary>
        /// 绑定会话窗体向上偏移增量，达到模拟滚动效果
        /// </summary>
        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            this.panel_sub.Top = -(this.scrollBar1.Value);
            if (this.scrollBar1.Value <= this.scrollBar1.Maximum - 51)
            {
                ScrollLock = false;
            }
            else if (this.scrollBar1.Value == this.scrollBar1.Maximum)
            {
                this.bt_NewMs.Visible = false;
                this.ScrollLock = true;
            }
        }

        /// <summary>
        /// 点击新消息数提示气泡时回到底部
        /// </summary>
        private void bt_NewMs_Click(object sender, EventArgs e)
        {
            this.scrollBar1.Maximum = this.panel_sub.Size.Height - this.Height;
            this.scrollBar1.Value = this.scrollBar1.Maximum;
            this.ScrollLock = true;
            this.bt_NewMs.Visible = false;
        }

        /// <summary>
        /// 定时显示时间
        /// </summary>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.showtime == false)
            {
                this.showtime = true;
                this.timer1.Stop();
            }
        }

        /// <summary>
        /// 移除控件时设置滚动条最小值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Panel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            this.scrollBar1.Minimum = this.scrCha;
        }

        /// <summary>
        /// 优化滚动条拖动时的剧烈拖尾现象
        /// </summary>
        private void VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int val = 0;
            this.panel_sub.BeginInvoke(new Action(() =>
            {
                if ((int)Math.Abs(this.scrollBar1.Value) > 80)
                {
                    this.panel_sub.Refresh();
                    val = this.scrollBar1.Value;
                }
            }
            ));
        }

        private void bt_NewMs_MouseEnter(object sender, EventArgs e)
        {
            this.bt_NewMs.Image = FixedImages.下拉箭头被选中;
        }

        private void bt_NewMs_MouseLeave(object sender, EventArgs e)
        {
            this.bt_NewMs.Image = FixedImages.下拉箭头默认;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.bt_NewMs.Left = (this.panel_sub.Width / 2) - (this.bt_NewMs.Width / 2) + 25;
            this.bt_NewMs.Top = this.Height - this.bt_NewMs.Height - 15;
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            this.bt_NewMs.Left = (this.panel_sub.Width / 2) - (this.bt_NewMs.Width / 2) + 25;
            this.bt_NewMs.Top = this.Height - this.bt_NewMs.Height - 15;
            //重新设置面板大小
            if (this.panel_sub.Controls.Count > 0)
            {
                Control cl = this.panel_sub.Controls[this.panel_sub.Controls.Count - 1];
                if (cl.Location.Y + cl.Height > this.panel_sub.Height) this.panel_sub.Height = cl.Location.Y + cl.Height;
            }
            this.scrollBar1.Maximum = (this.panel_sub.Height - this.Height);
            this.scrollBar1.Value = this.scrollBar1.Maximum;
            this.panel_sub.Width = this.Width - this.scrollBar1.Width;
        }
    }
}
