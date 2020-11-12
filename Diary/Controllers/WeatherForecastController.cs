using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Diary.Bussiness;
using Diary.Bussiness.Dtos;
using Diary.Bussiness.Dtos.User;
using Diary.IBLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        private readonly TokenOptions _tokenOptions;
        private readonly ICategoryService _categoryService;
        private readonly ITokenService _tokenService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOptions<TokenOptions> options,
            ICategoryService categoryService, ITokenService tokenService)
        {
            _logger = logger;
            _tokenOptions = options.Value;
            _categoryService = categoryService;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _categoryService.GetAsync(System.Guid.NewGuid());
            return new string[] { "hello", "world" };
            
        }

        [Authorize]
        [HttpGet("/t")]
        public IActionResult Get1()
        {
            var token = _tokenService.DecodeJwt(Request.Headers["Authorization"]);
            return Ok(token);
        }

        [HttpGet("/t2")]
        public IActionResult Get2()
        {
            var user = new UserDto()
            {
                Id = Guid.NewGuid(),
                Email = "aaa@aaa.com",
            };
            var token = _tokenService.CreateJwt(user);
            return Ok(token);
        }

    }
}
