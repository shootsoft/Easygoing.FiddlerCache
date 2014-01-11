using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Easygoing.FiddlerCache.Model;
using System.Drawing.Drawing2D;
using Easygoing.FiddlerCache.Controller;
using System.Diagnostics;
using Easygoing.FiddlerCache.Util;

namespace Easygoing.FiddlerCache.View
{
    public partial class CacheManagerView : UserControl
    {
        protected CacheManagerController cacheManagerController = null;
        //public Dictionary<string, BrightIdeasSoftware.OLVGroup> Groups { get; set; }
        public Dictionary<string, CacheHost> CacheIndex {get;set;}

        public CacheManagerView(CacheManagerController cacheManagerController)
        {
            
            InitializeComponent();
            InitTree();
            this.cacheManagerController = cacheManagerController;
            CacheIndex = new Dictionary<string, CacheHost>();
        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnDeleteCacheAction();
        }

        

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnClearCacheAction();
        }

        

        internal void LoadViewItem(IEnumerable<Model.CacheItem> items)
        {
            foreach (var item in items)
            {
                TreeListViewCache.AddObject(item);
            }
        }

        public void InitTree()
        {
            this.TreeListViewCache.HideSelection = false;
            this.TreeListViewCache.FullRowSelect = true;
            // You can change the way the connection lines are drawn by changing the pen
            BrightIdeasSoftware.TreeListView.TreeRenderer renderer = this.TreeListViewCache.TreeColumnRenderer;
            renderer.LinePen = new Pen(Color.Firebrick, 0.5f);
            renderer.LinePen.DashStyle = DashStyle.Dot;

            TreeListViewCache.CheckStateGetter = delegate(object x)
            {
                CheckState s = CheckState.Checked;
                return s;
        
            };

            TreeListViewCache.CanExpandGetter = delegate(object x)
            {
                return x is CacheHost;
            };

            TreeListViewCache.ChildrenGetter = delegate(object x)
            {
                CacheHost h = x as CacheHost;
                if (h != null)
                {
                    return h.Items.Values;
                }
                else
                {
                    return new CacheItem[0];
                }
            };

            olvColumnUrl.ImageGetter = delegate(object x)
            {
                if (x is CacheItem)
                {
                    CacheItem item = x as CacheItem;
                    if (cacheManagerController.ImageList != null
                        && cacheManagerController.ImageList.Images.Count > item.ImageIndex)
                    {
                        return cacheManagerController.ImageList.Images[item.ImageIndex];
                    }
                    else
                    {
                        return ImageListIcon.Images[0];
                    }
                }
                else
                {
                    return ImageListIcon.Images[1];
                }
            };

            olvColumnUrl.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return item.PathAndQuery;
                }
                else
                {
                    CacheNode node = x as CacheNode;
                    if(node!=null)
                    {
                        return node.Host;
                    } 
                    else 
                    {
                        return string.Empty;
                    }
                }
            };

            olvColumnCreationTime.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return item.Creation.ToString();
                }
                else
                {
                    return string.Empty;
                }
            };

            olvColumnPath.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return item.Local;
                }
                else
                {
                    return string.Empty;
                }
            };


            olvColumnLength.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return FileUtil.FormatLength(item.Length);
                }
                else
                {
                    return string.Empty;
                }
            };


        }


        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnEditCacheAction();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            cacheManagerController.OnEditCacheAction();

        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnDeleteCacheAction ();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnClearCacheAction();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnOpenCacheItemAction();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnOpenDirectoryAction();
        }

        private void ButtonEnabled_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnUIEnabledAction();
        }

        private void TreeListViewCache_SelectedIndexChanged(object sender, EventArgs e)
        {
            cacheManagerController.OnUISelectedChangedAction();
        }

        private void ButtonHideProperty_Click(object sender, EventArgs e)
        {
            cacheManagerController.OnUIHidePropertiesAction();
        }

        private void ToolStripMenuItemSystemMenu_Click(object sender, EventArgs e)
        {
            cacheManagerController.ShowSystemMenu(System.Windows.Forms.Cursor.Position);
        }

        private void TreeListViewCache_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Checked =
                !e.Item.Checked;
        }
    }
}
