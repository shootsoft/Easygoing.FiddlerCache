using Easygoing.FiddlerCache.Util;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.Model
{
    [Serializable]
    public class CacheItem : CacheNode
    {
        public string Url { get;  set; }
        public string PathAndQuery { get; set; }
        public string Local { get;  set; }
        public DateTime Creation { get; set; }
        public long Length { get; set; }
        public Dictionary<string, string> ResponseHeaders { get;  set; }
        public int ImageIndex { get; set; }

        private CacheHost cacheHost;
        public CacheHost CacheHost { get { return cacheHost; } set { this.cacheHost = value; } }
        private CheckState checkState;
        public override CheckState CheckState 
        {
            get { return checkState; }
            set 
            {
                this.checkState = value;
                if (cacheHost != null && !cacheHost.LockState)
                {
                    cacheHost.CheckStateUpdate();
                }
            }
        }

        public CacheItem()
        {
            cacheHost = null;
            checkState = System.Windows.Forms.CheckState.Checked;
            Url = string.Empty;
            Local = string.Empty;
            ResponseHeaders = new Dictionary<string, string>();
            Creation = DateTime.Now;
        }

        public CacheItem(Session session, string dir)
        {
            Url = session.fullUrl;
            try
            {
                Uri uri = new Uri(session.fullUrl);
                this.CheckState = System.Windows.Forms.CheckState.Checked;
                PathAndQuery = uri.PathAndQuery;
                ImageIndex = session.ViewItem.ImageIndex;
                Local = FileUtil.ReserveUriLocal(uri, dir, session.oResponse.MIMEType);
                ResponseHeaders = new Dictionary<string, string>();
                Creation = DateTime.Now;
                Host = uri.Host;
                session.utilDecodeResponse();
                Length = session.responseBodyBytes.LongLength;
                foreach (Fiddler.HTTPHeaderItem item in session.oResponse.headers)
                {
                    ResponseHeaders[item.Name] = item.Value;
                }

                FileInfo fi = new FileInfo(Local);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }

                File.WriteAllBytes(Local, session.responseBodyBytes);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            
        }

        public void SetSessionResponse(Session oSession)
        {
            foreach (var item in ResponseHeaders)
            {
                if (oSession.oResponse.headers != null)
                {
                    oSession.oResponse.headers[item.Key] = item.Value;
                }
                
            }
        }

   

    }
}
