using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Metadata
    {
        public string model { get; set; }

        public Metadata() { }

        public Metadata(string model) { this.model = model; } 

    }
}
