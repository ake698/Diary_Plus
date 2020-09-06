using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Diary.Bussiness.Dtos.Category
{
    public class CreateOrUpdateCategoryDto
    {
        [Required]
        [MaxLength(200)]
        [MinLength(2)]
        public string Title { get; set; }
    }

}
