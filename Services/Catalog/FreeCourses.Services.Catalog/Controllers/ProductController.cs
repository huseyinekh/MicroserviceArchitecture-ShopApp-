using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController

    {

        private readonly IProductService productService;

        public ProductController(IProductService ps)
        {
            productService = ps;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await productService.GetAllAsync();

            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await productService.GetByIdAsync(id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductCreateDto category)
        {
            var res = await productService.CreateAsync(category);
            return CreateActionResultInstance(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(ProductDto category)
        {
            var res = await productService.UpdateAsync(category);
            return CreateActionResultInstance(res);
        }

    }
}
