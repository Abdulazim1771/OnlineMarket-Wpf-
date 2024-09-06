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

        if (!string.IsNullOrEmpty(search))
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

    //public List<Product> Products =
    //[
    //    new Product()
    //    {
    //        Id = 1,
    //        Name = "Coca-Cola",
    //        SKU = "25636598",
    //        Price = 5,
    //        CreatedAt = DateTime.Now,
    //        Category = new Category()
    //        {
    //            Id = 1,
    //            Name = "Drinks",
    //            Description = null,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Inventory = new Inventory()
    //        {
    //            Id= 1,
    //            Quantity = 25,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Description = "do not drink this sh*t dangerous for health!!!",
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Product()
    //    {
    //        Id = 2,
    //        Name = "Fanta",
    //        SKU = "12345678",
    //        Price = 5,
    //        CreatedAt = DateTime.Now,
    //        Category = new Category()
    //        {
    //            Id = 1,
    //            Name = "Drinks",
    //            Description = null,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Inventory = new Inventory()
    //        {
    //            Id= 2,
    //            Quantity = 35,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Description = null,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Product()
    //    {
    //        Id = 3,
    //        Name = "Beef",
    //        SKU = "87654321",
    //        Price = 12,
    //        CreatedAt = DateTime.Now,
    //        Category = new Category()
    //        {
    //            Id = 2,
    //            Name = "Meats",
    //            Description = null,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Inventory = new Inventory()
    //        {
    //            Id= 3,
    //            Quantity = 20,
    //            CreatedAt = DateTime.Now,
    //            ModifiedAt = null,
    //            DeletedAt = null
    //        },
    //        Description = null,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    }
    //];

    //public List<Product> GetProducts()
    //{
    //    return Products;
    //}
}
