using BookStore.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Infrastructure.Data;

public class BookStoreDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) 
        : base(options) { }
}