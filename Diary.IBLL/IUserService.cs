using Diary.Bussiness.Dtos;
using Diary.Bussiness.Dtos.User;
using System;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface IUserService : IBaseService<CreateUserDto, UserDto, UpdateUserDto>
    {
        Task<UserDto> Login(string email, string password);
        Task ChangePassword(string oldPwd, string newPwd);
    }
}
