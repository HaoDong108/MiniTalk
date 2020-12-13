using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using PromptDll;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.Net.Sockets;
using System.IO.Ports;
using MiniTalk.Net;
using MiniTalk.Model;

namespace MiniTalk.Custom_Control
{
    public partial class FileMes : UserControl
    {
        string _fileName = string.Empty; //文件名
        string _senderFilePath = string.Empty;//发送者文件路径
        IPAddress _senderIP = null;
        string _saveTheFullPath = string.Empty;//最终保存到的完整路径
        string _saveToDir = string.Empty;//文件保存路径
        long _fileSize = 0;
        bool _overDown = false;
        bool _isDownloading = false;
        Thread td_red;
        ReadFile rd;


        public event Action<string,string> FileDownLoadOver;

        /// <summary>
        /// 设置文件名
        /// </summary>
        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {
                this._fileName = value;
                this.lb_fileName.Text = value;

                Bitmap bt = DSAPI.图形图像.获取扩展名关联图标(Path.GetExtension(value));
                this.pic_FileImg.BackgroundImage = bt;
            }
        }
        
        /// <summary>
        /// 文件大小
        /// </summary>
        public long FileSize
        {
            get
            {
                return _fileSize;
            }
            set
            {
                this._fileSize = value;
                this.lb_fileSzie.Text = "(" + ConverFileLen(value) + ")";
            }
        }

        /// <summary>
        /// 标识是否下载完毕
        /// </summary>
        public bool OverDown
        {
            get
            {
                return _overDown;
            }
            set
            {
                this._overDown = value;
                this.panel_NotDown.Visible = !value;
                this.panel_OverDown.Visible = value;
                if (value)
                {
                    this.lb_speed.Text = "(已完成)";
                    this.pro_Down.当前值 = 100;
                    this.pro_Down.前景颜色 = Color.SpringGreen;
                    this.lb_stae.Text = "下载完成";
                    this._saveTheFullPath = Path.Combine(this._saveToDir, this.FileName);
                }
                else
                {
                    this.pro_Down.前景颜色 = Color.DarkTurquoise;
                    this.lkb_Down.Text = "下 载";
                    this.lkb_Down.Visible = true;
                    this.lkb_SaveAs.Text = "另存为";
                    this.lkb_SaveAs.Visible = true;
                    this.lb_speed.Text = "(未下载)";
                    this.pro_Down.当前值 = 0;
                    this.lb_stae.Text = "等待下载";
                }
            }
        }

        /// <summary>
        /// 当前消息的唯一标识
        /// </summary>
        readonly string Identifier;

        public FileMes(string senderIP)
        {
            Identifier = this.GetHashCode().ToString();
            KeyData.receiver.ReceiveFileTransferStatusInformationEvent += Receiver_收到文件发送返回信息事件;
            this._senderIP = IPAddress.Parse(senderIP);
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Bitmap back = DSAPI.图形图像.绘制圆角矩形(this.Size, 10, Color.Transparent, Color.DarkTurquoise);
            this.BackgroundImage = back;
        }

        ~FileMes()
        {
            KeyData.receiver.ReceiveFileTransferStatusInformationEvent -= Receiver_收到文件发送返回信息事件;
        }

        /// <summary>
        /// 设置数据,用于本地显示
        /// </summary>
        public void SetInfo(string path)
        {
            FileInfo info = new FileInfo(path);
            this.FileSize = info.Length;
            this.Init(path, true);
        }

        public void SetInfo(Transmission. NetFileData info)
        {
            this.FileSize = long.Parse(info.fileLen);
            this.Init(info.senderFilePath, false);
        }

        private void Init(string path, bool overdown)
        {
            this._senderFilePath = path;
            this.FileName = Path.GetFileName(path);
            this.toolTip1.SetToolTip(this.lb_fileName, this.lb_fileName.Text);
            this.OverDown = overdown;
            this._saveTheFullPath = _senderFilePath;
        }

        #region 私有事件
        private void skinPanel1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.DarkTurquoise, 2f);
            e.Graphics.DrawLine(pen, 0, 1, this.Width, 1);
        }
        private void lkb_Down_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StartDownLoad(false);
        }
        private void lkb_SaveAs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (this._isDownloading)
            {
                this.rd.StopReceive();
            }
            else
            {
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this._saveToDir = this.folderBrowserDialog1.SelectedPath;
                    this.StartDownLoad(true);
                }
            }
        }
        private void lkb_OpenFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(this._saveTheFullPath);
            }
            catch (Exception ex)
            {
                Method.ShowPrompt(ex.Message, 1200);
            }
        }
        private void lkb_OpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(this._saveTheFullPath));
            }
            catch (Exception ex)
            {
                Method.ShowPrompt(ex.Message, 1200);
            }
        }
        private void Rd_OnReceiveFileFail(string obj)
        {
            this.Invoke(new Action(() => { this.OverDown = false; }));
        }
        private void Rd_OnReceiveFileOver(string obj)
        {
            this.Invoke(new Action(() => { this.OverDown = true; }));
            this.FileName = obj;
            if(this.FileDownLoadOver!=null) this.FileDownLoadOver.Invoke(this._senderIP.ToString(), this.FileName);
        }
        private void Rd_OnReadSpeedChange(string obj)
        {
            this.lb_speed.Text = obj;
        }
        private void Rd_OnProgresValueChange(int value)
        {
            this.pro_Down.当前值 = value;
        }
        private void Receiver_收到文件发送返回信息事件(Transmission.NetFileRequestRet obj)
        {
            if (this.Identifier != obj.identification) return;
            if (!obj.isSucc)
            {
                this.OverDown = false;
                connFlg = false;
                this.td_red.Abort();
                MessageBox.Show("下载请求处理失败\n\n错误信息:"+obj.staeMessage,"下载失败",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 私有方法

        /// <summary>
        /// 转换文件大小单位
        /// </summary>
        private string ConverFileLen(long b)
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;
            if (b / GB >= 1)
            {
                return Math.Round(b / (float)GB, 2) + "GB";
            }
            if (b / MB >= 1)
            {
                return Math.Round(b / (float)MB, 2) + "MB";
            }
            if (b / KB >= 1)
            {
                return Math.Round(b / (float)KB, 2) + "KB";
            }
            return b + "B";
        }

        bool connFlg = true;
        /// <summary>
        /// 开始文件下载
        /// </summary>
        private void StartDownLoad(bool lcw)
        {
            if(!lcw)this._saveToDir = Options._传输设置.保存路径;
            if (!Directory.Exists(this._saveToDir))
            {
                try
                {
                    Directory.CreateDirectory(this._saveToDir);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(string.Format("保存路径{0}\n没有足够权限访问及创建,请在（设置——传输设置）中更路径后重新尝试", this._saveToDir), "没有足够权限", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(string.Format("异常信息：{0}\n请尝试重新设置保存目录", ex.Message), "创建目录时出错",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            int prot = Method.Net.GetRanPort();//获取随机可用端口收文件
            
            TcpListener listener = new TcpListener(IPAddress.Parse(KeyData.StaticInfo.MyUser.IP), prot);

            //发送连接请求等待连接
            Transmitters.Sender.SendFileRequest(this._senderIP.ToString(), this._senderFilePath, this.Identifier, prot);
            this.lb_stae.Text = "正在排队";

            listener.Start();
            Socket sok = null;

            Action<Task> ac = new Action<Task>((stae) =>
              {
                  if (!connFlg) return;
                  this.lb_stae.Text = "正在下载";
                  this._isDownloading = true;
                  this.lkb_SaveAs.Text = "取 消";
                  this.lkb_Down.Visible = false;
                  this.rd = new ReadFile(sok, this.FileSize, this.FileName, this._saveToDir);
                  rd.OnProgresValueChange += Rd_OnProgresValueChange;
                  rd.OnReadSpeedChange += Rd_OnReadSpeedChange;
                  rd.OnReceiveFileOver += Rd_OnReceiveFileOver;
                  rd.OnReceiveFileFail += Rd_OnReceiveFileFail;
                  
                  this.td_red = new Thread(() => { rd.StartDownLoad(); });
                  this.td_red.Start();
              });

            Task t = Task.Run(() =>
             {
                 if (!Listen(listener, out sok))
                 {
                     if (!connFlg) return;
                     connFlg = false;
                     this.OverDown = false;
                     Method.ShowPrompt("当前该资源访问人数较多，请稍后再试", 1000);
                 }
             });
            t.ContinueWith(ac);
        }

        /// <summary>
        /// 开始侦听连接请求
        /// </summary>
        /// <param name="listener"></param>
        /// <param name="conSok"></param>
        /// <returns></returns>
        private bool Listen(TcpListener listener, out Socket conSok)
        {
            new Thread(() =>
            {
                Thread.Sleep(10000);
                try
                {
                    listener.Stop();
                }
                catch (Exception) { }
            }).Start();
            try
            {
                conSok = listener.AcceptSocket();
                return (conSok != null);
            }
            catch (Exception)
            {
                conSok = null;
                return false;
            }
        }
        #endregion
    }
}
