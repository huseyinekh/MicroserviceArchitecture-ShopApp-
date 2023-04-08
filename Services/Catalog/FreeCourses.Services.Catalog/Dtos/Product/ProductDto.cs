using FreeCourses.Services.Catalog.Dtos.Color;
using FreeCourses.Services.Catalog.Dtos.Popularity;
using FreeCourses.Services.Catalog.Dtos.Size;

namespace FreeCourses.Services.Catalog.Dtos.Product
{
    public class ProductDto
    {

        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int UnitsOfStock { get; set; }
        public decimal Price { get; set; }
        public List<ColorDto>? Color { get; set; }
        public List<PopularityDto>? Popularity { get; set; }
        public string PopularityId { get; set; }
        public List<string> ColorIds { get; set; }
        public List<SizeDto>? Size { get; set; }

        public List<string> SizeIds { get; set; }
    }

}
