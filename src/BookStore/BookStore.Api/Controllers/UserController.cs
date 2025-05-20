using BookStore.Application.DTO;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<UserResponseDto>>> GetUsers()
    {
        return Ok(await _userService.GetUsers());
    }

    [HttpPost("register")]
    public async Task<ActionResult<string>> Register([FromBody] UserRequestDto user)
    {
        var result = await _userService.Register(user);
        if (result) return Ok("Пользователь успешно зарегестрирован!");
        else return BadRequest("Пользователь с такой почтой уже зарегестрирован");
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginUserRequestDto user)
    {
        var token = await _userService.Login(user.Email, user.Password);
        if(token == null) return Unauthorized();

        
        HttpContext.Response.Cookies.Append(
            "kakoi-to-kluch",
            token,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddHours(2)
            });
        return Ok(token);
    }
    
    
    
}