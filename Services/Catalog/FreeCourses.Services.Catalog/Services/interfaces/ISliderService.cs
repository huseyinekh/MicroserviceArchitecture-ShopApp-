using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Slider;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface ISliderService
    {
        Task<Response<SliderDto>> CreateAsync(SliderDto category);
        Task<Response<List<SliderDto>>> GetAllAsync();
        Task<Response<SliderDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);
    }
}
