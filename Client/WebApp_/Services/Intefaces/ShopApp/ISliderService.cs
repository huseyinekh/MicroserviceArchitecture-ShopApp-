using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Slider;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface ISliderService
    {
        Task<Response<SliderDto>> CreateAsync(SliderDto category);
        Task<Response<List<SliderDto>>> GetAllAsync();
        Task<Response<SliderDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);
    }
}
