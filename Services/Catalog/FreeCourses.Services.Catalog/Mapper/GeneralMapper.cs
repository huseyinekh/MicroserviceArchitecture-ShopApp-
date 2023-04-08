using AutoMapper;
using FreeCourses.Services.Catalog.Dto.Author;
using FreeCourses.Services.Catalog.Dtos.Blog;
using FreeCourses.Services.Catalog.Dtos.Category;
using FreeCourses.Services.Catalog.Dtos.Color;
using FreeCourses.Services.Catalog.Dtos.Contact;
using FreeCourses.Services.Catalog.Dtos.Course;
using FreeCourses.Services.Catalog.Dtos.Feauture;
using FreeCourses.Services.Catalog.Dtos.For;
using FreeCourses.Services.Catalog.Dtos.Message;
using FreeCourses.Services.Catalog.Dtos.Popularity;
using FreeCourses.Services.Catalog.Dtos.Product;
using FreeCourses.Services.Catalog.Dtos.Size;
using FreeCourses.Services.Catalog.Dtos.Slider;
using FreeCourses.Services.Catalog.Dtos.Subscribe;
using FreeCourses.Services.Catalog.Models;

namespace FreeCourses.Services.Catalog.Mapper
{
    public class GeneralMapper : Profile
    {
        public GeneralMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<CategoryDto, Category>().ReverseMap();

            CreateMap<Course, CourseDto>().ReverseMap(); ;
            CreateMap<Course, CourseCreateDto>().ReverseMap();
            CreateMap<Course, CourseUpdateDto>().ReverseMap();

            CreateMap<Color, ColorDto>().ReverseMap();

            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<MapDto, Map>().ReverseMap();

            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<AuthorCreateDto, Author>().ReverseMap();
            CreateMap<AuthorUpdateDto, Author>().ReverseMap();

            CreateMap<BlogDto, Blog>().ReverseMap();

            CreateMap<ContactDto, Contact>().ReverseMap();
            CreateMap<ContactCreateDto, Contact>().ReverseMap();

            CreateMap<MessageDto, Message>().ReverseMap();



            CreateMap<BlogCreateDto, Blog>().ReverseMap();
            CreateMap<BlogUpdateDto, Blog>().ReverseMap();

            CreateMap<ForDto, For>().ReverseMap();
            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<PopularityDto, Popularity>().ReverseMap();
            CreateMap<SizeDto, Size>().ReverseMap();
            CreateMap<SliderDto, Slider>().ReverseMap();
            CreateMap<SubscribeDto, Subscribe>().ReverseMap();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<ProductCreateDto, Product>().ReverseMap();

        }
    }
}
