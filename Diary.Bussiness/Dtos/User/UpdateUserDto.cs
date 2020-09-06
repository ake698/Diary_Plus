using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos.User
{
    public class UpdateUserDto
    {
        public string AvatarPath { get; set; }
        public int FansCount { get; set; }
        public int FocusCount { get; set; }
    }
}
