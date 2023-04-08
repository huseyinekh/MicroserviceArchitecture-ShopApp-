using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Size;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class SizeService : ISizeService
    {


        private readonly IMapper _mapper;
        private readonly IMongoCollection<Size> _sizeCollection;

        public SizeService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sizeCollection =
                database.GetCollection<Size>(databaseSettings.SizesCollectionName);
        }


        public async Task<Response<List<SizeDto>>> GetAllAsync() =>
              Response<List<SizeDto>>.Success(
                  _mapper.Map<List<SizeDto>>(
                      await _sizeCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<SizeDto>> GetByIdAsync(string id)
        {
            var Size = await _sizeCollection.
                Find<Size>(x => x.Id == id).FirstOrDefaultAsync();
            if (Size == null)
                return Response<SizeDto>.Fail("Size Not Found", 404);
            return Response<SizeDto>.Success(_mapper.Map<SizeDto>(Size), 200);
        }

        public async Task<Response<SizeDto>> CreateAsync(SizeDto SizeDto)
        {
            var Size = _mapper.Map<Size>(SizeDto);
            await _sizeCollection.InsertOneAsync(Size);
            return Response<SizeDto>
                .Success(_mapper.Map<SizeDto>(Size), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var deleteItem = await _sizeCollection.DeleteOneAsync(x => x.Id == id);
            if (deleteItem.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Not found SizeItem", 404);
        }
    }
}
