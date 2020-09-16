using System;
using System.Threading.Tasks;
using Diary.Bussiness.Dtos.Comment;
using Diary.IBLL;
using Microsoft.AspNetCore.Mvc;

namespace Diary.Controllers
{
    [Route("api/diary/{id}/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetDiaryComments(Guid id)
        {
            var result = await _commentService.GetListAsync(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Guid id, CreateOrUpdateCommentDto input)
        {
            var result = await _commentService.CreateAsync(input);
            return Ok(result);
        }
    }
}