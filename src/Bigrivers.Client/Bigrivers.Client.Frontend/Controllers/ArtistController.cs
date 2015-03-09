using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigRivers.Client.Frontend.Controllers
{
    public class ArtiestenController : Controller
    {
        //
        // GET: /Artist/
        public ActionResult Index()
        {
            ViewBag.Message = "Artist Controller pagina test";
            
            return View();
        }
       
	}
}