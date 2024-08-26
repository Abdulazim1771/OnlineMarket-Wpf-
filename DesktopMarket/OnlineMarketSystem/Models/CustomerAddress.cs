namespace OnlineMarketSystem.Models;

public class CustomerAddress
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }

    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
}
