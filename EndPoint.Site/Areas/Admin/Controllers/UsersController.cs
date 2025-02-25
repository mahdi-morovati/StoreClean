using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Areas.Admin.Controllers;

public class UsersController : Controller
{
    // GET
    [Area("Admin")]
    public IActionResult Index()
    {
        return View();
    }
}