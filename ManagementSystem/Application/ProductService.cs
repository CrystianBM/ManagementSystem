using ManagementSystem.Domain;
using ManagementSystem.Application;

public class ProductService
{
    private readonly ProductRepository _repo;

    public ProductService(ProductRepository repo)
    {
        _repo = repo;
    }

    public async Task Create(ProductDto dto)
    {
        var existing = await _repo.GetBySku(dto.SKU);
        if (existing != null)
            throw new Exception("SKU já existe");

        var product = new Product(dto.Name, dto.SKU, dto.Price, dto.Stock, dto.Category);

        await _repo.Add(product);
    }

    public async Task<List<Product>> GetAll(int page, int pageSize)
        => await _repo.GetAll(page, pageSize);

    public async Task<Product> Get(Guid id)
        => await _repo.GetById(id);

    public async Task Update(Guid id, ProductDto dto)
    {
        var product = await _repo.GetById(id);

        product.Update(dto.Price, dto.Stock);

        await _repo.Update();
    }

    public async Task Delete(Guid id)
    {
        var product = await _repo.GetById(id);
        await _repo.Delete(product);
    }
}