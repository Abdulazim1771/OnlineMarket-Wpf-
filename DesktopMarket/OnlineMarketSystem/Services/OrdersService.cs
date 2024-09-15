using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class OrdersService
{
    private readonly OnlineMarketDbContext _context;

    public OrdersService()
    {
        _context = new();
    }

    public List<Order> GetOrders(string search = "")
    {
        var query = _context.Orders
            .Include(o => o.OrderDetails)
            .ThenInclude(o => o.Product)
            .Include(c => c.Customer)
            .AsNoTracking()
            .AsQueryable();

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Customer.FirstName.Contains(search));
        }

        var orders = query.ToList();

        return orders;
    }

    public Order? GetOrderById(int id)
        => _context.Orders.FirstOrDefault(x => x.Id == id);
}
