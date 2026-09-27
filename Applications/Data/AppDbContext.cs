// Ensure you have installed the Microsoft.EntityFrameworkCore NuGet package in your project.
// You can do this by running the following command in the Package Manager Console:
// Install-Package Microsoft.EntityFrameworkCore

using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Domain.Entities;
using OrderManagementAPI.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OrderManagementApi.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>()
            .HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId);

        modelBuilder.Entity<Order>()
            .Property(x => x.Status)
            .HasConversion<string>();
    }
}
