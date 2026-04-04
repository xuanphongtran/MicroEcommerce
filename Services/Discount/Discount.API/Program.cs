using Discount.API.Services;
using Discount.Application.Handlers;
using Discount.Core.Repositories;
using Discount.Infrastructure.Repositories;
using Discount.Infrastructure.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// MediatR
var assemlies = new Assembly[]
{
    Assembly.GetExecutingAssembly(), typeof(CreateDiscountHandler).Assembly
};
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemlies));
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddGrpc();

// Database settings
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

var app = builder.Build();

// Seed the database
app.MigrateDatabase();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();
});

app.Run();
