using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSQLServer
{
    public class Entity
    {
        public int index { get; set; }
        public string preHash { get; set; }
        public string hash { get; set; }
        public string data { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
