using WebApiA.Dtos;

namespace WebApiA.Services;

public interface IUserService
{
    void CreateUser(UserCreateDto userDto);
}
