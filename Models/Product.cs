public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Product()
    {
        Id = 0;
        Name = string.Empty;
        Description = string.Empty;
        Price = 0.0M;
    }
}