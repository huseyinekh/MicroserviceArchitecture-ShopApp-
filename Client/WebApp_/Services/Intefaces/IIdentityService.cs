using FreeCourse.Shared.Models;
using IdentityModel.Client;
using WebApp_.Models;

namespace WebApp_.Services.Intefaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SigninInput signinInput);
        Task<TokenResponse> GetAccessTokenByRefreshToken();
        Task RevokeRefreshToken();
    }
}
