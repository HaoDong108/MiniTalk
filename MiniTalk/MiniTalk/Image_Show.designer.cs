namespace MiniTalk
{
    partial class Image_Show
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Show));
            this.pic_Image = new System.Windows.Forms.PictureBox();
            this.bt_Rotate = new CCWin.SkinControl.SkinButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bt_Center = new CCWin.SkinControl.SkinButton();
            this.bt_Save = new CCWin.SkinControl.SkinButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.bt_Narrow = new CCWin.SkinControl.SkinButton();
            this.bt_BlowUp = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_Image
            // 
            this.pic_Image.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pic_Image.BackColor = System.Drawing.Color.Black;
            this.pic_Image.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pic_Image.Location = new System.Drawing.Point(-3, 22);
            this.pic_Image.MaximumSize = new System.Drawing.Size(5000, 4000);
            this.pic_Image.Name = "pic_Image";
            this.pic_Image.Size = new System.Drawing.Size(899, 647);
            this.pic_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_Image.TabIndex = 0;
            this.pic_Image.TabStop = false;
            this.pic_Image.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pic_Image_MouseDown);
            this.pic_Image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pic_Image_MouseMove);
            this.pic_Image.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pic_Image_MouseUp);
            // 
            // bt_Rotate
            // 
            this.bt_Rotate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Rotate.BackColor = System.Drawing.Color.Transparent;
            this.bt_Rotate.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Rotate.BorderColor = System.Drawing.Color.Silver;
            this.bt_Rotate.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Rotate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Rotate.DownBack = null;
            this.bt_Rotate.GlowColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_Rotate.Image = ((System.Drawing.Image)(resources.GetObject("bt_Rotate.Image")));
            this.bt_Rotate.ImageSize = new System.Drawing.Size(40, 40);
            this.bt_Rotate.Location = new System.Drawing.Point(817, 588);
            this.bt_Rotate.MouseBack = null;
            this.bt_Rotate.MouseBaseColor = System.Drawing.Color.LightSalmon;
            this.bt_Rotate.Name = "bt_Rotate";
            this.bt_Rotate.NormlBack = null;
            this.bt_Rotate.Radius = 20;
            this.bt_Rotate.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Rotate.Size = new System.Drawing.Size(52, 54);
            this.bt_Rotate.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bt_Rotate, "向右旋转90度");
            this.bt_Rotate.UseVisualStyleBackColor = false;
            this.bt_Rotate.Click += new System.EventHandler(this.bt_Rotate_Click);
            // 
            // bt_Center
            // 
            this.bt_Center.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Center.BackColor = System.Drawing.Color.Transparent;
            this.bt_Center.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Center.BorderColor = System.Drawing.Color.Silver;
            this.bt_Center.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Center.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Center.DownBack = null;
            this.bt_Center.GlowColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_Center.Image = ((System.Drawing.Image)(resources.GetObject("bt_Center.Image")));
            this.bt_Center.ImageSize = new System.Drawing.Size(30, 30);
            this.bt_Center.Location = new System.Drawing.Point(759, 588);
            this.bt_Center.MouseBack = null;
            this.bt_Center.MouseBaseColor = System.Drawing.Color.LightSalmon;
            this.bt_Center.Name = "bt_Center";
            this.bt_Center.NormlBack = null;
            this.bt_Center.Radius = 20;
            this.bt_Center.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Center.Size = new System.Drawing.Size(52, 54);
            this.bt_Center.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bt_Center, "居中图像");
            this.bt_Center.UseVisualStyleBackColor = false;
            this.bt_Center.Click += new System.EventHandler(this.bt_Center_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Save.BackColor = System.Drawing.Color.Transparent;
            this.bt_Save.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Save.BorderColor = System.Drawing.Color.Silver;
            this.bt_Save.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Save.DownBack = null;
            this.bt_Save.GlowColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_Save.Image = ((System.Drawing.Image)(resources.GetObject("bt_Save.Image")));
            this.bt_Save.ImageSize = new System.Drawing.Size(35, 35);
            this.bt_Save.Location = new System.Drawing.Point(701, 588);
            this.bt_Save.MouseBack = null;
            this.bt_Save.MouseBaseColor = System.Drawing.Color.LightSalmon;
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.NormlBack = null;
            this.bt_Save.Radius = 20;
            this.bt_Save.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Save.Size = new System.Drawing.Size(52, 54);
            this.bt_Save.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bt_Save, "保存到本地");
            this.bt_Save.UseVisualStyleBackColor = false;
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Narrow
            // 
            this.bt_Narrow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_Narrow.BackColor = System.Drawing.Color.Transparent;
            this.bt_Narrow.BaseColor = System.Drawing.Color.Transparent;
            this.bt_Narrow.BorderColor = System.Drawing.Color.Silver;
            this.bt_Narrow.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Narrow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Narrow.DownBack = null;
            this.bt_Narrow.GlowColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_Narrow.Image = ((System.Drawing.Image)(resources.GetObject("bt_Narrow.Image")));
            this.bt_Narrow.ImageSize = new System.Drawing.Size(35, 35);
            this.bt_Narrow.Location = new System.Drawing.Point(643, 588);
            this.bt_Narrow.MouseBack = null;
            this.bt_Narrow.MouseBaseColor = System.Drawing.Color.LightSalmon;
            this.bt_Narrow.Name = "bt_Narrow";
            this.bt_Narrow.NormlBack = null;
            this.bt_Narrow.Radius = 20;
            this.bt_Narrow.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Narrow.Size = new System.Drawing.Size(52, 54);
            this.bt_Narrow.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bt_Narrow, "缩小");
            this.bt_Narrow.UseVisualStyleBackColor = false;
            this.bt_Narrow.Click += new System.EventHandler(this.bt_Narrow_Click);
            // 
            // bt_BlowUp
            // 
            this.bt_BlowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_BlowUp.BackColor = System.Drawing.Color.Transparent;
            this.bt_BlowUp.BaseColor = System.Drawing.Color.Transparent;
            this.bt_BlowUp.BorderColor = System.Drawing.Color.Silver;
            this.bt_BlowUp.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_BlowUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_BlowUp.DownBack = null;
            this.bt_BlowUp.GlowColor = System.Drawing.Color.DeepSkyBlue;
            this.bt_BlowUp.Image = ((System.Drawing.Image)(resources.GetObject("bt_BlowUp.Image")));
            this.bt_BlowUp.ImageSize = new System.Drawing.Size(35, 35);
            this.bt_BlowUp.Location = new System.Drawing.Point(585, 588);
            this.bt_BlowUp.MouseBack = null;
            this.bt_BlowUp.MouseBaseColor = System.Drawing.Color.LightSalmon;
            this.bt_BlowUp.Name = "bt_BlowUp";
            this.bt_BlowUp.NormlBack = null;
            this.bt_BlowUp.Radius = 20;
            this.bt_BlowUp.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_BlowUp.Size = new System.Drawing.Size(52, 54);
            this.bt_BlowUp.TabIndex = 1;
            this.toolTip1.SetToolTip(this.bt_BlowUp, "放大");
            this.bt_BlowUp.UseVisualStyleBackColor = false;
            this.bt_BlowUp.Click += new System.EventHandler(this.bt_BlowUp_Click);
            // 
            // Image_Show
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(908, 654);
            this.Controls.Add(this.bt_BlowUp);
            this.Controls.Add(this.bt_Narrow);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.bt_Center);
            this.Controls.Add(this.bt_Rotate);
            this.Controls.Add(this.pic_Image);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Image_Show";
            this.Text = "MiniTalk - 图片查看器";
            ((System.ComponentModel.ISupportInitialize)(this.pic_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_Image;
        private CCWin.SkinControl.SkinButton bt_Rotate;
        private System.Windows.Forms.ToolTip toolTip1;
        private CCWin.SkinControl.SkinButton bt_Center;
        private CCWin.SkinControl.SkinButton bt_Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private CCWin.SkinControl.SkinButton bt_Narrow;
        private CCWin.SkinControl.SkinButton bt_BlowUp;
    }
}