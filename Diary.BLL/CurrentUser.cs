using AutoMapper;
using Diary.Bussiness.Dtos.User;
using Diary.Entity;
using Diary.IBLL;
using Diary.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Diary.BLL
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CurrentUser(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Mock 用户
        /// </summary>
        /// <returns></returns>
        public UserDto GetCurrentUser()
        {
            UserDto user = null;
            var users = _userRepository.GetAllAsync();
            if(users.Count() > 0)
            {
                user = _mapper.Map<UserDto>(users.First());
            }
            else
            {
                var result = _userRepository.CreateAsync(new User()
                {
                    Email = "fsq5431@qq.com",
                    AvatarPath = "Test.jpg",
                    Password = "123456",
                });
                user = _mapper.Map<UserDto>(result);
            }
            return user;
        }
    }
}
