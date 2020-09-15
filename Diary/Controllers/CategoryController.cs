using System;
using System.Threading.Tasks;
using Diary.Bussiness.Dtos.Category;
using Diary.IBLL;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _categoryService.GetAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _categoryService.GetListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateOrUpdateCategoryDto input)
        {
            var result = await _categoryService.CreateAsync(input);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _categoryService.DeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody]CreateOrUpdateCategoryDto input)
        {
            return Ok(await _categoryService.UpdateAsync(id, input));
        }
    }
}
