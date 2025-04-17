namespace BookStore.Api.Domain.Entities;

public class Cart
{
    public Guid Id { get; set; }
    public List<Guid> BookIds { get; set; }
}