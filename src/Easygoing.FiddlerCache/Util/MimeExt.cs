using System;
using System.Collections.Generic;



namespace Easygoing.FiddlerCache.Util
{
    public class MimeExt
    {
        public static Dictionary<string, string> MIME
            = new Dictionary<string, string>();

        static MimeExt()
        {
            MIME["video/x-msvideo"] = ".avi";
            MIME["audio/x-aiff"] = ".aif";
            MIME["audio/basic"] = ".au";
            MIME["application/postscript"] = ".ai";
            MIME["application/astound"] = ".asd";
            MIME["application/octet-stream"] = ".bin";
            MIME["application/x-macbinary"] = ".bin";
            MIME["text/comma-separated-values"] = ".csv";
            MIME["text/css"] = ".css";
            MIME["application/acad"] = ".dwg";
            MIME["application/dxf"] = ".dxf";
            MIME["application/x-director"] = ".dcr";
            MIME["application/msword"] = ".doc";
            MIME["application/gzip"] = ".gz";
            MIME["image/gif"] = ".gif";
            MIME["application/mshelp"] = ".hlp";
            MIME["text/xml"] = ".xml";
            MIME["text/html"] = ".html";
            MIME["text/javascript"] = ".js";
            MIME["image/jpeg"] = ".jpeg";
            MIME["video/mpeg"] = ".mpeg";
            MIME["audio/mpeg"] = ".mp3";
            MIME["video/quicktime"] = ".qt";
            MIME["application/msaccess"] = ".mdb";
            MIME["application/mspowerpoint"] = ".ppt";
            MIME["application/pdf"] = ".pdf";
            MIME["application/octet-stream"] = ".rar";
            MIME["application/rtf"] = ".rtf";
            MIME["text/richtext"] = ".rtx";
            MIME["audio/x-pn-realaudio"] = ".ram";
            MIME["application/vnd.rn-realmedia"] = ".rm";
            MIME["application/x-shockwave-flash"] = ".swf";
            MIME["text/plain"] = ".txt";
            MIME["application/msexcel"] = ".xls";
            MIME["application/x-compress"] = ".z";
            MIME["application/x-zip-compressed"] = ".zip";

        }
    }
}