namespace MiniTalk
{
    partial class MiniToast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiniToast));
            this.pic_ico = new System.Windows.Forms.PictureBox();
            this.lb_text = new System.Windows.Forms.Label();
            this.Layout_Panel = new System.Windows.Forms.TableLayoutPanel();
            this.lb_name = new System.Windows.Forms.Label();
            this.IcoList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pic_ico)).BeginInit();
            this.Layout_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pic_ico
            // 
            this.pic_ico.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic_ico.Image = ((System.Drawing.Image)(resources.GetObject("pic_ico.Image")));
            this.pic_ico.Location = new System.Drawing.Point(10, 10);
            this.pic_ico.Margin = new System.Windows.Forms.Padding(10);
            this.pic_ico.Name = "pic_ico";
            this.Layout_Panel.SetRowSpan(this.pic_ico, 2);
            this.pic_ico.Size = new System.Drawing.Size(60, 40);
            this.pic_ico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_ico.TabIndex = 0;
            this.pic_ico.TabStop = false;
            // 
            // lb_text
            // 
            this.lb_text.AutoEllipsis = true;
            this.lb_text.AutoSize = true;
            this.lb_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_text.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lb_text.Location = new System.Drawing.Point(83, 50);
            this.lb_text.Margin = new System.Windows.Forms.Padding(3, 0, 3, 10);
            this.lb_text.MaximumSize = new System.Drawing.Size(320, 60);
            this.lb_text.Name = "lb_text";
            this.lb_text.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lb_text.Size = new System.Drawing.Size(150, 1);
            this.lb_text.TabIndex = 1;
            this.lb_text.Text = "这里是消息简略文本";
            // 
            // Layout_Panel
            // 
            this.Layout_Panel.AutoSize = true;
            this.Layout_Panel.BackColor = System.Drawing.Color.Transparent;
            this.Layout_Panel.ColumnCount = 2;
            this.Layout_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Layout_Panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout_Panel.Controls.Add(this.pic_ico, 0, 0);
            this.Layout_Panel.Controls.Add(this.lb_name, 1, 0);
            this.Layout_Panel.Controls.Add(this.lb_text, 1, 1);
            this.Layout_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout_Panel.Location = new System.Drawing.Point(0, 0);
            this.Layout_Panel.Margin = new System.Windows.Forms.Padding(10);
            this.Layout_Panel.Name = "Layout_Panel";
            this.Layout_Panel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.Layout_Panel.RowCount = 2;
            this.Layout_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.Layout_Panel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Layout_Panel.Size = new System.Drawing.Size(246, 60);
            this.Layout_Panel.TabIndex = 2;
            this.Layout_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Layout_Panel_Paint);
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_name.Font = new System.Drawing.Font("微软雅黑", 10.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_name.ForeColor = System.Drawing.Color.Turquoise;
            this.lb_name.Location = new System.Drawing.Point(83, 0);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(150, 50);
            this.lb_name.TabIndex = 1;
            this.lb_name.Text = "发送者:";
            this.lb_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IcoList
            // 
            this.IcoList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IcoList.ImageStream")));
            this.IcoList.TransparentColor = System.Drawing.Color.Transparent;
            this.IcoList.Images.SetKeyName(0, "提示.png");
            // 
            // MiniToast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(246, 60);
            this.Controls.Add(this.Layout_Panel);
            this.ForeColor = System.Drawing.Color.Cyan;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(500, 800);
            this.Name = "MiniToast";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MiniToast";
            this.TopMost = true;
            this.TransparencyKey = this.BackColor;
            ((System.ComponentModel.ISupportInitialize)(this.pic_ico)).EndInit();
            this.Layout_Panel.ResumeLayout(false);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Layout_Panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pic_ico;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.TableLayoutPanel Layout_Panel;
        private System.Windows.Forms.ImageList IcoList;
        private System.Windows.Forms.Label lb_name;
    }
}