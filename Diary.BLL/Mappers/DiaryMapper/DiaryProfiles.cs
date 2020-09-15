using AutoMapper;
using Diary.Bussiness.Dtos.Diary;
using Diary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.BLL.Mappers.DiaryMapper
{
    public class DiaryProfiles : Profile
    {
        public DiaryProfiles()
        {
            CreateMap<DiaryEntity, DiaryDto>()
                .ForMember(s => s.UserDto, options => options.MapFrom(p => p.User))
                .ForMember(s => s.CategoryDto, options => options.MapFrom(p => p.Category));
            CreateMap<CreateOrUpdateDiaryDto, DiaryEntity>();
        }
    }
}
