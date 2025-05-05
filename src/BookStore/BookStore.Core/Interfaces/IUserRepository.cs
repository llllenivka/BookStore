using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUserByEmailAsync(string email);
    Task<bool> Register(User newUser);
}