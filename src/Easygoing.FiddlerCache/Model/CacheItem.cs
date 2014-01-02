using Easygoing.FiddlerCache.Util;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Model
{
    public class CacheItem
    {
        public string Url { get;  set; }
        public string Local { get;  set; }
        public Dictionary<string, string> ResponseHeaders { get;  set; }

        public CacheItem()
        {
            Url = string.Empty;
            Local = string.Empty;
            ResponseHeaders = new Dictionary<string, string>();
        }

        public CacheItem(Session session, string dir)
        {
            Local = FileUtil.ReserveUriLocal(session.fullUrl, dir);
            ResponseHeaders = new Dictionary<string, string>();
            foreach (var item in session.oResponse.headers)
            {
                Debug.WriteLine(item.GetType());
                
            }
        }

        public void SetSessionResponse(Session oSession)
        {
            foreach (var item in ResponseHeaders)
            {
                oSession.oResponse.headers[item.Key] = item.Value;
            }
        }

   

    }
}
