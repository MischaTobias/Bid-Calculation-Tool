using BidCalculation.Business.Implements;
using BidCalculation.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ensure environment variables are included in the configuration
builder.Configuration.AddEnvironmentVariables();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? builder.Configuration.GetConnectionString("progiBidCalculation") ?? "";

//Add db connection
builder.Services.AddDbContext<BidCalculationDbContext>(opt => {
    opt.UseMySQL(connectionString);
});

//Add services
builder.Services.AddScoped<IAdditionalCostService, AdditionalCostService>();
builder.Services.AddScoped<IBidCalculationService, BidCalculationService>();
builder.Services.AddScoped<IFeeService, FeeService>();
builder.Services.AddScoped<IFeeTypeService, FeeTypeService>();
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();

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

app.Run();
