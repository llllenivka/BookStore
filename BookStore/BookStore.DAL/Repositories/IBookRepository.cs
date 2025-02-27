using BookStore.Core.Models;
using BookStore.DAL.Entites;

namespace BookStore.DAL.Repositories;

public interface IBookRepository
{
    Task<List<Book>> Get();
    Task<Guid> Create(Book book);
    Task<Guid> Update(Guid id, string title, string description, decimal price);
    Task<Guid> Delete(Guid id);

}