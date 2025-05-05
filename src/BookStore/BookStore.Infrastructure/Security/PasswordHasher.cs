
namespace BookStore.Infrastructure;

public class PasswordHasher : IPasswordHasher
{
    public string GenerateHash(string password) => 
        BCrypt.Net.BCrypt.HashPassword(password);
    
    public bool VerifyHash(string password, string hash) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
}