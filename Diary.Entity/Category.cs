using System.ComponentModel.DataAnnotations;

namespace Diary.Entity
{
    public class Category : BaseEntity
    {
        [Required, StringLength(100)]
        public string Title { get; set; }

    }
}
