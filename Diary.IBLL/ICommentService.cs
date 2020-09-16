using Diary.Bussiness.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface ICommentService : IBaseService<CreateOrUpdateCommentDto, CommentDto, CreateOrUpdateCommentDto>
    {
        Task<List<CommentDto>> GetListAsync(Guid id);
    }
}
