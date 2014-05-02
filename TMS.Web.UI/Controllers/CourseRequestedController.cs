using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Helpers;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
    public class CourseRequestedController : Controller
    {
      private readonly IWebService<Course> _courseWebService;

      public CourseRequestedController(WebService<Course> courseWebService)
      {
        _courseWebService = courseWebService;
      }

      //
        // GET: /CourseRequested/

        public ActionResult Index()
        {
          IEnumerable<SelectListItem> courses =
            _courseWebService.Get((int?) null)
              .Select(course => new SelectListItem
                  {
                    Value = course.Id,
                    Text = string.Format("Title: {0}, Duration: {1} days, Price: ${2}", course.Title, course.Duration, course.Price.ToCurrencyString())
                  });
          ViewBag.Courses = courses;
          return View();
        }

        //
        // GET: /CourseRequested/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /CourseRequested/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /CourseRequested/Create

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
        // GET: /CourseRequested/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /CourseRequested/Edit/5

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
        // GET: /CourseRequested/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /CourseRequested/Delete/5

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
