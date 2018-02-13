using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PKS.KnowledgeBank
{
    public class MvcApplication : Jurassic.WebFrame.MvcApplication
    {
        protected override IEnumerable<string> ControllerNameSpaces
        {
            get
            {
                var ns = base.ControllerNameSpaces.Union(new string[] { "PKS.WebLayout" });
                return ns;
            }
        }

        protected override void Application_Start()
        {
            base.Application_Start();
        }
    }
}
