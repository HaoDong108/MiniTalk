using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using LMScrollBar;

namespace LM.CLibrary.Controls
{
    public partial class LMVScrollBar : UserControl
    {
        public LMVScrollBar()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.AutoSize = true;
        }


        #region 滚动条属性申明
        private Image _ImageUpArrow = Resources.VScroll_Up;
        [Description("滚动条上部箭头使用的图片")]
        public Image ImageUpArrow
        {
            get { return _ImageUpArrow; }
            set { _ImageUpArrow = value; }
        }

        private Image _ImageThumb = Resources.VScroll_Middle;
        [Description("滚动条滑块部分使用的图片")]
        public Image ImageThumb
        {
            get { return _ImageThumb; }
            set { _ImageThumb = value; }
        }

        private Image _ImageDownArrow = Resources.VScroll_Down;
        [Description("滚动条底部箭头使用的图片")]
        public Image ImageDownArrow
        {
            get { return _ImageDownArrow; }
            set { _ImageDownArrow = value; }
        }

        private Color _ColorBg = Color.Black;
        [Description("通道的背景色")]
        public Color ColorBg
        {
            get { return _ColorBg; }
            set { _ColorBg = value; }
        }

        private Color _ColorLine = Color.Black;
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

        private int _Minimum = 100;
        public int Minimum
        {
            get { return _Minimum; }
            set { _Minimum = value; }
        }

        private int _ThumbHeitht = 10;
        public int ThumbHeight
        {
            get { return _ThumbHeitht; }
            set { _ThumbHeitht = value; this.Invalidate(); }
        }

        private int _SmallChange = 10;
        public int SmallChange
        {
            get { return _SmallChange; }
            set { _SmallChange = value; }
        }

        private int _Value;
        public int Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private bool _MouseEnterThumb;
        private bool _MouseDown;
        private int _MouseClickUp;
        private int _MouseClickDown;
        private int _ThumbTop = 0;

        public new event EventHandler Scroll = null;
        public event EventHandler ValueChange = null;
        #endregion

        #region 滚动条事件
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(_ImageUpArrow, 0, 0, this.Width, _ImageUpArrow.Height);

            Brush BrushBg = new SolidBrush(_ColorBg);
            Pen PenLine = new Pen(_ColorLine);
            g.FillRectangle(BrushBg, new Rectangle(0, _ImageUpArrow.Height, this.Width, (this.Height - _ImageDownArrow.Height - _ImageUpArrow.Height - 1)));
            g.DrawLine(PenLine, 0, _ImageUpArrow.Height, 0, this.Height - _ImageDownArrow.Height - 1);
            g.DrawLine(PenLine, this.Width - 1, _ImageUpArrow.Height, this.Width - 1, this.Height - _ImageDownArrow.Height - 1);

            int WorkHeight = this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height;
            float fThumbHeight = ((float)_ThumbHeitht / (float)_Maximum) * WorkHeight;
            int iThumbHeight = (int)fThumbHeight;
            if (iThumbHeight > WorkHeight)
            {
                fThumbHeight = WorkHeight;
                iThumbHeight = WorkHeight;
            }
            if (iThumbHeight < 14)
            {
                fThumbHeight = 14;
                iThumbHeight = 14;
            }
            int TOPBUTTOM = 5;
            int iTop = _ThumbTop;
            iTop += _ImageUpArrow.Height;
            if (_MouseEnterThumb)
            {
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, TOPBUTTOM), new Rectangle(0, 0, _ImageThumb.Width, TOPBUTTOM), GraphicsUnit.Pixel);
                iTop += TOPBUTTOM;
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, iThumbHeight - (2 * TOPBUTTOM)), new Rectangle(0, TOPBUTTOM, _ImageThumb.Width, _ImageThumb.Height - (2 * TOPBUTTOM)), GraphicsUnit.Pixel);
                iTop += iThumbHeight - (2 * TOPBUTTOM);
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, TOPBUTTOM), new Rectangle(0, _ImageThumb.Height - TOPBUTTOM, _ImageThumb.Width, TOPBUTTOM), GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, TOPBUTTOM), new Rectangle(0, 0, _ImageThumb.Width, TOPBUTTOM), GraphicsUnit.Pixel);
                iTop += TOPBUTTOM;
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, iThumbHeight - (2 * TOPBUTTOM)), new Rectangle(0, TOPBUTTOM, _ImageThumb.Width, _ImageThumb.Height - (2 * TOPBUTTOM)), GraphicsUnit.Pixel);
                iTop += iThumbHeight - (2 * TOPBUTTOM);
                g.DrawImage(_ImageThumb, new Rectangle(0, iTop, this.Width, TOPBUTTOM), new Rectangle(0, _ImageThumb.Height - TOPBUTTOM, _ImageThumb.Width, TOPBUTTOM), GraphicsUnit.Pixel);
            }

            g.DrawImage(_ImageDownArrow, 0, this.Height - _ImageDownArrow.Height, this.Width, _ImageDownArrow.Height);
            BrushBg.Dispose();
            PenLine.Dispose();
        }
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
                if (AutoSize)
                {
                    this.Width = _ImageUpArrow.Width;
                }
            }
        }

        private void LMVScrollBar_MouseDown(object sender, MouseEventArgs e)
        {
            Point PointMouseClick = this.PointToClient(Cursor.Position);
            int WorkHeight = this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height;
            float fThumbHeight = ((float)_ThumbHeitht / (float)_Maximum) * WorkHeight;
            int iThumbHeight = (int)fThumbHeight;
            if (iThumbHeight > WorkHeight)
            {
                fThumbHeight = WorkHeight;
                iThumbHeight = WorkHeight;
            }
            if (iThumbHeight < 14)
            {
                fThumbHeight = 14;
                iThumbHeight = 14;
            }
            int iTop = _ImageUpArrow.Height;
            iTop += _ThumbTop;

            Rectangle UpRect = new Rectangle(0, 0, this.Width, _ImageUpArrow.Height);
            if (UpRect.Contains(PointMouseClick))
            {
                if (_ThumbTop - _SmallChange <= 0)
                    _ThumbTop = 0;
                else
                    _ThumbTop -= _SmallChange;
                float fv = ((float)_ThumbTop / (float)(this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - fThumbHeight)) * (_Maximum - _ThumbHeitht);
                _Value = (int)fv;
                if (Scroll != null)
                {
                    Scroll(this, new EventArgs());
                }
                if (ValueChange != null)
                {
                    ValueChange(this, new EventArgs());
                }
                VScrollBarValueChange();
                this.Invalidate();
            }

            Rectangle ThumbRect = new Rectangle(0, iTop, _ImageThumb.Width, iThumbHeight);
            if (ThumbRect.Contains(PointMouseClick))
            {
                _MouseDown = true;
                _MouseClickUp = PointMouseClick.Y - iTop;
                _MouseClickDown = iThumbHeight - _MouseClickUp;
            }

            Rectangle DownRect = new Rectangle(0, this.Height - _ImageDownArrow.Height, this.Width, _ImageDownArrow.Height);
            if (DownRect.Contains(PointMouseClick))
            {
                if (_ThumbTop + _SmallChange >= WorkHeight - iThumbHeight)
                    _ThumbTop = WorkHeight - iThumbHeight;
                else
                    _ThumbTop += _SmallChange;
                float fv = ((float)_ThumbTop / (float)(this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - fThumbHeight)) * (_Maximum - _ThumbHeitht);
                _Value = (int)fv;
                if (Scroll != null)
                {
                    Scroll(this, new EventArgs());
                }
                if (ValueChange != null)
                {
                    ValueChange(this, new EventArgs());
                }
                VScrollBarValueChange();
                this.Invalidate();
            }
        }
        private void LMVScrollBar_MouseUp(object sender, MouseEventArgs e)
        {
            _MouseDown = false;
        }
        #endregion

        private void LMVScrollBar_MouseMove(object sender, MouseEventArgs e)
        {
            Point PointMouseClick = this.PointToClient(Cursor.Position);

            int WorkHeight = this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height;
            float fThumbHeight = ((float)_ThumbHeitht / (float)_Maximum) * WorkHeight;
            int iThumbHeight = (int)fThumbHeight;
            if (iThumbHeight > WorkHeight)
            {
                fThumbHeight = WorkHeight;
                iThumbHeight = WorkHeight;
            }
            if (iThumbHeight < 14)
            {
                fThumbHeight = 14;
                iThumbHeight = 14;
            }
            int iTop = _ImageUpArrow.Height;
            iTop += _ThumbTop;
            Rectangle ThumbRect = new Rectangle(0, iTop, _ImageThumb.Width, iThumbHeight);
            if (ThumbRect.Contains(PointMouseClick))
                _MouseEnterThumb = true;
            else
                _MouseEnterThumb = false;
            this.Invalidate();

            if (_MouseDown)
            {
                _ThumbTop = e.Y - _MouseClickUp - _ImageUpArrow.Height;
                if (e.Y - _MouseClickUp <= _ImageUpArrow.Height)
                    _ThumbTop = 0;
                if (e.Y + _MouseClickDown >= this.Height - _ImageDownArrow.Height)
                    _ThumbTop = this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - iThumbHeight;
                float fv = ((float)_ThumbTop / (float)(this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - iThumbHeight)) * (_Maximum - _ThumbHeitht);
                _Value = (int)fv;
                if (Scroll != null)
                {
                    Scroll(this, new EventArgs());
                }
                if (ValueChange != null)
                {
                    ValueChange(this, new EventArgs());
                }
                VScrollBarValueChange();
                this.Invalidate();
            }
        }

        private void LMVScrollBar_MouseLeave(object sender, EventArgs e)
        {
            _MouseEnterThumb = false;
            this.Invalidate();
        }
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            Wheel(e);
        }

        private Control _BindControl;
        [CategoryAttribute("阿龙自定义属性"), Description("与该控件绑定的控件")]
        public Control BindControl
        {
            get { return _BindControl; }
            set
            {
                _BindControl = value;
                if (_BindControl != null)
                {
                    this.Location = new Point(0, 0);
                    int x, y, height;
                    x = _BindControl.Location.X + _BindControl.Width - this.Width;
                    y = _BindControl.Location.Y;
                    height = _BindControl.Height;
                    this.Location = new Point(x, y);
                    this.Size = new Size(this.Width, height);

                    //LMListBox LMListBox1 = _BindControl as LMListBox;
                    //if (LMListBox1 != null)
                    //{
                    //    //LMListBox1 = (LMListBox)_BindControl;
                    //    //this.Maximum = _Maximum;
                    //    //this.ThumbHeight = _ThumbHeitht;
                    //}
                    //this.Maximum = this._BindControl lmListBox1.Items.Count;
                    //this.ThumbHeight = lmListBox1.Height / lmListBox1.ItemHeight;

                    //this.Maximum = this._BindControl.Items.Count;
                    //this.ThumbHeight = this._BindControl.Height / this._BindControl.ItemHeight;
                    //this.SmallChange = _BindControl.ItemHeight * _BindControl.Items.Count / (alVScrollBar1.Height - alVScrollBar1.ImageUpArrow.Height - alVScrollBar1.ImageDownArrow.Height) * 5;

                }
            }
        }


        //private void setVScrollBar()
        //{
        //    alVScrollBar1.Location = new Point(0, 0);
        //    int x, y, height;
        //    x = BaseComList.Location.X + BaseComList.Width - alVScrollBar1.Width;
        //    y = BaseComList.Location.Y;
        //    height = BaseComList.Height;
        //    this.alVScrollBar1.Location = new Point(x, y);
        //    this.alVScrollBar1.Size = new Size(alVScrollBar1.Width, height);
        //    this.alVScrollBar1.Maximum = this.BaseComList.Items.Count;
        //    this.alVScrollBar1.ThumbHeight = this.BaseComList.Height / this.BaseComList.ItemHeight;
        //    this.alVScrollBar1.SmallChange = BaseComList.ItemHeight * BaseComList.Items.Count / (alVScrollBar1.Height - alVScrollBar1.ImageUpArrow.Height - alVScrollBar1.ImageDownArrow.Height) * 5;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        public void Wheel(MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (_ThumbTop > 0)
                {
                    int v = _Value;
                    while (v == _Value&&_ThumbTop>0)
                    {
                        _ThumbTop -= _SmallChange;
                        float fv = ((float)_ThumbTop / (float)(this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - ((float)_ThumbHeitht / (float)_Maximum) * (this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height))) * (_Maximum - _ThumbHeitht);
                        _Value = (int)fv;
                    }
                    if (Scroll != null) Scroll(this, new EventArgs());
                    if (ValueChange != null) ValueChange(this, new EventArgs());
                }
            }
            else
            {
                if (_ThumbTop < this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - ((float)_ThumbHeitht / (float)_Maximum) * (this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height))
                {
                    //上滚
                    int v = _Value;
                    while (_Value == v)
                    {
                        _ThumbTop += _SmallChange;
                        float fv = ((float)_ThumbTop / (float)(this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height - ((float)_ThumbHeitht / (float)_Maximum) * (this.Height - _ImageUpArrow.Height - _ImageDownArrow.Height))) * (_Maximum - _ThumbHeitht);
                        _Value = (int)fv;
                    }
                    if (Scroll != null) Scroll(this, new EventArgs());
                    if (ValueChange != null) ValueChange(this, new EventArgs());

                }
            }
            VScrollBarValueChange();
            this.Invalidate();
        }


        public Win32.SCROLLINFO tvImageListScrollInfo
        {
            get
            {
                Win32.SCROLLINFO si = new Win32.SCROLLINFO();
                si.cbSize = (uint)Marshal.SizeOf(si);
                si.fMask = (int)(Win32.ScrollInfoMask.SIF_DISABLENOSCROLL | Win32.ScrollInfoMask.SIF_ALL);
                Win32.GetScrollInfo(_BindControl.Handle, (int)Win32.ScrollBarDirection.SB_VERT, ref si);
                return si;
            }
        }
        //当鼠标滚动时，设置该滚动条
        private void SetImageListScroll()
        {
            Win32.SCROLLINFO info = tvImageListScrollInfo;
            if (info.nMax > 0)
            {
                int pos = info.nPos - 1;
                if (pos >= 0)
                {
                    this.Value = pos;
                }
            }
        }

        private void VScrollBarValueChange()
        {
            Win32.SCROLLINFO info = tvImageListScrollInfo;
            info.nPos = this.Value;
            Win32.SetScrollInfo(_BindControl.Handle, (int)Win32.ScrollBarDirection.SB_VERT, ref info, true);
            Win32.PostMessage(_BindControl.Handle, Win32.WM_VSCROLL, Win32.MakeLong((short)Win32.SB_THUMBTRACK, (short)(info.nPos)), 0);
        }
    }
    public class Win32
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct tagSCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        public enum fnBar
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2
        }
        public enum fMask
        {
            SIF_ALL,
            SIF_DISABLENOSCROLL = 0X0010,
            SIF_PAGE = 0X0002,
            SIF_POS = 0X0004,
            SIF_RANGE = 0X0001,
            SIF_TRACKPOS = 0X0008
        }

        public static int MakeLong(short lowPart, short highPart)
        {
            return (int)(((ushort)lowPart) | (uint)(highPart << 16));
        }
        public const int SB_THUMBTRACK = 5;
        public const int WM_HSCROLL = 0x114;
        public const int WM_VSCROLL = 0x115;
        [DllImport("user32.dll", EntryPoint = "GetScrollInfo")]
        public static extern bool GetScrollInfo(IntPtr hwnd, int fnBar, ref SCROLLINFO lpsi);
        [DllImport("user32.dll", EntryPoint = "SetScrollInfo")]
        public static extern int SetScrollInfo(IntPtr hwnd, int fnBar, [In] ref SCROLLINFO lpsi, bool fRedraw);

        [DllImport("User32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public struct SCROLLINFO
        {
            public uint cbSize;
            public uint fMask;
            public int nMin;
            public int nMax;
            public uint nPage;
            public int nPos;
            public int nTrackPos;
        }
        public enum ScrollInfoMask
        {
            SIF_RANGE = 0x1,
            SIF_PAGE = 0x2,
            SIF_POS = 0x4,
            SIF_DISABLENOSCROLL = 0x8,
            SIF_TRACKPOS = 0x10,
            SIF_ALL = SIF_RANGE + SIF_PAGE + SIF_POS + SIF_TRACKPOS
        }
        public enum ScrollBarDirection
        {
            SB_HORZ = 0,
            SB_VERT = 1,
            SB_CTL = 2,
            SB_BOTH = 3
        }
    }
}
