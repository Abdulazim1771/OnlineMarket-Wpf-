namespace OnlineMarketSystem.Models;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

    public ICollection<Order> Orders { get; set; }
    public ICollection<CustomerAddress> Addresses { get; set; }
    public ICollection<Review> Reviews { get; set; }

    public Customer()
    {
        Orders = [];
        Addresses = [];
        Reviews = [];
    }
}
