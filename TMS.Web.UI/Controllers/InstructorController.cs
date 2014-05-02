using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Helpers;
using TMS.Web.UI.Service;
using WebGrease.Css.Extensions;

namespace TMS.Web.UI.Controllers
{
  public class InstructorController : CustomController<Instructor>
  {
    private readonly IWebService<Instructor> _instructorWebService;
    private readonly IWebService<Course> _courseWebService;
    private readonly IWebService<Country> _countryWebService;
    private readonly IWebService<User> _userWebService;

    public InstructorController(IWebService<Instructor> instructorWebService, IWebService<Course> courseWebService, IWebService<Country> countryWebService, IWebService<User> userWebService) : base(instructorWebService)
    {
      _instructorWebService = instructorWebService;
      _courseWebService = courseWebService;
      _countryWebService = countryWebService;
      _userWebService = userWebService;
    }

    //
    // GET: /Instructor/Details/5

    public ActionResult Details(string id)
    {
      Instructor instructor = _instructorWebService.Get(id);
      if (!string.IsNullOrWhiteSpace(instructor.Country))
        ViewBag.Country = _countryWebService.Get(instructor.Country);
      if (!string.IsNullOrWhiteSpace(instructor.ReferredBy))
        ViewBag.User = _userWebService.Get(instructor.ReferredBy);
      if (instructor.Courses != null && instructor.Courses.Any())
      {
        List<Course> courses = new List<Course>();
        instructor.Courses.ForEach(x => courses.Add(_courseWebService.Get(x.CourseId)));
        ViewBag.Courses = courses;
      }
      return View(instructor);
    }

    //
    // GET: /Instructor/Create

    public ActionResult Create()
    {
      ViewBag.Countries = _countryWebService.Get((int?)null);
      ViewBag.Users = _userWebService.Get((int?)null);
      return View(new Instructor());
    }

    //
    // POST: /Instructor/Create

    [HttpPost]
    public ActionResult CreateInstructor(Instructor collection)
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

    [HttpPut]
    public ActionResult UpdateInstructor(Instructor collection)
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
    // GET: /Instructor/Edit/5

    public ActionResult Edit(string id)
    {
      Instructor instructor = _instructorWebService.Get(id);
      ViewBag.Countries = _countryWebService.Get((int?)null);
      ViewBag.Users = _userWebService.Get((int?)null);
      if (instructor.Courses != null && instructor.Courses.Any())
      {
        List<Course> courses = new List<Course>();
        instructor.Courses.ForEach(x => courses.Add(_courseWebService.Get(x.CourseId)));
        ViewBag.Courses = courses;
      }

      return View(instructor);
    }

    //public ActionResult Search(string searchString)
    //{
    //  ViewBag.Instructors = _instructorWebService.Search(searchString);
    //  return View("Index");
    //}

    public ActionResult AddInstructorToCourse()
    {
      ViewBag.Instructors = _instructorWebService.Get((int?) null);
      return View();
    }

    //public ActionResult Enable(string id)
    //{
    //  Instructor instructor = _instructorWebService.Get(id);
    //  instructor.Status = Status.Active;
    //  _instructorWebService.Update(instructor);
    //  return null;
    //}

    //public ActionResult Delete(string id)
    //{
    //  _instructorWebService.Delete(id);
    //  return null;
    //}

    //public ActionResult Disable(string id)
    //{
    //  Instructor instructor = _instructorWebService.Get(id);
    //  instructor.Status = Status.Inactive;
    //  _instructorWebService.Update(instructor);
    //  return null;
    //}
    public ActionResult CourseDetails()
    {
      ViewBag.Courses = _courseWebService.Get((int?) null)
        .Select(course => new SelectListItem
        {
          Value = course.Id,
          Text = string.Format("Title: {0}, Duration: {1} days", course.Title, course.Duration.ConvertToString(string.Empty))
        });

      return View();
    }

    public ActionResult CertificationDetails()
    {
      return View();
    }
  }
}
