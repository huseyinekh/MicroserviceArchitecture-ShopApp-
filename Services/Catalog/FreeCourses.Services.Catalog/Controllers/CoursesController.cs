using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Course;
using FreeCourses.Services.Catalog.Services;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : CustomBaseController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _courseService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        [HttpGet]
        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var res = await _courseService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CourseCreateDto courseDto)
        {
            var res = await _courseService.CreateAsync(courseDto);

            return CreateActionResultInstance(res);

        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var res = await _courseService.UpdateAsync(courseUpdateDto);
            return CreateActionResultInstance(res);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            var res = await _courseService.DeleteAsync(id);
            return CreateActionResultInstance(res);
        }

    }
}
