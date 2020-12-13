namespace MiniTalk
{
    partial class TalkPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TalkPanel));
            this.panel_sub = new System.Windows.Forms.Panel();
            this.bt_NewMs = new CCWin.SkinControl.SkinButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.scrollBar1 = new CCWin.SkinControl.SkinVScrollBar();
            this.panel_sub.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_sub
            // 
            this.panel_sub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_sub.BackColor = System.Drawing.Color.Black;
            this.panel_sub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel_sub.Controls.Add(this.bt_NewMs);
            this.panel_sub.Location = new System.Drawing.Point(0, 0);
            this.panel_sub.Margin = new System.Windows.Forms.Padding(0);
            this.panel_sub.Name = "panel_sub";
            this.panel_sub.Size = new System.Drawing.Size(651, 510);
            this.panel_sub.TabIndex = 3;
            this.panel_sub.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Panel1_ControlAdded);
            this.panel_sub.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.Panel1_ControlRemoved);
            // 
            // bt_NewMs
            // 
            this.bt_NewMs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bt_NewMs.BackColor = System.Drawing.Color.Transparent;
            this.bt_NewMs.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_NewMs.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_NewMs.DownBack = null;
            this.bt_NewMs.DrawType = CCWin.SkinControl.DrawStyle.Img;
            this.bt_NewMs.Font = new System.Drawing.Font("微软雅黑", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_NewMs.ForeColor = System.Drawing.Color.White;
            this.bt_NewMs.Image = ((System.Drawing.Image)(resources.GetObject("bt_NewMs.Image")));
            this.bt_NewMs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_NewMs.ImageSize = new System.Drawing.Size(20, 20);
            this.bt_NewMs.Location = new System.Drawing.Point(248, 478);
            this.bt_NewMs.MouseBack = null;
            this.bt_NewMs.Name = "bt_NewMs";
            this.bt_NewMs.NormlBack = null;
            this.bt_NewMs.Size = new System.Drawing.Size(177, 29);
            this.bt_NewMs.TabIndex = 1;
            this.bt_NewMs.Text = "有0条新消息";
            this.toolTip1.SetToolTip(this.bt_NewMs, "点击回到底部");
            this.bt_NewMs.UseVisualStyleBackColor = false;
            this.bt_NewMs.Visible = false;
            this.bt_NewMs.Click += new System.EventHandler(this.bt_NewMs_Click);
            this.bt_NewMs.MouseEnter += new System.EventHandler(this.bt_NewMs_MouseEnter);
            this.bt_NewMs.MouseLeave += new System.EventHandler(this.bt_NewMs_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // scrollBar1
            // 
            this.scrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollBar1.BorderColor = System.Drawing.Color.LightSalmon;
            this.scrollBar1.CausesValidation = false;
            this.scrollBar1.InnerPaddingWidth = 3;
            this.scrollBar1.Location = new System.Drawing.Point(651, -2);
            this.scrollBar1.Margin = new System.Windows.Forms.Padding(0);
            this.scrollBar1.MdlButtonRoundedRadius = 10;
            this.scrollBar1.Name = "scrollBar1";
            this.scrollBar1.Padding = new System.Windows.Forms.Padding(5);
            this.scrollBar1.Size = new System.Drawing.Size(15, 512);
            this.scrollBar1.SkinBackColor = System.Drawing.Color.Transparent;
            this.scrollBar1.TabIndex = 23;
            this.scrollBar1.TabStop = false;
            this.scrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1_ValueChanged);
            // 
            // TalkPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.scrollBar1);
            this.Controls.Add(this.panel_sub);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TalkPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.Size = new System.Drawing.Size(666, 510);
            this.panel_sub.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_sub;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Timer timer1;
        private CCWin.SkinControl.SkinVScrollBar scrollBar1;
        private CCWin.SkinControl.SkinButton bt_NewMs;
    }
}
