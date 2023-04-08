using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Size;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface ISizeService
    {
        Task<Response<SizeDto>> CreateAsync(SizeDto category);
        Task<Response<List<SizeDto>>> GetAllAsync();
        Task<Response<SizeDto>> GetByIdAsync(string id);
        Task<Response<NoConetent>> DeleteAsync(string id);

    }
}
