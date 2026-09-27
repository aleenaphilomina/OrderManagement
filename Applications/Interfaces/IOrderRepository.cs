using OrderManagementApi.Domain.Entities;

namespace OrderManagementApi.Application.Interfaces;

public interface IOrderRepository
{
    Task AddAsync(
        Order order,
        CancellationToken cancellationToken);

    Task<Order?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken);
}