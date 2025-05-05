using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BookStoreDbContext _context;

    public UserRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
        return user == null ? null : user;
    }

    public async Task<bool> Register(User user)
    {
        var result = await GetUserByEmailAsync(user.Email);
        if (result != null) return false;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return true;
    }
    
    
}