using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dto.Author;
using FreeCourses.Services.Catalog.Dtos.Blog;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Blog> _BlogCollection;
        private readonly IMongoCollection<Author> _AuthorCollection;


        public BlogService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _BlogCollection =
                database.GetCollection<Blog>(databaseSettings.BlogCollectionName);

            _AuthorCollection =
              database.GetCollection<Author>(databaseSettings.AuthorCollectionName);
        }

        public async Task<Response<BlogDto>> CreateAsync(BlogCreateDto blog)
        {
            var category = _mapper.Map<Blog>(blog);
            await _BlogCollection.InsertOneAsync(category);
            return Response<BlogDto>
                .Success(_mapper.Map<BlogDto>(category), 200);
        }

        public async Task<Response<AuthorCreateDto>> CreateAuthorAsync(AuthorCreateDto author)
        {
            var category = _mapper.Map<Author>(author);
            await _AuthorCollection.InsertOneAsync(category);
            return Response<AuthorCreateDto>
                .Success(_mapper.Map<AuthorCreateDto>(category), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var res = await _BlogCollection.DeleteOneAsync(x => x.Id == id);
            if (res.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Course cannot  deleted", 404);
        }

        public async Task<Response<NoConetent>> DeleteAuthorAsync(string id)
        {

            var res = await _AuthorCollection.DeleteOneAsync(x => x.Id == id);
            if (res.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Course cannot  deleted", 404);
        }



        public async Task<Response<List<BlogDto>>> GetAllAsync()
       =>
              Response<List<BlogDto>>.Success(
                  _mapper.Map<List<BlogDto>>(
                      await _BlogCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<List<AuthorDto>>> GetAllAuthorAsync()
         =>
              Response<List<AuthorDto>>.Success(
                  _mapper.Map<List<AuthorDto>>(
                      await _AuthorCollection.Find(x => true).ToListAsync()), 200);


        public async Task<Response<BlogDto>> GetByIdAsync(string id)
        {

            var category = await _BlogCollection.
                Find<Blog>(x => x.Id == id).FirstOrDefaultAsync();
            if (category == null)
                return Response<BlogDto>.Fail("Category Not Found", 404);
            return Response<BlogDto>.Success(_mapper.Map<BlogDto>(category), 200);

        }

        public async Task<Response<List<BlogDto>>> GetByPageAsync(int pageNumber)
        {
            var blogs = await _BlogCollection.Find(x => true)
                .Skip(pageNumber * 5)
                .Limit(5).ToListAsync();
            if (blogs == null)
                return Response<List<BlogDto>>.Fail("Category Not Found", 404);
            return Response<List<BlogDto>>.Success(_mapper.Map<List<BlogDto>>(blogs), 200);

        }

        public async Task<Response<List<BlogDto>>> Search(string searchWord)
        {
            var category = await _BlogCollection.
                Find<Blog>(x => x.Name.Contains(searchWord)
                                | x.Description.Contains(searchWord))
                                    .ToListAsync();
            if (category == null)
                return Response<List<BlogDto>>.Fail("Category Not Found", 404);
            return Response<List<BlogDto>>.Success(_mapper.Map<List<BlogDto>>(category), 200);
        }

        public async Task<Response<NoConetent>> UpdateAsync(BlogUpdateDto data)
        {
            var updateData = _mapper.Map<Blog>(data);
            var res = await _BlogCollection.FindOneAndReplaceAsync(x => x.Id == updateData.Id, updateData);

            if (res == null)
                return Response<NoConetent>.Fail("Course Not Found", 404);
            return Response<NoConetent>.Success(200);
        }

        public async Task<Response<NoConetent>> UpdateAuthorAsync(AuthorUpdateDto author)
        {
            var updateData = _mapper.Map<Author>(author);
            var res = await _AuthorCollection
                .FindOneAndReplaceAsync(x => x.Id == updateData.Id, updateData);
            if (res == null)
                return Response<NoConetent>.Fail("Auhtor Not Found", 404);
            return Response<NoConetent>.Success(200);
        }

    }
}
