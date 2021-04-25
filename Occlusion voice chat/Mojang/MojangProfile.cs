using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_UHC_Stats_Editor.mojang.json
{
    public class MojangProfile
    {
        public string id { get; set; }

        public string name { get; set; }

        public MojangProfileProperty[] properties { get; set; }
    }

    public class MojangProfileProperty
    {
        public string name { get; set; }
        
        public string value { get; set; }

        public string signature { get; set; }
    }
}
