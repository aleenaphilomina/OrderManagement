using Microsoft.EntityFrameworkCore;
using OrderManagementApi.Application.Interfaces;
using OrderManagementApi.Domain.Entities;
using OrderManagementApi.Infrastructure.Data;

namespace OrderManagementApi.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        Order order,
        CancellationToken cancellationToken)
    {
        await _context.Orders.AddAsync(
            order,
            cancellationToken);

        await _context.SaveChangesAsync(
            cancellationToken);
    }

    public async Task<Order?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        return await _context.Orders
            .AsNoTracking()
            .Include(x => x.Items)
            .FirstOrDefaultAsync(
                x => x.Id == id,
                cancellationToken);
    }
}
