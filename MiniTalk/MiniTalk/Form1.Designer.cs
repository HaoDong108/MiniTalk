using System;

namespace MiniTalk
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch (System.Exception)
            {
                Environment.Exit(0);
            }
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txb_input = new System.Windows.Forms.TextBox();
            this.cms_输入框 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.发送ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.插入表情ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_count = new System.Windows.Forms.Label();
            this.pic_NowHead = new System.Windows.Forms.PictureBox();
            this.lb_nowName = new System.Windows.Forms.Label();
            this.toolTip_控件提示 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_CloseForm = new CCWin.SkinControl.SkinButton();
            this.bt_Small = new CCWin.SkinControl.SkinButton();
            this.bt_Max = new CCWin.SkinControl.SkinButton();
            this.pic_Setup = new CCWin.SkinControl.SkinButton();
            this.bt_Ref = new CCWin.SkinControl.SkinButton();
            this.bt_select = new CCWin.SkinControl.SkinButton();
            this.bt_Exp = new CCWin.SkinControl.SkinButton();
            this.bt_Remote = new CCWin.SkinControl.SkinButton();
            this.bt_Adv = new CCWin.SkinControl.SkinButton();
            this.bt_SendImg = new CCWin.SkinControl.SkinButton();
            this.bt_SendFile = new CCWin.SkinControl.SkinButton();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.bt_zoom = new System.Windows.Forms.PictureBox();
            this.bt_resultClose = new CCWin.SkinControl.SkinButton();
            this.bt_Search = new CCWin.SkinControl.SkinButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label_watermark = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.cms_托盘 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip_显示主窗口 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip_退出 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_Send = new CCWin.SkinControl.SkinButton();
            this.bt_Clear = new CCWin.SkinControl.SkinButton();
            this.cms_在线列表 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iP备注不适用DHCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_TextRek = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Shield = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_Topping = new System.Windows.Forms.ToolStripMenuItem();
            this.bs_ListBoxOnline = new System.Windows.Forms.BindingSource(this.components);
            this.iP备注不适用于DHCPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip_成员信息 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_Result = new System.Windows.Forms.Panel();
            this.ListBox_Select_Result = new CCWin.SkinControl.SkinListBox();
            this.myPanel2 = new Override_Control.MyPanel();
            this.txb_SelectInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Pbar_schedule = new CCWin.SkinControl.SkinProgressBar();
            this.timer_ScreenHook = new System.Windows.Forms.Timer(this.components);
            this.ListBox_Online = new Override_Control.TransparentListBox();
            this.myPanel1 = new Override_Control.MyPanel();
            this.lb_Roll = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_left = new Override_Control.MyPanel();
            this.panel_At = new System.Windows.Forms.Panel();
            this.listBox_Ats = new CCWin.SkinControl.SkinListBox();
            this.uC_Expression1 = new Override_Control.UC_Expression();
            this.panel_right = new Override_Control.MyPanel();
            this.scrollBar_Online = new LM.CLibrary.Controls.LMVScrollBar();
            this.myPanel3 = new Override_Control.MyPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.myPanel4 = new Override_Control.MyPanel();
            this.picBox_HeadImg = new System.Windows.Forms.PictureBox();
            this.myPanel5 = new Override_Control.MyPanel();
            this.lb_Name = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.cms_输入框.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_NowHead)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_zoom)).BeginInit();
            this.cms_托盘.SuspendLayout();
            this.cms_在线列表.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_ListBoxOnline)).BeginInit();
            this.panel_Result.SuspendLayout();
            this.myPanel2.SuspendLayout();
            this.myPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_left.SuspendLayout();
            this.panel_At.SuspendLayout();
            this.panel_right.SuspendLayout();
            this.myPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.myPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HeadImg)).BeginInit();
            this.myPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox3.Location = new System.Drawing.Point(4, 3);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(53, 38);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(54, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "MiniTalk";
            // 
            // txb_input
            // 
            this.txb_input.AllowDrop = true;
            this.txb_input.BackColor = System.Drawing.Color.Black;
            this.txb_input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_input.ContextMenuStrip = this.cms_输入框;
            this.txb_input.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txb_input.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_input.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.txb_input.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txb_input.Location = new System.Drawing.Point(0, 562);
            this.txb_input.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txb_input.MaxLength = 1000;
            this.txb_input.Multiline = true;
            this.txb_input.Name = "txb_input";
            this.txb_input.Size = new System.Drawing.Size(792, 119);
            this.txb_input.TabIndex = 11;
            this.txb_input.TabStop = false;
            this.txb_input.Click += new System.EventHandler(this.TextBox1_Click);
            this.txb_input.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.txb_input.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBox1_DragDrop);
            this.txb_input.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBox1_DragEnter);
            this.txb_input.Enter += new System.EventHandler(this.textBox1_Enter);
            this.txb_input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            this.txb_input.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txb_input_KeyPress);
            this.txb_input.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // cms_输入框
            // 
            this.cms_输入框.BackColor = System.Drawing.Color.Black;
            this.cms_输入框.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_输入框.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.发送ToolStripMenuItem,
            this.插入表情ToolStripMenuItem});
            this.cms_输入框.Name = "contextMenuStrip1";
            this.cms_输入框.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.cms_输入框.ShowImageMargin = false;
            this.cms_输入框.Size = new System.Drawing.Size(100, 92);
            // 
            // 清空ToolStripMenuItem
            // 
            this.清空ToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.清空ToolStripMenuItem.Name = "清空ToolStripMenuItem";
            this.清空ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.清空ToolStripMenuItem.Text = "清空内容";
            this.清空ToolStripMenuItem.Click += new System.EventHandler(this.清空ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.粘贴ToolStripMenuItem.Text = "粘贴";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // 发送ToolStripMenuItem
            // 
            this.发送ToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.发送ToolStripMenuItem.Name = "发送ToolStripMenuItem";
            this.发送ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.发送ToolStripMenuItem.Text = "发送";
            this.发送ToolStripMenuItem.Click += new System.EventHandler(this.发送ToolStripMenuItem_Click);
            // 
            // 插入表情ToolStripMenuItem
            // 
            this.插入表情ToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.插入表情ToolStripMenuItem.Name = "插入表情ToolStripMenuItem";
            this.插入表情ToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.插入表情ToolStripMenuItem.Text = "插入表情";
            this.插入表情ToolStripMenuItem.Click += new System.EventHandler(this.插入表情ToolStripMenuItem_Click);
            // 
            // label_count
            // 
            this.label_count.BackColor = System.Drawing.Color.Transparent;
            this.label_count.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label_count.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_count.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label_count.Location = new System.Drawing.Point(10, 681);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(274, 21);
            this.label_count.TabIndex = 15;
            this.label_count.Text = "————— 在线成员(0) —————";
            this.label_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pic_NowHead
            // 
            this.pic_NowHead.BackColor = System.Drawing.Color.Transparent;
            this.pic_NowHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pic_NowHead.BackgroundImage")));
            this.pic_NowHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_NowHead.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pic_NowHead.Location = new System.Drawing.Point(296, 10);
            this.pic_NowHead.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_NowHead.Name = "pic_NowHead";
            this.pic_NowHead.Size = new System.Drawing.Size(51, 50);
            this.pic_NowHead.TabIndex = 16;
            this.pic_NowHead.TabStop = false;
            // 
            // lb_nowName
            // 
            this.lb_nowName.AutoSize = true;
            this.lb_nowName.BackColor = System.Drawing.Color.Transparent;
            this.lb_nowName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_nowName.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_nowName.Location = new System.Drawing.Point(364, 24);
            this.lb_nowName.Name = "lb_nowName";
            this.lb_nowName.Size = new System.Drawing.Size(74, 22);
            this.lb_nowName.TabIndex = 17;
            this.lb_nowName.Text = "公共会话";
            // 
            // toolTip_控件提示
            // 
            this.toolTip_控件提示.AutoPopDelay = 5000;
            this.toolTip_控件提示.BackColor = System.Drawing.SystemColors.GrayText;
            this.toolTip_控件提示.ForeColor = System.Drawing.Color.White;
            this.toolTip_控件提示.InitialDelay = 500;
            this.toolTip_控件提示.ReshowDelay = 100;
            this.toolTip_控件提示.ShowAlways = true;
            // 
            // bt_CloseForm
            // 
            this.bt_CloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_CloseForm.BackColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.BaseColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_CloseForm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_CloseForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_CloseForm.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.DownBack")));
            this.bt_CloseForm.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_CloseForm.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_CloseForm.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_CloseForm.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_CloseForm.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.IsDrawGlass = false;
            this.bt_CloseForm.Location = new System.Drawing.Point(146, 3);
            this.bt_CloseForm.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.MouseBack")));
            this.bt_CloseForm.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.Name = "bt_CloseForm";
            this.bt_CloseForm.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.NormlBack")));
            this.bt_CloseForm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_CloseForm.Size = new System.Drawing.Size(26, 21);
            this.bt_CloseForm.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.bt_CloseForm, "关闭");
            this.bt_CloseForm.UseVisualStyleBackColor = true;
            this.bt_CloseForm.Click += new System.EventHandler(this.bt_CloseForm_Click);
            // 
            // bt_Small
            // 
            this.bt_Small.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Small.BackColor = System.Drawing.Color.Transparent;
            this.bt_Small.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Small.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Small.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Small.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Small.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_Small.DownBack")));
            this.bt_Small.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Small.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Small.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Small.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Small.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Small.IsDrawGlass = false;
            this.bt_Small.Location = new System.Drawing.Point(83, 1);
            this.bt_Small.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_Small.MouseBack")));
            this.bt_Small.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Small.Name = "bt_Small";
            this.bt_Small.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_Small.NormlBack")));
            this.bt_Small.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Small.Size = new System.Drawing.Size(22, 24);
            this.bt_Small.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.bt_Small, "最小化");
            this.bt_Small.UseVisualStyleBackColor = true;
            this.bt_Small.Click += new System.EventHandler(this.bt_Small_Click);
            // 
            // bt_Max
            // 
            this.bt_Max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Max.BackColor = System.Drawing.Color.Transparent;
            this.bt_Max.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Max.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Max.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Max.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Max.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_Max.DownBack")));
            this.bt_Max.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Max.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Max.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Max.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Max.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Max.IsDrawGlass = false;
            this.bt_Max.Location = new System.Drawing.Point(110, 1);
            this.bt_Max.MouseBack = global::MiniTalk.FixedImages.最大化_被选中;
            this.bt_Max.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Max.Name = "bt_Max";
            this.bt_Max.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_Max.NormlBack")));
            this.bt_Max.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Max.Size = new System.Drawing.Size(26, 26);
            this.bt_Max.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.bt_Max, "最大化");
            this.bt_Max.UseVisualStyleBackColor = true;
            this.bt_Max.Click += new System.EventHandler(this.bt_Max_Click);
            // 
            // pic_Setup
            // 
            this.pic_Setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Setup.BackColor = System.Drawing.Color.Transparent;
            this.pic_Setup.BaseColor = System.Drawing.Color.Transparent;
            this.pic_Setup.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.pic_Setup.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.pic_Setup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Setup.DownBack = global::MiniTalk.FixedImages.设置;
            this.pic_Setup.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.pic_Setup.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pic_Setup.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.pic_Setup.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.pic_Setup.InnerBorderColor = System.Drawing.Color.Transparent;
            this.pic_Setup.IsDrawGlass = false;
            this.pic_Setup.Location = new System.Drawing.Point(54, 2);
            this.pic_Setup.MouseBack = global::MiniTalk.FixedImages.设置_被选中;
            this.pic_Setup.MouseBaseColor = System.Drawing.Color.Transparent;
            this.pic_Setup.Name = "pic_Setup";
            this.pic_Setup.NormlBack = global::MiniTalk.FixedImages.设置;
            this.pic_Setup.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.pic_Setup.Size = new System.Drawing.Size(23, 23);
            this.pic_Setup.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.pic_Setup, "设置");
            this.pic_Setup.UseVisualStyleBackColor = true;
            this.pic_Setup.Click += new System.EventHandler(this.pic_setup_Click);
            // 
            // bt_Ref
            // 
            this.bt_Ref.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Ref.BackColor = System.Drawing.Color.Transparent;
            this.bt_Ref.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Ref.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Ref.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Ref.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Ref.DownBack = global::MiniTalk.FixedImages.刷新;
            this.bt_Ref.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Ref.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Ref.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Ref.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Ref.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Ref.IsDrawGlass = false;
            this.bt_Ref.IsEnabledDraw = false;
            this.bt_Ref.Location = new System.Drawing.Point(190, 682);
            this.bt_Ref.MouseBack = global::MiniTalk.FixedImages.刷新_被选中;
            this.bt_Ref.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Ref.Name = "bt_Ref";
            this.bt_Ref.NormlBack = global::MiniTalk.FixedImages.刷新;
            this.bt_Ref.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Ref.Size = new System.Drawing.Size(20, 20);
            this.bt_Ref.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.bt_Ref, "刷新列表");
            this.bt_Ref.UseVisualStyleBackColor = true;
            this.bt_Ref.Click += new System.EventHandler(this.picRefresh_Click);
            // 
            // bt_select
            // 
            this.bt_select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_select.BackColor = System.Drawing.Color.Transparent;
            this.bt_select.BaseColor = System.Drawing.Color.Transparent;
            this.bt_select.BorderColor = System.Drawing.Color.SpringGreen;
            this.bt_select.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_select.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_select.DownBack")));
            this.bt_select.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_select.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_select.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_select.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_select.InnerBorderColor = System.Drawing.Color.LightCyan;
            this.bt_select.IsDrawGlass = false;
            this.bt_select.Location = new System.Drawing.Point(229, 2);
            this.bt_select.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_select.MouseBack")));
            this.bt_select.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_select.Name = "bt_select";
            this.bt_select.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_select.NormlBack")));
            this.bt_select.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_select.Size = new System.Drawing.Size(20, 20);
            this.bt_select.TabIndex = 30;
            this.toolTip_控件提示.SetToolTip(this.bt_select, "在列表中查找");
            this.bt_select.UseVisualStyleBackColor = true;
            this.bt_select.Click += new System.EventHandler(this.bt_select_Click);
            // 
            // bt_Exp
            // 
            this.bt_Exp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Exp.BackColor = System.Drawing.Color.Transparent;
            this.bt_Exp.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Exp.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Exp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Exp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Exp.DownBack = global::MiniTalk.FixedImages.发送表情;
            this.bt_Exp.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Exp.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Exp.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Exp.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Exp.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Exp.IsDrawGlass = false;
            this.bt_Exp.Location = new System.Drawing.Point(577, 2);
            this.bt_Exp.MouseBack = global::MiniTalk.FixedImages.发送表情_被选中;
            this.bt_Exp.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Exp.Name = "bt_Exp";
            this.bt_Exp.NormlBack = global::MiniTalk.FixedImages.发送表情;
            this.bt_Exp.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Exp.Size = new System.Drawing.Size(26, 26);
            this.bt_Exp.TabIndex = 27;
            this.bt_Exp.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_Exp, "发送表情");
            this.bt_Exp.UseVisualStyleBackColor = true;
            this.bt_Exp.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // bt_Remote
            // 
            this.bt_Remote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Remote.BackColor = System.Drawing.Color.Transparent;
            this.bt_Remote.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Remote.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Remote.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Remote.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Remote.DownBack = global::MiniTalk.FixedImages.远程协助;
            this.bt_Remote.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Remote.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Remote.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Remote.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Remote.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Remote.IsDrawGlass = false;
            this.bt_Remote.Location = new System.Drawing.Point(448, 3);
            this.bt_Remote.MouseBack = global::MiniTalk.FixedImages.远程协助_被选中;
            this.bt_Remote.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Remote.Name = "bt_Remote";
            this.bt_Remote.NormlBack = global::MiniTalk.FixedImages.远程协助;
            this.bt_Remote.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Remote.Size = new System.Drawing.Size(27, 26);
            this.bt_Remote.TabIndex = 27;
            this.bt_Remote.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_Remote, "远程协助");
            this.bt_Remote.UseVisualStyleBackColor = true;
            this.bt_Remote.Click += new System.EventHandler(this.pictureBox_Remote_Click);
            // 
            // bt_Adv
            // 
            this.bt_Adv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Adv.BackColor = System.Drawing.Color.Transparent;
            this.bt_Adv.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Adv.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Adv.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Adv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Adv.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_Adv.DownBack")));
            this.bt_Adv.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Adv.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Adv.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Adv.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Adv.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Adv.IsDrawGlass = false;
            this.bt_Adv.Location = new System.Drawing.Point(478, 2);
            this.bt_Adv.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_Adv.MouseBack")));
            this.bt_Adv.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Adv.Name = "bt_Adv";
            this.bt_Adv.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_Adv.NormlBack")));
            this.bt_Adv.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Adv.Size = new System.Drawing.Size(30, 28);
            this.bt_Adv.TabIndex = 27;
            this.bt_Adv.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_Adv, "MiniTalk-推广");
            this.bt_Adv.UseVisualStyleBackColor = true;
            this.bt_Adv.Click += new System.EventHandler(this.bt_Adv_Click);
            // 
            // bt_SendImg
            // 
            this.bt_SendImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_SendImg.BackColor = System.Drawing.Color.Transparent;
            this.bt_SendImg.BaseColor = System.Drawing.Color.Transparent;
            this.bt_SendImg.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_SendImg.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_SendImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_SendImg.DownBack = global::MiniTalk.FixedImages.发送图片消息;
            this.bt_SendImg.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_SendImg.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_SendImg.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_SendImg.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_SendImg.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_SendImg.IsDrawGlass = false;
            this.bt_SendImg.Location = new System.Drawing.Point(513, 4);
            this.bt_SendImg.MouseBack = global::MiniTalk.FixedImages.发送图片消息_被选中;
            this.bt_SendImg.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_SendImg.Name = "bt_SendImg";
            this.bt_SendImg.NormlBack = global::MiniTalk.FixedImages.发送图片消息;
            this.bt_SendImg.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_SendImg.Size = new System.Drawing.Size(27, 26);
            this.bt_SendImg.TabIndex = 27;
            this.bt_SendImg.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_SendImg, "发送图片");
            this.bt_SendImg.UseVisualStyleBackColor = true;
            this.bt_SendImg.Click += new System.EventHandler(this.picbox_SendImg_Click);
            // 
            // bt_SendFile
            // 
            this.bt_SendFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_SendFile.BackColor = System.Drawing.Color.Transparent;
            this.bt_SendFile.BaseColor = System.Drawing.Color.Transparent;
            this.bt_SendFile.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_SendFile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_SendFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_SendFile.DownBack = global::MiniTalk.FixedImages.文件发送;
            this.bt_SendFile.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_SendFile.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_SendFile.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_SendFile.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_SendFile.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_SendFile.IsDrawGlass = false;
            this.bt_SendFile.Location = new System.Drawing.Point(545, 2);
            this.bt_SendFile.MouseBack = global::MiniTalk.FixedImages.文件发送_被选中;
            this.bt_SendFile.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_SendFile.Name = "bt_SendFile";
            this.bt_SendFile.NormlBack = global::MiniTalk.FixedImages.文件发送;
            this.bt_SendFile.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_SendFile.Size = new System.Drawing.Size(27, 26);
            this.bt_SendFile.TabIndex = 27;
            this.bt_SendFile.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_SendFile, "发送文件");
            this.bt_SendFile.UseVisualStyleBackColor = true;
            this.bt_SendFile.Click += new System.EventHandler(this.Bt_SendFile_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(4, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(34, 29);
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.pictureBox5, "最新的消息会在这里通知");
            // 
            // bt_zoom
            // 
            this.bt_zoom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_zoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bt_zoom.Image = global::MiniTalk.FixedImages.右箭头;
            this.bt_zoom.Location = new System.Drawing.Point(3, 3);
            this.bt_zoom.Name = "bt_zoom";
            this.tableLayoutPanel2.SetRowSpan(this.bt_zoom, 2);
            this.bt_zoom.Size = new System.Drawing.Size(22, 59);
            this.bt_zoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bt_zoom.TabIndex = 25;
            this.bt_zoom.TabStop = false;
            this.toolTip_控件提示.SetToolTip(this.bt_zoom, "隐藏会话栏");
            this.bt_zoom.Click += new System.EventHandler(this.bt_zoom_Click);
            // 
            // bt_resultClose
            // 
            this.bt_resultClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_resultClose.BackColor = System.Drawing.Color.Transparent;
            this.bt_resultClose.BaseColor = System.Drawing.Color.Transparent;
            this.bt_resultClose.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_resultClose.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_resultClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_resultClose.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_resultClose.DownBack")));
            this.bt_resultClose.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_resultClose.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_resultClose.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_resultClose.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_resultClose.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_resultClose.IsDrawGlass = false;
            this.bt_resultClose.Location = new System.Drawing.Point(252, 6);
            this.bt_resultClose.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_resultClose.MouseBack")));
            this.bt_resultClose.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_resultClose.Name = "bt_resultClose";
            this.bt_resultClose.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_resultClose.NormlBack")));
            this.bt_resultClose.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_resultClose.Size = new System.Drawing.Size(25, 20);
            this.bt_resultClose.TabIndex = 28;
            this.toolTip_控件提示.SetToolTip(this.bt_resultClose, "关闭结果视图");
            this.bt_resultClose.UseVisualStyleBackColor = true;
            this.bt_resultClose.Click += new System.EventHandler(this.bt_resultClose_Click);
            // 
            // bt_Search
            // 
            this.bt_Search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Search.BackColor = System.Drawing.Color.Transparent;
            this.bt_Search.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Search.BorderColor = System.Drawing.Color.SpringGreen;
            this.bt_Search.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Search.DownBack = ((System.Drawing.Image)(resources.GetObject("bt_Search.DownBack")));
            this.bt_Search.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_Search.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Search.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Search.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Search.InnerBorderColor = System.Drawing.Color.LightCyan;
            this.bt_Search.IsDrawGlass = false;
            this.bt_Search.Location = new System.Drawing.Point(138, 9);
            this.bt_Search.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_Search.MouseBack")));
            this.bt_Search.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_Search.NormlBack")));
            this.bt_Search.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Search.Size = new System.Drawing.Size(20, 20);
            this.bt_Search.TabIndex = 30;
            this.toolTip_控件提示.SetToolTip(this.bt_Search, "在列表中搜索");
            this.bt_Search.UseVisualStyleBackColor = true;
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "选择一个文件";
            // 
            // label_watermark
            // 
            this.label_watermark.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_watermark.AutoSize = true;
            this.label_watermark.BackColor = System.Drawing.Color.Black;
            this.label_watermark.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label_watermark.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_watermark.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label_watermark.Location = new System.Drawing.Point(3, 562);
            this.label_watermark.Name = "label_watermark";
            this.label_watermark.Size = new System.Drawing.Size(141, 19);
            this.label_watermark.TabIndex = 26;
            this.label_watermark.Text = "点击输入发送消息...";
            this.label_watermark.Click += new System.EventHandler(this.label_watermark_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.cms_托盘;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "双击打开主界面";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // cms_托盘
            // 
            this.cms_托盘.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_托盘.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_显示主窗口,
            this.ToolStrip_退出,
            this.关于ToolStripMenuItem});
            this.cms_托盘.Name = "cms_托盘";
            this.cms_托盘.Size = new System.Drawing.Size(137, 70);
            // 
            // toolStrip_显示主窗口
            // 
            this.toolStrip_显示主窗口.Name = "toolStrip_显示主窗口";
            this.toolStrip_显示主窗口.Size = new System.Drawing.Size(136, 22);
            this.toolStrip_显示主窗口.Text = "打开主界面";
            this.toolStrip_显示主窗口.Click += new System.EventHandler(this.toolStrip_ShowMain_Click);
            // 
            // ToolStrip_退出
            // 
            this.ToolStrip_退出.Name = "ToolStrip_退出";
            this.ToolStrip_退出.Size = new System.Drawing.Size(136, 22);
            this.ToolStrip_退出.Text = "退出";
            this.ToolStrip_退出.Click += new System.EventHandler(this.ToolStrip_Cancel_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // bt_Send
            // 
            this.bt_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Send.BackColor = System.Drawing.Color.Transparent;
            this.bt_Send.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Send.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Send.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Send.DownBack = null;
            this.bt_Send.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Send.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Send.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Send.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Send.IsDrawGlass = false;
            this.bt_Send.Location = new System.Drawing.Point(616, 668);
            this.bt_Send.MouseBack = null;
            this.bt_Send.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Send.Name = "bt_Send";
            this.bt_Send.NormlBack = null;
            this.bt_Send.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Send.Size = new System.Drawing.Size(81, 41);
            this.bt_Send.TabIndex = 27;
            this.bt_Send.TabStop = false;
            this.bt_Send.Text = "发送";
            this.bt_Send.UseVisualStyleBackColor = true;
            this.bt_Send.Click += new System.EventHandler(this.Button1_Click);
            // 
            // bt_Clear
            // 
            this.bt_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Clear.BackColor = System.Drawing.Color.Transparent;
            this.bt_Clear.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Clear.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.bt_Clear.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Clear.DownBack = null;
            this.bt_Clear.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Clear.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Clear.GlowColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Clear.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Clear.IsDrawGlass = false;
            this.bt_Clear.Location = new System.Drawing.Point(706, 668);
            this.bt_Clear.MouseBack = null;
            this.bt_Clear.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.NormlBack = null;
            this.bt_Clear.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Clear.Size = new System.Drawing.Size(81, 41);
            this.bt_Clear.TabIndex = 27;
            this.bt_Clear.TabStop = false;
            this.bt_Clear.Text = "清空";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.Button2_Click);
            // 
            // cms_在线列表
            // 
            this.cms_在线列表.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.cms_在线列表.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_在线列表.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iP备注不适用DHCPToolStripMenuItem,
            this.ts_TextRek,
            this.toolStripSeparator1,
            this.ts_Shield,
            this.ts_Topping});
            this.cms_在线列表.Name = "cms_在线列表";
            this.cms_在线列表.ShowImageMargin = false;
            this.cms_在线列表.Size = new System.Drawing.Size(186, 101);
            this.cms_在线列表.Closed += new System.Windows.Forms.ToolStripDropDownClosedEventHandler(this.cms_在线列表_Closed);
            this.cms_在线列表.Opening += new System.ComponentModel.CancelEventHandler(this.cms_在线列表_Opening);
            // 
            // iP备注不适用DHCPToolStripMenuItem
            // 
            this.iP备注不适用DHCPToolStripMenuItem.Enabled = false;
            this.iP备注不适用DHCPToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.iP备注不适用DHCPToolStripMenuItem.Name = "iP备注不适用DHCPToolStripMenuItem";
            this.iP备注不适用DHCPToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.iP备注不适用DHCPToolStripMenuItem.Text = "IP备注(不适用DHCP):";
            // 
            // ts_TextRek
            // 
            this.ts_TextRek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ts_TextRek.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ts_TextRek.ForeColor = System.Drawing.Color.Khaki;
            this.ts_TextRek.MaxLength = 6;
            this.ts_TextRek.Name = "ts_TextRek";
            this.ts_TextRek.Size = new System.Drawing.Size(150, 23);
            this.ts_TextRek.Text = "昵称";
            this.ts_TextRek.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ts_TextRek_KeyDown);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // ts_Shield
            // 
            this.ts_Shield.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.ts_Shield.Name = "ts_Shield";
            this.ts_Shield.Size = new System.Drawing.Size(185, 22);
            this.ts_Shield.Text = "屏蔽此人";
            this.ts_Shield.Click += new System.EventHandler(this.ts_Shield_Click);
            // 
            // ts_Topping
            // 
            this.ts_Topping.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.ts_Topping.Name = "ts_Topping";
            this.ts_Topping.Size = new System.Drawing.Size(185, 22);
            this.ts_Topping.Text = "置顶";
            this.ts_Topping.Click += new System.EventHandler(this.ts_Topping_Click);
            // 
            // iP备注不适用于DHCPToolStripMenuItem
            // 
            this.iP备注不适用于DHCPToolStripMenuItem.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.iP备注不适用于DHCPToolStripMenuItem.Name = "iP备注不适用于DHCPToolStripMenuItem";
            this.iP备注不适用于DHCPToolStripMenuItem.Size = new System.Drawing.Size(208, 24);
            this.iP备注不适用于DHCPToolStripMenuItem.Text = "IP备注(不适用于DHCP)";
            // 
            // panel_Result
            // 
            this.panel_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Result.BackColor = System.Drawing.Color.Black;
            this.panel_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Result.Controls.Add(this.bt_resultClose);
            this.panel_Result.Controls.Add(this.ListBox_Select_Result);
            this.panel_Result.Controls.Add(this.myPanel2);
            this.panel_Result.Controls.Add(this.label2);
            this.panel_Result.Location = new System.Drawing.Point(5, 75);
            this.panel_Result.Name = "panel_Result";
            this.panel_Result.Padding = new System.Windows.Forms.Padding(15);
            this.panel_Result.Size = new System.Drawing.Size(289, 582);
            this.panel_Result.TabIndex = 31;
            this.panel_Result.Visible = false;
            this.panel_Result.Leave += new System.EventHandler(this.panel_Result_Leave);
            // 
            // ListBox_Select_Result
            // 
            this.ListBox_Select_Result.Back = null;
            this.ListBox_Select_Result.BackColor = System.Drawing.Color.Transparent;
            this.ListBox_Select_Result.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 20);
            this.ListBox_Select_Result.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.ListBox_Select_Result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListBox_Select_Result.ColumnWidth = 10;
            this.ListBox_Select_Result.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBox_Select_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Select_Result.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListBox_Select_Result.Font = new System.Drawing.Font("黑体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListBox_Select_Result.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.ListBox_Select_Result.FormattingEnabled = true;
            this.ListBox_Select_Result.ItemGlassVisble = false;
            this.ListBox_Select_Result.ItemHeight = 60;
            this.ListBox_Select_Result.Location = new System.Drawing.Point(15, 62);
            this.ListBox_Select_Result.MouseColor = System.Drawing.Color.Transparent;
            this.ListBox_Select_Result.Name = "ListBox_Select_Result";
            this.ListBox_Select_Result.RowBackColor1 = System.Drawing.Color.Transparent;
            this.ListBox_Select_Result.RowBackColor2 = System.Drawing.Color.Transparent;
            this.ListBox_Select_Result.SelectedColor = System.Drawing.Color.Transparent;
            this.ListBox_Select_Result.Size = new System.Drawing.Size(257, 503);
            this.ListBox_Select_Result.TabIndex = 24;
            this.ListBox_Select_Result.SelectedIndexChanged += new System.EventHandler(this.ListBox_Select_Result_SelectedIndexChanged);
            // 
            // myPanel2
            // 
            this.myPanel2.Controls.Add(this.bt_select);
            this.myPanel2.Controls.Add(this.txb_SelectInput);
            this.myPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.myPanel2.Location = new System.Drawing.Point(15, 30);
            this.myPanel2.Name = "myPanel2";
            this.myPanel2.Size = new System.Drawing.Size(257, 32);
            this.myPanel2.TabIndex = 33;
            // 
            // txb_SelectInput
            // 
            this.txb_SelectInput.BackColor = System.Drawing.Color.Black;
            this.txb_SelectInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txb_SelectInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txb_SelectInput.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txb_SelectInput.ForeColor = System.Drawing.Color.Turquoise;
            this.txb_SelectInput.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txb_SelectInput.Location = new System.Drawing.Point(0, 0);
            this.txb_SelectInput.Name = "txb_SelectInput";
            this.txb_SelectInput.Size = new System.Drawing.Size(257, 23);
            this.txb_SelectInput.TabIndex = 33;
            this.txb_SelectInput.TextChanged += new System.EventHandler(this.txb_SelectInput_TextChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(226)))), ((int)(((byte)(198)))));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(257, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "搜索在线列表：";
            // 
            // Pbar_schedule
            // 
            this.Pbar_schedule.Back = null;
            this.Pbar_schedule.BackColor = System.Drawing.Color.Transparent;
            this.Pbar_schedule.BarBack = null;
            this.Pbar_schedule.BarGlass = false;
            this.Pbar_schedule.BarRadius = 1;
            this.Pbar_schedule.BarRadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.Pbar_schedule.Border = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.Pbar_schedule, 3);
            this.Pbar_schedule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Pbar_schedule.ForeColor = System.Drawing.Color.Red;
            this.Pbar_schedule.FormatString = "";
            this.Pbar_schedule.Glass = false;
            this.Pbar_schedule.InnerBorder = System.Drawing.Color.Transparent;
            this.Pbar_schedule.Location = new System.Drawing.Point(0, 68);
            this.Pbar_schedule.Margin = new System.Windows.Forms.Padding(0);
            this.Pbar_schedule.Maximum = 256;
            this.Pbar_schedule.Name = "Pbar_schedule";
            this.Pbar_schedule.RadiusStyle = CCWin.SkinClass.RoundStyle.All;
            this.Pbar_schedule.Size = new System.Drawing.Size(274, 6);
            this.Pbar_schedule.TabIndex = 32;
            this.Pbar_schedule.TrackBack = System.Drawing.Color.Transparent;
            this.Pbar_schedule.TrackFore = System.Drawing.Color.Cyan;
            this.Pbar_schedule.Value = 150;
            // 
            // timer_ScreenHook
            // 
            this.timer_ScreenHook.Interval = 80;
            this.timer_ScreenHook.Tick += new System.EventHandler(this.timer_ScreenHook_Tick);
            // 
            // ListBox_Online
            // 
            this.ListBox_Online.BackColor = System.Drawing.Color.Transparent;
            this.ListBox_Online.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListBox_Online.ColumnWidth = 20;
            this.ListBox_Online.ContextMenuStrip = this.cms_在线列表;
            this.ListBox_Online.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ListBox_Online.DataSource = this.bs_ListBoxOnline;
            this.ListBox_Online.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBox_Online.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ListBox_Online.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ListBox_Online.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.ListBox_Online.FormattingEnabled = true;
            this.ListBox_Online.ItemHeight = 58;
            this.ListBox_Online.Location = new System.Drawing.Point(10, 79);
            this.ListBox_Online.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListBox_Online.Name = "ListBox_Online";
            this.ListBox_Online.Size = new System.Drawing.Size(274, 602);
            this.ListBox_Online.TabIndex = 21;
            this.ListBox_Online.TabStop = false;
            this.ListBox_Online.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_Online_MouseClick);
            this.ListBox_Online.SelectedIndexChanged += new System.EventHandler(this.ListBox_Online_SelectedIndexChanged);
            this.ListBox_Online.SizeChanged += new System.EventHandler(this.ListBox_Online_SizeChanged);
            // 
            // myPanel1
            // 
            this.myPanel1.BackColor = System.Drawing.Color.Black;
            this.myPanel1.Controls.Add(this.lb_Roll);
            this.myPanel1.Controls.Add(this.label3);
            this.myPanel1.Controls.Add(this.bt_Exp);
            this.myPanel1.Controls.Add(this.bt_Remote);
            this.myPanel1.Controls.Add(this.bt_Adv);
            this.myPanel1.Controls.Add(this.bt_SendImg);
            this.myPanel1.Controls.Add(this.bt_SendFile);
            this.myPanel1.Controls.Add(this.pictureBox5);
            this.myPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.myPanel1.Location = new System.Drawing.Point(0, 681);
            this.myPanel1.Name = "myPanel1";
            this.myPanel1.Size = new System.Drawing.Size(792, 31);
            this.myPanel1.TabIndex = 23;
            // 
            // lb_Roll
            // 
            this.lb_Roll.AutoSize = true;
            this.lb_Roll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Roll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(226)))), ((int)(((byte)(198)))));
            this.lb_Roll.Location = new System.Drawing.Point(86, 7);
            this.lb_Roll.Name = "lb_Roll";
            this.lb_Roll.Size = new System.Drawing.Size(0, 17);
            this.lb_Roll.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(226)))), ((int)(((byte)(198)))));
            this.label3.Location = new System.Drawing.Point(38, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "消息：";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.panel_left, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_right, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1098, 718);
            this.tableLayoutPanel1.TabIndex = 34;
            // 
            // panel_left
            // 
            this.panel_left.Controls.Add(this.panel_At);
            this.panel_left.Controls.Add(this.uC_Expression1);
            this.panel_left.Controls.Add(this.bt_Send);
            this.panel_left.Controls.Add(this.bt_Clear);
            this.panel_left.Controls.Add(this.label_watermark);
            this.panel_left.Controls.Add(this.pic_NowHead);
            this.panel_left.Controls.Add(this.txb_input);
            this.panel_left.Controls.Add(this.pictureBox3);
            this.panel_left.Controls.Add(this.myPanel1);
            this.panel_left.Controls.Add(this.label1);
            this.panel_left.Controls.Add(this.lb_nowName);
            this.panel_left.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_left.Location = new System.Drawing.Point(3, 3);
            this.panel_left.Name = "panel_left";
            this.panel_left.Size = new System.Drawing.Size(792, 712);
            this.panel_left.TabIndex = 35;
            this.panel_left.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_left_Paint);
            this.panel_left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_left_MouseDown);
            // 
            // panel_At
            // 
            this.panel_At.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel_At.BackColor = System.Drawing.Color.Black;
            this.panel_At.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_At.Controls.Add(this.listBox_Ats);
            this.panel_At.Location = new System.Drawing.Point(4, 243);
            this.panel_At.Name = "panel_At";
            this.panel_At.Padding = new System.Windows.Forms.Padding(5);
            this.panel_At.Size = new System.Drawing.Size(213, 314);
            this.panel_At.TabIndex = 31;
            this.panel_At.Visible = false;
            this.panel_At.VisibleChanged += new System.EventHandler(this.panel_At_VisibleChanged);
            this.panel_At.Leave += new System.EventHandler(this.panel_Result_Leave);
            // 
            // listBox_Ats
            // 
            this.listBox_Ats.Back = null;
            this.listBox_Ats.BackColor = System.Drawing.Color.Transparent;
            this.listBox_Ats.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 20);
            this.listBox_Ats.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.listBox_Ats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Ats.ColumnWidth = 10;
            this.listBox_Ats.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listBox_Ats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Ats.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.listBox_Ats.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Ats.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.listBox_Ats.FormattingEnabled = true;
            this.listBox_Ats.ItemGlassVisble = false;
            this.listBox_Ats.ItemHeight = 40;
            this.listBox_Ats.Location = new System.Drawing.Point(5, 5);
            this.listBox_Ats.MouseColor = System.Drawing.Color.Transparent;
            this.listBox_Ats.Name = "listBox_Ats";
            this.listBox_Ats.RowBackColor1 = System.Drawing.Color.Transparent;
            this.listBox_Ats.RowBackColor2 = System.Drawing.Color.Transparent;
            this.listBox_Ats.SelectedColor = System.Drawing.Color.Transparent;
            this.listBox_Ats.Size = new System.Drawing.Size(201, 302);
            this.listBox_Ats.TabIndex = 24;
            this.listBox_Ats.Click += new System.EventHandler(this.listBox_Ats_Click);
            // 
            // uC_Expression1
            // 
            this.uC_Expression1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_Expression1.BackColor = System.Drawing.Color.Black;
            this.uC_Expression1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.uC_Expression1.Location = new System.Drawing.Point(347, 325);
            this.uC_Expression1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uC_Expression1.Name = "uC_Expression1";
            this.uC_Expression1.Size = new System.Drawing.Size(440, 337);
            this.uC_Expression1.TabIndex = 28;
            this.uC_Expression1.Visible = false;
            // 
            // panel_right
            // 
            this.panel_right.Controls.Add(this.panel_Result);
            this.panel_right.Controls.Add(this.scrollBar_Online);
            this.panel_right.Controls.Add(this.bt_Ref);
            this.panel_right.Controls.Add(this.ListBox_Online);
            this.panel_right.Controls.Add(this.myPanel3);
            this.panel_right.Controls.Add(this.label_count);
            this.panel_right.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_right.Location = new System.Drawing.Point(801, 3);
            this.panel_right.Name = "panel_right";
            this.panel_right.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.panel_right.Size = new System.Drawing.Size(294, 712);
            this.panel_right.TabIndex = 35;
            // 
            // scrollBar_Online
            // 
            this.scrollBar_Online.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollBar_Online.AutoSize = true;
            this.scrollBar_Online.BindControl = this.ListBox_Online;
            this.scrollBar_Online.ColorBg = System.Drawing.Color.Transparent;
            this.scrollBar_Online.ColorLine = System.Drawing.Color.Transparent;
            this.scrollBar_Online.ImageDownArrow = ((System.Drawing.Image)(resources.GetObject("scrollBar_Online.ImageDownArrow")));
            this.scrollBar_Online.ImageThumb = ((System.Drawing.Image)(resources.GetObject("scrollBar_Online.ImageThumb")));
            this.scrollBar_Online.ImageUpArrow = ((System.Drawing.Image)(resources.GetObject("scrollBar_Online.ImageUpArrow")));
            this.scrollBar_Online.Location = new System.Drawing.Point(275, 80);
            this.scrollBar_Online.Margin = new System.Windows.Forms.Padding(4);
            this.scrollBar_Online.Maximum = 100;
            this.scrollBar_Online.Minimum = 100;
            this.scrollBar_Online.Name = "scrollBar_Online";
            this.scrollBar_Online.Size = new System.Drawing.Size(22, 610);
            this.scrollBar_Online.SmallChange = 10;
            this.scrollBar_Online.TabIndex = 35;
            this.scrollBar_Online.ThumbHeight = 10;
            this.scrollBar_Online.Value = 0;
            this.scrollBar_Online.MouseEnter += new System.EventHandler(this.scrollBar_Online_MouseEnter);
            this.scrollBar_Online.MouseLeave += new System.EventHandler(this.scrollBar_Online_MouseLeave);
            // 
            // myPanel3
            // 
            this.myPanel3.Controls.Add(this.tableLayoutPanel2);
            this.myPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.myPanel3.Location = new System.Drawing.Point(10, 0);
            this.myPanel3.Name = "myPanel3";
            this.myPanel3.Size = new System.Drawing.Size(274, 79);
            this.myPanel3.TabIndex = 34;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.95275F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.04724F));
            this.tableLayoutPanel2.Controls.Add(this.myPanel4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.Pbar_schedule, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.picBox_HeadImg, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.bt_zoom, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.myPanel5, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(274, 79);
            this.tableLayoutPanel2.TabIndex = 29;
            // 
            // myPanel4
            // 
            this.myPanel4.Controls.Add(this.bt_Max);
            this.myPanel4.Controls.Add(this.bt_Small);
            this.myPanel4.Controls.Add(this.bt_CloseForm);
            this.myPanel4.Controls.Add(this.pic_Setup);
            this.myPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanel4.Location = new System.Drawing.Point(99, 3);
            this.myPanel4.Name = "myPanel4";
            this.myPanel4.Size = new System.Drawing.Size(172, 25);
            this.myPanel4.TabIndex = 34;
            this.myPanel4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_left_MouseDown);
            // 
            // picBox_HeadImg
            // 
            this.picBox_HeadImg.BackColor = System.Drawing.Color.Transparent;
            this.picBox_HeadImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBox_HeadImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_HeadImg.Image = global::MiniTalk.HeadImages.im1;
            this.picBox_HeadImg.Location = new System.Drawing.Point(31, 2);
            this.picBox_HeadImg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBox_HeadImg.Name = "picBox_HeadImg";
            this.tableLayoutPanel2.SetRowSpan(this.picBox_HeadImg, 2);
            this.picBox_HeadImg.Size = new System.Drawing.Size(62, 61);
            this.picBox_HeadImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox_HeadImg.TabIndex = 5;
            this.picBox_HeadImg.TabStop = false;
            this.picBox_HeadImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_left_MouseDown);
            // 
            // myPanel5
            // 
            this.myPanel5.Controls.Add(this.bt_Search);
            this.myPanel5.Controls.Add(this.lb_Name);
            this.myPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myPanel5.Location = new System.Drawing.Point(111, 31);
            this.myPanel5.Margin = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.myPanel5.Name = "myPanel5";
            this.myPanel5.Size = new System.Drawing.Size(163, 34);
            this.myPanel5.TabIndex = 35;
            // 
            // lb_Name
            // 
            this.lb_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.lb_Name.Font = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Name.ForeColor = System.Drawing.Color.Aqua;
            this.lb_Name.Location = new System.Drawing.Point(0, 0);
            this.lb_Name.Margin = new System.Windows.Forms.Padding(15, 0, 3, 0);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(132, 34);
            this.lb_Name.TabIndex = 33;
            this.lb_Name.Text = "一无所知";
            this.lb_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lb_Name.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_left_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1100, 720);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 300);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1100, 720);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniTalk";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.cms_输入框.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_NowHead)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bt_zoom)).EndInit();
            this.cms_托盘.ResumeLayout(false);
            this.cms_在线列表.ResumeLayout(false);
            this.cms_在线列表.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bs_ListBoxOnline)).EndInit();
            this.panel_Result.ResumeLayout(false);
            this.myPanel2.ResumeLayout(false);
            this.myPanel2.PerformLayout();
            this.myPanel1.ResumeLayout(false);
            this.myPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_left.ResumeLayout(false);
            this.panel_left.PerformLayout();
            this.panel_At.ResumeLayout(false);
            this.panel_right.ResumeLayout(false);
            this.panel_right.PerformLayout();
            this.myPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.myPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_HeadImg)).EndInit();
            this.myPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txb_input;
        private System.Windows.Forms.ToolTip toolTip_控件提示;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.Label label_count;
        public System.Windows.Forms.PictureBox pic_NowHead;
        public System.Windows.Forms.Label lb_nowName;
        public Override_Control.TransparentListBox ListBox_Online;
        public Override_Control.MyPanel myPanel1;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_watermark;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip cms_托盘;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_显示主窗口;
        private System.Windows.Forms.ToolStripMenuItem ToolStrip_退出;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cms_输入框;
        private System.Windows.Forms.ToolStripMenuItem 清空ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 发送ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 插入表情ToolStripMenuItem;
        private System.Windows.Forms.Label lb_Roll;
        private CCWin.SkinControl.SkinButton bt_Send;
        private CCWin.SkinControl.SkinButton bt_Clear;
        public CCWin.SkinControl.SkinButton bt_SendFile;
        public CCWin.SkinControl.SkinButton bt_Exp;
        public CCWin.SkinControl.SkinButton bt_Remote;
        public CCWin.SkinControl.SkinButton bt_SendImg;
        public CCWin.SkinControl.SkinButton bt_CloseForm;
        public CCWin.SkinControl.SkinButton bt_Max;
        public CCWin.SkinControl.SkinButton bt_Small;
        public CCWin.SkinControl.SkinButton pic_Setup;
        public CCWin.SkinControl.SkinButton bt_Ref;
        internal System.Windows.Forms.BindingSource bs_ListBoxOnline;
        private System.Windows.Forms.ContextMenuStrip cms_在线列表;
        private System.Windows.Forms.ToolStripMenuItem iP备注不适用DHCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ts_TextRek;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ts_Shield;
        private System.Windows.Forms.ToolStripMenuItem iP备注不适用于DHCPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_Topping;
        private System.Windows.Forms.ToolTip toolTip_成员信息;
        public CCWin.SkinControl.SkinButton bt_select;
        private System.Windows.Forms.Panel panel_Result;
        private CCWin.SkinControl.SkinListBox ListBox_Select_Result;
        private System.Windows.Forms.Label label2;
        public CCWin.SkinControl.SkinButton bt_Adv;
        private System.Windows.Forms.Timer timer_ScreenHook;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public Override_Control.MyPanel panel_left;
        public Override_Control.MyPanel panel_right;
        private Override_Control.MyPanel myPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.PictureBox picBox_HeadImg;
        private System.Windows.Forms.Label lb_Name;
        private Override_Control.MyPanel myPanel4;
        private System.Windows.Forms.PictureBox bt_zoom;
        private System.Windows.Forms.TextBox txb_SelectInput;
        public Override_Control.MyPanel myPanel2;
        private Override_Control.UC_Expression uC_Expression1;
        private Override_Control.MyPanel myPanel5;
        public CCWin.SkinControl.SkinButton bt_Search;
        public CCWin.SkinControl.SkinButton bt_resultClose;
        public CCWin.SkinControl.SkinProgressBar Pbar_schedule;
        private LM.CLibrary.Controls.LMVScrollBar scrollBar_Online;
        private System.Windows.Forms.Panel panel_At;
        private CCWin.SkinControl.SkinListBox listBox_Ats;
    }
}

