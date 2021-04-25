using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_UHC_Stats_Editor.mojang.json
{
    public class MojangSkinProfile
    {
        public long timestamp { get; set; }

        public string profileId { get; set; }

        public string profileName { get; set; }

        public bool signatureRequired { get; set; }

        public MojangTextures textures { get; set; } = new MojangTextures();
    }

    public class MojangTextures
    {
        public MojangSkinEntry SKIN = new MojangSkinEntry();

        public MojangSkinEntry CAPE = new MojangSkinEntry();
    }

    public class MojangSkinEntry
    {
        public string url { get; set; }

        public MojangSkinMeta metadata { get; set; } = new MojangSkinMeta();
    }

    public class MojangSkinMeta
    {
        public string model { get; set; }
    }
}
