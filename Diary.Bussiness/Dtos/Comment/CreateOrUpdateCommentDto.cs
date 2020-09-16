using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diary.Bussiness.Dtos.Comment
{
    public class CreateOrUpdateCommentDto
    {
        [Required, MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public Guid DiaryId { get; set; }
    }
}
