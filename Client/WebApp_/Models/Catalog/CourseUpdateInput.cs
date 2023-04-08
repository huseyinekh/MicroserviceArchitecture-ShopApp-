
using System.ComponentModel.DataAnnotations;

namespace WebApp_.Models.Catalog
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }

        [Display(Name = "Kursun adı")]
        public string Name { get; set; } = null!;

        [Display(Name = "Kurs haqqında")]
        public string? Description { get; set; }

        [Display(Name = "Kurs qiyməti")]
        public decimal Price { get; set; } = decimal.Zero;

        public string? UserId { get; set; }

        public string? Picture { get; set; }
        public FeatureViewModel? Feature { get; set; }

        [Display(Name = "Kurs kateqoriya")]
        public string? CategoryId { get; set; }

        [Display(Name = "Kurs şəkli")]
        public IFormFile? PhotoFormFile { get; set; }
    }
}
