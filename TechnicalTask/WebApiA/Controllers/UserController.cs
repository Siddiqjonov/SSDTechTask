using Microsoft.AspNetCore.Mvc;
using WebApiA.Dtos;
using WebApiA.Services;

namespace WebApiA.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public void Create(UserCreateDto userDto)
        {
            _userService.CreateUser(userDto);
        }
    }
}
