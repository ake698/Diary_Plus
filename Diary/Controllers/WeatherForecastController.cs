using System.Collections.Generic;
using System.Threading.Tasks;
using Diary.Bussiness.Dtos;
using Diary.IBLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Diary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IUserService _userService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hello", "world" };
        }
        [HttpGet("/t")]
        public IActionResult Get1()
        {
            return Ok("fff");
        }

        [HttpPost("register")]
        public async Task<IActionResult> Post(CreateUserDto input)
        {
            await _userService.Register(input);
            return Ok();
        }
    }
}
