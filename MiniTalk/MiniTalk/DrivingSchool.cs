using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniTalk { 

    public partial class DrivingSchool : Form
    {

        public DrivingSchool()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            Animation.窗体动画.Enter_Animate(this.Handle, Animation.Enter_Animations.自下向上滑动, 800);
            this.bt_Before.Enabled = false;
            this.bt_After.Enabled = true;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Method.FormMove(this.Handle);
        }

        private void bt_Before_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = false;
            this.panel1.Visible = true;
            this.bt_Before.Enabled = false;
            this.bt_After.Enabled = true;
        }

        private void bt_After_Click(object sender, EventArgs e)
        {
            this.panel2.Visible = true;
            this.panel1.Visible = false;
            this.bt_Before.Enabled = true;
            this.bt_After.Enabled = false;
        }

        private void bt_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ControlAutoSize()
        {
            this.panel1.Width=this.panel2.Width= (int)(this.Width * 0.742);
        }
    }
}
