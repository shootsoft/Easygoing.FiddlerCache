using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public class CacheHeader
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
