using Microsoft.EntityFrameworkCore;
using SocialNGO.Infrastructure.Db.Repositories.Users.Contracts;
using SocialNGO.Models.Request;

namespace SocialNGO.Infrastructure.Db.Repositories.Users.Concrete
{
    public class UserSearchRepository :IUserSearchRepository
    {
        private readonly ApplicationDBContext _context;

        public UserSearchRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserSearchDTO>> GetUserRepoAsync(PaginationDto pagination, string searchTerm = null)
        {
            var query = _context.Users.AsQueryable();

            // Apply filtering based on search term
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.FirstName.Contains(searchTerm));
            }

            // Apply pagination
            var skip = (pagination.PageNumber - 1) * pagination.PageSize;
            query = query.Skip(skip).Take(pagination.PageSize);

            // Project to DTO
            return await query
                .Select(p => new UserSearchDTO
                {
                    Id = p.Id,
                    Name = p.FirstName,
                    //Price = p.Password
                    // Map other properties as needed
                })
                .ToListAsync();
        }
    }
}
