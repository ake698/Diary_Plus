using Diary.Entity;
using Diary.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.DAL
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly DiaryContext _db;
        public BaseRepository(DiaryContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(T model, bool saved = true)
        {
            _db.Set<T>().Add(model);
            if (saved) await Save();
        }

        public async Task DeleteAsync(T model, bool saved = true)
        {
            await DeleteAsync(model.Id, saved);
        }

        public async Task DeleteAsync(Guid id, bool saved = true)
        {

            T t = await GetAsync(id);
            _db.Entry(t).State = EntityState.Modified;
            t.IsRemove = true;
            if (saved)
            {
                await Save();
            }
        }

        public async Task PatchAsync(T model, bool saved = true)
        {
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await Save();
            }
        }

        public async Task UpdateAsync(T model, bool saved = true)
        {
            _db.Entry(model).State = EntityState.Modified;
            if (saved)
            {
                await Save();
            }
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        #region 查询
        public IQueryable<T> GetAllAsync()
        {
            return _db.Set<T>().Where(m => !m.IsRemove).AsNoTracking();
        }

        public IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0)
        {
            return GetAllAsync().Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true)
        {
            return GetAllOrderAsync(asc).Skip(pageSize * pageIndex).Take(pageSize);
        }

        public IQueryable<T> GetAllOrderAsync(bool asc = true)
        {
            var datas = GetAllAsync();
            datas = asc ? datas.OrderBy(m => m.CreateTime) : datas.OrderByDescending(m => m.CreateTime);
            return datas;
        }

        public async Task<T> GetAsync(Guid id)
        {
            return await GetAllAsync().FirstOrDefaultAsync(m => m.Id == id);
        }

        #endregion
    }
}
