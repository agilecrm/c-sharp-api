using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileCRM
{
    public class AgileContact
    {
        public AgileContact()
        {
            this.properties = new List<AgileContactProperty>();
            this.type = "PERSON";
        }

        public string id { get; set; }
        public string type { get; set; }
        //public DateTime created_time { get; set; }
        //public DateTime updated_time { get; set; }
        //public int star_value { get; set; }
        //public int lead_score { get; set; }
        //public List<string> tags;
        public List<AgileContactProperty> properties;
    }
}
