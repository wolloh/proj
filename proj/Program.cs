using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using proj.Dependency;
using Microsoft.EntityFrameworkCore;
using proj.EF;
using proj.BLL.Interfaces;
using proj.BLL.Services;
using proj.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<OrderDBContext>(options =>
options.UseSqlServer("Name=OrderDB"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddScoped<EfCoreRepository<Order,OrderDBContext>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
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
