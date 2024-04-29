using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;

namespace SocialNGO.Infrastructure.Db.Repositories.Users.Contracts
{

    public interface IUserSearchRepository
    {
        Task<List<UserSearchDTO>> GetUserRepoAsync(PaginationDto pagination, string searchTerm = null);
    }
}
