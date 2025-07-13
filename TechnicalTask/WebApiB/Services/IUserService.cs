using Models;
using WebApiB.Dtos;
//using WebApiB.Entities;

namespace WebApiB.Services;

public interface IUserService
{
    Task SaveUserAsync(User user);
    Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
}
