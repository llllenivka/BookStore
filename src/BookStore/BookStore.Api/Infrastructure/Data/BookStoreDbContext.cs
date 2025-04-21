using BookStore.Api.Domain.Entities;
using BookStore.Api.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Infrastructure.Data;

public class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) 
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>()
            .Property(u => u.Role)
            .HasConversion<string>();
    }
}