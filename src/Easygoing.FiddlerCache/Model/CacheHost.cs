using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public class CacheHost :CacheNode
    {
        public Dictionary<string, CacheItem> Items { get; set; }
        public bool LockState { get; private set; }
        private CheckState checkState;
        public override CheckState CheckState 
        {
            get { return checkState; }
            set 
            {
                this.checkState = value;
                LockState = true;
                CheckStateUpdate();
                LockState = false;
            }
        }
        public CacheHost()
        {
            Items = new Dictionary<string, CacheItem>();
        }

        internal void CheckStateUpdate()
        {
            if (!LockState)
            {
                CheckState? x = null;
                foreach (CacheItem item in Items.Values)
                {
                    if (x.HasValue)
                    {
                        if (x != item.CheckState)
                        {
                            this.checkState = System.Windows.Forms.CheckState.Indeterminate;
                            x = System.Windows.Forms.CheckState.Indeterminate;
                            break;
                        }
                    }
                    else
                    {
                        x = item.CheckState;
                    }
                }
                if (x.HasValue && x.Value != System.Windows.Forms.CheckState.Indeterminate)
                {
                    this.checkState = x.Value;
                }
            }
            else
            {
                if (this.checkState == System.Windows.Forms.CheckState.Checked ||
                    this.checkState == System.Windows.Forms.CheckState.Unchecked)
                {
                    foreach (CacheItem item in Items.Values)
                    {
                        item.CheckState = this.checkState;
                    }
                }
            }
                    
        }

    }
}
