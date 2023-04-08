using FreeCourses.Services.Catalog.Dtos.Product;

namespace DailyShopApp.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(List<ProductDto> products)
        {
            return View(products);
        }
    }
}
