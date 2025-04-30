using AutoMapper;
using BookStore.Application.DTO;
using BookStore.Application.Interfaces;
using BookStore.Core.Entities;
using BookStore.Core.Interfaces;

// using BookStore.Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        return _mapper.Map<IEnumerable<BookResponseDto>>(books);
    }

    public async Task<BookResponseDto?> GetBookByIdAsync(Guid id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        return book == null ? null : _mapper.Map<BookResponseDto>(book);
    }

    public async Task<BookResponseDto> AddBookAsync(BookRequestDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        await _bookRepository.AddBookAsync(book);
        return _mapper.Map<BookResponseDto>(book);
    }
    

    public async Task<BookResponseDto?> UpdateBookAsync(Guid id, BookRequestDto bookDto)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null) return null;
        
        _mapper.Map(bookDto, book);
        
        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);
        if (book == null) return false;
        
        return await _bookRepository.DeleteBookAsync(id);
    }
}