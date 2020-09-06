using Diary.Bussiness.Dtos.Diary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface IDiaryService : IBaseService<CreateOrUpdateDiaryDto, DiaryDto, CreateOrUpdateDiaryDto>
    {
    }
}
