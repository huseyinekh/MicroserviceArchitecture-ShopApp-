using FreeCourse.Discount.Models;
using FreeCourse.Shared.Models;

namespace FreeCourse.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<DiscountModel>>> GetAll();
        Task<Response<DiscountModel>> GetById(int id);
        Task<Response<NoConetent>> Save(DiscountModel model);
        Task<Response<NoConetent>> Delete(int id);
        Task<Response<NoConetent>> Update(DiscountModel model);
        Task<Response<DiscountModel>> GetByUserIdAndCode(string userId, string code);
    }
}
