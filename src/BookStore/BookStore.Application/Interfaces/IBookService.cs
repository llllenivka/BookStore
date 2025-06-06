using BookStore.Application.DTO;

namespace BookStore.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookResponseDto>> GetAllBooksAsync();
    Task<BookResponseDto?> GetBookByIdAsync(Guid id);
    Task<BookResponseDto> AddBookAsync(BookRequestDto bookDto);
    Task<BookResponseDto?> UpdateBookAsync(Guid id, BookRequestDto bookDto);
    Task<bool> DeleteBookAsync(Guid id);
    
}