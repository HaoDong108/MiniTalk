using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MiniTalk.Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MiniTalk
{
    public partial class Form_Install : Form
    {
        public delegate void InstallOverHandle(object sender, InstallEventArgs e);

        /// <summary>
        /// 保存设置时触发
        /// </summary>
        public event InstallOverHandle InstallOverEvent;

        public Options.传输设置 Final_传输设置{get;set;}
        public Options.常规设置 Final_常规设置{get;set;}
        public Options.提醒设置 Final_提醒设置{get;set;}
        public Options.用户管理 Final_用户管理 { get; set; }

        public Form_Install()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            this.ControlAutoSize();
            this.Set常规设置();
            this.Set传输设置();
            this.Set提醒设置();
            this.Set用户管理();
        }

        private void tb_Main_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lb_title.Text = "设置->" + this.tb_Main.TabPages[tb_Main.SelectedIndex].Text;
        }

        private void 传输设置_BtAdd_Click(object sender, EventArgs e)
        {
            string pattern = "\\.\\w{2,5}";
            string input = this.传输设置_ExtTxb.Text;
            if (!Regex.IsMatch(input, pattern))
            {
                MessageBox.Show("后缀名格式不合法", "格式错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ListBoxHasItem(input))
            {
                MessageBox.Show("列表中已包含该项!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            SkinListBoxItem item = new SkinListBoxItem(" " + input);
            item.Image = DSAPI.图形图像.获取扩展名关联图标(input, false);
            this.传输设置_ExtListBox.Items.Add(item);
        }

        private void Rbtn_移除_Click(object sender, EventArgs e)
        {
            SkinListBox lbox=null;
            if (传输设置_ExtListBox.Focused) lbox = 传输设置_ExtListBox;
            if (用户管理_lb_备注列表.Focused) lbox = 用户管理_lb_备注列表;
            if (用户管理_lb_黑名单.Focused) lbox = 用户管理_lb_黑名单;
            if (lbox==null) return;

            lbox.Items.RemoveAt(lbox.SelectedIndex);
        }

        private void Rbtn_移除所有_Click(object sender, EventArgs e)
        {
            SkinListBox lbox = null;
            if (传输设置_ExtListBox.Focused) lbox = 传输设置_ExtListBox;
            if (用户管理_lb_备注列表.Focused) lbox = 用户管理_lb_备注列表;
            if (用户管理_lb_黑名单.Focused) lbox = 用户管理_lb_黑名单;
            if (lbox == null) return;
            lbox.Items.Clear();
        }

        private void 传输设置_ExtTxb_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = this.传输设置_BtAdd;
        }

        private void 传输设置_ExtTxb_Leave(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }

        private void 传输设置_bt_更改保存路径_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.传输设置_lb_SavePath.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void tp_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Brushes.Gray);

            //绘制线段
            Rectangle r1 = this.tb_Main.GetTabRect(0);
            Rectangle r2 = this.tb_Main.GetTabRect(this.tb_Main.TabPages.Count - 1);
            Point start = new Point(5, r1.Y + (r1.Height / 2) - 2);
            Point end = new Point(5, r2.Y + (r2.Height / 2) - 2);
            e.Graphics.DrawLine(pen, start, end);
            //绘制端点
            r1 = new Rectangle(new Point(start.X - 4, start.Y - 4), new Size(8, 8));
            r2 = new Rectangle(new Point(end.X - 4, end.Y - 4), new Size(8, 8));
            e.Graphics.FillEllipse(Brushes.Gray, r1);
            e.Graphics.FillEllipse(Brushes.Gray, r2);
            //绘制热点
            Rectangle nowRec = this.tb_Main.GetTabRect(this.tb_Main.SelectedIndex);
            Point nowPoint = new Point(start.X, nowRec.Y + (nowRec.Height / 2) - 4);
            nowRec = new Rectangle(new Point(nowPoint.X - 6, nowPoint.Y - 6), new Size(12, 12));
            e.Graphics.FillEllipse(Brushes.DarkTurquoise, nowRec);
        }

        private void Form_Install_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Pen pen = new Pen(Brushes.DarkTurquoise);
            Point p1 = new Point(10, this.pic_Logo.Location.Y + this.pic_Logo.Height + 8);
            Point p2 = new Point(p1.X + 240, p1.Y);
            Point p3 = new Point(p2.X + 30, p2.Y - 15);
            Point p4 = new Point(this.Width - 10, p3.Y);
            Point[] points = new Point[] { p1, p2, p3, p4 };
            e.Graphics.DrawLines(pen, points);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.DarkTurquoise);
            Point lp1 = new Point(bt_Save.Location.X - 15, bt_Save.Height / 2 + 15);
            Point lp2 = new Point(0, lp1.Y);
            e.Graphics.DrawLine(pen, lp1, lp2);

            Point rp1 = new Point(bt_Save.Location.X + bt_Save.Width + 15, lp1.Y);
            Point rp2 = new Point(this.panel1.Width + 300, rp1.Y);
            e.Graphics.DrawLine(pen, rp1, rp2);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Method.FormMove(this.Handle);
            base.OnMouseDown(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.Dispose();
        }

        private bool ListBoxHasItem(string text)
        {
            foreach (SkinListBoxItem item in this.传输设置_ExtListBox.Items)
            {
                if (item.Text.Trim() == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            Settings1.Default.传输设置 = Get传输设置();
            Settings1.Default.常规设置 = Get常规设置();
            Settings1.Default.用户管理 = Get用户管理();
            Settings1.Default.提醒设置 = Get提醒设置();
            Settings1.Default.Save();
            Options.Update();
            this.OnInstallOver();
            Method.ShowPrompt("设置已经保存", 1000);
        }

        private void Set常规设置()
        {
            Options.常规设置 info = JsonConvert.DeserializeObject<Options.常规设置>(Settings1.Default.常规设置);
            常规设置_nup_历史消息保留数.Value = info.历史消息保存数;
            常规设置_nup_消息时间提醒间隔.Value = info.消息发送时间提示间隔;
            常规设置_cb_后台截图.Checked = info.快捷截图;
        }

        private void Set传输设置()
        {
            try
            {
                Options.传输设置 info = JsonConvert.DeserializeObject<Options.传输设置>(Settings1.Default.传输设置);
                传输设置_cb_下载完毕后自动打开文件.Checked = info.下载完毕后自动打开文件;
                传输设置_cb_屏蔽所有文件消息.Checked = info.屏蔽所有文件消息;
                传输设置_lb_SavePath.Text = info.保存路径;
                传输设置_nup_大于numMB则屏.Value = info.文件接收大小最大上限;
                this.传输设置_ExtListBox.Items.Clear();
                if (info.屏蔽的后缀名 != null)
                {
                    foreach (var text in info.屏蔽的后缀名)
                    {
                        SkinListBoxItem item = new SkinListBoxItem("  " + text);
                        item.Image = DSAPI.图形图像.获取扩展名关联图标(text, false);
                        this.传输设置_ExtListBox.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void Set提醒设置()
        {
            Options.提醒设置 info = JsonConvert.DeserializeObject<Options.提醒设置>(Settings1.Default.提醒设置);
            提醒设置_cb_事件消息.Checked=info.提醒类别_事件消息;
            提醒设置_cb_文件消息.Checked = info.提醒类别_文件消息;
            提醒设置_cb_图片消息.Checked= info.提醒类别_图片消息;
            提醒设置_cb_文本消息.Checked= info.提醒类别_文本消息;
            提醒设置_cb_强提醒模式_对话框.Checked=info.强提醒模式_对话框;
            提醒设置_cb_强提醒模式_托盘消息.Checked=info.强提醒模式_托盘消息;
            提醒设置_cb_置顶者强提醒.Checked=info.置顶者强提醒 ;
            提醒设置_cb_群消息提醒.Checked= info.群消息提醒;
            提醒设置_cb_群消息红点标注.Checked=info.群消息红点标注;
            提醒设置_cb_右下角浮动提醒.Checked = info.右下角浮动提醒;
            提醒设置_cb_用户消息悬浮提醒.Checked = info.悬浮提醒_用户消息悬浮提醒;
            提醒设置_cb_公共会话悬浮提醒.Checked = info.悬浮提醒_公共会话悬浮提醒;
        }

        private void Set用户管理()
        {
            var info = JsonConvert.DeserializeObject<Options.用户管理>(Settings1.Default.用户管理);
            if(info.备注表!=null)
            foreach (var item in info.备注表)
            {
                this.用户管理_lb_备注列表.Items.Add(new SkinListBoxItem(item.ToString()) { Tag=item});
            }
            if(info.黑名单!=null)
            foreach (var item in info.黑名单)
            {
                this.用户管理_lb_黑名单.Items.Add(new SkinListBoxItem(item));
            }
        }

        private string Get传输设置()
        {
            Options.传输设置 info = new Options.传输设置();
            info.下载完毕后自动打开文件 = 传输设置_cb_下载完毕后自动打开文件.Checked;
            info.保存路径 = 传输设置_lb_SavePath.Text;
            info.屏蔽所有文件消息 = 传输设置_cb_屏蔽所有文件消息.Checked;
            info.文件接收大小最大上限 = (int)传输设置_nup_大于numMB则屏.Value;
            List<string> list = new List<string>();
            foreach (SkinListBoxItem item in 传输设置_ExtListBox.Items)
            {
                list.Add(item.Text.Trim());
            }
            info.屏蔽的后缀名 = list;
            this.Final_传输设置 = info;
            return JsonConvert.SerializeObject(info);
        }

        private string Get常规设置()
        {
            Options.常规设置 info = new Options.常规设置();
            info.历史消息保存数 = (int)常规设置_nup_历史消息保留数.Value;
            info.消息发送时间提示间隔 = (int)常规设置_nup_消息时间提醒间隔.Value;
            info.快捷截图 = 常规设置_cb_后台截图.Checked;
            this.Final_常规设置 = info;
            return JsonConvert.SerializeObject(info);
        }

        private string Get提醒设置()
        {
            Options.提醒设置 info = new Options.提醒设置();
            info.提醒类别_事件消息 = 提醒设置_cb_事件消息.Checked;
            info.提醒类别_文件消息 = 提醒设置_cb_文件消息.Checked;
            info.提醒类别_图片消息 = 提醒设置_cb_图片消息.Checked;
            info.提醒类别_文本消息 = 提醒设置_cb_文本消息.Checked;
            info.强提醒模式_对话框 = 提醒设置_cb_强提醒模式_对话框.Checked;
            info.强提醒模式_托盘消息= 提醒设置_cb_强提醒模式_托盘消息.Checked;
            info.置顶者强提醒 = 提醒设置_cb_置顶者强提醒.Checked;
            info.群消息提醒 = 提醒设置_cb_群消息提醒.Checked;
            info.群消息红点标注 = 提醒设置_cb_群消息红点标注.Checked;
            info.群消息红点标注 = 提醒设置_cb_群消息红点标注.Checked;
            info.右下角浮动提醒 = 提醒设置_cb_右下角浮动提醒.Checked;
            info.悬浮提醒_用户消息悬浮提醒 = 提醒设置_cb_用户消息悬浮提醒.Checked;
            info.悬浮提醒_公共会话悬浮提醒 = 提醒设置_cb_公共会话悬浮提醒.Checked;
            this.Final_提醒设置 = info;
            return JsonConvert.SerializeObject(info);
        }

        private string Get用户管理()
        {
            Options.用户管理 info = new Options.用户管理();
            foreach (SkinListBoxItem itm in this.用户管理_lb_黑名单.Items)
            {
                info.黑名单.Add(itm.Text);
            }
            foreach (SkinListBoxItem itm in this.用户管理_lb_备注列表.Items)
            {
                info.备注表.Add((dynamic)itm.Tag);
            }
            this.Final_用户管理 = info;
            return JsonConvert.SerializeObject(info);
        }

        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox_MouseEnter(object sender, EventArgs e)
        {
            SkinListBox box = sender as SkinListBox;
            box.Focus();
        }

        private void 用户管理_lb_备注列表_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (用户管理_lb_备注列表.SelectedIndex < 0) return;
            IPRemarks rk = 用户管理_lb_备注列表.Items[用户管理_lb_备注列表.SelectedIndex].Tag as IPRemarks;
            this.用户管理_tb_备注名.Text = rk.Name;
        }

        private void 用户管理_bt_备注修改_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(用户管理_tb_备注名.Text.Trim()))
            {
                Method.ShowPrompt("备注名不能为空", 1000);
                this.用户管理_tb_备注名.Text = string.Empty;
            }
            IPRemarks rk = 用户管理_lb_备注列表.Items[用户管理_lb_备注列表.SelectedIndex].Tag as IPRemarks;
            rk = new IPRemarks(rk.IP, 用户管理_tb_备注名.Text);
            用户管理_lb_备注列表.Items[用户管理_lb_备注列表.SelectedIndex].Text = rk.ToString();
            用户管理_lb_备注列表.Items[用户管理_lb_备注列表.SelectedIndex].Tag = rk;
        }

        /// <summary>
        /// 分辨率自适应
        /// </summary>
        private void ControlAutoSize()
        {
            int left =(int)(this.tb_Main.TabPages[0].Width * 0.045);
            int pagew = this.tb_Main.TabPages[0].Width;
            //常规设置
            this.常规设置_nup_历史消息保留数.Left = left;
            this.常规设置_nup_消息时间提醒间隔.Left = left;
            this.label1.Left = left;
            this.label5.Left = left;
            //传输设置
            int w = (int)(pagew * 0.813);
            this.传输设置_lb_SavePath.Width = w;
            this.传输设置_lb_SavePath.Left = left;
            this.传输设置_bt_更改保存路径.Width = (int)(pagew * 0.1);
            this.传输设置_bt_更改保存路径.Left = this.传输设置_lb_SavePath.Location.X + this.传输设置_lb_SavePath.Width + 5;
            this.传输设置_cb_下载完毕后自动打开文件.Left = left;
            this.传输设置_cb_屏蔽所有文件消息.Left = left;
            this.传输设置_nup_大于numMB则屏.Left = left;
            this.传输设置_ExtTxb.Left=this.传输设置_ExtListBox.Left=label4.Left=(int)(pagew * 0.742);
            this.传输设置_BtAdd.Left = this.传输设置_ExtTxb.Location.X + this.传输设置_ExtTxb.Width + 3;
            this.label3.Left = left;
            this.label2.Left = left;
            //提醒设置
            this.skinGroupBox1.Left = left;
            this.skinGroupBox2.Left = left;
            this.skinGroupBox3.Left = left;
            this.提醒设置_panel2.Left = left;
            //用户管理
            this.用户管理_lb_备注列表.Width=this.用户管理_lb_黑名单.Width=(int)(pagew * 0.356);
            this.用户管理_lb_备注列表.Left = left;
            this.用户管理_tb_备注名.Width = (int)(pagew * 0.257);
            this.用户管理_tb_备注名.Left = left;
            this.用户管理_bt_备注修改.Width = (int)(pagew * 0.091);
            this.用户管理_bt_备注修改.Left = this.用户管理_tb_备注名.Location.X + this.用户管理_tb_备注名.Width + 5;
            this.label6.Left = left;
            this.label7.Left = this.用户管理_lb_黑名单.Left;
        }

        /// <summary>
        /// 触发事件
        /// </summary>
        private void OnInstallOver()
        {
            InstallEventArgs e = new InstallEventArgs();
            e.传输设置 = this.Final_传输设置;
            e.常规设置 = this.Final_常规设置;
            e.提醒设置 = this.Final_提醒设置;
            e.用户管理 = this.Final_用户管理;
            if(this.InstallOverEvent!=null)
            this.InstallOverEvent.Invoke(this, e);
        }
    }
}
