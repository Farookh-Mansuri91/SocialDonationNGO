using SocialNGO.Common.Filters;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;
using SocialNGO.Models.Response;

namespace SocialNGO.Business.Constants;

/// <summary> </summary>
public interface IUserManager
{
    /// <summary> </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<UserLoginResponse?> Authenticate(LoginModel model);
   // Task<IEnumerable<User>> GetAll();
    Task<UserLogin?> GetById(int id);
    Task<User?> AddAndUpdateUser(User userObj);

    Task<(IEnumerable<User>, MetaData)> GetUsers(SearchParams searchParam);
    Task <IEnumerable<Country>> GetCountries();
    Task <IEnumerable<State>> GetStates(int countryId);
    Task <IEnumerable<City>> GetCities(int stateId);
}
