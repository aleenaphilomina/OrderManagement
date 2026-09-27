
using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Application.Interfaces;
using OrderManagementApi.Application.Services;
using OrderManagementApi.Infrastructure.Data;
using OrderManagementApi.Infrastructure.Repositories;
using OrderManagementApi.Middleware;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddScoped<IOrderService, OrderService>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<GlobalExceptionMiddleware>();

        app.MapControllers();

        app.Run();
    }
}