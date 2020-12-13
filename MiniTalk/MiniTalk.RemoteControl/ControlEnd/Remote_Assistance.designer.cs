namespace MiniTalk.RemoteControl.ControlEnd
{
    partial class Remote_Assistance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Assistance));
            this.axRDPViewer1 = new AxRDPCOMAPILib.AxRDPViewer();
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最小化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.最大化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_Menu = new System.Windows.Forms.Panel();
            this.bt_Pull = new System.Windows.Forms.PictureBox();
            this.lb_UserName = new System.Windows.Forms.Label();
            this.bt_ShowBorder = new CCWin.SkinControl.SkinButton();
            this.bt_Close = new CCWin.SkinControl.SkinButton();
            this.lb_Wait = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer1)).BeginInit();
            this.notifyMenu.SuspendLayout();
            this.panel_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bt_Pull)).BeginInit();
            this.SuspendLayout();
            // 
            // axRDPViewer1
            // 
            this.axRDPViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axRDPViewer1.Enabled = true;
            this.axRDPViewer1.Location = new System.Drawing.Point(0, 0);
            this.axRDPViewer1.Name = "axRDPViewer1";
            this.axRDPViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axRDPViewer1.OcxState")));
            this.axRDPViewer1.Size = new System.Drawing.Size(1243, 675);
            this.axRDPViewer1.TabIndex = 1;
            // 
            // notifyMenu
            // 
            this.notifyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem,
            this.最小化ToolStripMenuItem,
            this.最大化ToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(139, 76);
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(138, 24);
            this.exitMenuItem.Text = "断开连接";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // 最小化ToolStripMenuItem
            // 
            this.最小化ToolStripMenuItem.Name = "最小化ToolStripMenuItem";
            this.最小化ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.最小化ToolStripMenuItem.Text = "最小化";
            this.最小化ToolStripMenuItem.Click += new System.EventHandler(this.最小化ToolStripMenuItem_Click);
            // 
            // 最大化ToolStripMenuItem
            // 
            this.最大化ToolStripMenuItem.Name = "最大化ToolStripMenuItem";
            this.最大化ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.最大化ToolStripMenuItem.Text = "最大化";
            this.最大化ToolStripMenuItem.Click += new System.EventHandler(this.最大化ToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "桌面广播客户端";
            this.notifyIcon1.Visible = true;
            // 
            // panel_Menu
            // 
            this.panel_Menu.Controls.Add(this.bt_Pull);
            this.panel_Menu.Controls.Add(this.lb_UserName);
            this.panel_Menu.Controls.Add(this.bt_ShowBorder);
            this.panel_Menu.Controls.Add(this.bt_Close);
            this.panel_Menu.Location = new System.Drawing.Point(835, -47);
            this.panel_Menu.Name = "panel_Menu";
            this.panel_Menu.Size = new System.Drawing.Size(315, 65);
            this.panel_Menu.TabIndex = 3;
            // 
            // bt_Pull
            // 
            this.bt_Pull.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Pull.Image = global::MiniTalk.RemoteControl.ControlEnd.Images.下拉;
            this.bt_Pull.Location = new System.Drawing.Point(0, 49);
            this.bt_Pull.Name = "bt_Pull";
            this.bt_Pull.Size = new System.Drawing.Size(315, 15);
            this.bt_Pull.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bt_Pull.TabIndex = 5;
            this.bt_Pull.TabStop = false;
            this.bt_Pull.Click += new System.EventHandler(this.bt_Pull_Click);
            // 
            // lb_UserName
            // 
            this.lb_UserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_UserName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_UserName.ForeColor = System.Drawing.Color.White;
            this.lb_UserName.Location = new System.Drawing.Point(3, 9);
            this.lb_UserName.Name = "lb_UserName";
            this.lb_UserName.Size = new System.Drawing.Size(183, 31);
            this.lb_UserName.TabIndex = 4;
            this.lb_UserName.Text = "无用户";
            this.lb_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_ShowBorder
            // 
            this.bt_ShowBorder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_ShowBorder.BackColor = System.Drawing.Color.Transparent;
            this.bt_ShowBorder.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_ShowBorder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_ShowBorder.DownBack = null;
            this.bt_ShowBorder.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.bt_ShowBorder.Image = ((System.Drawing.Image)(resources.GetObject("bt_ShowBorder.Image")));
            this.bt_ShowBorder.ImageSize = new System.Drawing.Size(40, 40);
            this.bt_ShowBorder.Location = new System.Drawing.Point(197, 3);
            this.bt_ShowBorder.MouseBack = null;
            this.bt_ShowBorder.Name = "bt_ShowBorder";
            this.bt_ShowBorder.NormlBack = null;
            this.bt_ShowBorder.Size = new System.Drawing.Size(51, 43);
            this.bt_ShowBorder.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bt_ShowBorder, "窗口模式");
            this.bt_ShowBorder.UseVisualStyleBackColor = false;
            this.bt_ShowBorder.Click += new System.EventHandler(this.bt_ShowBorder_Click);
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
            this.bt_Close.Location = new System.Drawing.Point(254, 3);
            this.bt_Close.MouseBack = null;
            this.bt_Close.Name = "bt_Close";
            this.bt_Close.NormlBack = null;
            this.bt_Close.Size = new System.Drawing.Size(51, 43);
            this.bt_Close.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bt_Close, "关闭连接");
            this.bt_Close.UseVisualStyleBackColor = false;
            this.bt_Close.Click += new System.EventHandler(this.bt_Close_Click);
            // 
            // lb_Wait
            // 
            this.lb_Wait.BackColor = System.Drawing.Color.White;
            this.lb_Wait.Font = new System.Drawing.Font("微软雅黑", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Wait.ForeColor = System.Drawing.Color.Gray;
            this.lb_Wait.Image = ((System.Drawing.Image)(resources.GetObject("lb_Wait.Image")));
            this.lb_Wait.Location = new System.Drawing.Point(461, 204);
            this.lb_Wait.Name = "lb_Wait";
            this.lb_Wait.Size = new System.Drawing.Size(626, 391);
            this.lb_Wait.TabIndex = 2;
            this.lb_Wait.Text = "正在连接到远程客户端,请稍后...";
            this.lb_Wait.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Remote_Assistance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1243, 675);
            this.ContextMenuStrip = this.notifyMenu;
            this.Controls.Add(this.panel_Menu);
            this.Controls.Add(this.lb_Wait);
            this.Controls.Add(this.axRDPViewer1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Remote_Assistance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程协助";
            ((System.ComponentModel.ISupportInitialize)(this.axRDPViewer1)).EndInit();
            this.notifyMenu.ResumeLayout(false);
            this.panel_Menu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bt_Pull)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private AxRDPCOMAPILib.AxRDPViewer axRDPViewer1;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ToolStripMenuItem 最小化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 最大化ToolStripMenuItem;
        private System.Windows.Forms.Label lb_Wait;
        private System.Windows.Forms.Panel panel_Menu;
        private System.Windows.Forms.Label lb_UserName;
        private CCWin.SkinControl.SkinButton bt_ShowBorder;
        private CCWin.SkinControl.SkinButton bt_Close;
        private System.Windows.Forms.PictureBox bt_Pull;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}