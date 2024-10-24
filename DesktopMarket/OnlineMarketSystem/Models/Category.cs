﻿namespace OnlineMarketSystem.Models;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = [];
    }
}
