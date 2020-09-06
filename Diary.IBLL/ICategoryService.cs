using Diary.Bussiness.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface ICategoryService : IBaseService<CreateOrUpdateCategoryDto, CategoryDto, CreateOrUpdateCategoryDto>
    {

    }
}
