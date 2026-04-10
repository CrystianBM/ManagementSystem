using Microsoft.EntityFrameworkCore;
using ManagementSystem.Domain;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.SKU)
            .IsUnique();
    }
}