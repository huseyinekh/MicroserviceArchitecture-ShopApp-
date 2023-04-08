using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Shared.Models;
using MediatR;

namespace FreeCourse.Services.Order.Application.Queries
{
    public class GetOrdersBUserIdQuery : IRequest<Response<List<OrderDto>>>
    {
        public string BuyerId { get; set; }
    }
}
