using FreeCourse.Services.FakePayment.Dtos;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : CustomBaseController
    {
        public FakePaymentController()
        {

        }


        [HttpPost]
        public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
        {
            return CreateActionResultInstance(Response<NoConetent>.Success(200));
        }
    }
}
