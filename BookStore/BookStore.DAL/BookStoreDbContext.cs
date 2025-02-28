using BookStore.DAL.Entites;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DAL;

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
    }
    
    public DbSet<BookEntity> Books { get; set; }
}