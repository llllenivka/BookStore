using BookStore.Application.DTO;

namespace BookStore.Application.Services;

public interface IUserService
{
    Task Register(UserRequestDto newUser);
    Task<UserResponseDto> GetUserByEmailAsync(string email);
}