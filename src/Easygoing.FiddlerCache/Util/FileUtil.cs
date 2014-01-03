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

        public static string ReserveUriLocal(string url, string dir, string mime)
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
                path = FileUtil.Format(uri.AbsolutePath).Substring(1);
                if(path==string.Empty || path.EndsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    path += "index.html";
                }
                path = Path.Combine(dir, uri.Scheme, host, path);
                FileInfo fi = new FileInfo(path);
                string ext = fi.Extension;
                if (string.IsNullOrEmpty(ext))
                {
                    if(mime==null)
                    {
                        mime = string.Empty;
                    }
                    mime=mime.Trim().ToLower();
                    if (MimeExt.MIME.ContainsKey(mime))
                    {
                        ext = MimeExt.MIME[mime];
                    }
                    else
                    {
                        ext = ".cache";
                    }
                }
                string filename = fi.Name;
                if (uri.Query.Length > 0)
                {
                    filename += "_" + uri.Query.Substring(1) + ext;
                    filename = FileUtil.Format(filename);
                }
                if (filename.Length > 128)
                { 
                    filename = FileUtil.MD5(url) + ext;
                } 
                path = Path.Combine(fi.DirectoryName, filename);

            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex);
            }
            return path;
        }

        public static string MD5(string url)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(url,
                "MD5");
        }


        const long KBYTE = 1024;
        const long MBYTE = 1024 * 1024;
        const long GBYTE = 1024 * 1024 * 1024;

        const double DKBYTE = 1024;
        const double DMBYTE = 1024 * 1024;
        const double DGBYTE = 1024 * 1024 * 1024;

        public static string FormatLength(long length)
        {
            if (length < KBYTE)
            {
                return length.ToString("0 byte");
            }
            else if (length < MBYTE && length > KBYTE)
            { 
                return (length / DKBYTE).ToString("0.00 KB");
            }
            else if (length < GBYTE && length > MBYTE)
            {
                return (length / DMBYTE).ToString("0.00 MB");
            } 
            else
            {
                return (length / DGBYTE).ToString("0.00 GB");
            }
        }

    }
}
