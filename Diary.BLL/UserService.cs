using AutoMapper;
using Diary.Bussiness.Dtos;
using Diary.Bussiness.Dtos.User;
using Diary.Bussiness.Exceptions;
using Diary.Entity;
using Diary.IBLL;
using Diary.IDAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diary.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUser _currentUser;

        public UserService(IUserRepository userRepository, IMapper mapper, ICurrentUser currentUser)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _currentUser = currentUser;
        }

        public async Task ChangePassword(string oldPwd, string newPwd)
        {
            if (!oldPwd.Equals(newPwd))
            {
                var currentUser = _currentUser.GetCurrentUser();
                var user = await _userRepository.GetAsync(currentUser.Id);
                user.Password = newPwd;
                await _userRepository.UpdateAsync(user);
            }
            else
            {
                throw new BussinessException("The new passwords are consistent!");
            }
        }


        public async Task<UserDto> CreateAsync(CreateUserDto input)
        {
            var users = GetUserByEmail(input.Email).ToList();
            if (users.Count > 0) throw new BussinessException("The user already exists");

            var result = await _userRepository.CreateAsync(new User()
            {
                Email = input.Email,
                Password = input.Password,
                AvatarPath = input.AvatarPath
            });
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> DeleteAsync(Guid id)
        {
            var result = await _userRepository.DeleteAsync(id);
            return _mapper.Map<UserDto>(result);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            return _mapper.Map<UserDto>(await _userRepository.GetAsync(id));
        }

        public Task<List<UserDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string email, string password)
        {
            var user = GetUserByEmailAndPassword(email, password);
            var result = await user.FirstOrDefaultAsync();
            if(user == null)
            {
                // 无账号
            }
            else
            {
                // 开始登录
            }
            return true;
        }

        public async Task<UserDto> UpdateAsync(Guid id, UpdateUserDto input)
        {
            var user = await _userRepository.GetAsync(id);
            user.AvatarPath = input.AvatarPath;
            await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        private IQueryable<User> GetUserByEmail(string email)
        {
            var result = _userRepository.GetAllAsync()
                .Where(x => x.Email == email);
            return result;
        }

        private IQueryable<User> GetUserByEmailAndPassword(string email, string password)
        {
            var users = GetUserByEmail(email);
            users = users.Where(x => x.Password == password);
            return users;
        }
    }
}
