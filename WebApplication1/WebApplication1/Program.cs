using WebApplication1.Services;
using WebApplication1.Services.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Dependency Injection
builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
