using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class MinecraftData
    {
        public string id { get; set; } = string.Empty;
        public string name { get; set; } = string.Empty;

        public Property[] properties { get; set; }

        public string value { get; set; } = string.Empty;

        public MinecraftData() { }

        public MinecraftData(string id, string name, string value)
        {
            this.name = name;
            this.id = id;
            this.value = value;
            
        }

        public override string ToString()
        {
            string minecraftString = "";

            minecraftString += $"UUID: {id}\n";
            minecraftString += $"Username: {name}";

            return minecraftString;
        }

    }
}
