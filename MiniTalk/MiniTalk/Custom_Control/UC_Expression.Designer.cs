namespace MiniTalk.Custom_Control
{
    partial class UC_Expression
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Expression));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_Parent = new System.Windows.Forms.Panel();
            this.vScrollBar1 = new CCWin.SkinControl.SkinVScrollBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_CloseForm = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "插入表情";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MiniTalk.FixedImages.发送表情;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 29);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel_Parent
            // 
            this.panel_Parent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Parent.BackColor = System.Drawing.Color.White;
            this.panel_Parent.Location = new System.Drawing.Point(21, 36);
            this.panel_Parent.Name = "panel_Parent";
            this.panel_Parent.Size = new System.Drawing.Size(397, 285);
            this.panel_Parent.TabIndex = 38;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.BorderColor = System.Drawing.Color.LightSalmon;
            this.vScrollBar1.CausesValidation = false;
            this.vScrollBar1.InnerPaddingWidth = 3;
            this.vScrollBar1.Location = new System.Drawing.Point(418, 36);
            this.vScrollBar1.Margin = new System.Windows.Forms.Padding(0);
            this.vScrollBar1.MdlButtonRoundedRadius = 10;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Padding = new System.Windows.Forms.Padding(5);
            this.vScrollBar1.Size = new System.Drawing.Size(22, 285);
            this.vScrollBar1.SkinBackColor = System.Drawing.Color.Transparent;
            this.vScrollBar1.TabIndex = 37;
            this.vScrollBar1.TabStop = false;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.VScrollBar1_ValueChanged);
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
            this.bt_CloseForm.Location = new System.Drawing.Point(411, 6);
            this.bt_CloseForm.MouseBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.MouseBack")));
            this.bt_CloseForm.MouseBaseColor = System.Drawing.Color.Transparent;
            this.bt_CloseForm.Name = "bt_CloseForm";
            this.bt_CloseForm.NormlBack = ((System.Drawing.Image)(resources.GetObject("bt_CloseForm.NormlBack")));
            this.bt_CloseForm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_CloseForm.Size = new System.Drawing.Size(26, 22);
            this.bt_CloseForm.TabIndex = 39;
            this.bt_CloseForm.UseVisualStyleBackColor = true;
            this.bt_CloseForm.Click += new System.EventHandler(this.bt_CloseForm_Click);
            // 
            // UC_Expression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.bt_CloseForm);
            this.Controls.Add(this.panel_Parent);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UC_Expression";
            this.Size = new System.Drawing.Size(440, 337);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_Parent;
        private CCWin.SkinControl.SkinVScrollBar vScrollBar1;
        private System.Windows.Forms.ToolTip toolTip1;
        public CCWin.SkinControl.SkinButton bt_CloseForm;
    }
}
