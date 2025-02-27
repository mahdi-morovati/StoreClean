using Store.Application.Interfaces.Contexts;
using Store.Common;

namespace Store.Application.Services.Users.Queries.GetUsers;

public class GetUserService : IGetUsersService
{
    private readonly IDatabaseContext _context;

    public GetUserService(IDatabaseContext context)
    {
        _context = context;
    }

    public ResultGetUserDto Execute(RequestGetUserDto request)
    {
        var users = _context.Users.AsQueryable();
        if (!string.IsNullOrWhiteSpace(request.SearchKey))
        {
            users = users.Where(p => p.FullName.Contains(request.SearchKey) && p.Email.Contains(request.SearchKey));
        }

        int rowsCount = 0;
        var usersList = users.ToPaged(request.Page, 20, out rowsCount).Select(q => new GetUsersDto
        {
            Email = q.Email,
            FullName = q.FullName,
            Id = q.Id,
        }).ToList();

        return new ResultGetUserDto
        {
            Rows = rowsCount,
            Users = usersList
        };
    }
}