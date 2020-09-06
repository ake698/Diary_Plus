using Diary.Bussiness.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.IBLL
{
    public interface ICommentService : IBaseService<CreateOrUpdateCommentDto, CommentDto, CreateOrUpdateCommentDto>
    {
    }
}
