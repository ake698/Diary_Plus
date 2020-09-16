using System.ComponentModel.DataAnnotations;

namespace Diary.Entity
{
    public class User : BaseEntity
    {
        [Required, StringLength(40)]
        public string Email { get; set; }
        [Required, StringLength(30)]
        public string Password { get; set; }
        [Required, StringLength(300)]
        public string AvatarPath { get; set; }
        public int FansCount { get; set; }
        public int FocusCount { get; set; }
    }
}
