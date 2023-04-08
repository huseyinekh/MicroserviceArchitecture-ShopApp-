using DailyShopApp.Models;
using System.Diagnostics;

namespace DailyShopApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Products(string? Name)
        {
            string[] catNames = new string[] { "men", "women", "kids", "sports" };
            string[] popularity = new string[] { "popular", "brand", "latest" };
            ViewBag.Title = "men";
            TempData["Title"] = "Men";

            return View();
        }

        public IActionResult Contact()
        {
            TempData["Title"] = "Contact";
            return View();
        }
        public IActionResult Blogs()
        {
            TempData["Title"] = "Blogs";
            return View();
        }
        public IActionResult WhishList()
        {
            TempData["Title"] = "Whishlist";
            return View();
        }


        public IActionResult Blog()
        {
            TempData["Title"] = "Blog";
            return View();
        }
        public IActionResult Product(int? id)
        {
            TempData["Title"] = "Product";
            return View();
        }
        public IActionResult Card(int? idt)
        {
            TempData["Title"] = "Cart";
            return View();
        }
        public IActionResult Checkout(int? idt)
        {
            TempData["Title"] = "Checkout";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}