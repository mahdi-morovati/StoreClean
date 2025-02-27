using Store.Common.Dto;

namespace Store.Application.Services.Users.Commands.RegisterUser;

public interface IRegisterUserService
{
    ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request);
}