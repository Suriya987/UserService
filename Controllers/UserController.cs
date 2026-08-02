using Microsoft.AspNetCore.Mvc;
using UserService.BOs;
using UserService.IServices;
using UserService.Models;

namespace UserService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] UserBO request)
    {
        var response = await _userService.RegisterAsync(request);

        return Ok(response);
    }

    [HttpGet("GetUserById/{userId:long}")]
    public async Task<IActionResult> GetUserById(long userId)
    {
        var response = await _userService.GetUserByIdAsync(userId);

        if (response == null)
        {
            return NotFound();
        }

        return Ok(response);
    }


}