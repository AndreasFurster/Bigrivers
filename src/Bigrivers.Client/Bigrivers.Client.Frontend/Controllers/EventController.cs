using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/
        public ActionResult Index()
        {
            ViewBag.Message = "Event Controller pagina test";

            return View();
        }
	}
}