using FreeCourse.Basket.Dtos;
using FreeCourse.Shared.Models;

namespace FreeCourse.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> Get(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

        Task<Response<bool>> Delete(string userId);
    }
}
