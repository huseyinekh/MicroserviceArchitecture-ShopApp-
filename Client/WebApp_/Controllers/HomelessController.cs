using Microsoft.AspNetCore.Diagnostics;
using System.Diagnostics;
using WebApp_.Exception;
using WebApp_.Models;
using WebApp_.Services.Intefaces;

namespace WebApp_.Controllers
{
    public class HomelessController : Controller
    {
        private readonly ILogger<HomelessController> _logger;
        private readonly ICatalogService _catalogService;


        public HomelessController(ILogger<HomelessController> logger, ICatalogService catalogService)
        {
            _logger = logger;
            _catalogService = catalogService;
        }

        public async Task<IActionResult> Index()
        {
            var res = await _catalogService.GetAllCourseAsync();

            return View(res);
        }

        public async Task<IActionResult> Detail(string id)
        {
            return View(await _catalogService.GetByCourseId(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorFeatures = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (errorFeatures != null & errorFeatures.Error is UnAuthorizeException)
            {
                return RedirectToAction(nameof(AuthController.LogOut), "Auth");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}