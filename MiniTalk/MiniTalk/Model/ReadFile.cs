using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MiniTalk.Model
{
    class ReadFile : IDisposable
    {
        long FileSize;        //文件大小
        string FileName;      //文件名
        string saveFullPath;  //将要保存的完整路径
        string saveDirectory; //将要保存的目录
        string kuo = ".tmp";  //文件未接收完整时的扩展名
        int _proBarValue = 0;
        Socket rd_sok;

        long writeSumLen = 0;      //已经写入磁盘的字节总数
        long readSumLen = 0;       //已经接收的字节总数
        int SendOrReadLen = 1024 * 1024; //文件每次最多接收的大小
        List<byte[]> Buffs = new List<byte[]>();//文件块缓冲区

        System.Timers.Timer Timer_Spead = new System.Timers.Timer() { Interval = 1000 };//计算速度的计时器
        System.Timers.Timer Timer_Out = new System.Timers.Timer() { Interval = 3000 };

        CancellationTokenSource cts = new CancellationTokenSource();//全局主要线程开关

        /// <summary>
        /// 当前进度值
        /// </summary>
        public int ProBarValue
        {
            get
            {
                return _proBarValue;
            }
            private set
            {
                if (value != this._proBarValue)
                {
                    if(OnProgresValueChange!=null) OnProgresValueChange.Invoke(value);
                }
                this._proBarValue = value;
            }
        }

        /// <summary>
        /// 下载速度改变时发生
        /// </summary>
        public event Action<string> OnReadSpeedChange;
        /// <summary>
        /// 下载进度改变时发生
        /// </summary>
        public event Action<int> OnProgresValueChange;
        /// <summary>
        /// 接收成功时发生
        /// </summary>
        public event Action<string> OnReceiveFileOver;
        /// <summary>
        /// 接收失败时发生
        /// </summary>
        public event Action<string> OnReceiveFileFail;

        /// <summary>
        /// 文件接收构造器
        /// </summary>
        /// <param name="socket">用于接收文件的非空套接字</param>
        /// <param name="size">文件大小</param>
        /// <param name="fileName">文件名</param>
        /// <param name="saveDirectory">文件保存目录</param>
        public ReadFile(Socket socket, long size, string fileName, string saveDirectory)
        {
            this.rd_sok = socket;
            this.FileSize = size;//设置文件大小
            this.saveDirectory = saveDirectory;
            this.FileName = DuplicateHandle(fileName);
            this.saveFullPath = saveDirectory + "\\" + this.RanExName(fileName, this.kuo);//设置文件写入流最终写入的文件完整路径
            this.Timer_Spead.Elapsed += Timer_Spead_Tick;
            this.Timer_Out.Elapsed += Timer_Out_Elapsed;
        }

        /// <summary>
        /// 停止任务
        /// </summary>
        public void StopReceive()
        {
            this.cts.Cancel();
        }

        /// <summary>
        /// 开始文件下载
        /// </summary>
        public void StartDownLoad()
        {
            this.Timer_Spead.Start();
            this.Timer_Out.Start();

            //启动异步文件写入功能
            Task t = Task.Run(new Action(BeginWrite), this.cts.Token);
            Task r = Task.Run(new Action(Read), this.cts.Token);
            r.Wait();
            t.Wait();

            if (t.IsCanceled || cts.IsCancellationRequested)
            {
                Method.ShowPrompt("传输被迫终止,文件接收失败", 2000);
                this.DeleteNowFile();
                if (OnReceiveFileFail!= null) OnReceiveFileFail.Invoke(this.FileName);
            }
            else
            {
                this.DefauleExName();
                if (OnReceiveFileOver!= null) OnReceiveFileOver.Invoke(this.FileName);
                string saveThePath = this.saveDirectory + "\\" + this.FileName;
                Method.ShowPrompt("文件保存到" +saveThePath , 2000, 40);
                try
                {
                    if(Options._传输设置.下载完毕后自动打开文件)
                    Process.Start(saveThePath);
                }
                catch (Exception ex)
                {
                    Method.ShowPrompt(ex.Message, 1200);
                }
            }
            Dispose();
            Debug.WriteLine("文件下载任务线程已经退出");
        }

        /// <summary>
        /// 异步写入线程方法
        /// </summary>
        private void BeginWrite()
        {
            using (FileStream saveStream = new FileStream(this.saveFullPath, FileMode.Append, FileAccess.Write))
            {
                while (!this.cts.IsCancellationRequested && this.writeSumLen < this.FileSize)
                {
                    cts.Token.ThrowIfCancellationRequested();
                    if (this.Buffs.Count > 0)
                    {
                        saveStream.Write(this.Buffs[0], 0, this.Buffs[0].Length);
                        saveStream.Flush();
                        this.writeSumLen += this.Buffs[0].Length;
                        this.Buffs.RemoveAt(0);
                    }
                    Thread.Sleep(10);
                }
            }
            Debug.WriteLine("文件写入线程已经退出");
        }

        /// <summary>
        /// 读取文件
        /// </summary>
        private void Read()
        {
            int templen = (1024 * 1024) * 10;//文件写入分页大小

            byte[] buff = null;
            try
            {
                while (this.readSumLen != this.FileSize && !cts.IsCancellationRequested)
                {
                    if (this.FileSize - readSumLen >= templen)
                    {
                        buff = this.ReceiveByte(templen);
                    }
                    else
                    {
                        buff = this.ReceiveByte((int)(this.FileSize - this.readSumLen));
                    }
                    this.Buffs.Add(buff);
                }
            }
            catch (Exception ex)
            {
                if (!cts.IsCancellationRequested)
                {
                    cts.Cancel();
                }
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("读取线程异常终止");
            }
            Debug.WriteLine("文件接收线程已经退出");
        }

        /// <summary>
        /// 接收指定大小的数据
        /// </summary>
        /// <param name="size">指定大小的数据</param>
        /// <returns></returns>
        private byte[] ReceiveByte(int size)
        {
            int dc = 0;//当次接收
            int jb = 0;//局部接收

            byte[] buff = new byte[size];

            try
            {
                while (dc != size && !cts.IsCancellationRequested)  //如果接收到的总字节数等于文件大小则跳出
                {
                    if (size - dc > this.SendOrReadLen)
                    {
                        jb = this.rd_sok.Receive(buff, dc, this.SendOrReadLen, SocketFlags.None);
                    }
                    else
                    {
                        jb = this.rd_sok.Receive(buff, dc, (size - dc), SocketFlags.None);
                    }
                    dc += jb;
                    this.readSumLen += jb;
                    int p = (int)(((double)this.readSumLen / (double)this.FileSize) * 100);
                    if (OnProgresValueChange!= null) OnProgresValueChange.Invoke(p);
                }
            }
            catch (Exception)
            { }
            return buff;
        }

        /// <summary>
        /// 如果没有将文件接收完毕而关闭流则应当调用此方法清理破碎文件
        /// </summary>
        private void DeleteNowFile()
        {
            try
            {
                File.Delete(this.saveFullPath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("清理未完成文件失败,原因:\n" + ex.Message);
            }
        }

        /// <summary>
        /// 更改文件的扩展名
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="kuo">新的文件扩展名</param>
        /// <returns>新的文件名</returns>
        private string RanExName(string fileName, string kuo)
        {
            string t1 = fileName.Remove(fileName.LastIndexOf('.'));
            return t1 + kuo;
        }

        /// <summary>
        /// 文件写入完毕后更改回正常可使用的文件名
        /// </summary>
        private void DefauleExName()
        {
            string oldpath = this.saveFullPath;
            string newpath = this.saveDirectory + "\\" + this.FileName;
            File.Move(oldpath, newpath);
        }

        long last_SumLen = 1;
        private void Timer_Out_Elapsed(object sender, ElapsedEventArgs e)
        {
            //在指定时间后若接收的字节数和上次的接收字节数相同，且小于总字节数，则启用超时处理
            if (this.readSumLen == last_SumLen && this.readSumLen < this.FileSize)
            {
                this.cts.Cancel();
                this.rd_sok.Close();
                this.Timer_Out.Stop();
            }
            last_SumLen = readSumLen;
        }

        long last_Time_Len = 0; //保存上次的接收总大小便于计算差值
        private void Timer_Spead_Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                double inc = this.readSumLen - last_Time_Len;
                if (inc >= Method.MB)
                {
                    if (OnReadSpeedChange!= null) OnReadSpeedChange.Invoke(Math.Round((inc / Method.MB), 2).ToString() + "Mb/s");
                }
                else if (inc < Method.MB && inc >= Method.KB)
                {
                    if (OnReadSpeedChange!= null) OnReadSpeedChange.Invoke(Math.Round((inc / Method.KB), 2).ToString() + "Kb/s");
                }
                else
                {
                    if (OnReadSpeedChange!= null) OnReadSpeedChange.Invoke(inc.ToString() + "B/s");
                }
                last_Time_Len = this.readSumLen;
            }
            catch (Exception)
            { }
        }

        /// <summary>
        /// 获取不重复的文件名
        /// </summary>
        /// <param name="filePath">原文件名</param>
        /// <returns></returns>
        private string DuplicateHandle(string fileName)
        {
            string filePath1 = Path.Combine(this.saveDirectory, fileName);
            string filePath2 = Path.Combine(this.saveDirectory, RanExName(fileName, this.kuo));

            if (!File.Exists(filePath1) && !File.Exists(filePath2)) return fileName;

            for (int i = 1; File.Exists(filePath1) || File.Exists(filePath2); i++)
            {
                filePath1 = filePath1.Insert(filePath1.LastIndexOf('.'), "(" + i + ")");
                filePath2 = filePath2.Insert(filePath2.LastIndexOf('.'), "(" + i + ")");
            }
            return Path.GetFileName(filePath1);
        }

        public void Dispose()
        {
            this.Timer_Out.Stop();
            this.Timer_Spead.Dispose();
            this.Timer_Spead.Stop();
            this.Timer_Spead.Dispose();
            this.Buffs.Clear();
            GC.SuppressFinalize(this);
            try { rd_sok.Close(); } catch { };
        }
    }
}
