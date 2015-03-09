using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/
        public ActionResult Index()
        {
            ViewBag.Message = "Page Controller pagina test";

            return View();
        }
	}
}