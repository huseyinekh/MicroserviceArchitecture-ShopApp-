using AutoMapper;
using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Slider;
using FreeCourses.Services.Catalog.Models;
using FreeCourses.Services.Catalog.Services.interfaces;
using FreeCourses.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCourses.Services.Catalog.Services
{
    public class SliderService : ISliderService
    {

        private readonly IMapper _mapper;
        private readonly IMongoCollection<Slider> _sliderCollection;

        public SliderService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;

            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sliderCollection =
                database.GetCollection<Slider>(databaseSettings.SliderCollectionName);
        }


        public async Task<Response<List<SliderDto>>> GetAllAsync() =>
              Response<List<SliderDto>>.Success(
                  _mapper.Map<List<SliderDto>>(
                      await _sliderCollection.Find(x => true).ToListAsync()), 200);

        public async Task<Response<SliderDto>> GetByIdAsync(string id)
        {
            var _Slider = await _sliderCollection.
                Find<Slider>(x => x.Id == id).FirstOrDefaultAsync();
            if (_Slider == null)
                return Response<SliderDto>.Fail("Slider Not Found", 404);
            return Response<SliderDto>.Success(_mapper.Map<SliderDto>(_Slider), 200);
        }

        public async Task<Response<SliderDto>> CreateAsync(SliderDto SliderDto)
        {
            var Slider = _mapper.Map<Slider>(SliderDto);
            await _sliderCollection.InsertOneAsync(Slider);
            return Response<SliderDto>
                .Success(_mapper.Map<SliderDto>(Slider), 200);
        }

        public async Task<Response<NoConetent>> DeleteAsync(string id)
        {
            var deleteItem = await _sliderCollection.DeleteOneAsync(x => x.Id == id);
            if (deleteItem.DeletedCount > 0)
                return Response<NoConetent>.Success(204);
            return Response<NoConetent>.Fail("Not found SliderItem", 404);
        }
    }
}
