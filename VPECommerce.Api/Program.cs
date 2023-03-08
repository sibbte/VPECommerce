using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VPECommerce.Application.Interfaces;
using VPECommerce.Application.Services;
using VPECommerce.Application.Validators.MyEcommerceApp.Application.Validators;
using VPECommerce.Domain.Dtos;
using VPECommerce.Infrastructure;
using VPECommerce.Infrastructure.MyEcommerceApp.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddControllers();
// Add database context
builder.Services.AddDbContext<VPECommerceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VPECommerceAppDatabase")));
// Add repositories
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

// Add services
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

