using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTalk.Model
{
    /// <summary>
    /// 备注键值对
    /// </summary>
    public class IPRemarks
    {
        public string IP { get; set; } 
        public string Name { get; set; }

        public IPRemarks(){}

        public IPRemarks(string ip,string name)
        {
            this.IP = ip;
            this.Name = name;
        }

        public override string ToString()
        {
            return string.Format("IP:{0}|{1}", IP, Name);
        }
    }
}
