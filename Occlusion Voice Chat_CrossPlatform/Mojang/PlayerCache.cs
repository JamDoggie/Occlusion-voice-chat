using MLG_UHC_Stats_Editor.mojang.json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.Mojang
{
    public static class PlayerCache
    {
        public static string CachePath { get; set; } = "playercache.json";

        public static PlayerCacheFile CacheFile { get; set; } = new PlayerCacheFile();

        /// <summary>
        /// Time between when the cache should be cleared and regenerated.
        /// </summary>
        private const int cacheInterval = 10;

        public static void RetrieveCacheFile()
        {
            if (File.Exists(CachePath))
            {
                string json = File.ReadAllText(CachePath);

                CacheFile = JsonConvert.DeserializeObject<PlayerCacheFile>(json);
            }
            else
            {
                CacheFile = new PlayerCacheFile();

                CacheFile.cacheTime = DateTime.Now;

                File.WriteAllText(CachePath, JsonConvert.SerializeObject(CacheFile));
            }
        }

        public static void UpdateCacheFile()
        {
            File.WriteAllText(CachePath, JsonConvert.SerializeObject(CacheFile));
        }

        public static string GetCachedPlayerUUID(string username)
        {
            if ((DateTime.Now - CacheFile.cacheTime).TotalMinutes < cacheInterval)
            {
                // Shouldn't recache entire file
                string cachedUID = null;

                foreach (PlayerCacheObject player in CacheFile.playerObjects)
                {
                    if (player.Username == username)
                    {
                        cachedUID = player.UUID;
                    }
                }

                if (cachedUID != null)
                {
                    return cachedUID;
                }
                else
                {
                    // Not already cached, add to cache
                    var uid = MojangAPI.GetPlayerUUID(username);

                    if (uid != null)
                        CachePlayer(uid);

                    return uid;
                }
            }
            else
            {
                // Cache is expired.
                // Recreate cache, and add this player to it.
                File.Delete(CachePath);

                RetrieveCacheFile();

                var uid = MojangAPI.GetPlayerUUID(username);

                if (uid != null)
                    CachePlayer(uid);

                return uid;
            }
        }


        public static string GetCachedPlayerUsername(string uuid)
        {
            if ((DateTime.Now - CacheFile.cacheTime).TotalMinutes < cacheInterval)
            {
                // Shouldn't recache entire file
                string cachedUsername = null;

                foreach (PlayerCacheObject player in CacheFile.playerObjects)
                {
                    if (player.UUID == uuid)
                    {
                        cachedUsername = player.Username;
                    }
                }

                if (cachedUsername != null)
                {
                    return cachedUsername;
                }
                else
                {
                    // Not already cached, add to cache
                    string? username = MojangAPI.GetPlayerProfile(uuid)?.name;

                    if (username != null)
                        CachePlayer(uuid);

                    return username;
                }
            }
            else
            {
                // Cache is expired.
                // Recreate cache, and add this player to it.
                File.Delete(CachePath);

                RetrieveCacheFile();

                PlayerCacheObject obj = new PlayerCacheObject();

                if (uuid != null)
                    obj = CachePlayer(uuid);

                return obj.Username;
            }
        }

        public static string GetCachedPlayerSkinURL(string uuid)
        {
            if ((DateTime.Now - CacheFile.cacheTime).TotalMinutes < cacheInterval)
            {
                // Shouldn't recache entire file
                string cachedSkin = null;

                foreach (PlayerCacheObject player in CacheFile.playerObjects)
                {
                    if (player.UUID == uuid)
                    {
                        cachedSkin = player.SkinURL;
                    }
                }

                if (cachedSkin != null)
                {
                    return cachedSkin;
                }
                else
                {
                    // Not already cached, add to cache
                    PlayerCacheObject cacheObj;


                    cacheObj = CachePlayer(uuid);

                    return cacheObj.SkinURL;
                }
            }
            else
            {
                // Cache is expired.
                // Recreate cache, and add this player to it.
                File.Delete(CachePath);

                RetrieveCacheFile();

                PlayerCacheObject cacheObj;

                cacheObj = CachePlayer(uuid);

                return cacheObj.SkinURL;
            }
        }



        public static PlayerCacheObject CachePlayer(string uid)
        {
            PlayerCacheObject player = new PlayerCacheObject();
            player.UUID = uid;

            MojangProfile profile = MojangAPI.GetPlayerProfile(uid);

            if (profile != null)
            {
                player.Username = profile.name;

                foreach (MojangProfileProperty property in profile.properties)
                {

                    if (property.name == "textures" && !string.IsNullOrEmpty(property.value))
                    {
                        string decodedBase64 = Encoding.ASCII.GetString(Convert.FromBase64String(property.value));

                        Console.WriteLine(decodedBase64);

                        MojangSkinProfile skinProfile = JsonConvert.DeserializeObject<MojangSkinProfile>(decodedBase64);

                        player.SkinURL = skinProfile.textures.SKIN.url;
                    }
                }

                CacheFile.playerObjects.Add(player);
                UpdateCacheFile();

            }


            return player;
        }
    }
}
