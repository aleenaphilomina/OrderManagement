using OrderManagementApi.Application.DTOs;
using OrderManagementApi.Application.Interfaces;
using OrderManagementApi.Domain.Entities;

namespace OrderManagementApi.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<OrderService> _logger;

    public OrderService(
        IOrderRepository orderRepository,
        ILogger<OrderService> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<OrderResponse> CreateAsync(
        CreateOrderRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Items.Count == 0)
        {
            throw new ArgumentException(
                "Order must contain at least one item.");
        }

        var order = new Order
        {
            CustomerId = request.CustomerId,
            CreatedAt = DateTime.UtcNow,
            Status = OrderStatus.Pending
        };

        foreach (var item in request.Items)
        {
            order.AddItem(
                item.ProductId,
                item.Quantity,
                item.UnitPrice);
        }

        await _orderRepository.AddAsync(
            order,
            cancellationToken);

        _logger.LogInformation(
            "Order {OrderId} created for customer {CustomerId}",
            order.Id,
            order.CustomerId);

        return new OrderResponse
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Status = order.Status.ToString(),
            TotalAmount = order.CalculateTotal()
        };
    }

    public async Task<OrderResponse?> GetByIdAsync(
        int id,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(
            id,
            cancellationToken);

        if (order == null)
            return null;

        return new OrderResponse
        {
            Id = order.Id,
            CustomerId = order.CustomerId,
            Status = order.Status.ToString(),
            TotalAmount = order.CalculateTotal()
        };
    }
}