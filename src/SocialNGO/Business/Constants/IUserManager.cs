namespace SocialNGO.Business.Constants;

/// <summary> </summary>
public interface IUserManager
{
    /// <summary> </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<Guid> GetById(Guid userId);
}
