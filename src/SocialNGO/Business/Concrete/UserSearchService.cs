using SocialNGO.Business.Contract;
using SocialNGO.Infrastructure.Db.Repositories.Users.Concrete;
using SocialNGO.Infrastructure.Db.Repositories.Users.Contracts;
using SocialNGO.Models.Request;

namespace SocialNGO.Business.Concrete
{
    public class UserSearchService:IUserSearchService
    {
        private readonly IUserSearchRepository _userRepository;

        public UserSearchService(IUserSearchRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserSearchDTO>> GetUserAsync(PaginationDto pagination, string searchTerm = null)
        {
            return await _userRepository.GetUserRepoAsync(pagination, searchTerm);
        }
    }
}
