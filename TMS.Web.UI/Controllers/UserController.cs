using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class UserController : CustomController<User>
  {
    private readonly IWebService<User> _userWebService;

    public UserController(IWebService<User> userWebService) : base(userWebService)
    {
      _userWebService = userWebService;
    }

    public override ActionResult Index()
    {
      ViewBag.
      return base.Index();
    }

    //
    // GET: /User/Details/5

    public ActionResult Details(string id)
    {
      return View(_userWebService.Get(id));
    }

    //
    // GET: /User/Create

    public ActionResult Create()
    {
      return View(new User());
    }

    //
    // POST: /User/Create

    [HttpPost]
    public ActionResult CreateUser(User user)
    {
      try
      {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch
      {
        return View("Create", user);
      }
    }

    //
    // GET: /User/Edit/5

    public ActionResult Edit(string id)
    {
      return View(_userWebService.Get(id));
    }

    //
    // POST: /User/Edit/5

    [HttpPost]
    public ActionResult EditUser(string id)
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
  }
}
