using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Color;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface IColorService
    {
        Task<Response<ColorDto>> CreateAsync(ColorDto category);
        Task<Response<List<ColorDto>>> GetAllAsync();
        Task<Response<ColorDto>> GetByIdAsync(string id);
        Task<Response<ColorDto>> DeleteAsync(string id);

    }
}
