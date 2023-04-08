using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Popularity;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface IPopularityService
    {
        Task<Response<PopularityDto>> CreateAsync(PopularityDto data);
        Task<Response<List<PopularityDto>>> GetAllAsync();
        Task<Response<PopularityDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);

    }
}
