using Microsoft.AspNetCore.Authorization;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

//startup add



JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");


var reqAuthPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddAuthentication().AddJwtBearer("webgatewayScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "webgateway_resource";
    opt.RequireHttpsMetadata = false;
});



//builder.Services.AddControllers(opt =>
//{
//    opt.Filters.Add(new AuthorizeFilter(reqAuthPolicy));
//});



builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToString().ToLower()}.json")
                    .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);


var app = builder.Build();

await app.UseOcelot();
app.UseAuthorization();
app.Run();
