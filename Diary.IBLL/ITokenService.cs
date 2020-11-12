using Diary.Bussiness.Dtos.Token;
using Diary.Bussiness.Dtos.User;

namespace Diary.IBLL
{
    public interface ITokenService
    {
        TokenDto DecodeJwt(string token);
        string CreateJwt(UserDto user);
    }
}
