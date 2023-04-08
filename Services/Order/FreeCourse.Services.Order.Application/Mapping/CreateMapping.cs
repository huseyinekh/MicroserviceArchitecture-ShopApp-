using AutoMapper;
using FreeCourse.Services.Order.Application.Dtos;

namespace FreeCourse.Services.Order.Application.Mapping
{
    public class CreateMapping : Profile
    {
        public CreateMapping()
        {
            CreateMap<Sevices.Order.Domain.OrderAggregate.Order, OrderDto>().ReverseMap();
            CreateMap<Sevices.Order.Domain.OrderAggregate.OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Sevices.Order.Domain.OrderAggregate.Address, AddressDto>().ReverseMap();

        }
    }
}
