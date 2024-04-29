using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SocialNGO.Business.Constants;
using SocialNGO.Common;
using SocialNGO.Common.Constants;
using SocialNGO.Common.Filters;
using SocialNGO.Infrastructure.Db;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using SocialNGO.Models.Response;
using SocialNGO.Utility.Concrete;
using SocialNGO.Utility.Contract;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

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

    public async Task<(IEnumerable<User> ,MetaData)> GetUsers(SearchParams searchParam)
    {
        List<ColumnFilter> columnFilters = new List<ColumnFilter>();
        if (!String.IsNullOrEmpty(searchParam.ColumnFilters))
        {
            try
            {
                columnFilters.AddRange(JsonSerializer.Deserialize<List<ColumnFilter>>(searchParam.ColumnFilters));
            }
            catch (Exception)
            {
                columnFilters = new List<ColumnFilter>();
            }
        }

        List<ColumnSorting> columnSorting = new List<ColumnSorting>();
        if (!String.IsNullOrEmpty(searchParam.OrderBy))
        {
            try
            {
                columnSorting.AddRange(JsonSerializer.Deserialize<List<ColumnSorting>>(searchParam.OrderBy));
            }
            catch (Exception)
            {
                columnSorting = new List<ColumnSorting>();
            }
        }

        Expression<Func<User, bool>> filters = null;
        //First, we are checking our SearchTerm. If it contains information we are creating a filter.
        var searchTerm = "";
        if (!string.IsNullOrEmpty(searchParam.SearchTerm))
        {
            searchTerm = searchParam.SearchTerm.Trim().ToLower();
            filters = x => x.FirstName.ToLower().Contains(searchTerm);
        }
        // Then we are overwriting a filter if columnFilters has data.
        if (columnFilters.Count > 0)
        {
            var customFilter = CustomExpressionFilter<User>.CustomFilter(columnFilters, "users");
            filters = customFilter;
        }


        var query = db.Users.AsQueryable().CustomQuery(filters);
        var count = query.Count();
        var filteredData = query.CustomPagination(searchParam.PageNumber, searchParam.PageSize).ToList();

        var pagedList = new PagedList<User>(filteredData, count, searchParam.PageNumber, searchParam.PageSize);
        return (pagedList,pagedList.MetaData);
    }
    public async Task<IEnumerable<Country>> GetCountries()
    {
        return await db.Countries.ToListAsync();
    }
    public async Task<IEnumerable<State>> GetStates(int countryId)
    {
        return await db.States.ToListAsync();
    }
    public async Task<IEnumerable<City>> GetCities(int stateId)
    {
        return await db.Cities.ToListAsync();
    }

}
