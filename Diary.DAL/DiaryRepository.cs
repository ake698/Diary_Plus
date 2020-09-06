using Diary.Entity;
using Diary.IDAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.DAL
{
    public class DiaryRepository : BaseRepository<DiaryEntity>, IDiaryRepository
    {
        public DiaryRepository(DiaryContext db) : base(db)
        {
        }
    }
}
