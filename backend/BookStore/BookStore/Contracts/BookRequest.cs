namespace BookStore.Contracts;

public record BookRequest(
    string Title,
    string Description,
    decimal Price);