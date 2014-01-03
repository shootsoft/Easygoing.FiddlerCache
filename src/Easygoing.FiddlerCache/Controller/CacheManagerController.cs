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

        public CacheManagerController()
        {
           cacheService = new CacheService();
           View = new CacheManagerView(this);
           AddCacheView(cacheService.Load());
           CacheConfig = cacheService.CacheConfig;
        }
        
        /// <summary>
        /// Bind to Fiddler
        /// </summary>
        public bool BindFiddler()
        {
            TabPage page = new TabPage("Cache Manager");
            Fiddler.FiddlerApplication.UI.tabsViews.TabPages.Add(page);
            page.Controls.Add(this.View);
            this.View.Dock = DockStyle.Fill;
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

        public void Filter(Session oSession) 
        {
            if (CacheConfig.Enabled)
            {
                cacheService.LoadFromCache(oSession);
            }
        }

        public void Edit(CacheItem item)
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


        public void AddCacheView(IEnumerable<CacheItem> items)
        {
            
            foreach (var item in items)
            {
                //if (!View.Groups.ContainsKey(item.Host))
                //{
                //    OLVGroup gp = new BrightIdeasSoftware.OLVGroup(item.Host);
                //    View.TreeListViewCache.OLVGroups.Add(gp);
                //    View.Groups.Add(item.Host, gp);
                    
                //}

                View.TreeListViewCache.AddObject(item);
            }

        }

        public bool DeleteCache(IEnumerable<CacheItem> items)
        {
            
            if (cacheService.DeleteCache(items))
            {
                foreach (var item in items)
                {
                    View.TreeListViewCache.RemoveObject(item);
                }
                //View.TreeListViewCache.RemoveObjects(items);
            }
            return true;
        }

        public bool ClearCache()
        {
            if (cacheService.ClearCache())
            {
                View.TreeListViewCache.ClearObjects();
                View.TreeListViewCache.Items.Clear();
            }
            return true;
            
        }

        public void Dispose()
        {
            cacheService.Dispose();
        }

        protected void OnMenuAddCache_Click(object sender, EventArgs e) 
        {
           if (sessionListView != null &&
            sessionListView.SelectedItems.Count > 0)
            {
                List<Session> sessionList = new List<Session>();
                foreach (ListViewItem item in sessionListView.SelectedItems)
                {
                    Fiddler.Session session = item.Tag as Session;
                    sessionList.Add(session);
                }
                IEnumerable<CacheItem> items = cacheService.AddCache(sessionList, UpdateCacheItemDelegate);
                this.AddCacheView(items);
            }
        }

        protected void OnMenuAddCache2_Click(object sender, EventArgs e)
        {
            if (sessionListView != null &&
             sessionListView.SelectedItems.Count > 0)
            {
                List<Session> sessionList = new List<Session>();
                foreach (ListViewItem item in sessionListView.SelectedItems)
                {
                    Fiddler.Session session = item.Tag as Session;
                    if (session.fullUrl.Contains('?'))
                    { 
                        session.fullUrl = session.fullUrl.Substring(0,  session.fullUrl.IndexOf('?'));
                    }
                    sessionList.Add(session);
                }
                IEnumerable<CacheItem> items = cacheService.AddCache(sessionList, UpdateCacheItemDelegate);
                this.AddCacheView(items);
            }
        }

        public void UpdateCacheItemDelegate(CacheItem cacheOld, CacheItem cacheNew)
        {
            View.TreeListViewCache.RemoveObject(cacheOld);
            View.TreeListViewCache.AddObject(cacheNew);
        }



        public void Open()
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

        public void OpenDirectory()
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
    }
}
