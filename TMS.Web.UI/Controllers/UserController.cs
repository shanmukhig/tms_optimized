using System.Web.Mvc;
using TMS.Entities;
using TMS.Web.UI.Service;

namespace TMS.Web.UI.Controllers
{
  public class UserController : CustomController<User>
  {
    private readonly IWebService<User> _userWebService;
    //private readonly IuserExtentions _userExtentions;

    public UserController(IWebService<User> userWebService, IuserExtentions userExtentions) : base(userWebService, userExtentions)
    {
      _userWebService = userWebService;
      //_userExtentions = userExtentions;
    }

    //public override ActionResult Index()
    //{
    //  //ViewBag.Details = _userExtentions.GetUserDetails(ViewBag.Users as IEnumerable<User>);
    //  return base.Index();
    //}

    //
    // GET: /User/Details/5

    public override ActionResult Details(string id)
    {
      return View(_userWebService.Get(id));
    }

    //
    // GET: /User/Create

    public override ActionResult Create()
    {
      return View(new User());
    }

    [HttpPost]
    public override ActionResult Create(User user)
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

    public override ActionResult Edit(string id)
    {
      return View(_userWebService.Get(id));
    }

    //
    // POST: /User/Edit/5

    [HttpPost]
    public override ActionResult Edit(User id)
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
