using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Slider;
using FreeCourses.Services.Catalog.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : CustomBaseController
    {
        private readonly ISliderService sliderService;

        public SliderController(ISliderService ps)
        {
            sliderService = ps;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await sliderService.GetAllAsync();
            return CreateActionResultInstance(res);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            var res = await sliderService.GetByIdAsync(id);
            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(SliderDto category)
        {
            var res = await sliderService.CreateAsync(category);
            return CreateActionResultInstance(res);
        }


    }
}
