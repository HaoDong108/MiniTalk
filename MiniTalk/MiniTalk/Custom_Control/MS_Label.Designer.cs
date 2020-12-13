namespace MiniTalk
{
    partial class MS_Label
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MS_Label));
            this.label1 = new System.Windows.Forms.Label();
            this.lb_Name = new System.Windows.Forms.Label();
            this.HeadImage = new System.Windows.Forms.PictureBox();
            this.cts_头像右击 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ts_Atbtn = new System.Windows.Forms.ToolStripMenuItem();
            this.lb_nowTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.HeadImage)).BeginInit();
            this.cts_头像右击.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 22);
            this.label1.TabIndex = 8;
            // 
            // lb_Name
            // 
            this.lb_Name.BackColor = System.Drawing.Color.Transparent;
            this.lb_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Name.ForeColor = System.Drawing.Color.Silver;
            this.lb_Name.Location = new System.Drawing.Point(374, 22);
            this.lb_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_Name.Name = "lb_Name";
            this.lb_Name.Size = new System.Drawing.Size(78, 20);
            this.lb_Name.TabIndex = 6;
            this.lb_Name.Text = "昵称";
            this.lb_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HeadImage
            // 
            this.HeadImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HeadImage.BackgroundImage")));
            this.HeadImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.HeadImage.ContextMenuStrip = this.cts_头像右击;
            this.HeadImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HeadImage.Location = new System.Drawing.Point(396, 44);
            this.HeadImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HeadImage.Name = "HeadImage";
            this.HeadImage.Size = new System.Drawing.Size(33, 42);
            this.HeadImage.TabIndex = 7;
            this.HeadImage.TabStop = false;
            this.HeadImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HeadImage_Click);
            // 
            // cts_头像右击
            // 
            this.cts_头像右击.BackColor = System.Drawing.Color.DarkSlateGray;
            this.cts_头像右击.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cts_头像右击.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_Atbtn});
            this.cts_头像右击.Name = "cts_头像右击";
            this.cts_头像右击.ShowImageMargin = false;
            this.cts_头像右击.Size = new System.Drawing.Size(128, 48);
            this.cts_头像右击.Opening += new System.ComponentModel.CancelEventHandler(this.cts_头像右击_Opening);
            // 
            // ts_Atbtn
            // 
            this.ts_Atbtn.ForeColor = System.Drawing.Color.Cyan;
            this.ts_Atbtn.Name = "ts_Atbtn";
            this.ts_Atbtn.Size = new System.Drawing.Size(127, 22);
            this.ts_Atbtn.Text = "@他";
            this.ts_Atbtn.Click += new System.EventHandler(this.ts_Atbtn_Click);
            // 
            // lb_nowTime
            // 
            this.lb_nowTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nowTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_nowTime.ForeColor = System.Drawing.Color.Aqua;
            this.lb_nowTime.Location = new System.Drawing.Point(-3, 22);
            this.lb_nowTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_nowTime.Name = "lb_nowTime";
            this.lb_nowTime.Size = new System.Drawing.Size(461, 22);
            this.lb_nowTime.TabIndex = 9;
            this.lb_nowTime.Text = "—（10:12）—";
            this.lb_nowTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MS_Label
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeadImage);
            this.Controls.Add(this.lb_Name);
            this.Controls.Add(this.lb_nowTime);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MS_Label";
            this.Size = new System.Drawing.Size(461, 235);
            this.SizeChanged += new System.EventHandler(this.MS_Label_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MS_Label_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.HeadImage)).EndInit();
            this.cts_头像右击.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox HeadImage;
        public System.Windows.Forms.Label lb_Name;
        private System.Windows.Forms.Label lb_nowTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip cts_头像右击;
        private System.Windows.Forms.ToolStripMenuItem ts_Atbtn;
    }
}
