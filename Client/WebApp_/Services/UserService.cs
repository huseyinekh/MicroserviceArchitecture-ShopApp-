using WebApp_.Models;
using WebApp_.Services.Intefaces;

namespace WebApp_.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {

            _httpClient = httpClient;
        }
        public async Task<UserViewModel> GetUser()
        {
            var res = await _httpClient.GetFromJsonAsync<UserViewModel>("/Api/User/GetUser");
            return res;
        }
    }
}
