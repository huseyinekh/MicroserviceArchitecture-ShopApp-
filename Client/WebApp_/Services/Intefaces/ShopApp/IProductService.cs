using FreeCourses.Services.Catalog.Dtos.Product;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();
        Task<List<ProductDto>> GetByPage(int pageNum);
        Task<List<ProductDto>> GetByColor(string colorId);
        Task<List<ProductDto>> GetByCategory(string categoryId);
        Task<List<ProductDto>> GetBySize(string size);
        Task<List<ProductDto>> Search(string searchWord);

        Task<ProductDto> GetByIdAsync(string id);
        Task<bool> CreateAsync(ProductCreateDto course);
        Task<bool> UpdateAsync(ProductDto course);
        Task<bool> DeleteAsync(string id);
    }
}
