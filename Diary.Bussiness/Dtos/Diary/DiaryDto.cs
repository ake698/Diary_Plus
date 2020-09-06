using Diary.Bussiness.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos.Diary
{
    public class DiaryDto : BaseReturnDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public UserDto User { get; set; }
        /// <summary>
        /// 点赞数量
        /// </summary>
        public int GoodCount { get; set; }
        /// <summary>
        /// 反对数量
        /// </summary>
        public int BadCount { get; set; }
        public int FollowCount { get; set; }

        public bool IsPublic { get; set; }
    }
}
