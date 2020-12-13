namespace MiniTalk.RemoteControl.SharingEnd
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bt_Close = new CCWin.SkinControl.SkinButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lb_Time = new System.Windows.Forms.Label();
            this.lb_State = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.HideToNotfyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.启用演示模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "正在进行屏幕共享";
            this.notifyIcon1.BalloonTipTitle = "MiniTalk-远程协助";
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "正在进行屏幕共享";
            this.notifyIcon1.Visible = true;
            // 
            // notifyMenu
            // 
            this.notifyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem,
            this.showToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(109, 52);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(108, 24);
            this.exitMenuItem.Text = "退出";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.showToolStripMenuItem.Text = "显示";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // bt_Close
            // 
            this.bt_Close.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Close.BackColor = System.Drawing.Color.Transparent;
            this.bt_Close.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Close.DownBack = null;
            this.bt_Close.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.bt_Close.Image = ((System.Drawing.Image)(resources.GetObject("bt_Close.Image")));
            this.bt_Close.ImageSize = new System.Drawing.Size(40, 40);
            this.bt_Close.Location = new System.Drawing.Point(298, 3);
            this.bt_Close.MouseBack = null;
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.NormlBack = null;
            this.bt_Close.Size = new System.Drawing.Size(70, 59);
            this.bt_Close.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bt_Close, "关闭连接");
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            this.bt_Close.MouseEnter += new System.EventHandler(this.bt_Close_MouseEnter);
            this.bt_Close.MouseLeave += new System.EventHandler(this.bt_Close_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 62);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Time_MouseDown);
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.Font = new System.Drawing.Font("华文琥珀", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Time.ForeColor = System.Drawing.Color.White;
            this.lb_Time.Location = new System.Drawing.Point(122, 9);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(114, 26);
            this.lb_Time.TabIndex = 3;
            this.lb_Time.Text = "00:00:00";
            this.lb_Time.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Time_MouseDown);
            // 
            // lb_State
            // 
            this.lb_State.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_State.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_State.ForeColor = System.Drawing.Color.Silver;
            this.lb_State.Location = new System.Drawing.Point(72, 35);
            this.lb_State.Name = "lb_State";
            this.lb_State.Size = new System.Drawing.Size(236, 22);
            this.lb_State.TabIndex = 4;
            this.lb_State.Text = "一无所知 正在控制你的电脑";
            this.lb_State.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lb_Time_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HideToNotfyToolStripMenuItem,
            this.启用演示模式ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(169, 52);
            // 
            // HideToNotfyToolStripMenuItem
            // 
            this.HideToNotfyToolStripMenuItem.Name = "HideToNotfyToolStripMenuItem";
            this.HideToNotfyToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.HideToNotfyToolStripMenuItem.Text = "最小化到托盘";
            this.HideToNotfyToolStripMenuItem.Click += new System.EventHandler(this.HideToNotfyToolStripMenuItem_Click);
            // 
            // 启用演示模式ToolStripMenuItem
            // 
            this.启用演示模式ToolStripMenuItem.Name = "启用演示模式ToolStripMenuItem";
            this.启用演示模式ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.启用演示模式ToolStripMenuItem.Text = "启用演示模式";
            this.启用演示模式ToolStripMenuItem.Click += new System.EventHandler(this.启用演示模式ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(371, 62);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.bt_Close);
            this.Controls.Add(this.lb_State);
            this.Controls.Add(this.lb_Time);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "远程协助共享端";
            this.TopMost = true;
            this.notifyMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private CCWin.SkinControl.SkinButton bt_Close;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lb_State;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem HideToNotfyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 启用演示模式ToolStripMenuItem;
    }
}

