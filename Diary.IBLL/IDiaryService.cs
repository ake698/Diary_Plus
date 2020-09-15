using Diary.Bussiness.Dtos.Diary;

namespace Diary.IBLL
{
    public interface IDiaryService : IBaseService<CreateOrUpdateDiaryDto, DiaryDto, CreateOrUpdateDiaryDto>
    {
    }
}
