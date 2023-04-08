namespace DailyShopApp.Components
{
    public class SliderViewComponent : ViewComponent
    {

        public SliderViewComponent()
        {

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
