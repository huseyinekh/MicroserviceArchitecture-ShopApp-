using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Popularity;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class PopularityService : IPopularityService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Popularity> _popularityCollection;

        public PopularityService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _popularityCollection =
                database.GetCollection<Popularity>(databaseSettings.PopularityCollectionName);
        }


        public async Task<Response<List<PopularityDto>>> GetAllAsync() =>
              Response<List<PopularityDto>>.Success(
                  _mapper.Map<List<PopularityDto>>(
                      await _popularityCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<PopularityDto>> GetByIdAsync(string id)
        {
            var _Popularity = await _popularityCollection.
                Find<Popularity>(x => x.Id == id).FirstOrDefaultAsync();
            if (_Popularity == null)
                return Response<PopularityDto>.Fail("Popularity Not Found", 404);
            return Response<PopularityDto>.Success(_mapper.Map<PopularityDto>(_Popularity), 200);
        }

        public async Task<Response<PopularityDto>> CreateAsync(PopularityDto PopularityDto)
        {
            var Popularity = _mapper.Map<Popularity>(PopularityDto);
            await _popularityCollection.InsertOneAsync(Popularity);
            return Response<PopularityDto>
                .Success(_mapper.Map<PopularityDto>(Popularity), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var deleteItem = await _popularityCollection.DeleteOneAsync(x => x.Id == id);
            if (deleteItem.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Not found PopularityItem", 404);
        }
    }
}
