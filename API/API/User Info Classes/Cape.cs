using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Cape
    {
        public string url { get; set; }

        public Cape() { }

        public Cape(string url)
        {
            this.url = url;
        }   
    }
}
