using Microsoft.AspNetCore.Mvc;

namespace DailyShopApp.Components
{
    public class ProductsViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
