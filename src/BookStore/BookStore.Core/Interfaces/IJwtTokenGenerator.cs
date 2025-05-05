using BookStore.Core.Entities;

namespace BookStore.Infrastructure;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}