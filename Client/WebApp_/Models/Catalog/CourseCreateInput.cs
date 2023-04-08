using System.ComponentModel.DataAnnotations;

namespace WebApp_.Models.Catalog
{
    public class CourseCreateInput
    {

        [Display(Name = "Kursun adı")]
        public string Name { get; set; } = null!;

        [Display(Name = "Kurs haqqında")]
        public string? Description { get; set; }

        [Display(Name = "Kurs qiyməti")]
        public decimal Price { get; set; } = Decimal.Zero;

        public string? Picture { get; set; }

        public string? UserId { get; set; }

        public FeatureViewModel? Feature { get; set; }

        [Display(Name = "Kurs kateqoriya")]
        public string? CategoryId { get; set; }

        [Display(Name = "Kursun şəkli")]
        public IFormFile? PhotoFormFile { get; set; }
    }
}
