using Easygoing.FiddlerCache.Controller;
using Fiddler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easygoing.FiddlerCache.Plugin
{
    public class FiddlerPlugin : IAutoTamper, IDisposable
    {
        protected CacheManagerController cacheController;

        public void AutoTamperRequestAfter(Session oSession)
        {

        }

        public void AutoTamperRequestBefore(Session oSession)
        {
            if (cacheController != null)
            {
                cacheController.Filter(oSession);
            }
        }

        public void AutoTamperResponseAfter(Session oSession)
        {

        }

        public void AutoTamperResponseBefore(Session oSession)
        {

        }

        public void OnBeforeReturningError(Session oSession)
        {

        }

        public void OnBeforeUnload()
        {
            if (cacheController != null)
            {
                cacheController.Dispose();
            }
        }

        public void OnLoad()
        {
            cacheController = new CacheManagerController();
            cacheController.BindFiddler();
            cacheController.BindFiddlerMenu();

        }

        public void Dispose()
        {
            
        }
    }
}
