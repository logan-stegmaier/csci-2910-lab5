using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Property
    {
        public string name { get; set; }

        public string value { get; set; }

        public Property() { }

        public Property(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}
