using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PKS.Home.Controllers
{
    public class StartController : BaseController
    {
        // GET: Start
        public ActionResult Index()
        {
            return View();
        }
    }
}