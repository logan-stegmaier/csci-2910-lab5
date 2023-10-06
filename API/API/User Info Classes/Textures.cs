using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class Textures
    {
        public Skin skin { get; set; }

        public Cape cape { get; set; }

        public Textures() { }

        public Textures(Skin skin, Cape cape)
        {
            this.skin = skin;
            this.cape = cape;
        }

    }
}
