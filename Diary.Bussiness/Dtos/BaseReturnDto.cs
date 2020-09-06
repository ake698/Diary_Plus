using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Dtos
{
    public class BaseReturnDto
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
