using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public abstract class CacheNode
    {
        public string Host { get; set; }
        public abstract  CheckState CheckState { get; set; }
    }
}
