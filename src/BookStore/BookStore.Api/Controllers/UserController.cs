using BookStore.Application.DTO;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Identity.Data;
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
    public async Task<ActionResult<string>> Login([FromQuery] string email, [FromQuery] string password)
    {
        var token = await _userService.Login(email, password);
        if(token == null) return Unauthorized();
        return Ok(token);
    }
    
}