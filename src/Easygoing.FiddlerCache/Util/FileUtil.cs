using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easygoing.FiddlerCache.Util
{
    public class FileUtil
    {
        public static Regex RegexFilename = null;
        public static Regex RegexPath = null;

        static FileUtil() 
        {
            RegexFilename = new Regex("[:\\*\\?\\\"\\<\\>|]");
            RegexPath = new Regex(@"[\\\/]");
        }

        public static string Format(string filePath)
        {
            string name = RegexPath.Replace(filePath, System.IO.Path.DirectorySeparatorChar.ToString());
            name = RegexFilename.Replace(name, "_");
            return name;
        }

        public static string ReserveUriLocal(string url, string dir)
        {
            string path = string.Empty;
            try
            {
                Uri uri = new Uri(url);
                string scheme = uri.Scheme;
                string host = uri.Host;
                if(uri.Port!=80)
                {
                    host += "_" + uri.Port;
                }
                if (dir.EndsWith(":")) { dir += Path.DirectorySeparatorChar; }                
                path = Path.Combine(dir, uri.Scheme, host , FileUtil.Format(uri.PathAndQuery).Substring(1)
                    
                    );

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            return path;
        }

    }
}
