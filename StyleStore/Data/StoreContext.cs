using Microsoft.EntityFrameworkCore;
using StyleStore.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions<StoreContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Men", Description = "Men's Fashion", ImageUrl = "/images/categories/men.jpg" },
            new Category { Id = 2, Name = "Women", Description = "Women's Fashion", ImageUrl = "/images/categories/women.jpg" },
            new Category { Id = 3, Name = "Accessories", Description = "Fashion Accessories", ImageUrl = "/images/categories/accessories.jpg" }
        );

        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Classic T-Shirt",
                Description = "Comfortable cotton t-shirt",
                Price = 29.99M,
                CategoryId = 1,
                Stock = 100,
                ImageUrl = "/images/products/tshirt.jpg",
                IsFeatured = true,
                CreatedAt = DateTime.Now
            }
            // Add more products as needed
        );
    }
}