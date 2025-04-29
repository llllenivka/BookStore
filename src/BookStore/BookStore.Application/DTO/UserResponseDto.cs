namespace BookStore.Application.DTO;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Guid CartId { get; set; }
    public Guid FavoriteBooksId { get; set; }
}