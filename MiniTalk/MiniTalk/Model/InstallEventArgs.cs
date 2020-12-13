using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTalk.Model
{
    public class InstallEventArgs
    {
        public Options.传输设置 传输设置 { get; set; } 
        public Options.常规设置 常规设置 { get; set; } 
        public Options.提醒设置 提醒设置 { get; set; } 
        public Options.用户管理 用户管理 { get; set; } 

        public InstallEventArgs(){}
    }
}
