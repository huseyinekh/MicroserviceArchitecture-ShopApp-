using Microsoft.AspNetCore.Mvc;

namespace DailyShopApp.Components
{
    public class PromoViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
