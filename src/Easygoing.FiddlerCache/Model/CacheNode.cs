using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public class CacheNode
    {
        public string Host { get; set; }
        public virtual CheckState CheckState { get; set; }
    }
}
