using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class InventoriesService
{
    private readonly OnlineMarketDbContext _context;

    public InventoriesService()
    {
        _context = new OnlineMarketDbContext();
    }

    public List<Inventory> GetInventories(string search = "", int? quantity = null)
    {
        var query = _context.Inventories
            .Include(p => p.Product)
            .AsNoTracking()
            .AsQueryable();

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Product.Name.Contains(search));
        }

        if(quantity is not null)
        {
            query = query.Where(x => x.Quantity.Equals(quantity));
        }

        return query.ToList();
    }

    public Inventory? GetById(int id) 
        => _context.Inventories.FirstOrDefault(x => x.Id == id);

    public void Create(Inventory inventory)
    {
        _context.Inventories.Add(inventory);
        _context.SaveChanges();
    }

    public void Update(Inventory inventory)
    {
        _context.Inventories.Update(inventory);
        _context.SaveChanges();
    }

    public void Delete(Inventory inventory)
    {
        _context.Inventories.Remove(inventory);
        _context.SaveChanges();
    }
}
