using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class CustomersService
{
    private readonly OnlineMarketDbContext _context;

    public CustomersService()
    {
        _context = new OnlineMarketDbContext();
    }

    public List<Customer> GetCustomers(string search = "")
    {
        var query = _context.Customers
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.FirstName.Contains(search) ||
                x.LastName.Contains(search) ||
                x.Email.Contains(search) ||
                x.Phone.Contains(search));
        }

        var customers = query.ToList();

        return customers;
    }

    public Customer? GetCustomerById(int id)
        => _context.Customers.FirstOrDefault(x => x.Id == id);

    //public void Create(Customer customer)
    //{
    //    _context.Customers.Add(customer);
    //    _context.SaveChanges();
    //}

    //public void Update(Customer customer)
    //{
    //    _context.Customers.Update(customer);
    //    _context.SaveChanges();
    //}

    //public void Delete(Customer customer)
    //{
    //    _context.Customers.Remove(customer);
    //    _context.SaveChanges();
    //}

    //public List<Customer> Customers =
    //[
    //    new Customer()
    //    {
    //        Id = 1,
    //        FirstName = "John",
    //        LastName = "Doe",
    //        Email = "JohnDoe@gmail.com",
    //        Password = "*********",
    //        Phone = "+1(598)5557856",
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null
    //    },
    //    new Customer()
    //    {
    //        Id = 2,
    //        FirstName = "Donald",
    //        LastName = "Trump",
    //        Email = "DonaldTrump@gmail.com",
    //        Password = "********//**",
    //        Phone = "+1(666)6666669",
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null
    //    },
    //    new Customer()
    //    {
    //        Id = 3,
    //        FirstName = "Andrew",
    //        LastName = "Tate",
    //        Email = "CobraTate@gmail.com",
    //        Password = "matrix333",
    //        Phone = "+1(888)9988898",
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null
    //    },
    //    new Customer()
    //    {
    //        Id = 4,
    //        FirstName = "Benjamin",
    //        LastName = "Franklin",
    //        Email = "BenjaminFranklin@gmail.com",
    //        Password = "100$**//",
    //        Phone = "+1(333)333633",
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null
    //    },
    //    new Customer()
    //    {
    //        Id = 5,
    //        FirstName = "John",
    //        LastName = "Uik",
    //        Email = "JohnUik@gmail.com",
    //        Password = "561***///##",
    //        Phone = "+1(111)0001100",
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null
    //    }
    //];

    //public List<Customer> GetCustomers()
    //{
    //    return Customers;
    //}
}
