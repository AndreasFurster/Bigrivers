using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class PodiumController : Controller
    {
        //
        // GET: /Podium/
        public ActionResult Index()
        {
            ViewBag.Message = "Podium Controller pagina test";

            return View();
        }
	}
}