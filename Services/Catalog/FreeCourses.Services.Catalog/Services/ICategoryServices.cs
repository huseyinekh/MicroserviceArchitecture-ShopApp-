using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Category;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface ICategoryService
    {
        Task<Response<CategoryDto>> CreateAsync(CategoryDto for_);
        Task<Response<List<CategoryDto>>> GetAllAsync();
        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
