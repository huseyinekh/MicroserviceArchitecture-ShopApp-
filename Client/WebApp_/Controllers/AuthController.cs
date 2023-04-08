using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp_.Models;
using WebApp_.Services.Intefaces;

namespace WebApp_.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<IActionResult> SignIn(SigninInput input)
        {
            TempData["Title"] = "Men";
            if (!ModelState.IsValid)
            {
                return View();
            }

            var res = await _identityService.SignIn(input);

            if (!res.IsSuccess)
            {
                res.Errors.ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error);
                });
                return View();

            }
            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await _identityService.RevokeRefreshToken();
            return RedirectToAction(nameof(Index), "Home");

        }
    }
}
