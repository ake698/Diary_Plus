using Diary.Entity;
using Diary.IDAL;

namespace Diary.DAL
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(DiaryContext db) : base(db)
        {
        }
    }
}
