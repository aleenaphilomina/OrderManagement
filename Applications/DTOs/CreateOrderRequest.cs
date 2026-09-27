namespace OrderManagementApi.Application.DTOs;

public class CreateOrderRequest
{
    public int CustomerId { get; set; }

    public List<CreateOrderItem> Items { get; set; } = new();
}

public class CreateOrderItem
{
    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
}