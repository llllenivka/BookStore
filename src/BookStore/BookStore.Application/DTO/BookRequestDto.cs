using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTO;

public class BookRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string?  Description { get; set; }
    public decimal Price { get; set; }
    public int? YearPublished { get; set; }
    public int PagesCount { get; set; }
    public string? CoverImageUrl { get; set; } 
}