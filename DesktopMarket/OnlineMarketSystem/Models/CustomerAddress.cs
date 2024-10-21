namespace OnlineMarketSystem.Models;

public class CustomerAddress
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public required string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
    public required string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
}
