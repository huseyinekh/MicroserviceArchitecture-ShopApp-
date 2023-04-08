using FluentValidation.AspNetCore;
using FreeCourse.Shared.Services;
using FreeCourse.Web.Handler;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp_.Extensions;
using WebApp_.Handler;
using WebApp_.Helpers;
using WebApp_.Models;
using WebApp_.Models.Catalog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddAccessTokenManagement();

builder.Services.AddSingleton<PhotoHelper>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<ClientCredentialTokenHandler>();
builder.Services.AddScoped<ISharedIdentityService, SharedIdentityService>();


//===0
builder.Services.AddHttpClientServices(builder.Configuration);
//===1

builder.Services.Configure<ServiceApiSettings>
        (builder.Configuration.GetSection(nameof(ServiceApiSettings)));
builder.Services.Configure<ClientSettings>
    (builder.Configuration.GetSection(nameof(ClientSettings)));


builder.Services.AddControllersWithViews().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<CourseCreateInput>();
});

//builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


// cookie config 0
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
    {
        opts.LoginPath = "/Auth/SignIn";
        opts.ExpireTimeSpan = TimeSpan.FromDays(60);
        opts.SlidingExpiration = true;
        opts.Cookie.Name = "authCookie";


    });
// 1


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
