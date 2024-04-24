using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNGO.Business.Constants;
using SocialNGO.Common;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using SocialNGO.Models.Response;
using SocialNGO.Utility.Concrete;
using SocialNGO.Utility.Contract;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialNGO.Business.Concrete;

/// <summary> </summary>
public class UserManager : IUserManager
{
    private readonly ILogger<UserManager> logger;
    public readonly ApplicationDBContext db;
    //private readonly AppSettings _appSettings;
    private readonly IJWTInterface _JWTservice;

    /// <summary> </summary>
    /// <param name="_logger"></param>
    public UserManager(ILogger<UserManager> _logger, ApplicationDBContext _dbContext,  
        IJWTInterface JWTservice)
    {
        logger = _logger;
        db = _dbContext;
        _JWTservice = JWTservice;


    }

    /// <summary> </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<UserLogin?> GetById(int id)
    {
        return await db.UserLogins.FirstOrDefaultAsync(x => x.Id == id);
    }


    public async Task<UserLoginResponse?> Authenticate(LoginModel model)
    {
        var user = await db.UserLogins.SingleOrDefaultAsync(x => x.Name == model.Username && x.UserPassword == model.Password);

        // return null if user not found
        if (user == null) return null;
        // authentication successful so generate jwt token
        var token = await _JWTservice.GenerateJwtToken(user);
        return new UserLoginResponse(user, token);
    }

    public async Task<User?> AddAndUpdateUser(User userObj)
    {
        bool isSuccess = false;
        if (userObj.Id > 0)
        {
            var obj = await db.Users.FirstOrDefaultAsync(c => c.Id == userObj.Id);
            if (obj != null)
            {
                // obj.Address = userObj.Address;
                obj.FirstName = userObj.FirstName;
                obj.LastName = userObj.LastName;
                db.Users.Update(obj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }
        }
        else
        {
            await db.Users.AddAsync(userObj);
            isSuccess = await db.SaveChangesAsync() > 0;
        }

        return isSuccess ? userObj : null;
    }
    public async Task<IEnumerable<User>> GetAll()
    {
        return await db.Users.Where(x => x.isActive == true).ToListAsync();
    }

}
