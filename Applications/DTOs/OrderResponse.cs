namespace OrderManagementApi.Application.DTOs;

public class OrderResponse
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }
}