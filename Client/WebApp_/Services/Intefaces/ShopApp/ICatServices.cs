using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Category;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface ICatServices
    {
        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
