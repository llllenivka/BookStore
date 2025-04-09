using System.ComponentModel.DataAnnotations;

namespace Api.Models;

public class Book
{
    public Guid Id { get; set; }
    
    [MaxLength(100)]
    public string Title { get; set; }
    
    public string Description { get; set; } = String.Empty;
    
    [MaxLength(100)]
    public string Author { get; set; }

    public uint Amount { get; set; } = 0;
    
    public float Price { get; set; } = 0.0f;
    public string CoverImageUrl { get; set; } = "https://placeholder.apptor.studio/200/200/product1.png";

}