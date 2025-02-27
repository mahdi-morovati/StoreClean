using Microsoft.AspNetCore.Mvc;
using Store.Application.Services.Users.Queries.GetUsers;

namespace EndPoint.Site.Areas.Admin.Controllers;

public class UsersController : Controller
{
    private readonly IGetUsersService _getUsersService;

    public UsersController(IGetUsersService getUsersService)
    {
        _getUsersService = getUsersService;
    }

    // GET
    // in this method we should return ViewModel. not Dto
    [Area("Admin")]
    public IActionResult Index(string searchKey, int page = 1)
    {
        return View(_getUsersService.Execute(new RequestGetUserDto
        {
            Page = page,
            SearchKey = searchKey
        }));
    }
}