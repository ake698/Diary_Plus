using Diary.Bussiness;
using Diary.Bussiness.Dtos.Token;
using Diary.Bussiness.Dtos.User;
using Diary.IBLL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Diary.BLL
{
    public class TokenService : ITokenService
    {
        private TokenOptions _options;

        public TokenService(IOptions<TokenOptions> options)
        {
            _options = options.Value ?? throw new ArgumentNullException(nameof(options));
        }

        public string CreateJwt(UserDto user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("UserId", user.Id.ToString()),
                new Claim("AvatarPath", user.AvatarPath),
                new Claim("Email", user.Email),
            };

            var now = DateTime.Now;
            var expires = now.AddSeconds(300);
            //signingCredentials  签名凭证
            var secret = Encoding.UTF8.GetBytes(_options.Sign);
            var key = new SymmetricSecurityKey(secret);
            var signcreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _options.Issurer,
                audience: _options.Audience,
                claims: claims, notBefore: now, expires: expires,
                signingCredentials: signcreds);
            var JwtHander = new JwtSecurityTokenHandler();
            var token = JwtHander.WriteToken(jwt);
            return token;
        }

        public TokenDto DecodeJwt(string token)
        {
            token = token.Replace("Bearer ", string.Empty);
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,//是否验证Issuer
                ValidateAudience = true,//是否验证Audience
                ValidateLifetime = true,//是否验证失效时间
                ValidateIssuerSigningKey = true,//是否验证SecurityKey
                ValidAudience = _options.Audience,//Audience
                ValidIssuer = _options.Issurer,//Issuer

                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Sign))//拿到SecurityKey
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            ClaimsPrincipal parse = jwtTokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validated);
            var claims = parse.Claims;
            return new TokenDto
            {
                UserId = claims.FirstOrDefault(m => m.Type == "UserId").Value,
                //UserName = claims.FirstOrDefault(m => m.Type == "UserName").Value,
                AvatarPath = claims.FirstOrDefault(m => m.Type == "AvatarPath").Value,
                Email = claims.FirstOrDefault(m => m.Type == "Email").Value
            };
        }
    }
}
