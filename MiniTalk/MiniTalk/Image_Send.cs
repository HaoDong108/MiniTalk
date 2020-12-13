using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MiniTalk.Model;
using MiniTalk.Net;

namespace MiniTalk
{
    public partial class Image_Send : Form
    {
        UserData user;

        public event Action<ImgMesKey> AddImage;
        public event Action<TextMesKey>  AddText;

        public Image_Send(UserData user,Image img)
        {
            InitializeComponent();
            this.user = user;
            this.lb_receiverName.Text = user.Name;
            this.pic_receiverHead.Image = user.IsPub? Images1.群聊头像 : user.HeadImage;
            this.pic_img.Image = img;
        }

        private void bt_Send_MouseEnter(object sender, EventArgs e)
        {
            this.bt_Send.Image = FixedImages.ImageSend_发送被选中;   
        }
        private void bt_Send_MouseLeave(object sender, EventArgs e)
        {
            this.bt_Send.Image = FixedImages.ImageSend_发送;
        }
        private void bt_return_MouseEnter(object sender, EventArgs e)
        {
            this.bt_return.Image = FixedImages.ImageSend_返回被选中;
        }
        private void bt_return_MouseLeave(object sender, EventArgs e)
        {
            this.bt_return.Image = FixedImages.ImageSend_返回;
        }

        private void bt_return_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void bt_Send_Click(object sender, EventArgs e)
        {
            string text = this.tb_Text.Text;

            TextMesKey txtmes = new TextMesKey()
            {
                Mes = text,
                User = this.user,
                Type = MsType.本地消息,
                isPublic = this.user.IsPub
            };
            ImgMesKey imgmes = new ImgMesKey()
            {
                User = user,
                Img = this.pic_img.Image.Clone() as Image,
                Type = MsType.本地消息,
                isPublic = this.user.IsPub
            };
            if(text.Trim().Length>0)
            if(this.AddText!=null) this.AddText.Invoke(txtmes);
            if (this.AddImage != null) this.AddImage.Invoke(imgmes);

            if (this.user.IsPub)
            {
                if (text.Trim().Length > 0)
                {
                    Transmitters.Sender.SendTo(text,false);
                }
                Transmitters.Sender.SendImgToAll(this.pic_img.Image.Clone() as Image);
            }
            else
            {
                if (text.Trim().Length>0)
                {
                    Transmitters.Sender.SendTo(user.IP, text);
                }
                Transmitters.Sender.SendImgTo(user.IP, this.pic_img.Image.Clone() as Image);
            }
            this.Close();
        }
        private void pic_img_Click(object sender, EventArgs e)
        {
            Method.ShowImage(this.pic_img.Image);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Brushes.DarkTurquoise);
            Rectangle rc = new Rectangle(new Point(pic_img.Left-2,pic_img.Top-2),new Size(pic_img.Width+2,pic_img.Height+2));
            e.Graphics.DrawRectangle(pen, rc);
            rc = new Rectangle(new Point(tb_Text.Left - 2, tb_Text.Top - 2), new Size(tb_Text.Width + 2, tb_Text.Height + 2));
            e.Graphics.DrawRectangle(pen, rc);
        }
    }
}
