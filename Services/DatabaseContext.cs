using SmartFood.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace SmartFood.Api.Services;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }
    
    public DbSet<Recipe> Recipes { get; set; }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>().ToContainer("recipes");
        modelBuilder.Entity<Category>().ToContainer("categories");
    }
}