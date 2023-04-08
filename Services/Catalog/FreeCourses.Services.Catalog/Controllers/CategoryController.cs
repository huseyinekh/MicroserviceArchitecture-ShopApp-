using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : CustomBaseController

    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryServices)
        {
            _categoryService = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _categoryService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await _categoryService.GetByIdAsync(id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CategoryDto category)
        {
            var res = await _categoryService.CreateAsync(category);
            return CreateActionResultInstance(res);
        }

    }
}
