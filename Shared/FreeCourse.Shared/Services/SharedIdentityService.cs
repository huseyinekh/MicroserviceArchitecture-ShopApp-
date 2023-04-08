using Microsoft.AspNetCore.Http;

namespace FreeCourse.Shared.Services
{
    public class SharedIdentityService : ISharedIdentityService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public SharedIdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;

    }
}
