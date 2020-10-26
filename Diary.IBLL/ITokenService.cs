using Diary.Bussiness.Dtos.Token;
using System.Security.Claims;

namespace Diary.IBLL
{
    public interface ITokenService
    {
        TokenDto DecodeJwt(string token);
        string CreateJwt(Claim[] claims);
    }
}
