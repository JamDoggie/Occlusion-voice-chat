using MLG_UHC_Stats_Editor.mojang.json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Occlusion_voice_chat.Mojang
{
    /// <summary>
    /// There's definitely a library for this but it was fun to make so whatever.
    /// </summary>
    public static class MojangAPI
    {
        public static string GetPlayerUUID(string username)
        {
            var json = HttpGet($"https://api.mojang.com/users/profiles/minecraft/{ username }");
            var obj = JsonConvert.DeserializeObject<MojangNameUIDPair>(json);

            CheckError(json);

            if (obj != null)
                return obj.id;
            else
                return string.Empty;
        }

        public static MojangProfile GetPlayerProfile(string uuid)
        {
            var json = HttpGet($"https://sessionserver.mojang.com/session/minecraft/profile/{ uuid }");

            MojangProfile profile = JsonConvert.DeserializeObject<MojangProfile>(json);

            CheckError(json);

            return profile;
        }

        private static void CheckError(string json)
        {
            APIErrorJson error = JsonConvert.DeserializeObject<APIErrorJson>(json);

            if (error != null && error.error != null && error.errorMessage != null)
                throw new MojangAPIException($"The Mojang API sent back an error message. \nReturned error type: {error.error}, Returned error message: {error.errorMessage}");
        }

        private static string HttpGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
