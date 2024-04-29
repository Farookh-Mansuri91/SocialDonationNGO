using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNGO.Common;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Utility.Contract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNGO.Utility.Concrete
{

    public class JWTService:IJWTInterface
    {
        private readonly AppSettings _appSettings;
        public JWTService(IOptions<AppSettings> appSettings) {
            _appSettings = appSettings.Value;
        }
        /// <summary> </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> GenerateJwtToken(UserLogin user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                        new Claim("id", user.Id.ToString()),
                        new Claim(JwtRegisteredClaimNames.Name, user.Name),
                        new Claim(JwtRegisteredClaimNames.Email, user.UserPassword),
                        new Claim(JwtRegisteredClaimNames.Jti,
                        Guid.NewGuid().ToString())
                    }),
                    Issuer= _appSettings.ValidIssuer,
                    Audience= _appSettings.ValidAudience,
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }
    }
}
