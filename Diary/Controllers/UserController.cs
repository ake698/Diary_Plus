using System.Threading.Tasks;
using Diary.Bussiness.Dtos;
using Diary.IBLL;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            await _userService.Login(email, password);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto input)
        {
            var result = await _userService.CreateAsync(input);
            return Ok(result);
        }
    }
}