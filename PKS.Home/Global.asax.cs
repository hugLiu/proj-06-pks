using Jurassic.WebFrame;
using Ninject;
using PKS.Home.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using static PKS.Home.HomeReg;

namespace PKS.Home
{
    public class MvcApplication :Jurassic.WebFrame.MvcApplication
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
            GlobalConfiguration.Configure(HomeApiConfig.Register);
            base.Application_Start();
        }

        protected override void AddBindings(IKernel kernel)
        {
            base.AddBindings(kernel);
            kernel.Bind<TokenService>().ToSelf().InSingletonScope();
        }
    }
}
