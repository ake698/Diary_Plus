using Diary.Bussiness.Dtos.Diary;
using Diary.IBLL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Diary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;

        public DiaryController(IDiaryService diaryService)
        {
            _diaryService = diaryService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiary(CreateOrUpdateDiaryDto input)
        {
            return Ok(await _diaryService.CreateAsync(input));
        }


        [HttpGet]
        public async Task<IActionResult> GetDiaryList()
        {
            return Ok(await _diaryService.GetListAsync());
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiary(Guid id)
        {
            return Ok(await _diaryService.GetAsync(id));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _diaryService.DeleteAsync(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CreateOrUpdateDiaryDto input)
        {
            return Ok(await _diaryService.UpdateAsync(id, input));
        }
    }
}
