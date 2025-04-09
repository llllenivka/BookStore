using AutoMapper;
using BookStore.Api.Application.DTO;
using BookStore.Api.Application.Interfaces;
using BookStore.Api.Domain.Entities;
using BookStore.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Application.Services;

public class BookService : IBookService
{
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;

    public BookService(BookStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<BookResponseDto>> GetAllBooksAsync()
    {
        var books = await _context.Books.ToListAsync();
        return _mapper.Map<IEnumerable<BookResponseDto>>(books);
    }

    public async Task<BookResponseDto?> GetBookByIdAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        return book == null ? null : _mapper.Map<BookResponseDto>(book);
    }

    public async Task<BookResponseDto> AddBookAsync(BookRequestDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return _mapper.Map<BookResponseDto>(book);
    }
    

    public async Task<BookResponseDto?> UpdateBookAsync(Guid id, BookRequestDto bookDto)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return null;
        
        _mapper.Map(bookDto, book);
        
        await _context.SaveChangesAsync();
        return _mapper.Map<BookResponseDto>(book);
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return false;
        
        _context.Books.Remove(book);
        return await _context.SaveChangesAsync() > 0;
    }
}