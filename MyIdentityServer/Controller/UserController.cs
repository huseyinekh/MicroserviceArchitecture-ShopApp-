using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyIdentityServer.Dtos;
using MyIdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MyIdentityServer.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signUpDto)
        {
            var appUser = new ApplicationUser()
            {
                UserName = signUpDto.UserName,
                Email = signUpDto.Email,
                City = signUpDto.City

            };
            var res = await _userManager.CreateAsync(appUser, signUpDto.Password);

            if (!res.Succeeded)
                return BadRequest(res.Errors.Select(x => x.Description).ToList());
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var UserIdClaims = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (UserIdClaims == null) return BadRequest();

            var user = await _userManager.FindByIdAsync(UserIdClaims.Value);

            if (user == null) return BadRequest();
            return Ok(new { user.Id, user.UserName, user.City });

        }
    }
}
