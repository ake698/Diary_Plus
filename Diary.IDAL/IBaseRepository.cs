using Diary.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.IDAL
{
    public interface IBaseRepository<T>  where T : BaseEntity
    {
        Task CreateAsync(T model, bool saved = true);
        Task UpdateAsync(T model, bool saved = true);
        Task PatchAsync(T model, bool saved = true);
        Task DeleteAsync(T model, bool saved = true);
        Task DeleteAsync(Guid id, bool saved = true);
        Task Save();

        Task<T> GetAsync(Guid id);
        IQueryable<T> GetAllAsync();
        IQueryable<T> GetAllByPageAsync(int pageSize = 10, int pageIndex = 0);
        IQueryable<T> GetAllOrderAsync(bool asc = true);
        IQueryable<T> GetAllByPageOrderAsync(int pageSize = 10, int pageIndex = 0, bool asc = true);
    }
}
