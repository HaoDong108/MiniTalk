using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using LMScrollBar;

namespace LM.CLibrary.Controls
{
    public partial class LMHScrollBar : UserControl
    {
        public LMHScrollBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoSize = true;
        }
        #region 蓝淼滚动条属性声明
        private Image _ImageLeftArrow = Resources.HScroll_Left;
        public Image ImageLeftArrow
        {
            get { return _ImageLeftArrow; }
            set { _ImageLeftArrow = value; }
        }

        private Image _ImageThumb = Resources.HScroll_Middle;
        public Image ImageThumb
        {
            get { return _ImageThumb; }
            set { _ImageThumb = value; }
        }

        private Image _ImageRightArrow = Resources.HScroll_Right;
        public Image ImageRightArrow
        {
            get { return _ImageRightArrow; }
            set { _ImageRightArrow = value; }
        }

        private Color _ColorBg = Color.FromArgb(235, 243, 246);
        [Description("通道的背景色")]
        public Color ColorBg
        {
            get { return _ColorBg; }
            set { _ColorBg = value; }
        }

        private Color _ColorLine = Color.FromArgb(220, 230, 240);
        [Description("通道的边框颜色")]
        public Color ColorLine
        {
            get { return _ColorLine; }
            set { _ColorLine = value; }
        }

        private int _Maximum = 100;
        public int Maximum
        {
            get { return _Maximum; }
            set { _Maximum = value; }
        }

        private int _ThumbWidth = 10;
        public int ThumbWidth
        {
            get { return _ThumbWidth; }
            set { _ThumbWidth = value; }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private bool _MouseThumbDown;
        private int _ThumbLeft = 0;
        private int _MouseClickLeft;
        public event EventHandler ValueChange = null;
        #endregion

        #region 蓝淼滚动条事件
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (this.AutoSize)
                {
                    this.Height = _ImageLeftArrow.Height;
                }
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(_ImageLeftArrow, 0, 0, _ImageLeftArrow.Width, this.Height);

            Brush BrushBg = new SolidBrush(_ColorBg);
            Pen PenLine = new Pen(_ColorLine);
            g.FillRectangle(BrushBg, new Rectangle(_ImageLeftArrow.Width, 0, this.Width - _ImageLeftArrow.Width - _ImageRightArrow.Width - 1, this.Height));
            g.DrawLine(PenLine, _ImageLeftArrow.Width, 0, this.Width - _ImageRightArrow.Width - 1, 0);
            g.DrawLine(PenLine, _ImageLeftArrow.Width, this.Height - 1, this.Width - _ImageLeftArrow.Width - 1, this.Height - 1);

            int WorkWidth = this.Width - _ImageLeftArrow.Width - _ImageRightArrow.Width;
            float fThumbWidth = (float)_ThumbWidth / (float)_Maximum * WorkWidth;
            int iThumbWidth = (int)fThumbWidth;
            if (iThumbWidth > WorkWidth)
            {
                iThumbWidth = WorkWidth;
                fThumbWidth = WorkWidth;
            }
            if (iThumbWidth < 14)
            {
                iThumbWidth = 14;
                fThumbWidth = 14;
            }
            int LEFTRIGHT = 5;
            int iLeft = _ThumbLeft;
            iLeft += _ImageLeftArrow.Width;
            g.DrawImage(_ImageThumb, new Rectangle(iLeft, 0, LEFTRIGHT, this.Height), new Rectangle(0, 0, LEFTRIGHT, _ImageThumb.Height), GraphicsUnit.Pixel);
            iLeft += LEFTRIGHT;
            g.DrawImage(_ImageThumb, new Rectangle(iLeft, 0, iThumbWidth - 2 * LEFTRIGHT, this.Height), new Rectangle(LEFTRIGHT, 0, _ImageThumb.Width - 2 * LEFTRIGHT, _ImageThumb.Height), GraphicsUnit.Pixel);
            iLeft += iThumbWidth - 2 * LEFTRIGHT;
            g.DrawImage(_ImageThumb, new Rectangle(iLeft, 0, LEFTRIGHT, this.Height), new Rectangle(_ImageThumb.Width - LEFTRIGHT, 0, LEFTRIGHT, _ImageThumb.Height), GraphicsUnit.Pixel);

            g.DrawImage(_ImageRightArrow, this.Width - _ImageRightArrow.Width, 0, _ImageRightArrow.Width, this.Height);
        }

        #endregion

        private void LMHScrollBar_MouseDown(object sender, MouseEventArgs e)
        {
            Point PointMouseClick = PointToClient(Cursor.Position);
            int WorkWidth = this.Width - _ImageLeftArrow.Width - _ImageRightArrow.Width;
            float fThumbWidth = (float)_ThumbWidth / (float)_Maximum * WorkWidth;
            int iThumbWidth = (int)fThumbWidth;
            if (iThumbWidth > WorkWidth)
            {
                iThumbWidth = WorkWidth;
                fThumbWidth = WorkWidth;
            }
            if (iThumbWidth < 14)
            {
                iThumbWidth = 14;
                fThumbWidth = 14;
            }
            int iLeft = _ThumbLeft;
            iLeft += _ImageLeftArrow.Width;
            Rectangle ThumRect = new Rectangle(iLeft, 0, iThumbWidth, this.Height);
            if (ThumRect.Contains(PointMouseClick))
            {
                _MouseThumbDown = true;
                _MouseClickLeft = e.X - iLeft;
            }
        }

        private void LMHScrollBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (_MouseThumbDown)
            {
                int WorkWidth = this.Width - _ImageLeftArrow.Width - _ImageRightArrow.Width;
                float fThumbWidth = (float)_ThumbWidth / (float)_Maximum * WorkWidth;
                int iThumbWidth = (int)fThumbWidth;
                if (iThumbWidth > WorkWidth)
                {
                    iThumbWidth = WorkWidth;
                    fThumbWidth = WorkWidth;
                }
                if (iThumbWidth < 14)
                {
                    iThumbWidth = 14;
                    fThumbWidth = 14;
                }

                _ThumbLeft = e.X - _MouseClickLeft - _ImageLeftArrow.Width;
                if (_ThumbLeft <= 0)
                    _ThumbLeft = 0;
                if (_ThumbLeft >= WorkWidth - iThumbWidth)
                    _ThumbLeft = WorkWidth - iThumbWidth;                 
                float fv = (float)_ThumbLeft / (float)(this.Width - _ImageLeftArrow.Width - _ImageRightArrow.Width - iThumbWidth) * (Maximum - _ThumbWidth);
                _Value = (int)fv;
                if (ValueChange != null)
                {
                    ValueChange(this, new EventArgs());
                }
                this.Invalidate();
            }
        }

        private void LMHScrollBar_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseThumbDown = false;
        }
    }
}
