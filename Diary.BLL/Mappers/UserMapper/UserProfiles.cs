using AutoMapper;
using Diary.Bussiness.Dtos.User;
using Diary.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diary.BLL.Mappers.UserMapper
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserDto>();
        }
    }
}
