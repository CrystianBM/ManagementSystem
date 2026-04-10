namespace ManagementSystem.Domain;

public class Product
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string SKU { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string Category { get; private set; }

    protected Product() { } // 👈 ESSENCIAL PRO EF

    public Product(string name, string sku, decimal price, int stock, string category)
    {
        if (stock < 0)
            throw new Exception("Estoque não pode ser negativo");

        if (category == "Eletrônicos" && price < 50)
            throw new Exception("Eletrônicos devem custar no mínimo R$50");

        Id = Guid.NewGuid();
        Name = name;
        SKU = sku;
        Price = price;
        Stock = stock;
        Category = category;
    }

    public void Update(decimal price, int stock)
    {
        if (stock < 0)
            throw new Exception("Estoque não pode ser negativo");

        if (Category == "Eletrônicos" && price < 50)
            throw new Exception("Eletrônicos devem custar no mínimo R$50");

        Price = price;
        Stock = stock;
    }
}