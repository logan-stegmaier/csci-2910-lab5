using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public class ProfileData
    {
        public long timestamp { get; set; }
        public string profileid { get; set; }
        public string profilename { get; set; }
        public Textures textures { get; set; }


        public ProfileData() { }
        public ProfileData(long timestamp, string profileID, string profilename, Textures textures)
        {
            this.timestamp = timestamp;
            this.profileid = profileID;
            this.profilename = profilename;
            this.textures = textures;
        }

        public override string ToString()
        {
            string profileData = "";
            profileData += $"[ACTIVE] Skin: {textures.skin?.url} \n";
            profileData += $"[ACTIVE] Cape: {textures.cape?.url} \n";

            return profileData;
        }
    }
}
