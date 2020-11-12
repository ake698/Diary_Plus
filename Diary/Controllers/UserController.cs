using System;
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
        private readonly ITokenService _tokenService;

        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]string email, string password)
        {
            var user = await _userService.Login(email, password);
            var token = _tokenService.CreateJwt(user);
            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserDto input)
        {
            var result = await _userService.CreateAsync(input);
            return Ok(result);
        }
    }
}