using System.ComponentModel.DataAnnotations;

namespace WebApp_.Models
{
    public class SigninInput
    {
        [Display(Name = "Emailinizi qeyd edin")]
        public string Email { get; set; } = null!;
        [Display(Name = "Parolunuzu qeyd edin")]
        public string Password { get; set; } = null!;
        [Display(Name = "Yadda saxla")]
        public bool RememberMe { get; set; }
    }
}
