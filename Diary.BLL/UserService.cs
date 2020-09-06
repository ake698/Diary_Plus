using Diary.Bussiness.Dtos;
using Diary.Entity;
using Diary.IBLL;
using Diary.IDAL;
using System;
using System.Threading.Tasks;

namespace Diary.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ChangePassword(string email, string oldPwd, string newPwd)
        {
            throw new NotImplementedException();
        }

        public async Task ChangeUserInformation(string email, string siteName, string imagePath)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task Register(CreateUserDto input)
        {
            await _userRepository.CreateAsync(new User()
            {
                Email = input.Email,
                Password = input.Password,
                AvatarPath = input.AvatarPath
            });
        }
    }
}
