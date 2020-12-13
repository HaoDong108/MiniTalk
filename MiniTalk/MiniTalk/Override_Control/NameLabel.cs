using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using MiniTalk;

namespace Override_Control
{
    public class NameLabel : Label
    {
        public NameLabel(string name)
        {
            this.Text = name;
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Font = new Font("微软雅黑", 14, FontStyle.Italic | FontStyle.Bold);
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }


        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Method.FormMove(KeyData.form1.Handle);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Point point = new Point(this.Width - 16, 5);
            Rectangle re2 = new Rectangle(point.X, point.Y, 3, 40);
            e.Graphics.FillRectangle(Brushes.DarkTurquoise, re2);
        }
    }
}

