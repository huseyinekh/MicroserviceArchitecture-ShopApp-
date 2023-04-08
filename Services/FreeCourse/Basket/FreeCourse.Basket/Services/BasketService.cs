using FreeCourse.Basket.Dtos;
using FreeCourse.Shared.Models;
using System.Text.Json;

namespace FreeCourse.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;

        }

        public async Task<Response<bool>> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket Cannot update", 500);

        }

        public async Task<Response<BasketDto>> Get(string userId)
        {
            var data = await _redisService.GetDb().StringGetAsync(userId);

            if (string.IsNullOrEmpty(data))
            {
                return Response<BasketDto>.Fail("Not data", 404);
            }

            return Response<BasketDto>.Success(JsonSerializer.Deserialize<BasketDto>(data), 200);
        }

        public async Task<Response<bool>> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync
                (basketDto.UserId, JsonSerializer.Serialize<BasketDto>(basketDto));

            return status ? Response<bool>.Success(204) : Response<bool>.Fail("Basket Cannot update", 500);
        }
    }
}
