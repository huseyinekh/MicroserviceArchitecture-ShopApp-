using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Course;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class CourseService : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Course> _courseCollection;
        private readonly IMongoCollection<Category> _categoryCollection;


        public CourseService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _courseCollection = database.GetCollection<Course>(databaseSettings
                .CourseCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings
                .CategoryCollectionName);
        }

        public async Task<Response<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _courseCollection.Find(x => true).ToListAsync();
            if (courses.Any())
            {
                foreach (Course course in courses)
                {
                    course.Category = await _categoryCollection
                                                .Find(x => x.Id == course.CategoryId)
                                                    .FirstOrDefaultAsync();

                }
                return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);
            }
            var res = new List<CourseDto>();

            return Response<List<CourseDto>>.Success(res, 200);

        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await _courseCollection.Find<Course>(x => x.Id == id).FirstOrDefaultAsync();

            if (course == null)
            {
                return Response<CourseDto>.Fail("Course not found", 404);
            }
            course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(course), 200);
        }


        public async Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await _courseCollection.Find<Course>(x => x.UserId == userId).ToListAsync();

            if (courses.Any())
            {
                foreach (var course in courses)
                {
                    course.Category = await _categoryCollection.Find<Category>(x => x.Id == course.CategoryId).FirstAsync();
                }
            }
            else
            {
                courses = new List<Course>();
            }

            return Response<List<CourseDto>>.Success(_mapper.Map<List<CourseDto>>(courses), 200);

        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto course)
        {
            var newCourse = _mapper.Map<Course>(course);
            newCourse.CreatedDate = DateTime.Now;
            await _courseCollection.InsertOneAsync(newCourse);

            return Response<CourseDto>.Success(_mapper.Map<CourseDto>(newCourse), 200);
        }

        public async Task<Response<NoConetent>> UpdateAsync(CourseUpdateDto course)
        {
            var updateCourse = _mapper.Map<Course>(course);
            var res = await _courseCollection.FindOneAndReplaceAsync(x => x.Id == updateCourse.Id, updateCourse);

            if (res == null)
                return Response<NoConetent>.Fail("Course Not Found", 404);
            return Response<NoConetent>.Success(200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {

            var res = await _courseCollection.DeleteOneAsync(x => x.Id == id);
            if (res.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Course cannot  deleted", 404);

        }
    }
}
