using Microsoft.EntityFrameworkCore;
using ManagementSystem.Domain;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Product>> GetAll(int page, int pageSize)
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(Guid id)
        => await _context.Products.FindAsync(id);

    public async Task<Product?> GetBySku(string sku)
        => await _context.Products.FirstOrDefaultAsync(p => p.SKU == sku);

    public async Task Add(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task Update()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Product product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }
}