namespace MiniTalk
{
    partial class Image_Send
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Send));
            this.pic_img = new System.Windows.Forms.PictureBox();
            this.bt_Send = new CCWin.SkinControl.SkinButton();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_return = new CCWin.SkinControl.SkinButton();
            this.lb_SendTo = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pic_receiverHead = new System.Windows.Forms.PictureBox();
            this.lb_receiverName = new System.Windows.Forms.Label();
            this.tb_Text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_img)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_receiverHead)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_img
            // 
            this.pic_img.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pic_img.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_img.Location = new System.Drawing.Point(66, 87);
            this.pic_img.Name = "pic_img";
            this.pic_img.Size = new System.Drawing.Size(353, 307);
            this.pic_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_img.TabIndex = 0;
            this.pic_img.TabStop = false;
            this.toolTip1.SetToolTip(this.pic_img, "点击查看图片");
            this.pic_img.Click += new System.EventHandler(this.pic_img_Click);
            // 
            // bt_Send
            // 
            this.bt_Send.BackColor = System.Drawing.Color.Transparent;
            this.bt_Send.BaseColor = System.Drawing.Color.Gainsboro;
            this.bt_Send.BorderColor = System.Drawing.Color.Silver;
            this.bt_Send.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_Send.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_Send.DownBack = null;
            this.bt_Send.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.bt_Send.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Send.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.bt_Send.Image = ((System.Drawing.Image)(resources.GetObject("bt_Send.Image")));
            this.bt_Send.ImageSize = new System.Drawing.Size(40, 40);
            this.bt_Send.Location = new System.Drawing.Point(425, 12);
            this.bt_Send.MouseBack = null;
            this.bt_Send.Name = "bt_Send";
            this.bt_Send.NormlBack = null;
            this.bt_Send.Radius = 30;
            this.bt_Send.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_Send.Size = new System.Drawing.Size(52, 48);
            this.bt_Send.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bt_Send, "发送");
            this.bt_Send.UseVisualStyleBackColor = false;
            this.bt_Send.Click += new System.EventHandler(this.bt_Send_Click);
            this.bt_Send.MouseEnter += new System.EventHandler(this.bt_Send_MouseEnter);
            this.bt_Send.MouseLeave += new System.EventHandler(this.bt_Send_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.label1.Location = new System.Drawing.Point(66, 402);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "留言:";
            // 
            // bt_return
            // 
            this.bt_return.BackColor = System.Drawing.Color.Transparent;
            this.bt_return.BaseColor = System.Drawing.Color.Gainsboro;
            this.bt_return.BorderColor = System.Drawing.Color.Silver;
            this.bt_return.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.bt_return.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bt_return.DownBack = null;
            this.bt_return.DrawType = CCWin.SkinControl.DrawStyle.None;
            this.bt_return.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_return.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.bt_return.Image = ((System.Drawing.Image)(resources.GetObject("bt_return.Image")));
            this.bt_return.ImageSize = new System.Drawing.Size(40, 40);
            this.bt_return.Location = new System.Drawing.Point(367, 12);
            this.bt_return.MouseBack = null;
            this.bt_return.Name = "bt_return";
            this.bt_return.NormlBack = null;
            this.bt_return.Radius = 30;
            this.bt_return.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.bt_return.Size = new System.Drawing.Size(52, 48);
            this.bt_return.TabIndex = 2;
            this.toolTip1.SetToolTip(this.bt_return, "返回");
            this.bt_return.UseVisualStyleBackColor = false;
            this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
            this.bt_return.MouseEnter += new System.EventHandler(this.bt_return_MouseEnter);
            this.bt_return.MouseLeave += new System.EventHandler(this.bt_return_MouseLeave);
            // 
            // lb_SendTo
            // 
            this.lb_SendTo.AutoSize = true;
            this.lb_SendTo.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_SendTo.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_SendTo.Location = new System.Drawing.Point(10, 9);
            this.lb_SendTo.Name = "lb_SendTo";
            this.lb_SendTo.Size = new System.Drawing.Size(99, 23);
            this.lb_SendTo.TabIndex = 3;
            this.lb_SendTo.Text = "发送图片给:";
            // 
            // pic_receiverHead
            // 
            this.pic_receiverHead.Location = new System.Drawing.Point(156, 9);
            this.pic_receiverHead.Name = "pic_receiverHead";
            this.pic_receiverHead.Size = new System.Drawing.Size(50, 50);
            this.pic_receiverHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_receiverHead.TabIndex = 5;
            this.pic_receiverHead.TabStop = false;
            // 
            // lb_receiverName
            // 
            this.lb_receiverName.AutoSize = true;
            this.lb_receiverName.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_receiverName.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.lb_receiverName.Location = new System.Drawing.Point(212, 22);
            this.lb_receiverName.Name = "lb_receiverName";
            this.lb_receiverName.Size = new System.Drawing.Size(113, 26);
            this.lb_receiverName.TabIndex = 3;
            this.lb_receiverName.Text = "接收者昵称 ";
            // 
            // tb_Text
            // 
            this.tb_Text.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.tb_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_Text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Text.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.tb_Text.Location = new System.Drawing.Point(66, 432);
            this.tb_Text.MaxLength = 100;
            this.tb_Text.Multiline = true;
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(353, 122);
            this.tb_Text.TabIndex = 6;
            // 
            // Image_Send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.ClientSize = new System.Drawing.Size(491, 578);
            this.Controls.Add(this.tb_Text);
            this.Controls.Add(this.pic_receiverHead);
            this.Controls.Add(this.lb_receiverName);
            this.Controls.Add(this.lb_SendTo);
            this.Controls.Add(this.bt_return);
            this.Controls.Add(this.bt_Send);
            this.Controls.Add(this.pic_img);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Image_Send";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "发送图片给";
            ((System.ComponentModel.ISupportInitialize)(this.pic_img)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_receiverHead)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_img;
        private CCWin.SkinControl.SkinButton bt_Send;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinButton bt_return;
        private System.Windows.Forms.Label lb_SendTo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pic_receiverHead;
        private System.Windows.Forms.Label lb_receiverName;
        private System.Windows.Forms.TextBox tb_Text;
    }
}