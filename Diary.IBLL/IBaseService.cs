using Diary.Bussiness.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface IBaseService<C, R, U> where R : BaseReturnDto
    {
        Task<R> GetAsync(Guid id);

        Task<List<R>> GetListAsync();

        Task<R> DeleteAsync(Guid id);

        Task<R> UpdateAsync(Guid id, U input);

        Task<R> CreateAsync(C input);
    }
}
