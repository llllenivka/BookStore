using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookStoreDbContext _context;

    public BookRepository(BookStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        return await _context.Books.FindAsync(id);
    }

    public async Task<Book> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        
        return book;
    }

    public async Task<Book?> UpdateBookAsync(Guid id, Book book)
    {
        var bookToUpdate = await _context.Books.FindAsync(id);
        if (bookToUpdate == null) return null;

        _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
        await _context.SaveChangesAsync();
        
        return book;
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        
        return true;
    }
}