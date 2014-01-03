using Easygoing.FiddlerCache.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Tests
{
    [TestFixture]
    public class UtilTests
    {

        [Test]
        public void TestName()
        {
            TestRun("___", @"|?*");
            TestRun("\\__", @"\?*");
            TestRun("_\\_", @"|/*");
            TestRun("___", @"<>*");
            TestRun("_\\_\\__", @":\|/?*");
            TestRun("____", "\"|?*");

        }


        public void TestRun(string expected, string name)
        {
            string actual = FileUtil.Format(name);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestReserveUriLocal()
        {
            string url = "http://smsapi.micloud.xiaomi.net/mic/sms/v2/user/24018380/bindId/7275085/full?syncTag=ooOlttAlhNkcuP7KQvaQm0oe%2Bvgq2WWnK0k7LcP3Wdg%3D&limit=J73iwc%2BZDLnGZ0a7l3EirA%3D%3D&signature=t951reXtMK59km2r49ZuhVsJ8dw%3D";
            string expected = @"c:\http\smsapi.micloud.xiaomi.net\mic\sms\v2\user\24018380\bindId\7275085\B60E0A663A61F230124B478C328CBEEC.cache";
            Debug.WriteLine(FileUtil.ReserveUriLocal(url, "c:\\", ""));
            Assert.AreEqual(expected, FileUtil.ReserveUriLocal(url, "c:\\", ""));
            Assert.AreEqual(expected, FileUtil.ReserveUriLocal(url, "c:", ""));


            url = "http://fm.baidu.com/static/flash/fmp_mp3.swf?_t=1388689382975?_m3_0_0.9295997833714762";
            expected = @"c:\http\fm.baidu.com\static\flash\fmp_mp3.swf__t=1388689382975__m3_0_0.9295997833714762.swf";
            Debug.WriteLine(FileUtil.ReserveUriLocal(url, "c:\\", ".http"));
            Assert.AreEqual(expected, FileUtil.ReserveUriLocal(url, "c:\\", ".http"));
            Assert.AreEqual(expected, FileUtil.ReserveUriLocal(url, "c:", ".http"));
            

        }
    }
}
