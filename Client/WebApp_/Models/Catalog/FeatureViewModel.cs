using System.ComponentModel.DataAnnotations;

namespace WebApp_.Models.Catalog
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs süre")]
        public int Duration { get; set; }
    }
}
