using AutoMapper;
using Diary.Bussiness.Dtos.Category;
using Diary.IBLL;
using Diary.IDAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Diary.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var result = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<List<CategoryDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CategoryDto> UpdateAsync(CreateOrUpdateCategoryDto u)
        {
            throw new NotImplementedException();
        }
    }
}
