using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Diary.IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _categoryService.GetAsync(id));
        }
    }
}
