using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diary.Bussiness.Dtos.Diary
{
    public class CreateOrUpdateDiaryDto
    {
        [Required, MaxLength(200)]
        public string Title { get; set; }
        [Required, MaxLength(2000)]
        public string Content { get; set; }

        [Required]
        public bool IsPublic { get; set; } = true;

        public Guid CategoryId { get; set; }
    }

}
