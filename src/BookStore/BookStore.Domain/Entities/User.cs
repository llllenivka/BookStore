using BookStore.Domain.Enums;

namespace BookStore.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserRole Role { get; set; } = UserRole.Customer;
    public Guid CartId { get; set; }
    public Guid FavoriteBooksId { get; set; }
}