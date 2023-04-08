using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Blog;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    public class BlogController : CustomBaseController

    {

        private readonly IBlogService blogService;

        public BlogController(IBlogService bs)
        {
            blogService = bs;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await blogService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await blogService.GetByIdAsync(id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BlogCreateDto category)
        {
            var res = await blogService.CreateAsync(category);
            return CreateActionResultInstance(res);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(BlogUpdateDto category)
        {
            var res = await blogService.UpdateAsync(category);
            return CreateActionResultInstance(res);
        }

    }
}
