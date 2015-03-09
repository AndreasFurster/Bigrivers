using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contactgegevens.";

            return View();
        }

        public ActionResult Overzicht()
        {
            ViewBag.Message = "Overzicht van doorlinkpagina's.";

            return View();
        }
    }
}