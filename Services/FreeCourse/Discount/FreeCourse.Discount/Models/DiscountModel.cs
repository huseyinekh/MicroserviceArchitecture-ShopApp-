namespace FreeCourse.Discount.Models
{

    [Dapper.Contrib.Extensions.Table("discount")]
    public class DiscountModel
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Code { get; set; }


    }
}
