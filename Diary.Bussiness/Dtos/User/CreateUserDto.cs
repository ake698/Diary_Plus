using System.ComponentModel.DataAnnotations;

namespace Diary.Bussiness.Dtos
{
    public class CreateUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string AvatarPath { get; set; } = "default.png";
    }
}
