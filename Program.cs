using ConsoleToDB.Data;
using Contracts;
using Microsoft.EntityFrameworkCore;
using Repositary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(optionsAction: options =>
          options.UseSqlServer(builder.Configuration.GetConnectionString("connectDB")));
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerDetailServices, CustomerDetailRepositary>();
builder.Services.AddScoped<IHotelBookingServices, HotelBookingRepositary>();
builder.Services.AddScoped<IRoomDetailServices, RoomDetailRepositary>();

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
