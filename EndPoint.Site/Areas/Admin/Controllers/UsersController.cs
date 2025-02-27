using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    private readonly IGetUsersService _getUsersService;

    public UsersController(IGetUsersService getUsersService)
    {
        _getUsersService = getUsersService;
    }

    // GET
    // in fact this method we should return ViewModel. not Dto
    public IActionResult Index(string searchKey, int page = 1)
    {
        return View(_getUsersService.Execute(new RequestGetUserDto
        {
            Page = page,
            SearchKey = searchKey
        }));
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
}