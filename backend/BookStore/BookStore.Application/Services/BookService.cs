using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _bookRepository.Get();
    }

    public async Task<Guid> CreateBook(Book book)
    {
        return await _bookRepository.Create(book);
    }

    public async Task<Guid> Update(Guid id, string title, string description, decimal price)
    {
        return await _bookRepository.Update(id, title, description, price);
    }

    public async Task<Guid> Delete(Guid id)
    {
        return await _bookRepository.Delete(id);
    }
    
}