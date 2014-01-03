using Easygoing.FiddlerCache.Model;
using Fiddler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Easygoing.FiddlerCache.Service
{
    /// <summary>
    /// Index update delegate
    /// </summary>
    /// <param name="cacheOld"></param>
    /// <param name="cacheNew"></param>
    public delegate void UpdateCacheItemDelegate(CacheItem cacheOld, CacheItem cacheNew);


    public class CacheService : IDisposable
    {
        public CacheConfig CacheConfig { get; set; }

        //protected RaptorDB.RaptorDB<string> db= null;
        protected Dictionary<string, CacheItem> cache = null;
        protected Dictionary<string, CacheHost> cacheIndex = null;

        public CacheService()
        {
            CacheConfig = CacheConfig.Load();
            //db = new RaptorDB.RaptorDB<string>(CacheConfig.DBFile, false);
            cache = new Dictionary<string, CacheItem>();
            cacheIndex = new Dictionary<string, CacheHost>();
        }

        public IEnumerable<CacheItem> Load()
        {
            if (File.Exists(CacheConfig.DBFile))
            {
                using (FileStream fs = new FileStream(CacheConfig.DBFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Binder = new InsideCOMBinder();
            
                    object obj = formatter.Deserialize(fs);
                    cache = obj as Dictionary<string, CacheItem>;
                    if (cache == null) cache = new Dictionary<string, CacheItem>();
                    return cache.Values;
                }
            }
            else 
            { 
                return new CacheItem[0];
            }
            //List<CacheItem> list = new List<CacheItem>();
            //int count = (int)db.Count();
            //for (int i = 0; i < count; i++)
            //{
            //    string val = db.FetchRecordString(i);
            //    CacheItem c = JsonConvert.DeserializeObject<CacheItem>(val);
            //    cache[c.Url] = c;
            //    list.Add(c);
            //}
            //return list;
        }

        private class InsideCOMBinder : System.Runtime.Serialization.SerializationBinder
        {
            public override Type BindToType(string assemblyName, string typeName)
            {
                return Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            }
        }

        public bool LoadFromCache(Session oSession)
        {
            bool success = false;
            string key = oSession.fullUrl;
            if (!cache.ContainsKey(key))
            {
                if (key.Contains('?')) {
                    key = key.Substring(0, key.IndexOf('?'));
                }
            }
            if (cache.ContainsKey(key)) 
            {
                oSession.utilCreateResponseAndBypassServer();
                CacheItem item = cache[key];
                item.SetSessionResponse(oSession);
                if (File.Exists(item.Local))
                {
                    success = oSession.LoadResponseFromFile(item.Local);
                }
            }


            return success;
        }

        public List<CacheItem> AddCache(IEnumerable<Session> oSessions, UpdateCacheItemDelegate updateDelegate)
        {
            List<CacheItem> list = new List<CacheItem>();
            foreach (var session in oSessions)
            {
                CacheItem item = new CacheItem(session, CacheConfig.CacheDir);
                if (!cacheIndex.ContainsKey(item.Host))
                {
                    cacheIndex[item.Host] = new CacheHost();

                }
                cacheIndex[item.Host].Items[item.Url] = item;

                if (cache.ContainsKey(item.Url))
                {
                    if (updateDelegate != null)
                    {   
                        updateDelegate(cache[item.Url], item);
                    }
                }
                else
                {
                    list.Add(item);
                }
                cache[item.Url] = item;
                //AddCache(item);
                
            }
            SaveIndex();
            return list;
        }

        //public CacheItem AddCache(CacheItem item)
        //{   
        //    //db.Set(item.Url, JsonConvert.SerializeObject(item));
        //    cache[item.Url] = item;
        //    return item;
        //}

        public bool DeleteCache(IEnumerable<CacheItem> items)
        {
            foreach (var item in items)
            {
                DeleteCache(item, false);
            }
            SaveIndex();
            //db.SaveIndex();
            return true;
        }

        public bool DeleteCache(CacheItem item, bool saveIndex)
        {
            cache.Remove(item.Url);
            File.Delete(item.Local);
            if (saveIndex)
            {
                SaveIndex();
            }
            return true;
        }

        public bool ClearCache()
        {
            try
            {
                lock (cache)
                {
                    cache.Clear();
                    File.Delete(CacheConfig.DBFile);
                    //db.Shutdown();
                    //string[] files = Directory.GetFiles(CacheConfig.Path, "db.*");
                    //foreach (var item in files)
                    //{
                    //    File.Delete(item);
                    //}
                    if(Directory.Exists(CacheConfig.CacheDir))
                    {
                        Directory.Delete(CacheConfig.CacheDir, true);
                    }
                    //db = new RaptorDB.RaptorDB<string>(CacheConfig.DBFile, false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            return true;
        }

        public void SaveIndex()
        {
            using(FileStream fs = new FileStream(CacheConfig.DBFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, cache);   
            }
        }

        public void Dispose()
        {
            SaveIndex();
            CacheConfig.Save();
        }

        internal Model.CacheConfig InitConfig()
        {
            return CacheConfig;
        }
    }
}
