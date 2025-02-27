namespace Store.Application.Services.Users.Queries.GetUsers;

public interface IGetUsersService
{
    ResultGetUserDto Execute(RequestGetUserDto request);
}