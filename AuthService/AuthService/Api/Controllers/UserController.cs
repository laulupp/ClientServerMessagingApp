using AuthService.Api.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("/")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {
        return Ok(await _userService.LoginAsync(loginDTO));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserDTO userDTO)
    {
        return Ok(await _userService.RegisterAsync(userDTO));
    }
}