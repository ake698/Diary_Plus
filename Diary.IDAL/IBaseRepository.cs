using Diary.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.IDAL
{
    public interface IBaseRepository<T>  where T : BaseEntity
    {
        Task<T> CreateAsync(T model, bool saved = true);
        Task<List<T>> CreateListAsync(List<T> models, bool saved = true);
        Task<T> UpdateAsync(T model, bool saved = true);
        Task<T> PatchAsync(T model, bool saved = true);
        Task<T> DeleteAsync(T model, bool saved = true);
        Task<T> DeleteAsync(Guid id, bool saved = true);
        Task Save();

        Task<T> GetAsync(Guid id);
        IQueryable<T> GetAllAsync();
        IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllOrderAsync(bool asc = true);
        IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}
