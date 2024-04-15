using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNGO.Models.Request;

namespace SocialNGO.Controllers;

/// <summary> </summary>
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    /// <summary> </summary>
    public LoginController()
    {
        
    }

    /// <summary> </summary>
    /// <param name="userModel"></param>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize]
    public async Task<IActionResult> AddSchools([FromBody] UserModel userModel)
    {
        await Task.CompletedTask;
        return Ok();
    }
}
