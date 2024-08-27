using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class ProductsService
{
    private readonly OnlineMarketDbContext _context;

    public ProductsService()
    {
        _context = new OnlineMarketDbContext();
    }

    public List<Product> GetProducts(string search = "")
    {
        var query = _context.Products
            .Include(x => x.Category)
            .Include(i => i.Inventory)
            .AsNoTracking()
            .AsQueryable();

        if(!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Name.Contains(search) || 
            x.Description != null && x.Description.Contains(search));
        }

        var products = query.ToList();

        return products;
    }

    public Product? GetProductById(int id)
        => _context.Products.FirstOrDefault(x => x.Id == id);

    public void Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Update(Product product)
    {
        _context.Update(product);
        _context.SaveChanges();
    }

    public void Delete(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }
}
