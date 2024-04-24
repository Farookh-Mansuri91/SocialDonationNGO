using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SocialNGO.Utility
{
    /// <summary>
    /// Configuration of Jwt
    /// </summary>
    public static class JWT
    {
        /// <summary>
        /// Register Jwt
        /// </summary>
        /// <param name="builder"></param>
        /// <returns>builder</returns>
        public static WebApplicationBuilder RegisterJwt(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["AppSettings:ValidIssuer"],
                    ValidAudience = builder.Configuration["AppSettings:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AppSettings:Secret"]))
                };
            });

            return builder;
        }
    }
}
