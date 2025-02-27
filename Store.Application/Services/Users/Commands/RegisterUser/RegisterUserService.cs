using Store.Application.Interfaces.Contexts;
using Store.Common.Dto;
using Store.Common.Messages;
using Store.Domain.Entities.Users;

namespace Store.Application.Services.Users.Commands.RegisterUser;

public class RegisterUserService : IRegisterUserService
{
    private readonly IDatabaseContext _context;

    public RegisterUserService(IDatabaseContext context)
    {
        _context = context;
    }

    public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
    {
        User user = new User()
        {
            Email = request.Email,
            FullName = request.FullName
        };

        List<UserInRole> userInRoles = new List<UserInRole>();
        foreach (var item in request.Roles)
        {
            var role = _context.Roles.Find(item.Id);
            userInRoles.Add(new UserInRole
            {
                Role = role,
                RoleId = role.Id,
                User = user,
                UserId = user.Id
            });
        }

        user.UserInRoles = userInRoles;
        _context.Users.Add(user);
        _context.SaveChanges();

        return new ResultDto<ResultRegisterUserDto>()
        {
            Data = new ResultRegisterUserDto()
            {
                UserId = user.Id,
            },
            IsSuccess = true,
            Message = ResponseMessages.RegisterOk
        };
    }
}