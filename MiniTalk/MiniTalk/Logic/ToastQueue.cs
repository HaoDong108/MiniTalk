using MiniTalk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MiniTalk.Model;

namespace MiniTalk
{
    public class ToastAddEventAgs : EventArgs
    {
        /// <summary>
        /// 用于队列等待
        /// </summary>
        public List<Task> tasks { get; private set; }

        public ToastAddEventAgs()
        {
            tasks = new List<Task>();
        }
    }

    public class ToastQueue : CBlockQueue<MiniToast>
    {
        private delegate void NewToastAddEventHandler(object sender, ToastAddEventAgs e);
        Thread td_add;

        public ToastQueue()
        {
             this.td_add = new Thread(() =>
              {
                  while (true)
                  {
                      this.EnqueueNewToast(this.Dequeue());
                  }
              });
            this.td_add.IsBackground = true;
            this.td_add.Start();
        }
        /// <summary>
        /// 加入新窗口之前触发
        /// </summary>
        private event NewToastAddEventHandler NewToastAdd;


        private void EnqueueNewToast(MiniToast mt)
        {
            ToastAddEventAgs e = new ToastAddEventAgs();
            if (this.NewToastAdd != null)
            {
                this.NewToastAdd(this, e);
                Task.WaitAll(e.tasks.ToArray());
            }
            this.NewToastAdd += new NewToastAddEventHandler(mt.ShiftTop);
            var t= new Thread(() => 
            {
                System.Windows.Forms.Application.Run(mt);
            });
            t.SetApartmentState(ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }
    }
}
