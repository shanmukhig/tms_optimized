using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TMS.Web.UI.Controllers
{
    public class BestTimeToContactController : Controller
    {
        //
        // GET: /BestTimeToContact/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /BestTimeToContact/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /BestTimeToContact/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /BestTimeToContact/Create

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

        //
        // GET: /BestTimeToContact/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /BestTimeToContact/Edit/5

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

        //
        // GET: /BestTimeToContact/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /BestTimeToContact/Delete/5

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
