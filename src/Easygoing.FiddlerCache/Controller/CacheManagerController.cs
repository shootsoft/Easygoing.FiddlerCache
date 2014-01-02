using Easygoing.FiddlerCache.Model;
using Easygoing.FiddlerCache.Service;
using Easygoing.FiddlerCache.View;
using Fiddler;
using System;
using System.Collections.Generic;
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
           View = new CacheManagerView();
           AddCache(cacheService.Load());

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
            MenuItem menuRegex = new MenuItem("Add Cache");
            menuRegex.Click += OnMenuAddCache_Click;
            Fiddler.FiddlerApplication.UI.mnuTools.MenuItems.Add(menuRegex);
            Fiddler.FiddlerApplication.UI.mnuSessionContext.MenuItems.Add(menuRegex);
        }

        public void Filter(Session oSession) 
        {
            if (CacheConfig.Enabled)
            {
                cacheService.LoadFromCache(oSession);
            }
        }

        public void AddCache(IEnumerable<CacheItem> items)
        {
            foreach (var item in items)
            {
                View.TreeListViewCache.AddObject(item);
            }

        }

        public bool DeleteCache(IEnumerable<string> urls)
        {
            if (cacheService.DeleteCache(urls))
            { 
                //View.TreeListViewCache.RemoveObject
            }
            return true;
        }


        public bool DeleteCache(string url) 
        {
            return cacheService.DeleteCache(url);
        }

        public bool ClearCache()
        {
            return cacheService.ClearCache();
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
                Fiddler.Session session = sessionListView.SelectedItems[0].Tag as Session;
                sessionList.Add(session);
                IEnumerable<CacheItem> items = cacheService.AddCache(sessionList);
                this.AddCache(items);
            }
        }

    }
}
