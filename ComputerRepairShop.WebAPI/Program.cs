using ComputerRepairShop.Domain;
using ComputerRepairShop.Repository;
using ComputerRepairShop.Service;
using ComputerRepairShop.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;

// Get application configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

//
// Add services to the container -->
//
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add application services
builder.Services
    .AddDbContext<ShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
    .AddScoped<IRepository<Device>, Repository<Device>>()
    .AddScoped<IDeviceService, DeviceService>();
//
// Add services to the container <--
//

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.PrepareDatabase();

app.Run();
