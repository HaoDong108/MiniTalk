using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiniTalk;
using MiniTalk.Model;

namespace Override_Control
{
    //自定义透明Listbox
    public class TransparentListBox : ListBox
    {
        public event Action<object, UserData> HoverIndexChange;

        private int floatNowIndex = -1;//记录临时鼠标坐标所在的索引值

        /// <summary>
        ///获取当前选中的用户实例
        /// </summary>
        public UserData NowSelectUser
        {
            get
            {
                if (this.SelectedIndex < 0) return null;
                return this.Items[this.SelectedIndex] as UserData;
            }
        }

        /// <summary>
        /// 获取当前悬浮用户
        /// </summary>
        public UserData NowHoverUser
        {
            get
            {
                if (this.floatNowIndex < 0) return null;
                return this.Items[this.floatNowIndex] as UserData;
            }
        }

        /// <summary>
        /// 当前悬浮索引
        /// </summary>
        public int NowHoverIndex
        {
            get
            {
                return floatNowIndex;
            }
        }

        public TransparentListBox()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            //设置默认选中项
            this.SelectedItem = 0;
            //开启双缓冲
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.floatNowIndex = -1;
            this.Refresh();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            int nowIndex = this.IndexFromPoint(e.X, e.Y);
            if (nowIndex != this.floatNowIndex)
            {
                this.floatNowIndex = nowIndex;
                if (this.HoverIndexChange != null) this.HoverIndexChange.Invoke(this,this.NowHoverUser);
                this.Invalidate();
            }
            base.OnMouseMove(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            PaintItem(e.Graphics);
            base.OnPaint(e);
        }

        /// <summary>
        /// 绘制items
        /// </summary>
        /// <param name="e">事件画笔</param>
        /// <param name="ScrollPosIndex">滚动条索引</param>
        private void PaintItem(Graphics g)
        {
            if (this.Items.Count == 0) return;
            try
            {
                //绘制悬浮底色
                if (this.floatNowIndex >= 0)
                {
                    Rectangle itemRect = this.GetItemRectangle(floatNowIndex);
                    Bitmap bit = DSAPI.图形图像.绘制圆角矩形(new Size(itemRect.Width-10,itemRect.Height), 10, Color.FromArgb(0x78008B8B), Color.FromArgb(0x7800CED1));
                    g.DrawImage(bit, new Point(itemRect.X, itemRect.Y));
                }
                //绘制选中图标
                if (this.SelectedIndex >= 0)
                {
                    Rectangle rec = this.GetItemRectangle(this.SelectedIndex);
                    g.DrawImage(FixedImages.选中, new Point(rec.X + rec.Width - 50, rec.Y + 13));
                }

                StringFormat strFmt = new StringFormat
                {
                    Alignment = StringAlignment.Center, //文本垂直居中
                    LineAlignment = StringAlignment.Center //文本水平居中                 
                };
                //绘制头像,昵称,状态标记
                for (int i = 0; i < Items.Count; i++)
                {
                    Rectangle itemRect = this.GetItemRectangle(i);
                    dynamic data = this.Items[i];
                    Font f = new Font("黑体", 7.5f, FontStyle.Regular);
                    g.DrawString(this.GetItemText(this.Items[i]), this.Font, new SolidBrush(this.ForeColor), this.GetItemRectangle(i), strFmt);
                    g.DrawImage(i > 0 ? data.HeadImage : Images1.群聊头像, itemRect.X, itemRect.Y + 5, 50, 50);
                    if (data.InBlacklist) g.DrawString("BLK", f, Brushes.Red, new Point(itemRect.X + 55, itemRect.Y + 45));
                    if (data.IsTop) g.DrawString("TOP", f, Brushes.Turquoise, new Point(itemRect.X + 55, itemRect.Y + 5));
                    if (data.DrawDot) g.FillEllipse(Brushes.Red, itemRect.X, itemRect.Y + 5, 10, 10);
                }
            }
            catch (Exception)
            { }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.Style &= ~0x00200000; ; //禁用垂直滚动条
                return parms;
            }
        }
    }
}
