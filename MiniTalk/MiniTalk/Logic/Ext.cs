using Override_Control;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using MiniTalk.Model;
using MiniTalk.Net;

namespace MiniTalk
{
    public static class Form1Ext
    {
        /// <summary>
        /// 设置指定用户为活动会话
        /// </summary>
        /// <param name="user">指定用户数据</param>
        public static void SetKinetic(this Form1 f1, UserData user)
        {
            if (!KeyData.Activity.UserStruchOnline.Contains(user)) return;
            if (!f1.panel_left.Controls.Contains(user.TalkPanel))
            {
               f1.panel_left.Controls.Add(user.TalkPanel);
            }
            f1.Shrink = false;
            f1.ListBox_Online.SelectedItem = user;
            user.TalkPanel.Visible = true;
            user.TalkPanel.BringToFront();
            user.NewMesCount = 0;
            //设置活动用户
            f1.NowUserData = user;
        }

        /// <summary>
        /// 将消息添加到会话窗口中
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="name">用户昵称</param>
        /// <param name="ControName">控件名</param>
        /// <param name="headImg">用户头像</param>
        /// <param name="type">消息类型</param>
        public static void AppendMessage(this Form1 f1, TextMesKey key)
        {
            if (key.isPublic)
            {
                KeyData.StaticInfo.ClassPanel.AppendText(key.Mes, key.User, key.Type);
            }
            else
            {
                key.User.TalkPanel.AppendText(key.Mes, key.User, key.Type);
            }
        }

        /// <summary>
        /// 将文件消息添加到窗口
        /// </summary>
        public static void AppendFileMes(this Form1 f1, string path, UserData data)
        {
            try
            {
                data.TalkPanel.AppendFileMes(path, data);
            }
            catch (Exception)
            {
                Method.ShowPrompt("当前用户已下线", 1000);
            }
        }

        /// <summary>
        /// 将文件消息添加到窗口
        /// </summary>
        public static void AppendFileMes(this Form1 f1, Transmission.NetFileData fdata)
        {
            if (fdata.isPublic)
            {
                KeyData.StaticInfo.ClassPanel.AppendFileMes(fdata, Method.GetUser(fdata.senderIP), true);
            }
            else
            {
                UserData data = Method.GetUser(fdata.senderIP);
                data.TalkPanel.AppendFileMes(fdata, data, false);
            }
        }

        /// <summary>
        /// 添加一条事件消息
        /// </summary>
        public static void AppendEventMessage(this Form1 f1, EventMesKey key)
        {
            try
            {
                if (key.isPublic)
                {
                    KeyData.Activity.UserStruchOnline[0].TalkPanel.AppendEventMessage(key.Mes);
                }
                else
                {
                    key.User.TalkPanel.AppendEventMessage(key.Mes);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("添加事件消息失败，错误信息:" + ex.Message);
            }
        }

        /// <summary>
        /// 添加一条图片消息
        /// </summary>
        public static void AppendPicMessage(this Form1 f1, ImgMesKey key)
        {
            if (key.isPublic)
            {
                KeyData.StaticInfo.ClassPanel.AppendPicMessage(key.Img, key.User, key.Type);
            }
            else
            {
                key.User.TalkPanel.AppendPicMessage(key.Img, key.User, key.Type);
            }
        }

        /// <summary>
        /// 将上线的用户添加到ListBoxItems中
        /// </summary>
        /// <param name="name">要进行添加的用户名</param>
        /// <param name="Ip">要回送的ip地址</param>
        public static void ListBoxItemsAdd(this Form1 f1, UserData data)
        {
            f1.bs_ListBoxOnline.Add(data);
            f1.UpdateScollBarMaxValue();
        }

        /// <summary>
        /// 重命名指定索引的用户名称
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newname"></param>
        public static void Rename(this Form1 f1, int index, UserData newUserData)
        {
            f1.bs_ListBoxOnline[index] = newUserData;
        }

        /// <summary>
        /// 将指定键值的用户删除
        /// </summary>
        /// <param name="Keyi">要删除的用户的键值,也就是IP地址</param>
        public static void RemoveUser(this Form1 f1, string ip)
        {
            UserData user = Method.GetUser(ip);
            //判断控件字典中是否已有与该用户的会话窗口
            if (user == null) return;
            try
            {
                if (f1.NowUserData.IP.Equals(ip))
                {
                    Method.ShowPrompt("当前用户已下线", 2000);
                    return;
                }
                //将其从ListBox中删除
                f1.bs_ListBoxOnline.Remove(user);
                if (f1.panel_left.Controls.Contains(user.TalkPanel))
                f1.panel_left.Controls.Remove(user.TalkPanel);
            }
            catch (Exception)
            {
                Debug.WriteLine("Method-RemoveUser:从列表中删除用户时出现异常！");
            }
            f1.UpdateScollBarMaxValue();
        }

        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="f1"></param>
        /// <param name="path"></param>
        public static void SendFileInfo(this Form1 f1, string path)
        {
            if (f1.NowUserData.IsPub)
            {
                if (new FileInfo(path).Length > 1024 * 1024 * 10)
                {
                    Method.ShowPrompt("不支持在公共会话频道内传输大于10MB的文件", 1000);
                    return;
                }
                f1.AppendFileMes(path, KeyData.Activity.UserStruchOnline[0]);
                Transmitters.Sender.SendFileData(path);
            }
            else
            {
                f1.AppendFileMes(path, f1.NowUserData);
                Transmitters.Sender.SendFileMessage(f1.NowUserData.IP, path);
            }
        }

        /// <summary>
        /// 发送图片
        /// </summary>
        public static void SendPicInfo(this Form1 f1, Image img)
        {
            long len = Method.ImageToBytes(img).Length;
            if (img.Size.Width > 5000 || img.Size.Height > 5000 || len >= 1024 * 1024 * 3)
            {
                Method.ShowPrompt("图片尺寸过大或文件大小过大，不支持发送", 1000);
                return;
            }
            ImgMesKey mes = new ImgMesKey()
            {
                User = f1.NowUserData,
                Img = img,
                Type = MsType.本地消息,
                isPublic = false
            };
            var f = new Image_Send(f1.NowUserData, img);
            f.AddImage += e => f1.AppendPicMessage(e);
            f.AddText += e => f1.AppendMessage(e);
            f.ShowDialog();
            f.Dispose();
        }

        /// <summary>
        /// 添加一条滚动消息
        /// </summary>
        public static void RollMesInput(this Form1 f1, string text)
        {
            if (text.Trim().Length == 0)
            {
                return;
            }
            f1.ts.Enqueue(text);
        }

        /// <summary>
        /// 将指定索引用户置顶
        /// </summary>
        public static void SendTop(this Form1 f1, int index)
        {
            object obj = f1.bs_ListBoxOnline[index];
            f1.bs_ListBoxOnline.RemoveAt(index);
            f1.bs_ListBoxOnline.Insert(1, obj);
            UserData data = obj as UserData;
            data.IsTop = true;
            f1.SetKinetic(data);
        }

        /// <summary>
        /// 将指定索引用户取消置顶
        /// </summary>
        public static void SendLast(this Form1 f1, int index)
        {
            object obj = f1.bs_ListBoxOnline[index];
            f1.bs_ListBoxOnline.RemoveAt(index);
            f1.bs_ListBoxOnline.Add(obj);
            UserData data = obj as UserData;
            data.IsTop = false;
            f1.SetKinetic(data);
        }

        /// <summary>
        /// 将指定索引用户发送到次于指定者位置
        /// </summary>
        public static void SendToNew(this Form1 f1, UserData user)
        {
            if (user.IsTop) return;
            dynamic dy;
            int i = 1;
            do
            {
                dy = f1.bs_ListBoxOnline[i++];
            } while (dy.IsTop);
            --i;
            f1.bs_ListBoxOnline.Remove(user);
            f1.bs_ListBoxOnline.Insert(i, user);
        }
    }
}
