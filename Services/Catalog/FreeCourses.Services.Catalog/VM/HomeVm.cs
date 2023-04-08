using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Dtos.Slider;

namespace FreeCourses.Services.Catalog.VM
{
    public class HomeVm
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<SliderDto> Sliders { get; set; }

    }
}
