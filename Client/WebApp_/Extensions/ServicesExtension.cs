using FreeCourse.Web.Handler;
using WebApp_.Handler;
using WebApp_.Models;
using WebApp_.Services;
using WebApp_.Services.Intefaces;
using WebApp_.Services.Intefaces.ShopApp;
using WebApp_.Services.ShopApp;

namespace WebApp_.Extensions
{
    public static class ServicesExtension
    {
        public static void AddHttpClientServices
                    (this IServiceCollection services, IConfiguration configuration)
        {
            var serviceApiSettings = configuration
                .GetSection(nameof(ServiceApiSettings))
                    .Get<ServiceApiSettings>();

            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
            services.AddHttpClient<IIdentityService, IdentityService>();
            services.AddHttpClient<IUserService, UserService>(_ =>
            {
                _.BaseAddress = new Uri(serviceApiSettings.BaseUri);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IBasketService, BasketService>(_ =>
            {
                _.BaseAddress = new
               Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(_ =>
            {
                _.BaseAddress = new
               Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Discount.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IPaymentService, PaymentService>(_ =>
            {
                _.BaseAddress = new
               Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Payment.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            services.AddHttpClient<IOrderService, OrderService>(_ =>
            {
                _.BaseAddress = new
               Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();
            //----------------
            services.AddHttpClient<ICatalogService, CatalogService>(opt =>
            {
                opt.BaseAddress = new
                Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
            services.AddHttpClient<IPhotoStockService, PhotoStockService>(opt =>
            {
                opt.BaseAddress = new
                Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.PhotoStock.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(opt =>
            {
                opt.BaseAddress = new
                Uri($"{serviceApiSettings.GatewayBaseUri}{serviceApiSettings.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();



        }
    }
}
