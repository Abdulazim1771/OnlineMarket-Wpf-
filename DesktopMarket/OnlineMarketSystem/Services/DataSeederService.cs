using Bogus;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class DataSeederService
{
    //private static readonly Faker faker = new();

    public static void SeedDatabase()
    {
        using var context = new OnlineMarketDbContext();

        CreateCustomers(context);
    }

    private static void CreateCustomers(OnlineMarketDbContext context)
    {
        var customerFaker = new Faker<Customer>()
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Email, f => f.Person.Email)
            .RuleFor(c => c.Password, f => f.Random.Word())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("+998##-###-##-##"))
            .RuleFor(c => c.CreatedAt, f => f.Date.Past(30, DateTime.Now));

        var customers = customerFaker.Generate(50);

        //context.Customers.Add(customers);
        context.SaveChanges();
    }
}
