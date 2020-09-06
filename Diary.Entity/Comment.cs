using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Diary.Entity
{
    public class Comment : BaseEntity
    {
        [Required, MaxLength(2000)]
        public string Content { get; set; }
        [ForeignKey(nameof(User))]
        public Guid CreateId { get; set; }
        public User Creater { get; set; }

        [ForeignKey(nameof(Diary))]
        public Guid DiaryId { get; set; }
        public DiaryEntity Diary { get; set; }

    }
}
