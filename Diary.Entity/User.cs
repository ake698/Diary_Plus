using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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
