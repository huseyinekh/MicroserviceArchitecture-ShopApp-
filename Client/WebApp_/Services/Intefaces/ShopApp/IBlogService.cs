using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dto.Author;
using FreeCourses.Services.Catalog.Dtos.Blog;
using FreeCourses.Services.Catalog.Models;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface IBlogService
    {
        Task<Response<List<BlogDto>>> GetAllAsync();
        Task<Response<BlogDto>> GetByIdAsync(string id);
        Task<Response<List<BlogDto>>> GetByPageAsync(int pageNumber);
        Task<Response<List<BlogDto>>> Search(string searchWord);

        Task<Response<BlogDto>> CreateAsync(BlogCreateDto course);
        Task<Response<NoConetent>> UpdateAsync(BlogUpdateDto course);
        Task<Response<NoConetent>> DeleteAsync(string id);


        Task<Response<List<AuthorDto>>> GetAllAuthorAsync();
        Task<Response<AuthorCreateDto>> CreateAuthorAsync(AuthorCreateDto author);
        Task<Response<NoConetent>> UpdateAuthorAsync(AuthorUpdateDto author);
        Task<Response<NoConetent>> DeleteAuthorAsync(string id);






    }
}
