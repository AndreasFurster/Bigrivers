using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bigrivers.Client.Backend.Controllers
{
    public class StageController : Controller
    {
        // GET: Stage
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stage/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stage/Create
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

        // GET: Stage/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stage/Edit/5
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

        // GET: Stage/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stage/Delete/5
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
