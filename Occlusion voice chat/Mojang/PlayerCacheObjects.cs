using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLG_UHC_Stats_Editor.mojang.json
{
    

    public class PlayerCacheObject
    {
        public string UUID { get; set; }

        public string Username { get; set; }

        public string SkinURL { get; set; }
    }

    public class PlayerCacheFile
    {
        public DateTime cacheTime { get; set; }

        public List<PlayerCacheObject> playerObjects { get; set; }

        public PlayerCacheFile()
        {
            playerObjects = new List<PlayerCacheObject>();
        }
    }
}
