using Diary.Entity;
using Diary.IDAL;

namespace Diary.DAL
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        public CommentRepository(DiaryContext db) : base(db)
        {
        }
    }
}
