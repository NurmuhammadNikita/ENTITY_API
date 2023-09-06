

using Microsoft.EntityFrameworkCore;
using Services.DataContext;
using Services.Interfaces;
using Services.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddTransient<IpurchaseRepository, PurchaseRepository>();



builder.Services.AddDbContext<MarketDB>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostConnection")));

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
