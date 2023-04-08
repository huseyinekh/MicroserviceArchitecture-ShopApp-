using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Subscribe;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface ISubscribeService
    {
        Task<Response<SubscribeDto>> CreateAsync(SubscribeDto category);
        Task<Response<List<SubscribeDto>>> GetAllAsync();
        Task<Response<SubscribeDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);

    }
}
