using Microsoft.AspNetCore.Mvc;
using SocialNGO.Business.Concrete;
using SocialNGO.Business.Contract;
using SocialNGO.Infrastructure.Db.Repositories.Users.Contracts;
using SocialNGO.Infrastructure.Db.Repositories.Users.Contracts;
using SocialNGO.Models.Request;

namespace SocialNGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
public class UserSearchController : ControllerBase
{
        private readonly IUserSearchService _userSearchService;

        public UserSearchController(IUserSearchService userSearchService)
        {
            _userSearchService = userSearchService;
        }

    [HttpGet]
    public async Task<ActionResult<List<UserSearchDTO>>> GetUsers([FromQuery] PaginationDto pagination, string searchTerm)
    {
        var products = await _userSearchService.GetUserAsync(pagination, searchTerm);
        return Ok(products);
    }
}
}
