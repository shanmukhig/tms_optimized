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

    public override ActionResult Details(string id)
    {
      return View(_courseWebService.Get(id));
    }

    //
    // GET: /Course/Create

    public override ActionResult Create()
    {
      return View(new Course());
    }

    [HttpPost]
    public override ActionResult Create(Course course)
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

    public override ActionResult Edit(string id)
    {
      return View("Edit", _courseWebService.Get(id));
    }

    [HttpPost]
    public override ActionResult Edit(Course course)
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
