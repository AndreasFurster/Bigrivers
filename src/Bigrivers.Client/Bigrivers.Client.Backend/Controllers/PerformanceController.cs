using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bigrivers.Client.Backend.Controllers
{
    public class PerformanceController : Controller
    {
        // GET: Performance
        public ActionResult Index()
        {
            return View();
        }

        // GET: Performance/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Performance/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Performance/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Performance/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Performance/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Performance/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
