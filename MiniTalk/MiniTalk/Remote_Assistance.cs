using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UDP_网络通信
{
    public partial class Remote_Assistance : Form
    {
        public Remote_Assistance()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;//让窗体可被线程控制
            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// 关闭模块
        /// </summary>
        private new void Close()
        {

        }

        private void Remote_Assistance_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.label1.Location = new Point((this.Width / 2) - (this.label1.Width / 2), -(this.label1.Height - 8));
            new Prompt().Show("对焦速度加啊多久啊我皮带机恐怕我大家晚安哦功夫瓦房福娃和覅是发完后覅哦啊无法啊大王分外佛教",2000,null);
            this.label1.ForeColor = Color.DeepSkyBlue;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;  // Winuser.h定义
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;   // 最小化
                return cp;
            }
        }


        #region 键盘

        protected override void OnKeyDown(KeyEventArgs e)
        {

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
        }

        #endregion

        #region 鼠标

        protected override void OnMouseMove(MouseEventArgs e)
        {

            base.OnMouseMove(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            base.OnMouseDoubleClick(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
        }

        #endregion

        #region 提示标签
        //label滑动动画
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            
            for (int i = this.label1.Location.Y; i <= 0; i += 2)
            {
                this.label1.Location = new Point(this.label1.Location.X, i);
                Thread.Sleep(10);
            }
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            this.label1.Location = new Point(this.label1.Location.X, -(this.label1.Height - 8));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //退出远程协助
        }
        #endregion


    }

}
