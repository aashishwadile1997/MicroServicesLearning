using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extesions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration).AddInfrastructureServices(builder.Configuration).AddApiServices(builder.Configuration);



//add services to container
var app = builder.Build();




//app.MapGet("/", () => "Hello World!");
// configure http pipeline
app.UseApiServices();

if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
}
app.Run();
