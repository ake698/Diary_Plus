using Diary.Bussiness.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos.Comment
{
    public class CommentDto : BaseReturnDto
    {
        public string Content { get; set; }

        public UserDto Creater { get; set; }

        public Guid DiayId { get; set; }
    }
}
