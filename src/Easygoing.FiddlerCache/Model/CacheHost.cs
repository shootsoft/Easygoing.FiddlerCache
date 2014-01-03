using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public class CacheHost :CacheNode
    {
        public Dictionary<string, CacheItem> Items { get; set; }
        
        public CacheHost()
        {
            Items = new Dictionary<string, CacheItem>();
        }
    }
}
