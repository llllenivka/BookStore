using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBookService
{ 
    Task<List<Book>> GetAllBooks();
    Task<Guid> CreateBook(Book book);
    Task<Guid> Update(Guid id, string title, string description, decimal price);
    Task<Guid> Delete(Guid id);
}