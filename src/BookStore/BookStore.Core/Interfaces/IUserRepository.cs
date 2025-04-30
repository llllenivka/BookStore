using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces;

public interface IUserRepository
{
    Task Register(User newUser);
    Task<User> GetUserByEmailAsync(string email);
}