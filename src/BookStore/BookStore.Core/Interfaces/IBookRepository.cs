using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();
    Task<Book?> GetBookByIdAsync(Guid id);
    Task<Book> AddBookAsync(Book book);
    Task<Book?> UpdateBookAsync(Guid id, Book book);
    Task<bool> DeleteBookAsync(Guid id);
}