using AutoMapper;
using Diary.Bussiness.Dtos.Category;
using Diary.Entity;

namespace Diary.Bussiness.Mappers.CategoryMapper
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CreateOrUpdateCategoryDto, CategoryDto>();
        }
    }
}
