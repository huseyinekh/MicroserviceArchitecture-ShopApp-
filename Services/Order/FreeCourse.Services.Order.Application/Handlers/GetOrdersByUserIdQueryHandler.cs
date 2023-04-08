using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Application.Mapping;
using FreeCourse.Services.Order.Application.Queries;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Shared.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FreeCourse.Services.Order.Application.Handlers
{
    public class GetOrdersByUserIdQueryHandler :
                    IRequestHandler<GetOrdersBUserIdQuery, Response<List<OrderDto>>>
    {
        private readonly OrderDBContext _context;
        public GetOrdersByUserIdQueryHandler(OrderDBContext contex)
        {
            _context = contex;

        }
        public async Task<Response<List<OrderDto>>> Handle(GetOrdersBUserIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _context.Orders
                                .Include(x => x.OrderItems)
                                  .Where(o => o.BuyerId == request.BuyerId).ToListAsync();

            if (!orders.Any())
            {
                return Response<List<OrderDto>>.Success(new List<OrderDto>(), 200);
            }

            var orderDto = ObjectMapper.Mapper.Map<List<OrderDto>>(orders);

            return Response<List<OrderDto>>.Success(orderDto, 200);

        }
    }
}
