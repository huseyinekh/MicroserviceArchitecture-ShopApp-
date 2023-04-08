using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Color;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface IColorService
    {
        Task<Response<ColorDto>> CreateAsync(ColorDto category);
        Task<Response<List<ColorDto>>> GetAllAsync();
        Task<Response<ColorDto>> GetByIdAsync(string id);
        Task<Response<ColorDto>> DeleteAsync(string id);

    }
}
