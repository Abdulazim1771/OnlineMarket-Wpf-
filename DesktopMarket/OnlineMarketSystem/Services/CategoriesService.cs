using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Data;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Services;

public class CategoriesService
{
    private readonly OnlineMarketDbContext _context;

    public CategoriesService()
    {
        _context = new OnlineMarketDbContext();
    }

    public List<Category> GetCategories(string search = "")
    {
        var query = _context.Categories
            .AsNoTracking()
            .AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(x => x.Name == search);
        }

        var categories = query.ToList();

        return categories;
    }

    public Category? GetCategoryById(int id)
        => _context.Categories.FirstOrDefault(x => x.Id == id);

    public void Create(Category category)
    {
        _context.Categories.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Categories.Update(category);
        _context.SaveChanges();
    }

    public void Delete(Category category)
    {
        _context.Categories.Remove(category);
        _context.SaveChanges();
    }

    //public List<Category> Categories =
    //[
    //    new Category()
    //    {
    //        Id = 1,
    //        Name = "Drinks",
    //        Description = null,
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Category()
    //    {
    //        Id = 2,
    //        Name = "Meats",
    //        Description = null,
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Category()
    //    {
    //        Id = 3,
    //        Name = "Fruits",
    //        Description = null,
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Category()
    //    {
    //        Id = 4,
    //        Name = "Bread",
    //        Description = null,
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    },
    //    new Category()
    //    {
    //        Id = 5,
    //        Name = "Vegetables",
    //        Description = null,
    //        CreatedAt = DateTime.Now,
    //        ModifiedAt = null,
    //        DeletedAt = null
    //    }
    //];

    //public List<Category> GetCategories()
    //{
    //    return Categories;
    //}
}
