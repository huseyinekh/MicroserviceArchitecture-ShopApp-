using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection =
                database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }


        public async Task<Response<List<CategoryDto>>> GetAllAsync() =>
              Response<List<CategoryDto>>.Success(
                  _mapper.Map<List<CategoryDto>>(
                      await _categoryCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.
                Find<Category>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Response<CategoryDto>.Fail("Category Not Found", 404);
            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);
            return Response<CategoryDto>
                .Success(_mapper.Map<CategoryDto>(category), 200);
        }

    }
}
