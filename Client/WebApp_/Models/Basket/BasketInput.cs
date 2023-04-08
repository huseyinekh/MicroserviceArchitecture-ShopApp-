namespace WebApp_.Models.Basket
{
    public class BasketInput
    {
        public string UserId { get; set; }

        public string? DiscountCode { get; set; }

        public int? DiscountRate { get; set; }
        public List<BasketItemViewModel> basketItems { get; set; }

        public decimal TotalPrice
        {
            get => basketItems is not null ? basketItems.Sum(x => x.Price) : decimal.Zero;

        }
    }
}
