namespace Store.Application.Services.Users.Queries.GetUsers;

public interface IGetUsersService
{
    List<GetUsersDto> Execute(RequestGetUserDto request);
}