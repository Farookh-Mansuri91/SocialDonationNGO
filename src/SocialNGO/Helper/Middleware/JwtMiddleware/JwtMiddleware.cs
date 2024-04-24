using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNGO.Business.Constants;
using SocialNGO.Common;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNGO.Helper.Middleware.JwtMiddleware;

/// <summary></summary>
public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    /// <summary> </summary>
    /// <param name="next"></param>
    /// <param name="appSettings"></param>
    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings) => (_next, _appSettings) = (next, appSettings.Value);

    /// <summary> </summary>
    /// <param name="context"></param>
    /// <param name="userService"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context, IUserManager userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachUserToContext(context, userService, token);

        await _next(context);
    }

    /// <summary> </summary>
    /// <param name="context"></param>
    /// <param name="userService"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private async Task AttachUserToContext(HttpContext context, IUserManager userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidIssuer = _appSettings.ValidIssuer,
                ValidAudience = _appSettings.ValidAudience,
                // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            //Attach user to context on successful JWT validation
            context.Items["User"] = await userService.GetById(userId);
        }
        catch(Exception ex)
        {

            //Do nothing if JWT validation fails
            // user is not attached to context so the request won't have access to secure routes

        }
    }

}
