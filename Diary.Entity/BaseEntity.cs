using System;
using System.ComponentModel.DataAnnotations;

namespace Diary.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public bool IsRemove { get; set; }
    }
}
