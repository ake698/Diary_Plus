using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos.Token
{
    public class TokenDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AvatarPath { get; set; } = "default.png";
    }
}
