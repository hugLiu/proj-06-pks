using Jurassic.WebFrame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PKS.KnowledgeBank.Controllers
{
    public class MainPageController : BaseController
    {
        public ActionResult index()
        {
            return View();
        }
    }
}