namespace WebApp_.Models.Basket
{
    public class BasketItemViewModel
    {
        public int? Quantity { get; set; } = 1;

        public string CourseId { get; set; }
        public string CourseName { get; set; }

        public decimal Price { get; set; } = 0;

        private decimal? DiscountAppliedPrice;

        public decimal GetCurrentPrice
        {
            get => (Price != 0) && DiscountAppliedPrice != null ? DiscountAppliedPrice.Value : Price;
        }

        public void AppliedDiscount(decimal discountPrice)
        {
            DiscountAppliedPrice = discountPrice;
        }
    }
}
