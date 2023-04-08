using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Dtos.Slider;
using WebApp_.Models;

namespace WebApp_.VM
{
    public class HomeVM
    {
        public IEnumerable<ProductDto> Products { get; set; }
        public IEnumerable<SliderDto> Sliders { get; set; }
        public SigninInput SigninInput { get; set; } = new SigninInput();


    }
}
