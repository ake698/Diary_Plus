using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary.Entity
{
    public class DiaryEntity : BaseEntity
    {
        [Required,StringLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(2000)]
        public string Content { get; set; }
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// 点赞数量
        /// </summary>
        public int GoodCount { get; set; }
        /// <summary>
        /// 反对数量
        /// </summary>
        public int BadCount { get; set; }
        public int FollowCount { get; set; }

        [Required]
        public bool IsPublic { get; set; }

        [ForeignKey(nameof(Category))]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
