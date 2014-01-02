using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Model
{
    public class CacheConfig
    {
        public string Path { get; set; }
        public string ConfigFile { get; set; }
        public string DBFile { get; set; }
        public string CacheDir { get; set; }
        public bool Enabled { get; set; }

        internal static CacheConfig Load()
        {
            CacheConfig cfg = new CacheConfig();
            cfg.Path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Fiddler2", "Cache");
            if (!Directory.Exists(cfg.Path))
            {
                Directory.CreateDirectory(cfg.Path);
            }
            cfg.ConfigFile = System.IO.Path.Combine(cfg.Path, "config.json");
            cfg.DBFile = System.IO.Path.Combine(cfg.Path, "db.raptordb");
            cfg.CacheDir = System.IO.Path.Combine(cfg.Path, "Files");

            if (!File.Exists(cfg.ConfigFile))
            {
                cfg.Save();
            }
            else 
            {
                cfg = Newtonsoft.Json.JsonConvert.DeserializeObject<CacheConfig>(File.ReadAllText(cfg.ConfigFile, Encoding.UTF8));
            }
            return cfg;
        }

        private void Save()
        {
            string cfg =
            Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(ConfigFile, cfg, Encoding.UTF8);
        }
    }
}
