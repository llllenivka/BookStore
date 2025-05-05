using BookStore.Application.DTO;

namespace BookStore.Application.Services;

public interface IUserService
{
    Task<IEnumerable<UserResponseDto>> GetUsers();
    Task<UserResponseDto> GetUserByEmailAsync(string email);
    Task<bool> Register(UserRequestDto newUser);
    
    Task<string> Login(string email, string password);
}