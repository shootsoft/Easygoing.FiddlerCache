using Easygoing.FiddlerCache.Model;
using Fiddler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Service
{
    public class CacheService : IDisposable
    {
        public CacheConfig CacheConfig { get; set; }

        protected RaptorDB.RaptorDB<string> db= null;
        protected Dictionary<string, CacheItem> cache = null;


        public CacheService()
        {
            CacheConfig = CacheConfig.Load();
            db = new RaptorDB.RaptorDB<string>(CacheConfig.DBFile, false);
            cache = new Dictionary<string, CacheItem>();
        }

        public IEnumerable<CacheItem> Load()
        {
            List<CacheItem> list = new List<CacheItem>();

            IEnumerable<RaptorDB.StorageData> items = db.EnumerateStorageFile();
            foreach (var item in items)
            {
                string val = Encoding.UTF8.GetString(item.Data);
                CacheItem c = JsonConvert.DeserializeObject<CacheItem>(val);
                cache[c.Url] = c;
                list.Add(c);
            }
            return list;
        }

        public bool LoadFromCache(Session oSession)
        {
            string outCache;
            if (db.Get(oSession.fullUrl, out outCache))
            {
                
                CacheItem item = null;
                if (cache.ContainsKey(oSession.fullUrl))
                {
                    item = cache[oSession.fullUrl];
                }
                else
                {
                    item = JsonConvert.DeserializeObject<CacheItem>(outCache);
                }
                item.SetSessionResponse(oSession);
                if (File.Exists(item.Local))
                {
                    oSession.LoadResponseFromFile(item.Local);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<CacheItem> AddCache(IEnumerable<Session> oSessions)
        {
            List<CacheItem> list = new List<CacheItem>();
            foreach (var session in oSessions)
            {
                 CacheItem c = AddCache(session);
                 list.Add(c);
            }
            return list;
        }

        public CacheItem AddCache(Session oSession)
        {
            CacheItem item = new CacheItem(oSession, CacheConfig.CacheDir);
            db.Set(oSession.fullUrl, JsonConvert.SerializeObject(item));
            cache[oSession.fullUrl] = item;
            return item;
        }

        public bool DeleteCache(IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                DeleteCache(url);
            }
            return true;
        }

        public bool DeleteCache(string url)
        {
            db.RemoveKey(url);
            cache.Remove(url);
            db.SaveIndex();
            return true;
        }

        public bool ClearCache()
        {
            try
            {
                lock (db)
                {
                    db.Shutdown();
                    File.Delete(CacheConfig.DBFile);
                    db = new RaptorDB.RaptorDB<string>(CacheConfig.DBFile, false);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

            }
            return false;
        }

        public void Dispose()
        {
            db.SaveIndex();
            db.Shutdown();
        }
    }
}
