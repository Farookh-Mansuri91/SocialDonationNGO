using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;

namespace SocialNGO.Business.Contract
{
   public interface IUserSearchService
    {
        Task<List<UserSearchDTO>> GetUserAsync(PaginationDto pagination, string searchTerm = null);
    }
}
