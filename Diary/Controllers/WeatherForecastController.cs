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
        private readonly ICategoryService _categoryService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUserService userService, ICategoryService categoryService)
        {
            _logger = logger;
            _userService = userService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _categoryService.GetAsync(System.Guid.NewGuid());
            return new string[] { "hello", "world" };
            
        }
        [HttpGet("/t")]
        public IActionResult Get1()
        {
            return BadRequest("fff");
        }

    }
}
