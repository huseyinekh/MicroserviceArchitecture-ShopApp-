using WebApp_.Models;

namespace WebApp_.Services.Intefaces
{
    public interface IUserService
    {
        Task<UserViewModel> GetUser();
    }
}
