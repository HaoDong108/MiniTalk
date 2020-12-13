using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Override_Control
{
    class TabButton : Label
    {
        public int ButtonIndex { get; set; }
        public bool IsSelect { get; set; }

        public TabButton(string text)
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.LabelSetUp(text);
        }

        private void LabelSetUp(string text)
        {
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.Black;
            this.Font = new Font("微软雅黑", 10, FontStyle.Regular);
            this.TextAlign = ContentAlignment.MiddleCenter;
            this.Text = text;
            this.AutoSize = false;
            this.Size = new Size(168, 44);
            this.Location = new Point(3, 16);
            this.BorderStyle = BorderStyle.None;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            this.BackColor = Color.DeepSkyBlue;
            this.Font = new Font("微软雅黑", 10, FontStyle.Bold);
            this.ForeColor = Color.White;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = !this.IsSelect ? Color.Transparent : Color.Silver;
            this.Font = new Font("微软雅黑", 10, FontStyle.Regular);
            this.ForeColor = Color.Black;
            base.OnMouseLeave(e);
        }

    }
}

