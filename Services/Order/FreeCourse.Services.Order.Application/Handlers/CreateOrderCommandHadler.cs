using FreeCourse.Services.Order.Application.Commands;
using FreeCourse.Services.Order.Application.Dtos;
using FreeCourse.Services.Order.Infrastructure;
using FreeCourse.Sevices.Order.Domain.OrderAggregate;
using FreeCourse.Shared.Models;
using MediatR;

namespace FreeCourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHadler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>

    {
        private readonly OrderDBContext _context;
        public CreateOrderCommandHadler(OrderDBContext contex)
        {
            _context = contex;
        }
        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province,
                                    request.Address.District
                                    , request.Address.Street, request.Address.ZipCode,
                                    request.Address.Line);

            Sevices.Order.Domain.OrderAggregate.Order newOrder =
                new Sevices.Order.Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _context.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto() { OrderId = newOrder.Id }, 200);



        }


    }
}
