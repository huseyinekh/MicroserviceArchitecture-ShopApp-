using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.For;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class ForService : IForService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<For> _forCollection;

        public ForService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _forCollection =
             database.GetCollection<For>(databaseSettings.ForCollectionName);
        }


        public async Task<Response<List<ForDto>>> GetAllAsync() =>
              Response<List<ForDto>>.Success(
                  _mapper.Map<List<ForDto>>(
                      await _forCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<ForDto>> GetByIdAsync(string id)
        {
            var For = await _forCollection.Find<For>(x => x.Id == id).FirstOrDefaultAsync();
            if (For == null)
                return Response<ForDto>.Fail("For Not Found", 404);
            return Response<ForDto>.Success(_mapper.Map<ForDto>(For), 200);
        }

        public async Task<Response<ForDto>> CreateAsync(ForDto ForDto)
        {
            var For = _mapper.Map<For>(ForDto);
            await _forCollection.InsertOneAsync(For);
            return Response<ForDto>
                .Success(_mapper.Map<ForDto>(For), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {

            var res = await _forCollection.DeleteOneAsync(x => x.Id == id);
            if (res.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("For_ cannot  deleted", 404);
        }
    }
}
