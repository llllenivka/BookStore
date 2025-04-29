using BookStore.Application.DTO;
using BookStore.Application.DTO.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponseDto>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDto>> GetBookById(Guid id)
    {
        var book = await _bookService.GetBookByIdAsync(id);
        if (book == null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> CreateBook(BookRequestDto book)
    {
        if (!ModelState.IsValid) return BadRequest();
        var newBook = await _bookService.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookResponseDto>> UpdateBook(Guid id, BookRequestDto book)
    {
        if (!ModelState.IsValid) return BadRequest();
        var updatedBook = await _bookService.UpdateBookAsync(id, book);
        if (updatedBook == null) return NotFound();
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<BookResponseDto>> DeleteBook(Guid id)
    {
        var deletedBook = await _bookService.DeleteBookAsync(id);
        if (deletedBook == null) return NotFound();
        return NoContent();
    }
    
    
    
}