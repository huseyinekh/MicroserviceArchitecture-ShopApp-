using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Popularity;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface IPopularityService
    {
        Task<Response<PopularityDto>> CreateAsync(PopularityDto data);
        Task<Response<List<PopularityDto>>> GetAllAsync();
        Task<Response<PopularityDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);

    }
}
