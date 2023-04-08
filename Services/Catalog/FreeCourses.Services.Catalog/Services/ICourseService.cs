using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Course;

namespace FreeCourses.Services.Catalog.Services
{
    public interface ICourseService
    {
        Task<Response<List<CourseDto>>> GetAllAsync();
        Task<Response<CourseDto>> GetByIdAsync(string id);
        Task<Response<CourseDto>> CreateAsync(CourseCreateDto course);
        Task<Response<NoConetent>> UpdateAsync(CourseUpdateDto course);
        Task<Response<NoConetent>> DeleteAsync(string id);

        Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);
    }
}
