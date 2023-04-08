using FreeCourse.Shared.BaseController;
using FreeCourses.Services.Catalog.Dtos.Contact;
using FreeCourses.Services.Catalog.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourses.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : CustomBaseController
    {

        private readonly IContactService contactService;

        public ContactController(IContactService cs)
        {
            contactService = cs;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await contactService.GetAllAsync();
            return CreateActionResultInstance(res);
        }


        //public async Task<IActionResult> GetAllMessageAsync()
        //{
        //    var res = await contactService.GetAllMessagesAsync();
        //    return CreateActionResultInstance(res);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ContactCreateDto category)
        {
            var res = await contactService.CreateAsync(category);
            return CreateActionResultInstance(res);
        }

    }
}
