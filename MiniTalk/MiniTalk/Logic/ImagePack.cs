using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniTalk.Net;

namespace MiniTalk.Class
{
    /// <summary>
    /// 图片接收数据包暂存类
    /// </summary>
    public class ImagePack
    {
        private int receCount = 0;
        private int sumLen = 0;
        private byte[][] buffs;
        System.Timers.Timer timeOut = new System.Timers.Timer() { Interval = 3000, AutoReset = true };//超时
        System.Timers.Timer misPackInspect = new System.Timers.Timer() { Interval = 300};
        public event Action<ImagePack, byte[]> DownOver; //任务完成时触发
        public event Action<ImagePack> TimeOut;          //接收超时触发

        /// <summary>
        /// 发送者IP
        /// </summary>
        public string senderIP { get; private set; }

        /// <summary>
        /// 是否为群消息
        /// </summary>
        public bool isPublic { get; private set; } 

        /// <summary>
        /// 单任务标识
        /// </summary>
        public string Key { get; private set; } 

        public ImagePack(string key, int packlen, string senderIP, bool isPublic)
        {
            this.Key = key;
            this.isPublic = false;
            this.buffs = new byte[packlen][];
            this.senderIP = senderIP;
            this.isPublic = isPublic;
            this.timeOut.Elapsed += TimeOut_Elapsed;
            this.misPackInspect.Elapsed += MisPackInspect_Elapsed;
            this.timeOut.Start();
        }

        private void MisPackInspect_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            for (int i = 0; i <buffs.Length; i++)
            {
                Debug.WriteLine(string.Format("包{0}检测到{1}号包漏包,申请重发", this.Key, i + 1));
                if (!(buffs[i] == null || buffs[i].Length == 0)) continue;
                Transmitters.Sender.SendRetRan(this.senderIP, this.Key, i+1);
            }
        }

        private void TimeOut_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Debug.WriteLine(string.Format("包{0},接收超时", this.Key));
            Recovery();
            if(this.TimeOut!=null) this.TimeOut.Invoke(this);
        }

        /// <summary>
        /// 填入数据包
        /// </summary>
        /// <param name="id"></param>
        /// <param name="buff"></param>
        public void AddPack(int id, byte[] buff)
        {
            try
            {
                if (Method.CRC8.DataIsError(buff))//校验不通过直接申请重新发送该包
                {
                    Debug.WriteLine(string.Format("包{0},ID：{1}数据错误申请重发", this.Key, id));
                    Transmitters.Sender.SendRetRan(senderIP, this.Key, id);
                    return;
                }
                byte[] tmp = new byte[buff.Length - 1];
                Array.Copy(buff, 0, tmp, 0, tmp.Length);
                buff = tmp;

                buffs[id - 1] = buff;
                this.receCount++;
                this.sumLen += buff.Length;
                this.timeOut.Stop();
                this.misPackInspect.Stop();
                this.misPackInspect.Start();//若在指定时间内没有接收到新的包则进行漏包检测
                if (receCount == buffs.Length)
                {
                    if (this.DownOver!= null) this.DownOver.Invoke(this, this.SplicingArray());
                    Recovery();
                    return;
                }
                this.timeOut.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("数据包接收异常,错误信息:{0}", ex.Message));
            } 
        }


        /// <summary>
        /// 拼接数据包
        /// </summary>
        /// <returns></returns>
        private byte[] SplicingArray()
        {
            byte[] overBuff = new byte[this.sumLen];
            int tag = 0;
            foreach (byte[] buf in this.buffs)
            {
                Array.Copy(buf, 0, overBuff, tag, buf.Length);
                tag += buf.Length;
            }
            return overBuff;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        private void Recovery()
        {
            this.timeOut.Stop();
            this.misPackInspect.Stop();
            this.timeOut.Dispose();
            this.misPackInspect.Dispose();
            this.buffs = null;
        }
    }
}
