namespace OnlineMarketSystem.Models;

public class Review
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public double Rating { get; set; }
    public string? Comment { get; set; }
    public DateTime CreatedAt { get; set; }
}
