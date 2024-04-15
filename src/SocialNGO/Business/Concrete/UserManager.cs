using SocialNGO.Business.Constants;

namespace SocialNGO.Business.Concrete;

/// <summary> </summary>
public class UserManager : IUserManager
{
    private readonly ILogger<UserManager> logger;

    /// <summary> </summary>
    /// <param name="_logger"></param>
    public UserManager(ILogger<UserManager> _logger) => (logger) = (_logger);

    /// <summary> </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Guid> GetById(Guid userId)
    {
        throw new NotImplementedException();
    }
}
