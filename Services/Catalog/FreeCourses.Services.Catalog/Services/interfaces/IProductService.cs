using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Product;

namespace FreeCourses.Services.Catalog.Services.interfaces
{
    public interface IProductService
    {
        Task<Response<List<ProductDto>>> GetAllAsync();
        Task<Response<List<ProductDto>>> GetByPage(int pageNum);
        Task<Response<List<ProductDto>>> GetByColor(string colorId);
        Task<Response<List<ProductDto>>> GetByCategory(string categoryId);
        Task<Response<List<ProductDto>>> GetBySize(string size);
        Task<Response<List<ProductDto>>> Search(string searchWord);

        Task<Response<ProductDto>> GetByIdAsync(string id);
        Task<Response<ProductCreateDto>> CreateAsync(ProductCreateDto course);
        Task<Response<NoConetent>> UpdateAsync(ProductDto course);
        Task<Response<NoConetent>> DeleteAsync(string id);
    }
}
