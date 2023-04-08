using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Subscribe;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Subscribe> _subscribeCollectionName;

        public SubscribeService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _subscribeCollectionName =
                database.GetCollection<Subscribe>(databaseSettings.SubscribeCollectionName);
        }


        public async Task<Response<List<SubscribeDto>>> GetAllAsync() =>
              Response<List<SubscribeDto>>.Success(
                  _mapper.Map<List<SubscribeDto>>(
                      await _subscribeCollectionName.Find(x => true).ToListAsync()), 200);

        public async Task<Response<SubscribeDto>> GetByIdAsync(string id)
        {
            var _Subscribe = await _subscribeCollectionName.
                Find<Subscribe>(x => x.Id == id).FirstOrDefaultAsync();
            if (_Subscribe == null)
                return Response<SubscribeDto>.Fail("Subscribe Not Found", 404);
            return Response<SubscribeDto>.Success(_mapper.Map<SubscribeDto>(_Subscribe), 200);
        }

        public async Task<Response<SubscribeDto>> CreateAsync(SubscribeDto SubscribeDto)
        {
            var Subscribe = _mapper.Map<Subscribe>(SubscribeDto);
            await _subscribeCollectionName.InsertOneAsync(Subscribe);
            return Response<SubscribeDto>
                .Success(_mapper.Map<SubscribeDto>(Subscribe), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var deleteItem = await _subscribeCollectionName.DeleteOneAsync(x => x.Id == id);
            if (deleteItem.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Not found SubscribeItem", 404);
        }
    }
}
