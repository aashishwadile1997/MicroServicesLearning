


using Cataog_API.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to container
builder.Services.AddCarter();

builder.Services.AddMediatR(config =>
{

    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidateBehaviours<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database"));
}).UseLightweightSessions();

//if (builder.Environment.IsDevelopment())
//    builder.Services.InitializeMartenWith<CatalogInitialData>();
builder.Services.AddHealthChecks();
var app = builder.Build();

// configure htpps request pipeline

app.MapCarter();

app.UseExceptionHandler(options => { });
app.UseHealthChecks("/health");
app.Run();
