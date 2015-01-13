using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bigrivers.Client.DAL.Bigrivers.Server.Model;
using Bigrivers.Client.DAL.Default;

namespace Bigrivers.Client.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        // Create AccessLayer with Uri from the App.Config
        static readonly Container AccessLayer = new Container(new Uri(ConfigurationManager.AppSettings["WebserviceUri"]));

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events()
        {
            ViewBag.EventList = AccessLayer.Events
                .Expand(e => e.Location)
                .Where(e => e.Status)
                .ToList();

            return View();
        }

        public ActionResult Event(int? id)
        {
            if (id == null) return RedirectToAction("Events");

            Event currentEvent = AccessLayer.Events
                .Where(e => e.Id == id)
                .SingleOrDefault();

            ViewBag.CurrentEvent = currentEvent;

            if (currentEvent == null) return Redirect(Request.UrlReferrer.ToString());

            ViewBag.PerformancesList = AccessLayer.Performances
                .Expand(p => p.Artist)
                .Where(p => p.Event.Id == currentEvent.Id)
                .ToList();

            return View();
        }

        public ActionResult Optredens()
        {
            ViewBag.PerformancesList = AccessLayer.Performances
                .Where(p => p.Status)
                .OrderBy(p => p.Start)
                .ToList();

            return View();
        }

        public ActionResult Optreden(int? id)
        {
            if (id == null) return RedirectToAction("Optredens");
            throw new NotImplementedException();
        }

        public ActionResult Genre(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Artiest(int id)
        {
            throw new NotImplementedException();
        }
    }
}