using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCRM
{
    public class AgileContactProperty
    {
        public AgileContactProperty()
        {
            this.type = "SYSTEM";
        }

        public string type;
        public string subtype { get; set; }

        public string name { get; set; }

        public string value { get; set; }
    }
}
