using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class PerformanceController : Controller
    {
        //
        // GET: /Performance/
        public ActionResult Index()
        {
            ViewBag.Message = "Performance Controller pagina test";

            return View();
        }
	}
}