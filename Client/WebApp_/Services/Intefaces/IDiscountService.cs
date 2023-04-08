using WebApp_.Models.Discount;

namespace WebApp_.Services.Intefaces
{
    public interface IDiscountService
    {
        Task<DiscountViewModel> GetDiscount(string discountCode);
    }
}
