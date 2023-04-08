namespace DailyShopApp.Models
{
    public class Product
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int UnitsOfStock { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Price { get; set; }
        public Color? Color { get; set; }
        public Size? Size { get; set; }
        public For? For { get; set; }
        public Category? Category { get; set; }
        public string? CategoryId { get; set; }
    }
}
