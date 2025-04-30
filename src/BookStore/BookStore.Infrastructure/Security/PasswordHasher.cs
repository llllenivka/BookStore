
namespace BookStore.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string GenerateHash(string password) => 
        BCrypt.Net.BCrypt.HashPassword(password);
    
}