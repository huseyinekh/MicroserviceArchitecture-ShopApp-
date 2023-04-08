using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using MyIdentityServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyIdentityServer.Services
{
    public class IdentityResourcePasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourcePasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await _userManager.FindByEmailAsync(context.UserName);
            Dictionary<string, object> Errors = new Dictionary<string, object>();

            if (existUser == null)
            {
                Errors.Add("errors", new List<string> { "email ve ya password yalnis" });
                context.Result.Error = Errors.ToString();
                return;
            }


            var checkPassword = await _userManager.CheckPasswordAsync(existUser, context.Password);

            if (!checkPassword)
            {
                Errors.Add("errors", new List<string> { "email ve ya password yalnis" });
                context.Result.CustomResponse = Errors;
                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString()
                    , OidcConstants.AuthenticationMethods.Password);



        }
    }
}
