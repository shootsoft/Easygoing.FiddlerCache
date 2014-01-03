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
        public Dictionary<string, BrightIdeasSoftware.OLVGroup> Groups { get; set; }

        public CacheManagerView(CacheManagerController cacheManagerController)
        {
            
            InitializeComponent();
            InitTree();
            this.cacheManagerController = cacheManagerController;
            Groups = new Dictionary<string, BrightIdeasSoftware.OLVGroup>();
            TreeListViewCache.OLVGroups = new List<BrightIdeasSoftware.OLVGroup>();
        }


        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            if (MessageBox.Show("Delete selected cache?", "Confirm Deletion", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                IList<CacheItem> items = new List<CacheItem>();
                foreach (CacheItem item in TreeListViewCache.SelectedObjects)
                {
                    items.Add(item);
                }
                if (items != null)
                {
                    cacheManagerController.DeleteCache(items);
                }
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearCache();
        }

        private void ClearCache()
        {
            if (MessageBox.Show("Clear all the cache?", "Confirm Clearance", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TreeListViewCache.Items.Clear();
                Debug.WriteLine(TreeListViewCache.Items.Count);
                cacheManagerController.ClearCache();
            }
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

            olvColumnHost.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return item.Host;
                }
                else
                {
                    return string.Empty;
                }
            };



            olvColumnUrl.AspectGetter = delegate(object x)
            {
                CacheItem item = x as CacheItem;
                if (item != null)
                {
                    return item.Url;
                }
                else
                {
                    return string.Empty;
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

            TreeListViewCache.ItemsAdding += TreeListViewCache_ItemsAdding;
            //TreeListViewCache.IndexOf();

        }

        void TreeListViewCache_ItemsAdding(object sender, BrightIdeasSoftware.ItemsAddingEventArgs e)
        {
            //foreach (ListViewItem item in e.ObjectsToAdd)
            //{
                
            //}
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (TreeListViewCache.SelectedObject != null)
            {
                CacheItem item = TreeListViewCache.SelectedObject as CacheItem;
                cacheManagerController.Edit(item);
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

            EditCache();

        }

        private void EditCache()
        {
            if (TreeListViewCache.SelectedObject != null)
            {
                CacheItem item = TreeListViewCache.SelectedObject as CacheItem;
                cacheManagerController.Edit(item);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearCache();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.Open();
        }

        private void openDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cacheManagerController.OpenDirectory();
        }
    }
}
