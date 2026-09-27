using OrderManagementApi.Application.DTOs;

namespace OrderManagementApi.Application.Interfaces;

public interface IOrderService
{
    Task<OrderResponse> CreateAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken);

    Task<OrderResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken);
}

