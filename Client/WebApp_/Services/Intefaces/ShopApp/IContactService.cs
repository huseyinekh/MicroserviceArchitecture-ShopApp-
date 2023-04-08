using FreeCourse.Shared.Models;
using FreeCourses.Services.Catalog.Dtos.Contact;
using FreeCourses.Services.Catalog.Dtos.Message;

namespace WebApp_.Services.Intefaces.ShopApp
{
    public interface IContactService
    {
        Task<Response<List<ContactDto>>> GetAllAsync();
        Task<Response<NoConetent>> CreateAsync(ContactCreateDto data);

        Task<Response<NoConetent>> UpdateAsync(ContactDto data);

        Task<Response<NoConetent>> SendMessage(MessageDto message);

        Task<Response<List<MessageDto>>> GetAllMessagesAsync();
        Task<Response<NoConetent>> DeleteMessageAsync(string id);







    }
}
