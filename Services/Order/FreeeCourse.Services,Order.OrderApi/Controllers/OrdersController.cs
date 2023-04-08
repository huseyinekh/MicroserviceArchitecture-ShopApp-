using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeeCourse.Services_Order.OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public OrdersController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrder()
        {
            var res = await _mediator.Send(new GetOrdersBUserIdQuery()
            { BuyerId = _sharedIdentityService.GetUserId });

            return CreateActionResultInstance(res);
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser(CreateOrderCommand command)
        {
            var res = await _mediator.Send(command);
            return CreateActionResultInstance(res);
        }
    }
}
