using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using MiniTalk.Model;

namespace MiniTalk
{
    /// <summary>
    /// 设置
    /// </summary>
    public static class Options
    {
        static Options()
        {
            _常规设置 = JsonConvert.DeserializeObject<常规设置>(Settings1.Default.常规设置);
            
             _传输设置 = JsonConvert.DeserializeObject<传输设置>(Settings1.Default.传输设置);

            _提醒设置 = JsonConvert.DeserializeObject<提醒设置>(Settings1.Default.提醒设置);
        }

        public static 常规设置 _常规设置 { get; private set; } 

        public static 传输设置 _传输设置 { get; private set; } 

        public static 提醒设置 _提醒设置 { get; private set; } 

        public class 常规设置
        {
            public int 历史消息保存数 { get; set; }
            public int 消息发送时间提示间隔 { get; set; }
            public bool 快捷截图 { get; set; }
        }

        public class 传输设置
        {
            public string 保存路径 { get; set; } 
            public bool 下载完毕后自动打开文件 { get; set; }
            public bool 屏蔽所有文件消息 { get; set; } 
            public int 文件接收大小最大上限 { get; set; } 
            public List<string> 屏蔽的后缀名 { get; set; }
        }

        public class 提醒设置
        {
            public bool 提醒类别_文本消息 { get; set; }
            public bool 提醒类别_文件消息 { get; set; }
            public bool 提醒类别_图片消息 { get; set; } 
            public bool 提醒类别_事件消息 { get; set; }
            public bool 群消息提醒 { get; set; } 
            public bool 群消息红点标注 { get; set; }
            public bool 置顶者强提醒 { get; set; } 
            public bool 右下角浮动提醒 { get; set; }
            public bool 强提醒模式_对话框 { get; set; } 
            public bool 强提醒模式_托盘消息 { get; set; } 
            public bool 悬浮提醒_公共会话悬浮提醒 { get; set; } 
            public bool 悬浮提醒_用户消息悬浮提醒 { get; set; } 
        }

        public class 用户管理
        {
            public List<IPRemarks> 备注表 { get; set; }
            public List<string> 黑名单 { get; set; }

            public static class 备注设置
            {
                private static List<IPRemarks> list = (JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理)).备注表;

                private static void Update()
                {
                    用户管理 ment = JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理);
                    ment.备注表 = list;
                    string json = JsonConvert.SerializeObject(ment);
                    Settings1.Default.用户管理 = json;
                    Settings1.Default.Save();
                }

                public static void UpdateList()
                {
                    list = (JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理)).备注表;
                }

                public static void Add(IPRemarks rk)
                {
                    if (list == null) list = new List<IPRemarks>();
                    foreach (var item in list)
                    {
                        if (item.IP.Equals(rk.IP)) return;
                    }
                    list.Add(rk);
                    Update();
                }

                public static void Remote(string ip)
                {
                    if (list == null) return;
                    try
                    {
                        foreach (var item in list)
                        {
                            if (item.IP == ip) list.Remove(item);
                        }
                        Update();
                    }
                    catch (Exception)
                    { }
                }

                public static bool GetName(string ip, out string Name)
                {
                    Name = null;
                    if (list == null) return false;
                    foreach (var item in list)
                    {
                        if (item.IP == ip)
                        {
                            Name = item.Name;
                            return true;
                        }
                    }
                    return false;
                }
            }

            public static class 黑名单管理
            {
                private static List<string> list = (JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理)).黑名单;

                private static void Update()
                {
                    用户管理 ment = JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理);
                    ment.黑名单 = list;
                    string json = JsonConvert.SerializeObject(ment);
                    Settings1.Default.用户管理 = json;
                    Settings1.Default.Save();
                }

                public static void UpdateList()
                {
                    list = (JsonConvert.DeserializeObject<用户管理>(Settings1.Default.用户管理)).黑名单;
                }

                public static void Add(string ip)
                {
                    if (list == null) list = new List<string>();
                    if (list.Contains(ip)) return;
                    list.Add(ip);
                    Update();
                }

                public static void Remote(string ip)
                {
                    if (list == null) return;
                    {

                    }
                    try
                    {
                        list.Remove(ip);
                        Update();
                    }
                    catch (Exception)
                    { }
                }

                public static bool Contains(string ip)
                {
                    if (list == null) return false;
                    return list.Contains(ip);
                }
            }

            public 用户管理()
            {
                备注表 = new List<IPRemarks>();
                黑名单 = new List<string>();
            }
        }

        public static void Update()
        {
            _常规设置 = JsonConvert.DeserializeObject<常规设置>(Settings1.Default.常规设置);
            _传输设置 = JsonConvert.DeserializeObject<传输设置>(Settings1.Default.传输设置);
            _提醒设置 = JsonConvert.DeserializeObject<提醒设置>(Settings1.Default.提醒设置);
            用户管理.备注设置.UpdateList();
            用户管理.黑名单管理.UpdateList();
        }
    }
}
