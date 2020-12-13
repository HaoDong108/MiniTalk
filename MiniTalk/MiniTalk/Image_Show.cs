using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTalk
{
    public partial class Image_Show : Form
    {
        public Image_Show()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.pic_Image.MouseWheel += PictureBox1_MouseWheel;
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            int i = e.Delta * SystemInformation.MouseWheelScrollLines / 5;
            this.SetSize(i);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.pic_Image.Size = this.Size;
            this.pic_Image.Location = Point.Empty;
            this.pic_Image.MinimumSize = new Size(this.Width - 500, this.Height - 500);
        }

        protected override void OnShown(EventArgs e)
        {
            this.pic_Image.Size = this.Size;
            this.pic_Image.Location = Point.Empty;
        }

        /// <summary>
        /// 设置图像
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(Image image)
        {
            this.pic_Image.Image = image;
        }

        /// <summary>
        /// 根据角度旋转图标
        /// </summary>
        /// <param name="img"></param>
        private Image RotateImg(Image img, float angle)
        {
            //通过Png图片设置图片透明，修改旋转图片变黑问题。
            int width = img.Width;
            int height = img.Height;
            //角度
            Matrix mtrx = new Matrix();
            mtrx.RotateAt(angle, new PointF((width / 2), (height / 2)), MatrixOrder.Append);
            //得到旋转后的矩形
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(new RectangleF(0f, 0f, width, height));
            RectangleF rct = path.GetBounds(mtrx);
            //生成目标位图
            Bitmap devImage = new Bitmap((int)(rct.Width), (int)(rct.Height));
            Graphics g = Graphics.FromImage(devImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((int)(rct.Width - width) / 2, (int)(rct.Height - height) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, (int)width, (int)height);
            Point center = new Point((int)(rect.X + rect.Width / 2), (int)(rect.Y + rect.Height / 2));
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(img, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            path.Dispose();
            return devImage;
        }

        #region 图像拖动
        bool isSelect = false;
        Point mouseStartPoint;
        private void pic_Image_MouseDown(object sender, MouseEventArgs e)
        {
            this.mouseStartPoint = e.Location;
            this.isSelect = true;
            this.pic_Image.Cursor = Cursors.SizeAll;
        }
        private void pic_Image_MouseUp(object sender, MouseEventArgs e)
        {
            this.isSelect = false;
            this.pic_Image.Cursor = Cursors.Arrow;
        }
        private void pic_Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isSelect) return;
            this.pic_Image.Left += (e.Location.X - this.mouseStartPoint.X);
            this.pic_Image.Top += (e.Location.Y - this.mouseStartPoint.Y);
        }
        #endregion

        private void bt_Rotate_Click(object sender, EventArgs e)
        {
            Image map = this.RotateImg(this.pic_Image.Image.Clone() as Image, 90);
            this.pic_Image.Image = map;
        }

        private void bt_Center_Click(object sender, EventArgs e)
        {
            this.pic_Image.Size = this.Size;
            this.pic_Image.Location = Point.Empty;
        }

        private void bt_Save_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.Filter = " jpg格式 (*.jpg)|*.jpg";
            this.saveFileDialog1.FilterIndex = 1;
            this.saveFileDialog1.RestoreDirectory = true;
            this.saveFileDialog1.FileName = DateTime.Now.ToString("yyyMMddHHmmssff")+".jpg";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                this.pic_Image.Image.Save(saveFileDialog1.FileName);
                MessageBox.Show(string.Format("图片成功保存至{0}", saveFileDialog1.FileName), "保存成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.pic_Image.Image = null;
            this.pic_Image.Dispose();
            GC.Collect();
        }

        private void bt_Narrow_Click(object sender, EventArgs e)
        {
            this.SetSize(-100);
        }

        private void bt_BlowUp_Click(object sender, EventArgs e)
        {
            this.SetSize(100);
        }

        private void SetSize(int i)
        {
            if ((pic_Image.Width + i <= this.pic_Image.MinimumSize.Width))
            {
                return;
            }
            if ((pic_Image.Width + i >= this.pic_Image.MaximumSize.Width))
            {
                return;
            }
            pic_Image.Width = pic_Image.Width + i;//增加picturebox的宽度
            pic_Image.Height = pic_Image.Height + i;
            pic_Image.Left = pic_Image.Left - i / 2;//使picturebox的中心位于窗体的中心
            pic_Image.Top = pic_Image.Top - i / 2;//进而缩放时图片也位于窗体的中心
        }
    }
}
