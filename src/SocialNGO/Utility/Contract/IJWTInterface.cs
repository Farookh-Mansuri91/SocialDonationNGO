using SocialNGO.Infrastructure.Db.Entities;

namespace SocialNGO.Utility.Contract
{
    public interface IJWTInterface
    {
      Task<string> GenerateJwtToken(UserLogin user);
    }
}
