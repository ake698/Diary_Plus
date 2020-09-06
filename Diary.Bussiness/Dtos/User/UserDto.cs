using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos.User
{
    public class UserDto : BaseReturnDto
    {
        public string Email { get; set; }
        public string AvatarPath { get; set; } = "default.png";
    }
}
