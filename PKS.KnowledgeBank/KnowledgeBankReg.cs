using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Web.Routing;
using System.Web.Mvc;

namespace PKS.KnowledgeBank
{
    /// <summary>
    /// 注册主页的路由，替换掉框架原有的主页
    /// </summary>
    public class KnowledgeBankReg : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "KnowledgeBank";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "MainPage", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}