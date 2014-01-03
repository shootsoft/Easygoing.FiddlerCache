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
    [Serializable]
    public class CacheItem
    {
        public string Url { get;  set; }
        public string Local { get;  set; }
        public DateTime Creation { get; set; }
        public long Length { get; set; }
        public Dictionary<string, string> ResponseHeaders { get;  set; }

        public CacheItem()
        {
            Url = string.Empty;
            Local = string.Empty;
            ResponseHeaders = new Dictionary<string, string>();
            Creation = DateTime.Now;
        }

        public CacheItem(Session session, string dir)
        {
            Url = session.fullUrl;
            
            Local = FileUtil.ReserveUriLocal(session.fullUrl, dir, session.oResponse.MIMEType);
            ResponseHeaders = new Dictionary<string, string>();
            Creation = DateTime.Now;
            
            session.utilDecodeResponse();
            Length = session.responseBodyBytes.LongLength;
            foreach (Fiddler.HTTPHeaderItem item in session.oResponse.headers)
            {
                ResponseHeaders[item.Name]= item.Value;
            }
            
            FileInfo fi = new FileInfo(Local);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            
            File.WriteAllBytes(Local, session.responseBodyBytes);
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
