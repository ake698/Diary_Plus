using Diary.Bussiness.Dtos;
using Diary.Bussiness.Dtos.User;
using System.Threading.Tasks;

namespace Diary.IBLL
{
    public interface IUserService
    {
        Task Register(CreateUserDto input);
        Task<bool> Login(string email, string password);
        Task ChangePassword(string email, string oldPwd, string newPwd);
        Task ChangeUserInformation(string email, string siteName, string imagePath);

    }
}
