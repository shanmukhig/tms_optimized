using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  [AllowAnonymous]
  public class CourseController : CustomController<Course>
  {
    private readonly IWebService<Course> _courseWebService;

    public CourseController(IWebService<Course> courseWebService, IWebService<Instructor> instructorWebService)
      : base(courseWebService)
    {
      ViewBag.Instructors = instructorWebService.Get((int?) null);
      _courseWebService = courseWebService;
    }

    public ActionResult AddCourseTopic(string time, int cid)
    {
      ViewBag.Time = time;
      ViewBag.Cid = cid;
      return View();
    }

    //
    // GET: /Course/Details/5

    public ActionResult Details(string id)
    {
      return View(_courseWebService.Get(id));
    }

    //
    // GET: /Course/Create

    public ActionResult Create()
    {
      return View(new Course());
    }

    //
    // POST: /Course/Create

    [HttpPost]
    public ActionResult CreateCourse(Course course)
    {
      try
      {
        _courseWebService.Create(course);
        return null;
      }
      catch
      {
        return View("Create", course);
      }
    }

    //
    // GET: /Course/Edit/5

    public ActionResult Edit(string id)
    {
      return View("Edit", _courseWebService.Get(id));
    }

    //
    // POST: /Course/Edit/5

    [HttpPost]
    public ActionResult EditCourse(Course course)
    {
      try
      {
        _courseWebService.Update(course);
        return null;
      }
      catch
      {
        return View("Edit", course);
      }
    }
  }
}
