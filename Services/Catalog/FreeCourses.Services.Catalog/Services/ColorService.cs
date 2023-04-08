using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Color;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class ColorService : IColorService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Color> _ColorCollection;

        public ColorService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _ColorCollection =
                database.GetCollection<Color>(databaseSettings.ColorCollectionName);
        }


        public async Task<Response<List<ColorDto>>> GetAllAsync() =>
              Response<List<ColorDto>>.Success(
                  _mapper.Map<List<ColorDto>>(
                      await _ColorCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<ColorDto>> GetByIdAsync(string id)
        {


            var Color = await _ColorCollection.
                Find<Color>(x => x.Id == id).FirstOrDefaultAsync();
            if (Color == null)
                return Response<ColorDto>.Fail("Color Not Found", 404);
            return Response<ColorDto>.Success(_mapper.Map<ColorDto>(Color), 200);
        }

        public async Task<Response<ColorDto>> CreateAsync(ColorDto ColorDto)
        {
            var Color = _mapper.Map<Color>(ColorDto);
            await _ColorCollection.InsertOneAsync(Color);
            return Response<ColorDto>
                .Success(_mapper.Map<ColorDto>(Color), 200);
        }

        public Task<Response<ColorDto>> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
