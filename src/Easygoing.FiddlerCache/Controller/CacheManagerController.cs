using BrightIdeasSoftware;
using Easygoing.FiddlerCache.Model;
using Easygoing.FiddlerCache.Service;
using Easygoing.FiddlerCache.View;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.Controller
{
    public class CacheManagerController: IDisposable
    {
        public CacheManagerView View { get; set; }
        public CacheConfig CacheConfig { get; set; }
        protected CacheService cacheService = null;
        protected SessionListView sessionListView = null;
        public ImageList ImageList { get; set; }

        public CacheManagerController()
        {
           cacheService = new CacheService();
           View = new CacheManagerView(this);
           OnAddCacheViewAction(cacheService.Load());
           CacheConfig = cacheService.CacheConfig;
           InitializeUI();
        }

        /// <summary>
        /// Call all the initialize action
        /// </summary>
        public void InitializeUI()
        {
            OnUIEnabledAction(CacheConfig.Enabled);
            OnUIHidePropertiesAction(CacheConfig.HideProperties);
        }


        #region UI Action
        /// <summary>
        /// Enable or disable ui action
        /// </summary>
        public void OnUIEnabledAction()
        {
            OnUIEnabledAction(!CacheConfig.Enabled);
        }

        /// <summary>
        /// Enable or disable ui action by parameter
        /// </summary>
        /// <param name="enabled"></param>
        public void OnUIEnabledAction(bool enabled)
        {
            View.TreeListViewCache.Enabled = enabled;
            CacheConfig.Enabled = enabled;
            View.ButtonClear.Enabled = enabled;
            View.ButtonDelete.Enabled = enabled;
            View.ButtonEdit.Enabled = enabled;
            if (enabled)
            {
                View.ButtonEnabled.Text = "Disable";
                View.ButtonEnabled.Image = View.ImageListIcon.Images["pause"];
                View.ButtonEnabled.ToolTipText = "Click to disable the Cache Manager";
            }
            else
            {
                View.ButtonEnabled.Text = "Enable";
                View.ButtonEnabled.Image = View.ImageListIcon.Images["start"];
                View.ButtonEnabled.ToolTipText = "Click to enable the Cache Manager";

            }
        }

        public void OnUIHidePropertiesAction()
        {
            OnUIHidePropertiesAction(!CacheConfig.HideProperties);
        }

        public void OnUIHidePropertiesAction(bool hide)
        {
            CacheConfig.HideProperties = hide;
            View.SplitContainerMain.Panel2Collapsed = hide;
            View.ButtonHideProperty.Text = (hide ? "Show" : "Hide") + " properties";
            View.ButtonHideProperty.Image = View.ImageListIcon.Images[View.ButtonHideProperty.Text];
        }


        /// <summary>
        /// Set the status text
        /// </summary>
        public void OnUISelectedChangedAction()
        {
            CacheItem item = View.TreeListViewCache.SelectedObject as CacheItem;
            if (item == null)
            {
                View.PropertyGrid.SelectedObject = null;
                //View.VirtualObjectListViewAttr.ClearObjects() ;
            }
            else
            {
                View.PropertyGrid.SelectedObject = item;
                //View.VirtualObjectListViewAttr.AddObject(new KeyValuePair<string, string>("Url", item.Url));
                //View.VirtualObjectListViewAttr.AddObject(new KeyValuePair<string, string>("Local", item.Local));
            }
        }
        #endregion

        #region Bind
        /// <summary>
        /// Bind to Fiddler
        /// </summary>
        public bool BindFiddler()
        {
            TabPage page = new TabPage("Cache Manager");

            Fiddler.FiddlerApplication.UI.tabsViews.TabPages.Add(page);
            page.Controls.Add(this.View);
            Fiddler.FiddlerApplication.UI.tabsViews.ImageList.Images.Add("cachemanager", View.ImageListIcon.Images["cache"]);
            page.ImageKey = "cachemanager";
            this.View.Dock = DockStyle.Fill;
            BindFiddlerResource();
            return true;

        }

        public bool BindFiddlerResource()
        {
            this.ImageList = Fiddler.FiddlerApplication.UI.imglSessionIcons;
            //Find the Fiddler session list
            foreach (var item in Fiddler.FiddlerApplication.UI.pnlSessions.Controls)
            {
                if (item.GetType() == typeof(Fiddler.SessionListView))
                {
                    sessionListView = item as SessionListView;
                    break;
                }

            }
            return sessionListView != null;
        }

        /// <summary>
        /// Bind Fiddler menu item
        /// </summary>
        public void BindFiddlerMenu()
        {
            MenuItem menuAddCache = new MenuItem("Add Cache");
            menuAddCache.Click += OnMenuAddCache_Click;
            Fiddler.FiddlerApplication.UI.mnuTools.MenuItems.Add(menuAddCache);
            Fiddler.FiddlerApplication.UI.mnuSessionContext.MenuItems.Add(menuAddCache);

            MenuItem menuAddCache2 = new MenuItem("Add Cache Without Query");
            menuAddCache2.Click += OnMenuAddCache2_Click;
            Fiddler.FiddlerApplication.UI.mnuTools.MenuItems.Add(menuAddCache2);
            Fiddler.FiddlerApplication.UI.mnuSessionContext.MenuItems.Add(menuAddCache2);
        } 
        #endregion

        /// <summary>
        /// Using cache
        /// </summary>
        /// <param name="oSession"></param>
        public void Filter(Session oSession) 
        {
            if (CacheConfig.Enabled)
            {
                cacheService.LoadFromCache(oSession);
            }
        }



        public void Dispose()
        {
            cacheService.Dispose();
        }

        #region Add cache actions
        protected void OnMenuAddCache_Click(object sender, EventArgs e)
        {
            OnAddSessions2CacheAction(true);
        }

        protected void OnMenuAddCache2_Click(object sender, EventArgs e)
        {
            OnAddSessions2CacheAction(false);
        }

        private void OnAddSessions2CacheAction(bool withQuery)
        {
            if (sessionListView != null &&
             sessionListView.SelectedItems.Count > 0)
            {
                List<Session> sessionList = new List<Session>();
                foreach (ListViewItem item in sessionListView.SelectedItems)
                {
                    Fiddler.Session session = item.Tag as Session;
                    if (!withQuery && session.fullUrl.Contains('?'))
                    {
                        session.fullUrl = session.fullUrl.Substring(0, session.fullUrl.IndexOf('?'));
                    }
                    sessionList.Add(session);
                }
                IEnumerable<CacheItem> items = cacheService.AddCache(sessionList, OnUpdateCacheItemAction);
                this.OnAddCacheViewAction(items);
            }
        }

        /// <summary>
        /// Update item
        /// </summary>
        /// <param name="cacheOld"></param>
        /// <param name="cacheNew"></param>
        public void OnUpdateCacheItemAction(CacheItem cacheOld, CacheItem cacheNew)
        {
            if (View.CacheIndex.ContainsKey(cacheOld.Host))
            {
                CacheHost host = View.CacheIndex[cacheOld.Host];
                if (host.Items.ContainsKey(cacheOld.Url))
                {
                    host.Items[cacheOld.Url] = cacheNew;
                }
            }
        }

        public void OnAddCacheViewAction(IEnumerable<CacheItem> items)
        {

            foreach (var item in items)
            {
                if (!View.CacheIndex.ContainsKey(item.Host))
                {
                    CacheHost host = new CacheHost() { Host = item.Host };
                    View.CacheIndex[item.Host] = host;
                    View.TreeListViewCache.AddObject(host);
                }
                View.CacheIndex[item.Host].Items[item.Url] = item;
            }

        }
        #endregion

        #region Menu & Toolbar buttons
        /// <summary>
        /// Open cache item with default program
        /// </summary>
        public void OnOpenCacheItemAction()
        {
            CacheItem item = View.TreeListViewCache.SelectedObject as CacheItem;
            if (item != null)
            {
                try
                {
                    Process.Start(item.Local);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Open local cache file directory
        /// </summary>
        public void OnOpenDirectoryAction()
        {
            CacheItem item = View.TreeListViewCache.SelectedObject as CacheItem;
            if (item != null)
            {
                try
                {
                    Process.Start(new FileInfo(item.Local).DirectoryName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void OnDeleteCacheAction()
        {
            if (MessageBox.Show("Delete selected cache?", "Confirm Deletion", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<CacheItem> items = new List<CacheItem>();
                foreach (object obj in View.TreeListViewCache.SelectedObjects)
                {
                    View.TreeListViewCache.RemoveObject(obj);
                    CacheItem item = obj as CacheItem;
                    if (item != null)
                    {
                        items.Add(item);
                        if (View.CacheIndex.ContainsKey(item.Host))
                        {
                            CacheHost host = View.CacheIndex[item.Host];
                            host.Items.Remove(item.Url);
                            if (host.Items.Count == 0)
                            {
                                View.TreeListViewCache.RemoveObject(host);
                            }
                        }


                    }
                    else
                    {
                        CacheHost host = obj as CacheHost;
                        if (host != null)
                        {
                            items.AddRange(host.Items.Values);
                            View.CacheIndex.Remove(host.Host);
                        }


                    }
                }
                if (items != null)
                {
                    cacheService.DeleteCache(items);
                }

                //foreach (ListViewItem item in View.TreeListViewCache.SelectedItems)
                //{
                //    View.TreeListViewCache.Items.Remove(item);
                //}

                //View.TreeListViewCache.RemoveObjects(View.TreeListViewCache.SelectedObjects);
                //View.TreeListViewCache.RemoveObjects(items);
                //View.TreeListViewCache.RefreshSelectedObjects();
                View.TreeListViewCache.RebuildAll(true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnClearCacheAction()
        {
            if (MessageBox.Show("Clear all the cache?", "Confirm Clearance", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question) == DialogResult.Yes)
            {

                foreach (var item in View.TreeListViewCache.Objects)
                {
                    View.TreeListViewCache.RemoveObject(item);
                }
                cacheService.ClearCache();
                View.CacheIndex.Clear();
                //View.TreeListViewCache.ClearObjects();
                View.PropertyGrid.SelectedObject = null;
            }
        }

        /// <summary>
        /// Start
        /// </summary>
        public void OnEditCacheAction()
        {
            if (View.TreeListViewCache.SelectedObject != null)
            {
                CacheItem item = View.TreeListViewCache.SelectedObject as CacheItem;
                if (item != null)
                {
                    try
                    {
                        if (File.Exists(CacheConfig.Editor))
                        {
                            Process.Start(CacheConfig.Editor, item.Local);
                        }
                        else
                        {
                            Process.Start("notepad", item.Local);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                }
            }
        }

        #endregion
        
    }
}
