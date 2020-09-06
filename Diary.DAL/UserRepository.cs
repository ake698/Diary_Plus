using Diary.Entity;
using Diary.IDAL;

namespace Diary.DAL
{
    public class UserRepository : BaseRepository<User> ,IUserRepository
    {
        public UserRepository(DiaryContext db) : base(db)
        {
        }
    }
}
