namespace ManagementSystem.Client.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
    }
}
