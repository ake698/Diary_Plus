using System.ComponentModel.DataAnnotations;

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
