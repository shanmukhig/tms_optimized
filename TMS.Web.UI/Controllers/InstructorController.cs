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
    private readonly IuserExtentions _userExtentions;

    public InstructorController(IWebService<Instructor> instructorWebService, IWebService<Course> courseWebService, IWebService<Country> countryWebService, IuserExtentions userExtentions) : base(instructorWebService)
    {
      _instructorWebService = instructorWebService;
      _courseWebService = courseWebService;
      _countryWebService = countryWebService;
      _userExtentions = userExtentions;
    }

    //
    // GET: /Instructor/Details/5

    public override ActionResult Details(string id)
    {
      Instructor instructor = _instructorWebService.Get(id);
      
      if (!string.IsNullOrWhiteSpace(instructor.Country))
        ViewBag.Country = _countryWebService.Get(instructor.Country);

      List<string> userIds = new List<string>();
      
      if(!string.IsNullOrWhiteSpace(instructor.ReferredBy))
        userIds.Add(instructor.ReferredBy);
      
      if (instructor.Payments != null && instructor.Payments.Any())
        instructor.Payments.ForEach(x => userIds.Add(x.PaymentMadeBy));

      ViewBag.Details = _userExtentions.GetUserDetails(userIds);

      SetupCourse(instructor);
      return View(instructor);
    }

    //
    // GET: /Instructor/Create

    public override ActionResult Create()
    {
      SetupCreateEdit();
      return View(new Instructor());
    }

    private void SetupCreateEdit()
    {
      ViewBag.Countries = _countryWebService.Get((int?)null);
      ViewBag.Details = _userExtentions.GetUserDetails();
    }

    private void SetupCourse(Instructor instructor)
    {
      if (instructor.Courses != null && instructor.Courses.Any())
      {
        List<Course> courses = new List<Course>();
        foreach (CourseExperience courseExperience in instructor.Courses)
        {
          if (courses.Any(x => x.Id == courseExperience.CourseId))
            continue;
          courses.Add(_courseWebService.Get(courseExperience.CourseId));
        }
        ViewBag.Courses = courses;
      }
    }

    [HttpPost]
    public override ActionResult Create(Instructor instructor)
    {
      try
      {
        _instructorWebService.Create(instructor);
        return null;
      }
      catch
      {
        return View("Create", instructor);
      }
    }

    [HttpPost]
    public override ActionResult Edit(Instructor instructor)
    {
      try
      {
        _instructorWebService.Update(instructor);
        return null;
      }
      catch
      {
        return View("Edit", instructor);
      }
    }

    //
    // GET: /Instructor/Edit/5

    public override ActionResult Edit(string id)
    {
      Instructor instructor = _instructorWebService.Get(id);
      SetupCreateEdit();
      SetupCourse(instructor);
      return View(instructor);
    }

    public ActionResult AddInstructorToCourse()
    {
      ViewBag.Instructors = _instructorWebService.Get((int?) null);
      return View();
    }

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

    public ActionResult PaymentsMade()
    {
      ViewBag.Details = _userExtentions.GetUserDetails();
      return View(new PaymentsMade());
    }
  }
}
