using BookStore.Domain.Enums;

namespace BookStore.Application.DTO;

public class UserRequestDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.Customer;
}