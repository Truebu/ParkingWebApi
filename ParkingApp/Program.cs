using ParkingApp.business.Service;
using ParkingApp.Config;
using ParkingApp.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ParkingService, ParkingServiceImpl>();
builder.Services.AddTransient<ParkingRepository>();
builder.Services.AddTransient<VehicleTypeRepository>();
builder.Services.AddTransient<VehicleTypeRepository>();
builder.Services.AddScoped<ConnectorSql>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
