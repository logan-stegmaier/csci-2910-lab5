using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Skin
    {
        public string url { get; set; }

        public Metadata metadata { get; set; }

        public Skin() { }

        public Skin(string url, Metadata metadata)
        {
            this.url = url;
            this.metadata = metadata;
        }
    }
}
