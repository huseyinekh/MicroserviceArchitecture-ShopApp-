using FreeCourses.Services.Catalog.Services;
using FreeCourses.Services.Catalog.Services.interfaces;

namespace FreeCourses.Services.Catalog.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServiceCollections(this IServiceCollection Services)
        {
            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<IColorService, ColorService>();
            Services.AddScoped<ICourseService, CourseService>();
            Services.AddScoped<IBlogService, BlogService>();
            Services.AddScoped<IContactService, ContactService>();
            Services.AddScoped<IForService, ForService>();
            Services.AddScoped<IProductService, ProductService>();
            Services.AddScoped<IPopularityService, PopularityService>();
            Services.AddScoped<ISizeService, SizeService>();
            Services.AddScoped<ISliderService, SliderService>();
            Services.AddScoped<ISubscribeService, SubscribeService>();


            return Services;
        }
    }
}
