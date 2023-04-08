using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Dtos.Color;
using FreeCourses.Services.Catalog.Dtos.For;
using FreeCourses.Services.Catalog.Dtos.Popularity;
using FreeCourses.Services.Catalog.Dtos.Size;

namespace FreeCourses.Services.Catalog.Dtos.Product
{
    public class ProductCreateDto
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int UnitsOfStock { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<ColorDto>? Color { get; set; }
        public IEnumerable<PopularityDto>? Popularity { get; set; }
        public string PopularityId { get; set; }
        public IEnumerable<string> ColorIds { get; set; }
        public IEnumerable<SizeDto>? Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<string> SizeIds { get; set; }
        public ForDto? For { get; set; }
        public string ForId { get; set; }
        public CategoryDto? Category { get; set; }
        public string? CategoryId { get; set; }
    }
}
