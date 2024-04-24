using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNGO.Business.Constants;
using SocialNGO.Infrastructure.Db.Entities;
using SocialNGO.Models.Request;

namespace SocialNGO.Controllers;

/// <summary> </summary>
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{

    private readonly IConfiguration _config;
    private IUserManager _userService;
    /// <summary> </summary>
    public LoginController(IConfiguration config, IUserManager userService)
    {
        _config = config;
        _userService = userService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginModel login)
    {
        var response = await _userService.Authenticate(login);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    /// <summary>
    /// Add User
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
   
    [HttpPost("AddUser")]
    [Authorize]
    public async Task<IActionResult> Post(User userObj)
    {
        userObj.Id = 0;
        return Ok(await _userService.AddAndUpdateUser(userObj));
    }

    /// <summary>
    /// Update User
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userObj"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Put(int id, [FromBody] User userObj)
    {
        return Ok(await _userService.AddAndUpdateUser(userObj));
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
