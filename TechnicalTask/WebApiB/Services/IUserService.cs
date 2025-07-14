using Models;
using WebApiB.Dtos;

namespace WebApiB.Services;

public interface IUserService
{
    Task SaveUserAsync(User user);
    Task<IEnumerable<UserGetDto>> GetAllUsersAsync();
}
