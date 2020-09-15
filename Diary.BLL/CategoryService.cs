using AutoMapper;
using Diary.Bussiness.Dtos.Category;
using Diary.Entity;
using Diary.IBLL;
using Diary.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<CategoryDto> CreateAsync(CreateOrUpdateCategoryDto input)
        {
            var result = await _categoryRepository.CreateAsync(new Category()
            {
                Title = input.Title
            });
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<CategoryDto> DeleteAsync(Guid id)
        {
            var result = await _categoryRepository.DeleteAsync(id);
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<CategoryDto> GetAsync(Guid id)
        {
            var result = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryDto>(result);
        }

        public async Task<List<CategoryDto>> GetListAsync()
        {
            var result = await _categoryRepository.GetAllAsync().ToListAsync();
            return _mapper.Map<List<Category>, List<CategoryDto>>(result);
        }

        public async Task<CategoryDto> UpdateAsync(Guid id, CreateOrUpdateCategoryDto input)
        {
            var category = await _categoryRepository.GetAsync(id);
            category.Title = input.Title;
            var result = await _categoryRepository.UpdateAsync(category);
            return _mapper.Map<CategoryDto>(result);
        }
    }
}