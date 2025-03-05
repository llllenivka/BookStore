using BookStore.Contracts;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;
    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<List<BooksResponse>>> GetBooks()
    {
        var books = await _bookService.GetAllBooks();
        
        var response = books
            .Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest request)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.Price);
    
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }
        
        var bookId = await _bookService.CreateBook(book);
    
        return Ok(bookId);
    
    }
    
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest request)
    {
        var bookId = await _bookService.Update(id, request.Title, request.Description, request.Price);
        return Ok(bookId);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        var bookId = await _bookService.Delete(id);
        return Ok(bookId);
    }
    
}