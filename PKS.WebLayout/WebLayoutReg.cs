using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Web.Routing;
using System.Web.Mvc;

namespace PKS.WebLayout
{
    /// <summary>
    /// 注册主页的路由，替换掉框架原有的主页
    /// </summary>
    public class WebLayoutReg : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WebLayout";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}