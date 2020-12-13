namespace MiniTalk.Custom_Control
{
    partial class FileMes
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
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pic_FileImg = new System.Windows.Forms.PictureBox();
            this.lb_fileName = new System.Windows.Forms.Label();
            this.lb_fileSzie = new System.Windows.Forms.Label();
            this.lkb_Down = new System.Windows.Forms.LinkLabel();
            this.lkb_SaveAs = new System.Windows.Forms.LinkLabel();
            this.lb_speed = new System.Windows.Forms.Label();
            this.panel_NotDown = new CCWin.SkinControl.SkinPanel();
            this.lb_stae = new System.Windows.Forms.Label();
            this.panel_OverDown = new CCWin.SkinControl.SkinPanel();
            this.lkb_OpenFile = new System.Windows.Forms.LinkLabel();
            this.lkb_OpenFolder = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pro_Down = new DSControls.DS进度条();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pic_FileImg)).BeginInit();
            this.panel_NotDown.SuspendLayout();
            this.panel_OverDown.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_FileImg
            // 
            this.pic_FileImg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pic_FileImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_FileImg.Location = new System.Drawing.Point(8, 12);
            this.pic_FileImg.Name = "pic_FileImg";
            this.pic_FileImg.Size = new System.Drawing.Size(60, 60);
            this.pic_FileImg.TabIndex = 0;
            this.pic_FileImg.TabStop = false;
            // 
            // lb_fileName
            // 
            this.lb_fileName.AutoEllipsis = true;
            this.lb_fileName.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_fileName.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_fileName.Location = new System.Drawing.Point(77, 11);
            this.lb_fileName.Name = "lb_fileName";
            this.lb_fileName.Size = new System.Drawing.Size(263, 25);
            this.lb_fileName.TabIndex = 1;
            this.lb_fileName.Text = "MiniTalk.zip";
            this.lb_fileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_fileSzie
            // 
            this.lb_fileSzie.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_fileSzie.ForeColor = System.Drawing.Color.DarkGray;
            this.lb_fileSzie.Location = new System.Drawing.Point(76, 41);
            this.lb_fileSzie.Name = "lb_fileSzie";
            this.lb_fileSzie.Size = new System.Drawing.Size(95, 19);
            this.lb_fileSzie.TabIndex = 1;
            this.lb_fileSzie.Text = "(124.00MB)";
            this.lb_fileSzie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lkb_Down
            // 
            this.lkb_Down.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.lkb_Down.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkb_Down.AutoSize = true;
            this.lkb_Down.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lkb_Down.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkb_Down.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_Down.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_Down.Location = new System.Drawing.Point(215, 4);
            this.lkb_Down.Name = "lkb_Down";
            this.lkb_Down.Size = new System.Drawing.Size(47, 19);
            this.lkb_Down.TabIndex = 0;
            this.lkb_Down.TabStop = true;
            this.lkb_Down.Text = "下  载";
            this.lkb_Down.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_Down_LinkClicked);
            // 
            // lkb_SaveAs
            // 
            this.lkb_SaveAs.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.lkb_SaveAs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkb_SaveAs.AutoSize = true;
            this.lkb_SaveAs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lkb_SaveAs.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkb_SaveAs.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_SaveAs.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_SaveAs.Location = new System.Drawing.Point(275, 4);
            this.lkb_SaveAs.Name = "lkb_SaveAs";
            this.lkb_SaveAs.Size = new System.Drawing.Size(54, 19);
            this.lkb_SaveAs.TabIndex = 0;
            this.lkb_SaveAs.TabStop = true;
            this.lkb_SaveAs.Text = "另存为";
            this.lkb_SaveAs.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_SaveAs_LinkClicked);
            // 
            // lb_speed
            // 
            this.lb_speed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_speed.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_speed.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_speed.Location = new System.Drawing.Point(245, 36);
            this.lb_speed.Name = "lb_speed";
            this.lb_speed.Size = new System.Drawing.Size(84, 25);
            this.lb_speed.TabIndex = 4;
            this.lb_speed.Text = "(未下载)";
            this.lb_speed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel_NotDown
            // 
            this.panel_NotDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_NotDown.BackColor = System.Drawing.Color.Transparent;
            this.panel_NotDown.Controls.Add(this.lb_stae);
            this.panel_NotDown.Controls.Add(this.lkb_Down);
            this.panel_NotDown.Controls.Add(this.lkb_SaveAs);
            this.panel_NotDown.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_NotDown.DownBack = null;
            this.panel_NotDown.Location = new System.Drawing.Point(0, 77);
            this.panel_NotDown.MouseBack = null;
            this.panel_NotDown.Name = "panel_NotDown";
            this.panel_NotDown.NormlBack = null;
            this.panel_NotDown.Radius = 50;
            this.panel_NotDown.Size = new System.Drawing.Size(344, 28);
            this.panel_NotDown.TabIndex = 5;
            this.panel_NotDown.Paint += new System.Windows.Forms.PaintEventHandler(this.skinPanel1_Paint);
            // 
            // lb_stae
            // 
            this.lb_stae.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_stae.AutoSize = true;
            this.lb_stae.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_stae.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_stae.Location = new System.Drawing.Point(5, 5);
            this.lb_stae.Name = "lb_stae";
            this.lb_stae.Size = new System.Drawing.Size(72, 18);
            this.lb_stae.TabIndex = 4;
            this.lb_stae.Text = "等待下载";
            this.lb_stae.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_OverDown
            // 
            this.panel_OverDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_OverDown.BackColor = System.Drawing.Color.Transparent;
            this.panel_OverDown.Controls.Add(this.lkb_OpenFile);
            this.panel_OverDown.Controls.Add(this.lkb_OpenFolder);
            this.panel_OverDown.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.panel_OverDown.DownBack = null;
            this.panel_OverDown.Location = new System.Drawing.Point(0, 77);
            this.panel_OverDown.MouseBack = null;
            this.panel_OverDown.Name = "panel_OverDown";
            this.panel_OverDown.NormlBack = null;
            this.panel_OverDown.Radius = 50;
            this.panel_OverDown.Size = new System.Drawing.Size(344, 28);
            this.panel_OverDown.TabIndex = 6;
            this.panel_OverDown.Visible = false;
            this.panel_OverDown.Paint += new System.Windows.Forms.PaintEventHandler(this.skinPanel1_Paint);
            // 
            // lkb_OpenFile
            // 
            this.lkb_OpenFile.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.lkb_OpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkb_OpenFile.AutoSize = true;
            this.lkb_OpenFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lkb_OpenFile.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkb_OpenFile.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_OpenFile.Location = new System.Drawing.Point(183, 4);
            this.lkb_OpenFile.Name = "lkb_OpenFile";
            this.lkb_OpenFile.Size = new System.Drawing.Size(47, 19);
            this.lkb_OpenFile.TabIndex = 0;
            this.lkb_OpenFile.TabStop = true;
            this.lkb_OpenFile.Text = "打  开";
            this.lkb_OpenFile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_OpenFile_LinkClicked);
            // 
            // lkb_OpenFolder
            // 
            this.lkb_OpenFolder.ActiveLinkColor = System.Drawing.Color.Cyan;
            this.lkb_OpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lkb_OpenFolder.AutoSize = true;
            this.lkb_OpenFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lkb_OpenFolder.Font = new System.Drawing.Font("微软雅黑", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkb_OpenFolder.LinkColor = System.Drawing.Color.DarkTurquoise;
            this.lkb_OpenFolder.Location = new System.Drawing.Point(248, 4);
            this.lkb_OpenFolder.Name = "lkb_OpenFolder";
            this.lkb_OpenFolder.Size = new System.Drawing.Size(84, 19);
            this.lkb_OpenFolder.TabIndex = 0;
            this.lkb_OpenFolder.TabStop = true;
            this.lkb_OpenFolder.Text = "打开文件夹";
            this.lkb_OpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkb_OpenFolder_LinkClicked);
            // 
            // pro_Down
            // 
            this.pro_Down.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pro_Down.BackColor = System.Drawing.Color.Transparent;
            this.pro_Down.Location = new System.Drawing.Point(76, 64);
            this.pro_Down.Name = "pro_Down";
            this.pro_Down.Size = new System.Drawing.Size(258, 7);
            this.pro_Down.TabIndex = 7;
            this.pro_Down.光泽强度百分比 = 0F;
            this.pro_Down.前景颜色 = System.Drawing.Color.SpringGreen;
            this.pro_Down.底层颜色 = System.Drawing.Color.Transparent;
            this.pro_Down.当前值 = 100;
            this.pro_Down.渐进速度 = 2;
            this.pro_Down.边框色 = System.Drawing.Color.Transparent;
            // 
            // FileMes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.pro_Down);
            this.Controls.Add(this.lb_speed);
            this.Controls.Add(this.panel_NotDown);
            this.Controls.Add(this.lb_fileSzie);
            this.Controls.Add(this.lb_fileName);
            this.Controls.Add(this.pic_FileImg);
            this.Controls.Add(this.panel_OverDown);
            this.Name = "FileMes";
            this.Size = new System.Drawing.Size(343, 105);
            ((System.ComponentModel.ISupportInitialize)(this.pic_FileImg)).EndInit();
            this.panel_NotDown.ResumeLayout(false);
            this.panel_NotDown.PerformLayout();
            this.panel_OverDown.ResumeLayout(false);
            this.panel_OverDown.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_FileImg;
        private System.Windows.Forms.Label lb_fileName;
        private System.Windows.Forms.Label lb_fileSzie;
        private System.Windows.Forms.LinkLabel lkb_Down;
        private System.Windows.Forms.LinkLabel lkb_SaveAs;
        private System.Windows.Forms.Label lb_speed;
        private CCWin.SkinControl.SkinPanel panel_NotDown;
        private CCWin.SkinControl.SkinPanel panel_OverDown;
        private System.Windows.Forms.LinkLabel lkb_OpenFile;
        private System.Windows.Forms.LinkLabel lkb_OpenFolder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lb_stae;
        private DSControls.DS进度条 pro_Down;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
