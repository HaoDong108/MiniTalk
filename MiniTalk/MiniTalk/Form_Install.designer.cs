namespace MiniTalk
{
    partial class Form_Install
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Install));
            this.tb_Main = new CCWin.SkinControl.SkinTabControl();
            this.tp_常规设置 = new CCWin.SkinControl.SkinTabPage();
            this.常规设置_cb_后台截图 = new CCWin.SkinControl.SkinCheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.常规设置_nup_消息时间提醒间隔 = new CCWin.SkinControl.SkinNumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.常规设置_nup_历史消息保留数 = new CCWin.SkinControl.SkinNumericUpDown();
            this.tp_传输设置 = new CCWin.SkinControl.SkinTabPage();
            this.传输设置_nup_大于numMB则屏 = new CCWin.SkinControl.SkinNumericUpDown();
            this.传输设置_cb_屏蔽所有文件消息 = new CCWin.SkinControl.SkinCheckBox();
            this.传输设置_ExtTxb = new DSControls.DS文本框();
            this.传输设置_cb_下载完毕后自动打开文件 = new CCWin.SkinControl.SkinCheckBox();
            this.传输设置_BtAdd = new System.Windows.Forms.Button();
            this.传输设置_bt_更改保存路径 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.传输设置_lb_SavePath = new System.Windows.Forms.Label();
            this.传输设置_ExtListBox = new CCWin.SkinControl.SkinListBox();
            this.Rbtn_Listbox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Rbtn_移除 = new System.Windows.Forms.ToolStripMenuItem();
            this.Rbtn_移除所有 = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tp_提醒设置 = new CCWin.SkinControl.SkinTabPage();
            this.提醒设置_panel2 = new System.Windows.Forms.Panel();
            this.提醒设置_cb_群消息红点标注 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_群消息提醒 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_右下角浮动提醒 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_置顶者强提醒 = new CCWin.SkinControl.SkinCheckBox();
            this.skinGroupBox3 = new CCWin.SkinControl.SkinGroupBox();
            this.提醒设置_cb_公共会话悬浮提醒 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_用户消息悬浮提醒 = new CCWin.SkinControl.SkinCheckBox();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.提醒设置_cb_强提醒模式_对话框 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_强提醒模式_托盘消息 = new CCWin.SkinControl.SkinCheckBox();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.提醒设置_cb_事件消息 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_图片消息 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_文件消息 = new CCWin.SkinControl.SkinCheckBox();
            this.提醒设置_cb_文本消息 = new CCWin.SkinControl.SkinCheckBox();
            this.tp_用户管理 = new CCWin.SkinControl.SkinTabPage();
            this.用户管理_bt_备注修改 = new System.Windows.Forms.Button();
            this.用户管理_tb_备注名 = new DSControls.DS文本框();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.用户管理_lb_黑名单 = new CCWin.SkinControl.SkinListBox();
            this.用户管理_lb_备注列表 = new CCWin.SkinControl.SkinListBox();
            this.pic_Logo = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_Save = new CCWin.SkinControl.SkinButton();
            this.lb_title = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_CloseForm = new CCWin.SkinControl.SkinButton();
            this.tb_Main.SuspendLayout();
            this.tp_常规设置.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.常规设置_nup_消息时间提醒间隔)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.常规设置_nup_历史消息保留数)).BeginInit();
            this.tp_传输设置.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.传输设置_nup_大于numMB则屏)).BeginInit();
            this.Rbtn_Listbox.SuspendLayout();
            this.tp_提醒设置.SuspendLayout();
            this.提醒设置_panel2.SuspendLayout();
            this.skinGroupBox3.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.tp_用户管理.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_Main
            // 
            this.tb_Main.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tb_Main.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tb_Main.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tb_Main.Controls.Add(this.tp_常规设置);
            this.tb_Main.Controls.Add(this.tp_传输设置);
            this.tb_Main.Controls.Add(this.tp_提醒设置);
            this.tb_Main.Controls.Add(this.tp_用户管理);
            this.tb_Main.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.tb_Main.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Main.HeadBack = null;
            this.tb_Main.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tb_Main.ItemSize = new System.Drawing.Size(50, 130);
            this.tb_Main.Location = new System.Drawing.Point(2, 70);
            this.tb_Main.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.tb_Main.Multiline = true;
            this.tb_Main.Name = "tb_Main";
            this.tb_Main.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tb_Main.PageArrowDown")));
            this.tb_Main.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tb_Main.PageArrowHover")));
            this.tb_Main.PageBaseColor = System.Drawing.Color.Transparent;
            this.tb_Main.PageBorderColor = System.Drawing.Color.Transparent;
            this.tb_Main.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tb_Main.PageCloseHover")));
            this.tb_Main.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tb_Main.PageCloseNormal")));
            this.tb_Main.PageDown = null;
            this.tb_Main.PageDownTxtColor = System.Drawing.Color.DarkTurquoise;
            this.tb_Main.PageHover = ((System.Drawing.Image)(resources.GetObject("tb_Main.PageHover")));
            this.tb_Main.PageHoverTxtColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tb_Main.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tb_Main.PageNorml = null;
            this.tb_Main.PageNormlTxtColor = System.Drawing.Color.Gray;
            this.tb_Main.Radius = 1;
            this.tb_Main.SelectedIndex = 2;
            this.tb_Main.Size = new System.Drawing.Size(853, 500);
            this.tb_Main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tb_Main.TabIndex = 0;
            this.tb_Main.SelectedIndexChanged += new System.EventHandler(this.tb_Main_SelectedIndexChanged);
            // 
            // tp_常规设置
            // 
            this.tp_常规设置.BackColor = System.Drawing.Color.Transparent;
            this.tp_常规设置.Controls.Add(this.常规设置_cb_后台截图);
            this.tp_常规设置.Controls.Add(this.label5);
            this.tp_常规设置.Controls.Add(this.常规设置_nup_消息时间提醒间隔);
            this.tp_常规设置.Controls.Add(this.label1);
            this.tp_常规设置.Controls.Add(this.常规设置_nup_历史消息保留数);
            this.tp_常规设置.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tp_常规设置.ForeColor = System.Drawing.Color.Cyan;
            this.tp_常规设置.Location = new System.Drawing.Point(130, 0);
            this.tp_常规设置.Name = "tp_常规设置";
            this.tp_常规设置.Padding = new System.Windows.Forms.Padding(10);
            this.tp_常规设置.Size = new System.Drawing.Size(723, 500);
            this.tp_常规设置.TabIndex = 0;
            this.tp_常规设置.TabItemImage = null;
            this.tp_常规设置.Text = "常规设置";
            this.tp_常规设置.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            // 
            // 常规设置_cb_后台截图
            // 
            this.常规设置_cb_后台截图.AutoSize = true;
            this.常规设置_cb_后台截图.BackColor = System.Drawing.Color.Transparent;
            this.常规设置_cb_后台截图.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.常规设置_cb_后台截图.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.常规设置_cb_后台截图.DownBack = null;
            this.常规设置_cb_后台截图.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.常规设置_cb_后台截图.LightEffect = false;
            this.常规设置_cb_后台截图.LightEffectBack = System.Drawing.Color.Transparent;
            this.常规设置_cb_后台截图.Location = new System.Drawing.Point(33, 210);
            this.常规设置_cb_后台截图.MouseBack = null;
            this.常规设置_cb_后台截图.Name = "常规设置_cb_后台截图";
            this.常规设置_cb_后台截图.NormlBack = null;
            this.常规设置_cb_后台截图.SelectedDownBack = null;
            this.常规设置_cb_后台截图.SelectedMouseBack = null;
            this.常规设置_cb_后台截图.SelectedNormlBack = null;
            this.常规设置_cb_后台截图.Size = new System.Drawing.Size(213, 24);
            this.常规设置_cb_后台截图.TabIndex = 25;
            this.常规设置_cb_后台截图.Text = "启用后台截图 (Ctrl+Alt+S)";
            this.常规设置_cb_后台截图.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(31, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "消息发送时间提示间隔(分钟)：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 常规设置_nup_消息时间提醒间隔
            // 
            this.常规设置_nup_消息时间提醒间隔.ArrowColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_消息时间提醒间隔.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.常规设置_nup_消息时间提醒间隔.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.常规设置_nup_消息时间提醒间隔.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_消息时间提醒间隔.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_消息时间提醒间隔.Location = new System.Drawing.Point(33, 138);
            this.常规设置_nup_消息时间提醒间隔.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.常规设置_nup_消息时间提醒间隔.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.常规设置_nup_消息时间提醒间隔.Name = "常规设置_nup_消息时间提醒间隔";
            this.常规设置_nup_消息时间提醒间隔.Size = new System.Drawing.Size(66, 30);
            this.常规设置_nup_消息时间提醒间隔.TabIndex = 23;
            this.常规设置_nup_消息时间提醒间隔.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(31, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "历史消息保留数：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 常规设置_nup_历史消息保留数
            // 
            this.常规设置_nup_历史消息保留数.ArrowColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_历史消息保留数.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.常规设置_nup_历史消息保留数.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.常规设置_nup_历史消息保留数.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_历史消息保留数.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.常规设置_nup_历史消息保留数.Location = new System.Drawing.Point(33, 52);
            this.常规设置_nup_历史消息保留数.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.常规设置_nup_历史消息保留数.Name = "常规设置_nup_历史消息保留数";
            this.常规设置_nup_历史消息保留数.Size = new System.Drawing.Size(66, 30);
            this.常规设置_nup_历史消息保留数.TabIndex = 19;
            this.常规设置_nup_历史消息保留数.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // tp_传输设置
            // 
            this.tp_传输设置.BackColor = System.Drawing.Color.Transparent;
            this.tp_传输设置.Controls.Add(this.传输设置_nup_大于numMB则屏);
            this.tp_传输设置.Controls.Add(this.传输设置_cb_屏蔽所有文件消息);
            this.tp_传输设置.Controls.Add(this.传输设置_ExtTxb);
            this.tp_传输设置.Controls.Add(this.传输设置_cb_下载完毕后自动打开文件);
            this.tp_传输设置.Controls.Add(this.传输设置_BtAdd);
            this.tp_传输设置.Controls.Add(this.传输设置_bt_更改保存路径);
            this.tp_传输设置.Controls.Add(this.label3);
            this.tp_传输设置.Controls.Add(this.传输设置_lb_SavePath);
            this.tp_传输设置.Controls.Add(this.传输设置_ExtListBox);
            this.tp_传输设置.Controls.Add(this.label4);
            this.tp_传输设置.Controls.Add(this.label2);
            this.tp_传输设置.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tp_传输设置.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.tp_传输设置.Location = new System.Drawing.Point(130, 0);
            this.tp_传输设置.Name = "tp_传输设置";
            this.tp_传输设置.Size = new System.Drawing.Size(723, 500);
            this.tp_传输设置.TabIndex = 1;
            this.tp_传输设置.TabItemImage = null;
            this.tp_传输设置.Text = "传输设置";
            this.tp_传输设置.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            // 
            // 传输设置_nup_大于numMB则屏
            // 
            this.传输设置_nup_大于numMB则屏.ArrowColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_nup_大于numMB则屏.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.传输设置_nup_大于numMB则屏.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.传输设置_nup_大于numMB则屏.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_nup_大于numMB则屏.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_nup_大于numMB则屏.Location = new System.Drawing.Point(33, 223);
            this.传输设置_nup_大于numMB则屏.Maximum = new decimal(new int[] {
            5120,
            0,
            0,
            0});
            this.传输设置_nup_大于numMB则屏.Name = "传输设置_nup_大于numMB则屏";
            this.传输设置_nup_大于numMB则屏.Size = new System.Drawing.Size(66, 30);
            this.传输设置_nup_大于numMB则屏.TabIndex = 18;
            this.传输设置_nup_大于numMB则屏.Value = new decimal(new int[] {
            5120,
            0,
            0,
            0});
            // 
            // 传输设置_cb_屏蔽所有文件消息
            // 
            this.传输设置_cb_屏蔽所有文件消息.AutoSize = true;
            this.传输设置_cb_屏蔽所有文件消息.BackColor = System.Drawing.Color.Transparent;
            this.传输设置_cb_屏蔽所有文件消息.BaseColor = System.Drawing.Color.MediumSeaGreen;
            this.传输设置_cb_屏蔽所有文件消息.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.传输设置_cb_屏蔽所有文件消息.DownBack = null;
            this.传输设置_cb_屏蔽所有文件消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.传输设置_cb_屏蔽所有文件消息.LightEffect = false;
            this.传输设置_cb_屏蔽所有文件消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.传输设置_cb_屏蔽所有文件消息.Location = new System.Drawing.Point(33, 144);
            this.传输设置_cb_屏蔽所有文件消息.MouseBack = null;
            this.传输设置_cb_屏蔽所有文件消息.Name = "传输设置_cb_屏蔽所有文件消息";
            this.传输设置_cb_屏蔽所有文件消息.NormlBack = null;
            this.传输设置_cb_屏蔽所有文件消息.SelectedDownBack = null;
            this.传输设置_cb_屏蔽所有文件消息.SelectedMouseBack = null;
            this.传输设置_cb_屏蔽所有文件消息.SelectedNormlBack = null;
            this.传输设置_cb_屏蔽所有文件消息.Size = new System.Drawing.Size(151, 24);
            this.传输设置_cb_屏蔽所有文件消息.TabIndex = 22;
            this.传输设置_cb_屏蔽所有文件消息.Text = "屏蔽所有文件消息";
            this.传输设置_cb_屏蔽所有文件消息.UseVisualStyleBackColor = false;
            // 
            // 传输设置_ExtTxb
            // 
            this.传输设置_ExtTxb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.传输设置_ExtTxb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.传输设置_ExtTxb.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_ExtTxb.Location = new System.Drawing.Point(539, 110);
            this.传输设置_ExtTxb.MaxLength = 5;
            this.传输设置_ExtTxb.Name = "传输设置_ExtTxb";
            this.传输设置_ExtTxb.Size = new System.Drawing.Size(86, 30);
            this.传输设置_ExtTxb.TabIndex = 19;
            this.传输设置_ExtTxb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.传输设置_ExtTxb.边框色 = System.Drawing.Color.DarkTurquoise;
            this.传输设置_ExtTxb.Enter += new System.EventHandler(this.传输设置_ExtTxb_Enter);
            this.传输设置_ExtTxb.Leave += new System.EventHandler(this.传输设置_ExtTxb_Leave);
            // 
            // 传输设置_cb_下载完毕后自动打开文件
            // 
            this.传输设置_cb_下载完毕后自动打开文件.AutoSize = true;
            this.传输设置_cb_下载完毕后自动打开文件.BackColor = System.Drawing.Color.Transparent;
            this.传输设置_cb_下载完毕后自动打开文件.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.传输设置_cb_下载完毕后自动打开文件.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.传输设置_cb_下载完毕后自动打开文件.DownBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.传输设置_cb_下载完毕后自动打开文件.LightEffect = false;
            this.传输设置_cb_下载完毕后自动打开文件.LightEffectBack = System.Drawing.Color.Transparent;
            this.传输设置_cb_下载完毕后自动打开文件.Location = new System.Drawing.Point(33, 100);
            this.传输设置_cb_下载完毕后自动打开文件.MouseBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.Name = "传输设置_cb_下载完毕后自动打开文件";
            this.传输设置_cb_下载完毕后自动打开文件.NormlBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.SelectedDownBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.SelectedMouseBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.SelectedNormlBack = null;
            this.传输设置_cb_下载完毕后自动打开文件.Size = new System.Drawing.Size(196, 24);
            this.传输设置_cb_下载完毕后自动打开文件.TabIndex = 21;
            this.传输设置_cb_下载完毕后自动打开文件.Text = "下载完毕后自动打开文件";
            this.传输设置_cb_下载完毕后自动打开文件.UseVisualStyleBackColor = false;
            // 
            // 传输设置_BtAdd
            // 
            this.传输设置_BtAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.传输设置_BtAdd.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.传输设置_BtAdd.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_BtAdd.Location = new System.Drawing.Point(631, 110);
            this.传输设置_BtAdd.Name = "传输设置_BtAdd";
            this.传输设置_BtAdd.Size = new System.Drawing.Size(66, 30);
            this.传输设置_BtAdd.TabIndex = 24;
            this.传输设置_BtAdd.Text = "添加";
            this.传输设置_BtAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.传输设置_BtAdd.UseVisualStyleBackColor = true;
            this.传输设置_BtAdd.Click += new System.EventHandler(this.传输设置_BtAdd_Click);
            // 
            // 传输设置_bt_更改保存路径
            // 
            this.传输设置_bt_更改保存路径.Cursor = System.Windows.Forms.Cursors.Hand;
            this.传输设置_bt_更改保存路径.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.传输设置_bt_更改保存路径.Font = new System.Drawing.Font("幼圆", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.传输设置_bt_更改保存路径.Location = new System.Drawing.Point(628, 42);
            this.传输设置_bt_更改保存路径.Name = "传输设置_bt_更改保存路径";
            this.传输设置_bt_更改保存路径.Size = new System.Drawing.Size(73, 34);
            this.传输设置_bt_更改保存路径.TabIndex = 19;
            this.传输设置_bt_更改保存路径.Text = "更改";
            this.传输设置_bt_更改保存路径.UseVisualStyleBackColor = true;
            this.传输设置_bt_更改保存路径.Click += new System.EventHandler(this.传输设置_bt_更改保存路径_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(33, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "文件大小接收最大上限(MB)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label3, "如果接收的文件大小大于指定值，则屏蔽该消息");
            // 
            // 传输设置_lb_SavePath
            // 
            this.传输设置_lb_SavePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.传输设置_lb_SavePath.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.传输设置_lb_SavePath.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_lb_SavePath.Location = new System.Drawing.Point(33, 42);
            this.传输设置_lb_SavePath.Name = "传输设置_lb_SavePath";
            this.传输设置_lb_SavePath.Size = new System.Drawing.Size(588, 34);
            this.传输设置_lb_SavePath.TabIndex = 18;
            this.传输设置_lb_SavePath.Text = "C:\\Program Files\\MiniTalk\\DownLoad";
            this.传输设置_lb_SavePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // 传输设置_ExtListBox
            // 
            this.传输设置_ExtListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.传输设置_ExtListBox.Back = null;
            this.传输设置_ExtListBox.BackColor = System.Drawing.Color.Transparent;
            this.传输设置_ExtListBox.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 20);
            this.传输设置_ExtListBox.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.传输设置_ExtListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.传输设置_ExtListBox.ContextMenuStrip = this.Rbtn_Listbox;
            this.传输设置_ExtListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.传输设置_ExtListBox.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.传输设置_ExtListBox.ForeColor = System.Drawing.Color.White;
            this.传输设置_ExtListBox.FormattingEnabled = true;
            this.传输设置_ExtListBox.ItemGlassVisble = false;
            this.传输设置_ExtListBox.ItemHeight = 40;
            this.传输设置_ExtListBox.ItemRadius = 4;
            this.传输设置_ExtListBox.Location = new System.Drawing.Point(539, 144);
            this.传输设置_ExtListBox.MouseColor = System.Drawing.Color.Transparent;
            this.传输设置_ExtListBox.Name = "传输设置_ExtListBox";
            this.传输设置_ExtListBox.RowBackColor1 = System.Drawing.Color.Transparent;
            this.传输设置_ExtListBox.RowBackColor2 = System.Drawing.Color.Transparent;
            this.传输设置_ExtListBox.SelectedColor = System.Drawing.Color.Transparent;
            this.传输设置_ExtListBox.Size = new System.Drawing.Size(158, 322);
            this.传输设置_ExtListBox.TabIndex = 23;
            this.传输设置_ExtListBox.MouseEnter += new System.EventHandler(this.ListBox_MouseEnter);
            // 
            // Rbtn_Listbox
            // 
            this.Rbtn_Listbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.Rbtn_Listbox.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Rbtn_Listbox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Rbtn_移除,
            this.Rbtn_移除所有});
            this.Rbtn_Listbox.Name = "Rbtn_ExtListbox";
            this.Rbtn_Listbox.ShowImageMargin = false;
            this.Rbtn_Listbox.Size = new System.Drawing.Size(114, 52);
            this.Rbtn_Listbox.Click += new System.EventHandler(this.Rbtn_移除_Click);
            // 
            // Rbtn_移除
            // 
            this.Rbtn_移除.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.Rbtn_移除.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.Rbtn_移除.Name = "Rbtn_移除";
            this.Rbtn_移除.Size = new System.Drawing.Size(113, 24);
            this.Rbtn_移除.Text = "移除";
            // 
            // Rbtn_移除所有
            // 
            this.Rbtn_移除所有.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.Rbtn_移除所有.Name = "Rbtn_移除所有";
            this.Rbtn_移除所有.Size = new System.Drawing.Size(113, 24);
            this.Rbtn_移除所有.Text = "移除所有";
            this.Rbtn_移除所有.Click += new System.EventHandler(this.Rbtn_移除所有_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(537, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "将要屏蔽的文件后缀:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(33, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "下载文件保存路径:";
            // 
            // tp_提醒设置
            // 
            this.tp_提醒设置.BackColor = System.Drawing.Color.Transparent;
            this.tp_提醒设置.Controls.Add(this.提醒设置_panel2);
            this.tp_提醒设置.Controls.Add(this.skinGroupBox3);
            this.tp_提醒设置.Controls.Add(this.skinGroupBox2);
            this.tp_提醒设置.Controls.Add(this.skinGroupBox1);
            this.tp_提醒设置.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tp_提醒设置.ForeColor = System.Drawing.Color.Gray;
            this.tp_提醒设置.Location = new System.Drawing.Point(130, 0);
            this.tp_提醒设置.Name = "tp_提醒设置";
            this.tp_提醒设置.Size = new System.Drawing.Size(723, 500);
            this.tp_提醒设置.TabIndex = 2;
            this.tp_提醒设置.TabItemImage = null;
            this.tp_提醒设置.Text = "提醒设置";
            this.tp_提醒设置.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            // 
            // 提醒设置_panel2
            // 
            this.提醒设置_panel2.Controls.Add(this.提醒设置_cb_群消息红点标注);
            this.提醒设置_panel2.Controls.Add(this.提醒设置_cb_群消息提醒);
            this.提醒设置_panel2.Controls.Add(this.提醒设置_cb_右下角浮动提醒);
            this.提醒设置_panel2.Controls.Add(this.提醒设置_cb_置顶者强提醒);
            this.提醒设置_panel2.Location = new System.Drawing.Point(33, 140);
            this.提醒设置_panel2.Name = "提醒设置_panel2";
            this.提醒设置_panel2.Size = new System.Drawing.Size(628, 31);
            this.提醒设置_panel2.TabIndex = 24;
            // 
            // 提醒设置_cb_群消息红点标注
            // 
            this.提醒设置_cb_群消息红点标注.AutoSize = true;
            this.提醒设置_cb_群消息红点标注.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_群消息红点标注.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_群消息红点标注.Checked = true;
            this.提醒设置_cb_群消息红点标注.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_群消息红点标注.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_群消息红点标注.DownBack = null;
            this.提醒设置_cb_群消息红点标注.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_群消息红点标注.LightEffect = false;
            this.提醒设置_cb_群消息红点标注.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_群消息红点标注.Location = new System.Drawing.Point(148, 4);
            this.提醒设置_cb_群消息红点标注.MouseBack = null;
            this.提醒设置_cb_群消息红点标注.Name = "提醒设置_cb_群消息红点标注";
            this.提醒设置_cb_群消息红点标注.NormlBack = null;
            this.提醒设置_cb_群消息红点标注.SelectedDownBack = null;
            this.提醒设置_cb_群消息红点标注.SelectedMouseBack = null;
            this.提醒设置_cb_群消息红点标注.SelectedNormlBack = null;
            this.提醒设置_cb_群消息红点标注.Size = new System.Drawing.Size(136, 24);
            this.提醒设置_cb_群消息红点标注.TabIndex = 22;
            this.提醒设置_cb_群消息红点标注.Text = "群消息红点标注";
            this.提醒设置_cb_群消息红点标注.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_群消息提醒
            // 
            this.提醒设置_cb_群消息提醒.AutoSize = true;
            this.提醒设置_cb_群消息提醒.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_群消息提醒.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_群消息提醒.Checked = true;
            this.提醒设置_cb_群消息提醒.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_群消息提醒.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_群消息提醒.DownBack = null;
            this.提醒设置_cb_群消息提醒.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_群消息提醒.LightEffect = false;
            this.提醒设置_cb_群消息提醒.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_群消息提醒.Location = new System.Drawing.Point(18, 4);
            this.提醒设置_cb_群消息提醒.MouseBack = null;
            this.提醒设置_cb_群消息提醒.Name = "提醒设置_cb_群消息提醒";
            this.提醒设置_cb_群消息提醒.NormlBack = null;
            this.提醒设置_cb_群消息提醒.SelectedDownBack = null;
            this.提醒设置_cb_群消息提醒.SelectedMouseBack = null;
            this.提醒设置_cb_群消息提醒.SelectedNormlBack = null;
            this.提醒设置_cb_群消息提醒.Size = new System.Drawing.Size(106, 24);
            this.提醒设置_cb_群消息提醒.TabIndex = 22;
            this.提醒设置_cb_群消息提醒.Text = "群消息提醒";
            this.提醒设置_cb_群消息提醒.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_右下角浮动提醒
            // 
            this.提醒设置_cb_右下角浮动提醒.AutoSize = true;
            this.提醒设置_cb_右下角浮动提醒.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_右下角浮动提醒.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_右下角浮动提醒.Checked = true;
            this.提醒设置_cb_右下角浮动提醒.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_右下角浮动提醒.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_右下角浮动提醒.DownBack = null;
            this.提醒设置_cb_右下角浮动提醒.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_右下角浮动提醒.LightEffect = false;
            this.提醒设置_cb_右下角浮动提醒.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_右下角浮动提醒.Location = new System.Drawing.Point(473, 4);
            this.提醒设置_cb_右下角浮动提醒.MouseBack = null;
            this.提醒设置_cb_右下角浮动提醒.Name = "提醒设置_cb_右下角浮动提醒";
            this.提醒设置_cb_右下角浮动提醒.NormlBack = null;
            this.提醒设置_cb_右下角浮动提醒.SelectedDownBack = null;
            this.提醒设置_cb_右下角浮动提醒.SelectedMouseBack = null;
            this.提醒设置_cb_右下角浮动提醒.SelectedNormlBack = null;
            this.提醒设置_cb_右下角浮动提醒.Size = new System.Drawing.Size(136, 24);
            this.提醒设置_cb_右下角浮动提醒.TabIndex = 22;
            this.提醒设置_cb_右下角浮动提醒.Text = "右下角浮动提醒";
            this.提醒设置_cb_右下角浮动提醒.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_置顶者强提醒
            // 
            this.提醒设置_cb_置顶者强提醒.AutoSize = true;
            this.提醒设置_cb_置顶者强提醒.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_置顶者强提醒.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_置顶者强提醒.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_置顶者强提醒.DownBack = null;
            this.提醒设置_cb_置顶者强提醒.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_置顶者强提醒.LightEffect = false;
            this.提醒设置_cb_置顶者强提醒.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_置顶者强提醒.Location = new System.Drawing.Point(321, 4);
            this.提醒设置_cb_置顶者强提醒.MouseBack = null;
            this.提醒设置_cb_置顶者强提醒.Name = "提醒设置_cb_置顶者强提醒";
            this.提醒设置_cb_置顶者强提醒.NormlBack = null;
            this.提醒设置_cb_置顶者强提醒.SelectedDownBack = null;
            this.提醒设置_cb_置顶者强提醒.SelectedMouseBack = null;
            this.提醒设置_cb_置顶者强提醒.SelectedNormlBack = null;
            this.提醒设置_cb_置顶者强提醒.Size = new System.Drawing.Size(121, 24);
            this.提醒设置_cb_置顶者强提醒.TabIndex = 22;
            this.提醒设置_cb_置顶者强提醒.Text = "置顶者强提醒";
            this.提醒设置_cb_置顶者强提醒.UseVisualStyleBackColor = false;
            // 
            // skinGroupBox3
            // 
            this.skinGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.skinGroupBox3.Controls.Add(this.提醒设置_cb_公共会话悬浮提醒);
            this.skinGroupBox3.Controls.Add(this.提醒设置_cb_用户消息悬浮提醒);
            this.skinGroupBox3.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox3.Location = new System.Drawing.Point(33, 276);
            this.skinGroupBox3.Name = "skinGroupBox3";
            this.skinGroupBox3.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox3.Size = new System.Drawing.Size(346, 76);
            this.skinGroupBox3.TabIndex = 23;
            this.skinGroupBox3.TabStop = false;
            this.skinGroupBox3.Text = "悬浮提醒设置";
            this.skinGroupBox3.TitleBorderColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox3.TitleRectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.skinGroupBox3.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 提醒设置_cb_公共会话悬浮提醒
            // 
            this.提醒设置_cb_公共会话悬浮提醒.AutoSize = true;
            this.提醒设置_cb_公共会话悬浮提醒.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_公共会话悬浮提醒.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_公共会话悬浮提醒.Checked = true;
            this.提醒设置_cb_公共会话悬浮提醒.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_公共会话悬浮提醒.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_公共会话悬浮提醒.DownBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_公共会话悬浮提醒.LightEffect = false;
            this.提醒设置_cb_公共会话悬浮提醒.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_公共会话悬浮提醒.Location = new System.Drawing.Point(18, 39);
            this.提醒设置_cb_公共会话悬浮提醒.MouseBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.Name = "提醒设置_cb_公共会话悬浮提醒";
            this.提醒设置_cb_公共会话悬浮提醒.NormlBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.SelectedDownBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.SelectedMouseBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.SelectedNormlBack = null;
            this.提醒设置_cb_公共会话悬浮提醒.Size = new System.Drawing.Size(151, 24);
            this.提醒设置_cb_公共会话悬浮提醒.TabIndex = 22;
            this.提醒设置_cb_公共会话悬浮提醒.Text = "公共会话悬浮提醒";
            this.提醒设置_cb_公共会话悬浮提醒.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_用户消息悬浮提醒
            // 
            this.提醒设置_cb_用户消息悬浮提醒.AutoSize = true;
            this.提醒设置_cb_用户消息悬浮提醒.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_用户消息悬浮提醒.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_用户消息悬浮提醒.Checked = true;
            this.提醒设置_cb_用户消息悬浮提醒.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_用户消息悬浮提醒.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_用户消息悬浮提醒.DownBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_用户消息悬浮提醒.LightEffect = false;
            this.提醒设置_cb_用户消息悬浮提醒.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_用户消息悬浮提醒.Location = new System.Drawing.Point(193, 39);
            this.提醒设置_cb_用户消息悬浮提醒.MouseBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.Name = "提醒设置_cb_用户消息悬浮提醒";
            this.提醒设置_cb_用户消息悬浮提醒.NormlBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.SelectedDownBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.SelectedMouseBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.SelectedNormlBack = null;
            this.提醒设置_cb_用户消息悬浮提醒.Size = new System.Drawing.Size(151, 24);
            this.提醒设置_cb_用户消息悬浮提醒.TabIndex = 22;
            this.提醒设置_cb_用户消息悬浮提醒.Text = "用户消息悬浮提醒";
            this.提醒设置_cb_用户消息悬浮提醒.UseVisualStyleBackColor = false;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.skinGroupBox2.Controls.Add(this.提醒设置_cb_强提醒模式_对话框);
            this.skinGroupBox2.Controls.Add(this.提醒设置_cb_强提醒模式_托盘消息);
            this.skinGroupBox2.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox2.Location = new System.Drawing.Point(33, 178);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(306, 79);
            this.skinGroupBox2.TabIndex = 23;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "强提醒模式";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 提醒设置_cb_强提醒模式_对话框
            // 
            this.提醒设置_cb_强提醒模式_对话框.AutoSize = true;
            this.提醒设置_cb_强提醒模式_对话框.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_强提醒模式_对话框.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_强提醒模式_对话框.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_强提醒模式_对话框.DownBack = null;
            this.提醒设置_cb_强提醒模式_对话框.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_强提醒模式_对话框.LightEffect = false;
            this.提醒设置_cb_强提醒模式_对话框.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_强提醒模式_对话框.Location = new System.Drawing.Point(18, 39);
            this.提醒设置_cb_强提醒模式_对话框.MouseBack = null;
            this.提醒设置_cb_强提醒模式_对话框.Name = "提醒设置_cb_强提醒模式_对话框";
            this.提醒设置_cb_强提醒模式_对话框.NormlBack = null;
            this.提醒设置_cb_强提醒模式_对话框.SelectedDownBack = null;
            this.提醒设置_cb_强提醒模式_对话框.SelectedMouseBack = null;
            this.提醒设置_cb_强提醒模式_对话框.SelectedNormlBack = null;
            this.提醒设置_cb_强提醒模式_对话框.Size = new System.Drawing.Size(76, 24);
            this.提醒设置_cb_强提醒模式_对话框.TabIndex = 22;
            this.提醒设置_cb_强提醒模式_对话框.Text = "对话框";
            this.提醒设置_cb_强提醒模式_对话框.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_强提醒模式_托盘消息
            // 
            this.提醒设置_cb_强提醒模式_托盘消息.AutoSize = true;
            this.提醒设置_cb_强提醒模式_托盘消息.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_强提醒模式_托盘消息.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_强提醒模式_托盘消息.Checked = true;
            this.提醒设置_cb_强提醒模式_托盘消息.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_强提醒模式_托盘消息.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_强提醒模式_托盘消息.DownBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_强提醒模式_托盘消息.LightEffect = false;
            this.提醒设置_cb_强提醒模式_托盘消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_强提醒模式_托盘消息.Location = new System.Drawing.Point(175, 39);
            this.提醒设置_cb_强提醒模式_托盘消息.MouseBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.Name = "提醒设置_cb_强提醒模式_托盘消息";
            this.提醒设置_cb_强提醒模式_托盘消息.NormlBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.SelectedDownBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.SelectedMouseBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.SelectedNormlBack = null;
            this.提醒设置_cb_强提醒模式_托盘消息.Size = new System.Drawing.Size(91, 24);
            this.提醒设置_cb_强提醒模式_托盘消息.TabIndex = 22;
            this.提醒设置_cb_强提醒模式_托盘消息.Text = "托盘消息";
            this.提醒设置_cb_强提醒模式_托盘消息.UseVisualStyleBackColor = false;
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.skinGroupBox1.Controls.Add(this.提醒设置_cb_事件消息);
            this.skinGroupBox1.Controls.Add(this.提醒设置_cb_图片消息);
            this.skinGroupBox1.Controls.Add(this.提醒设置_cb_文件消息);
            this.skinGroupBox1.Controls.Add(this.提醒设置_cb_文本消息);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox1.Location = new System.Drawing.Point(33, 16);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(306, 109);
            this.skinGroupBox1.TabIndex = 23;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "消息提醒类别";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.DarkTurquoise;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // 提醒设置_cb_事件消息
            // 
            this.提醒设置_cb_事件消息.AutoSize = true;
            this.提醒设置_cb_事件消息.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_事件消息.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_事件消息.Checked = true;
            this.提醒设置_cb_事件消息.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_事件消息.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_事件消息.DownBack = null;
            this.提醒设置_cb_事件消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_事件消息.LightEffect = false;
            this.提醒设置_cb_事件消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_事件消息.Location = new System.Drawing.Point(175, 69);
            this.提醒设置_cb_事件消息.MouseBack = null;
            this.提醒设置_cb_事件消息.Name = "提醒设置_cb_事件消息";
            this.提醒设置_cb_事件消息.NormlBack = null;
            this.提醒设置_cb_事件消息.SelectedDownBack = null;
            this.提醒设置_cb_事件消息.SelectedMouseBack = null;
            this.提醒设置_cb_事件消息.SelectedNormlBack = null;
            this.提醒设置_cb_事件消息.Size = new System.Drawing.Size(91, 24);
            this.提醒设置_cb_事件消息.TabIndex = 22;
            this.提醒设置_cb_事件消息.Text = "事件消息";
            this.提醒设置_cb_事件消息.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_图片消息
            // 
            this.提醒设置_cb_图片消息.AutoSize = true;
            this.提醒设置_cb_图片消息.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_图片消息.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_图片消息.Checked = true;
            this.提醒设置_cb_图片消息.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_图片消息.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_图片消息.DownBack = null;
            this.提醒设置_cb_图片消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_图片消息.LightEffect = false;
            this.提醒设置_cb_图片消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_图片消息.Location = new System.Drawing.Point(18, 69);
            this.提醒设置_cb_图片消息.MouseBack = null;
            this.提醒设置_cb_图片消息.Name = "提醒设置_cb_图片消息";
            this.提醒设置_cb_图片消息.NormlBack = null;
            this.提醒设置_cb_图片消息.SelectedDownBack = null;
            this.提醒设置_cb_图片消息.SelectedMouseBack = null;
            this.提醒设置_cb_图片消息.SelectedNormlBack = null;
            this.提醒设置_cb_图片消息.Size = new System.Drawing.Size(91, 24);
            this.提醒设置_cb_图片消息.TabIndex = 22;
            this.提醒设置_cb_图片消息.Text = "图片消息";
            this.提醒设置_cb_图片消息.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_文件消息
            // 
            this.提醒设置_cb_文件消息.AutoSize = true;
            this.提醒设置_cb_文件消息.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_文件消息.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_文件消息.Checked = true;
            this.提醒设置_cb_文件消息.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_文件消息.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_文件消息.DownBack = null;
            this.提醒设置_cb_文件消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_文件消息.LightEffect = false;
            this.提醒设置_cb_文件消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_文件消息.Location = new System.Drawing.Point(175, 28);
            this.提醒设置_cb_文件消息.MouseBack = null;
            this.提醒设置_cb_文件消息.Name = "提醒设置_cb_文件消息";
            this.提醒设置_cb_文件消息.NormlBack = null;
            this.提醒设置_cb_文件消息.SelectedDownBack = null;
            this.提醒设置_cb_文件消息.SelectedMouseBack = null;
            this.提醒设置_cb_文件消息.SelectedNormlBack = null;
            this.提醒设置_cb_文件消息.Size = new System.Drawing.Size(91, 24);
            this.提醒设置_cb_文件消息.TabIndex = 22;
            this.提醒设置_cb_文件消息.Text = "文件消息";
            this.提醒设置_cb_文件消息.UseVisualStyleBackColor = false;
            // 
            // 提醒设置_cb_文本消息
            // 
            this.提醒设置_cb_文本消息.AutoSize = true;
            this.提醒设置_cb_文本消息.BackColor = System.Drawing.Color.Transparent;
            this.提醒设置_cb_文本消息.BaseColor = System.Drawing.Color.MediumAquamarine;
            this.提醒设置_cb_文本消息.Checked = true;
            this.提醒设置_cb_文本消息.CheckState = System.Windows.Forms.CheckState.Checked;
            this.提醒设置_cb_文本消息.ControlState = CCWin.SkinClass.ControlState.Focused;
            this.提醒设置_cb_文本消息.DownBack = null;
            this.提醒设置_cb_文本消息.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提醒设置_cb_文本消息.LightEffect = false;
            this.提醒设置_cb_文本消息.LightEffectBack = System.Drawing.Color.Transparent;
            this.提醒设置_cb_文本消息.Location = new System.Drawing.Point(18, 28);
            this.提醒设置_cb_文本消息.MouseBack = null;
            this.提醒设置_cb_文本消息.Name = "提醒设置_cb_文本消息";
            this.提醒设置_cb_文本消息.NormlBack = null;
            this.提醒设置_cb_文本消息.SelectedDownBack = null;
            this.提醒设置_cb_文本消息.SelectedMouseBack = null;
            this.提醒设置_cb_文本消息.SelectedNormlBack = null;
            this.提醒设置_cb_文本消息.Size = new System.Drawing.Size(91, 24);
            this.提醒设置_cb_文本消息.TabIndex = 22;
            this.提醒设置_cb_文本消息.Text = "文本消息";
            this.提醒设置_cb_文本消息.UseVisualStyleBackColor = false;
            // 
            // tp_用户管理
            // 
            this.tp_用户管理.BackColor = System.Drawing.Color.Transparent;
            this.tp_用户管理.Controls.Add(this.用户管理_bt_备注修改);
            this.tp_用户管理.Controls.Add(this.用户管理_tb_备注名);
            this.tp_用户管理.Controls.Add(this.label7);
            this.tp_用户管理.Controls.Add(this.label6);
            this.tp_用户管理.Controls.Add(this.用户管理_lb_黑名单);
            this.tp_用户管理.Controls.Add(this.用户管理_lb_备注列表);
            this.tp_用户管理.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tp_用户管理.Location = new System.Drawing.Point(130, 0);
            this.tp_用户管理.Name = "tp_用户管理";
            this.tp_用户管理.Size = new System.Drawing.Size(723, 500);
            this.tp_用户管理.TabIndex = 3;
            this.tp_用户管理.TabItemImage = null;
            this.tp_用户管理.Text = "用户管理";
            this.tp_用户管理.Paint += new System.Windows.Forms.PaintEventHandler(this.tp_Paint);
            // 
            // 用户管理_bt_备注修改
            // 
            this.用户管理_bt_备注修改.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.用户管理_bt_备注修改.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.用户管理_bt_备注修改.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.用户管理_bt_备注修改.Location = new System.Drawing.Point(225, 360);
            this.用户管理_bt_备注修改.Name = "用户管理_bt_备注修改";
            this.用户管理_bt_备注修改.Size = new System.Drawing.Size(66, 30);
            this.用户管理_bt_备注修改.TabIndex = 27;
            this.用户管理_bt_备注修改.Text = "修改";
            this.用户管理_bt_备注修改.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.用户管理_bt_备注修改.UseVisualStyleBackColor = true;
            this.用户管理_bt_备注修改.Click += new System.EventHandler(this.用户管理_bt_备注修改_Click);
            // 
            // 用户管理_tb_备注名
            // 
            this.用户管理_tb_备注名.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.用户管理_tb_备注名.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.用户管理_tb_备注名.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.用户管理_tb_备注名.Location = new System.Drawing.Point(33, 360);
            this.用户管理_tb_备注名.MaxLength = 5;
            this.用户管理_tb_备注名.Name = "用户管理_tb_备注名";
            this.用户管理_tb_备注名.Size = new System.Drawing.Size(186, 30);
            this.用户管理_tb_备注名.TabIndex = 26;
            this.用户管理_tb_备注名.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.用户管理_tb_备注名.边框色 = System.Drawing.Color.DarkTurquoise;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(351, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "黑名单用户:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.Gray;
            this.label6.Location = new System.Drawing.Point(33, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "已备注用户:";
            // 
            // 用户管理_lb_黑名单
            // 
            this.用户管理_lb_黑名单.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.用户管理_lb_黑名单.Back = null;
            this.用户管理_lb_黑名单.BackColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_黑名单.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 20);
            this.用户管理_lb_黑名单.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.用户管理_lb_黑名单.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.用户管理_lb_黑名单.ContextMenuStrip = this.Rbtn_Listbox;
            this.用户管理_lb_黑名单.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.用户管理_lb_黑名单.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.用户管理_lb_黑名单.ForeColor = System.Drawing.Color.White;
            this.用户管理_lb_黑名单.FormattingEnabled = true;
            this.用户管理_lb_黑名单.ItemGlassVisble = false;
            this.用户管理_lb_黑名单.ItemHeight = 30;
            this.用户管理_lb_黑名单.ItemRadius = 4;
            this.用户管理_lb_黑名单.Location = new System.Drawing.Point(354, 32);
            this.用户管理_lb_黑名单.MouseColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_黑名单.Name = "用户管理_lb_黑名单";
            this.用户管理_lb_黑名单.RowBackColor1 = System.Drawing.Color.Transparent;
            this.用户管理_lb_黑名单.RowBackColor2 = System.Drawing.Color.Transparent;
            this.用户管理_lb_黑名单.SelectedColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_黑名单.Size = new System.Drawing.Size(258, 322);
            this.用户管理_lb_黑名单.TabIndex = 24;
            this.用户管理_lb_黑名单.MouseEnter += new System.EventHandler(this.ListBox_MouseEnter);
            // 
            // 用户管理_lb_备注列表
            // 
            this.用户管理_lb_备注列表.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.用户管理_lb_备注列表.Back = null;
            this.用户管理_lb_备注列表.BackColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_备注列表.BackRectangle = new System.Drawing.Rectangle(10, 10, 10, 20);
            this.用户管理_lb_备注列表.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.用户管理_lb_备注列表.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.用户管理_lb_备注列表.ContextMenuStrip = this.Rbtn_Listbox;
            this.用户管理_lb_备注列表.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.用户管理_lb_备注列表.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.用户管理_lb_备注列表.ForeColor = System.Drawing.Color.White;
            this.用户管理_lb_备注列表.FormattingEnabled = true;
            this.用户管理_lb_备注列表.ItemGlassVisble = false;
            this.用户管理_lb_备注列表.ItemHeight = 30;
            this.用户管理_lb_备注列表.ItemRadius = 4;
            this.用户管理_lb_备注列表.Location = new System.Drawing.Point(33, 32);
            this.用户管理_lb_备注列表.MouseColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_备注列表.Name = "用户管理_lb_备注列表";
            this.用户管理_lb_备注列表.RowBackColor1 = System.Drawing.Color.Transparent;
            this.用户管理_lb_备注列表.RowBackColor2 = System.Drawing.Color.Transparent;
            this.用户管理_lb_备注列表.SelectedColor = System.Drawing.Color.Transparent;
            this.用户管理_lb_备注列表.Size = new System.Drawing.Size(258, 322);
            this.用户管理_lb_备注列表.TabIndex = 24;
            this.用户管理_lb_备注列表.SelectedIndexChanged += new System.EventHandler(this.用户管理_lb_备注列表_SelectedIndexChanged);
            this.用户管理_lb_备注列表.MouseEnter += new System.EventHandler(this.ListBox_MouseEnter);
            // 
            // pic_Logo
            // 
            this.pic_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pic_Logo.Image")));
            this.pic_Logo.Location = new System.Drawing.Point(3, 0);
            this.pic_Logo.Name = "pic_Logo";
            this.pic_Logo.Size = new System.Drawing.Size(67, 53);
            this.pic_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Logo.TabIndex = 2;
            this.pic_Logo.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.bt_Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 576);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 58);
            this.panel1.TabIndex = 25;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // bt_Save
            // 
            this.bt_Save.BackColor = System.Drawing.Color.Transparent;
            this.bt_Save.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Save.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.bt_Save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Save.DownBack = null;
            this.bt_Save.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Save.ForeColor = System.Drawing.Color.Aqua;
            this.bt_Save.GlowColor = System.Drawing.Color.MediumSeaGreen;
            this.bt_Save.InnerBorderColor = System.Drawing.Color.Transparent;
            this.bt_Save.IsDrawGlass = false;
            this.bt_Save.Location = new System.Drawing.Point(379, 8);
            this.bt_Save.MouseBack = null;
            this.bt_Save.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.NormlBack = null;
            this.bt_Save.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Save.Size = new System.Drawing.Size(97, 41);
            this.bt_Save.TabIndex = 0;
            this.bt_Save.Text = "保存设置";
            this.bt_Save.UseVisualStyleBackColor = true;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // lb_title
            // 
            this.lb_title.AutoSize = true;
            this.lb_title.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_title.ForeColor = System.Drawing.Color.Gray;
            this.lb_title.Location = new System.Drawing.Point(76, 19);
            this.lb_title.Name = "lb_title";
            this.lb_title.Size = new System.Drawing.Size(149, 20);
            this.lb_title.TabIndex = 1;
            this.lb_title.Text = "设置->常规设置";
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
            this.bt_CloseForm.Location = new System.Drawing.Point(833, 12);
            this.bt_CloseForm.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.MouseBack")));
            this.bt_CloseForm.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.Name = "bt_CloseForm";
            this.bt_CloseForm.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.NormlBack")));
            this.bt_CloseForm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_CloseForm.Size = new System.Drawing.Size(26, 22);
            this.bt_CloseForm.TabIndex = 30;
            this.bt_CloseForm.UseVisualStyleBackColor = true;
            this.bt_CloseForm.Click += new System.EventHandler(this.bt_CloseForm_Click);
            // 
            // Form_Install
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(859, 634);
            this.Controls.Add(this.bt_CloseForm);
            this.Controls.Add(this.lb_title);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pic_Logo);
            this.Controls.Add(this.tb_Main);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Install";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MiniTalk-设置";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Install_Paint);
            this.tb_Main.ResumeLayout(false);
            this.tp_常规设置.ResumeLayout(false);
            this.tp_常规设置.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.常规设置_nup_消息时间提醒间隔)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.常规设置_nup_历史消息保留数)).EndInit();
            this.tp_传输设置.ResumeLayout(false);
            this.tp_传输设置.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.传输设置_nup_大于numMB则屏)).EndInit();
            this.Rbtn_Listbox.ResumeLayout(false);
            this.tp_提醒设置.ResumeLayout(false);
            this.提醒设置_panel2.ResumeLayout(false);
            this.提醒设置_panel2.PerformLayout();
            this.skinGroupBox3.ResumeLayout(false);
            this.skinGroupBox3.PerformLayout();
            this.skinGroupBox2.ResumeLayout(false);
            this.skinGroupBox2.PerformLayout();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.tp_用户管理.ResumeLayout(false);
            this.tp_用户管理.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Logo)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTabControl tb_Main;
        private CCWin.SkinControl.SkinTabPage tp_常规设置;
        private CCWin.SkinControl.SkinTabPage tp_传输设置;
        private CCWin.SkinControl.SkinTabPage tp_提醒设置;
        private System.Windows.Forms.Button 传输设置_bt_更改保存路径;
        private System.Windows.Forms.Label 传输设置_lb_SavePath;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinCheckBox 传输设置_cb_下载完毕后自动打开文件;
        private CCWin.SkinControl.SkinCheckBox 传输设置_cb_屏蔽所有文件消息;
        private System.Windows.Forms.Label label3;
        private CCWin.SkinControl.SkinNumericUpDown 传输设置_nup_大于numMB则屏;
        private CCWin.SkinControl.SkinListBox 传输设置_ExtListBox;
        private DSControls.DS文本框 传输设置_ExtTxb;
        private System.Windows.Forms.Button 传输设置_BtAdd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip Rbtn_Listbox;
        private System.Windows.Forms.ToolStripMenuItem Rbtn_移除;
        private System.Windows.Forms.ToolStripMenuItem Rbtn_移除所有;
        private System.Windows.Forms.PictureBox pic_Logo;
        private System.Windows.Forms.Panel panel1;
        private CCWin.SkinControl.SkinButton bt_Save;
        private System.Windows.Forms.Label lb_title;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinNumericUpDown 常规设置_nup_历史消息保留数;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private CCWin.SkinControl.SkinNumericUpDown 常规设置_nup_消息时间提醒间隔;
        public CCWin.SkinControl.SkinButton bt_CloseForm;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_文本消息;
        private CCWin.SkinControl.SkinTabPage tp_用户管理;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_强提醒模式_对话框;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_强提醒模式_托盘消息;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_事件消息;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_图片消息;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_文件消息;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_置顶者强提醒;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_群消息红点标注;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_群消息提醒;
        private System.Windows.Forms.Button 用户管理_bt_备注修改;
        private DSControls.DS文本框 用户管理_tb_备注名;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinListBox 用户管理_lb_黑名单;
        private CCWin.SkinControl.SkinListBox 用户管理_lb_备注列表;
        private System.Windows.Forms.Panel 提醒设置_panel2;
        private CCWin.SkinControl.SkinCheckBox 常规设置_cb_后台截图;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_右下角浮动提醒;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox3;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_公共会话悬浮提醒;
        private CCWin.SkinControl.SkinCheckBox 提醒设置_cb_用户消息悬浮提醒;
    }
}