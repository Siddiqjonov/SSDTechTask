using WebApiA.Dtos;

namespace WebApiA.Services;

public interface IUserService
{
    Task CreateUser(UserCreateDto userDto);
}
