using AutoMapper;
using Diary.Bussiness.Dtos.Category;
using Diary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.Bussiness.Mappers.CategoryMapper
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
