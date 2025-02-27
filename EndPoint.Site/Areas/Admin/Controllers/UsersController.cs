using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Store.Application.Services.Users.Queries.GetRoles;
using Store.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers;

[Area("Admin")]
public class UsersController : Controller
{
    private readonly IGetUsersService _getUsersService;
    private readonly IGetRolesService _getRolesService;

    public UsersController(IGetUsersService getUsersService, IGetRolesService getRolesService)
    {
        _getUsersService = getUsersService;
        _getRolesService = getRolesService;
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
        ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");
        return View();
    }
    
}