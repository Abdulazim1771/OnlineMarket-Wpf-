using Microsoft.EntityFrameworkCore;
using OnlineMarketSystem.Models;

namespace OnlineMarketSystem.Data;

public class OnlineMarketDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=desktop-qrmohru;Initial Catalog=Online_Market_System;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Category to Product
        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        // Product to Inventory
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Inventory)
            .WithOne(i => i.Product)
            .HasForeignKey<Inventory>(i => i.ProductId);

        // Product to OrderDetail
        modelBuilder.Entity<Product>()
            .HasMany(p => p.OrderDetails)
            .WithOne(od => od.Product)
            .HasForeignKey(od => od.ProductId);

        // Order to OrderDetail
        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        // Customer to Order
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        // Customer to CustomerAddress
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Addresses)
            .WithOne(ca => ca.Customer)
            .HasForeignKey(ca => ca.CustomerId);

        // Customer to Review
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Reviews)
            .WithOne(r => r.Customer)
            .HasForeignKey(r => r.CustomerId);

        // Product to Review
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Reviews)
            .WithOne(r => r.Product)
            .HasForeignKey(r => r.ProductId);
    }
}
