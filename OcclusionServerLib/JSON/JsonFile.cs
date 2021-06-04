using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OcclusionDedicatedServer.json
{
    public class JsonFile<T>
    {
        public string Path { get; set; }

        private T _obj;
        public T Obj 
        { 
            get
            {
                lock(lockObj)
                {
                    return _obj;
                }
            }
            set
            {
                lock(lockObj)
                {
                    _obj = value;
                }
            }
        }

        private object lockObj = new object();

        public JsonFile(string path, T obj)
        {
            Path = path;

            if (!File.Exists(Path))
            {
                Obj = obj;
            }
            else
            {
                ReloadFromFile();
            }
        }


        /**
         * Serializes and writes the internal object to the file path.
         */
        public void Update()
        {
            lock(lockObj)
            {
                File.WriteAllText(Path, JsonConvert.SerializeObject(Obj));
            }
        }

        public void ReloadFromFile()
        {
            lock(lockObj)
            {
                Obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(Path), new JsonSerializerSettings());
            }
        }
    }
}
