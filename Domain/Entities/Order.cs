using System;
using System.Collections.Generic;
using System.Linq;
using OrderManagementApi.Domain.Entities;
using OrderManagementAPI.Domain.Entities; // Ensure this is correct or adjust as needed

namespace OrderManagementApi.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public DateTime CreatedAt { get; set; }

    public OrderStatus Status { get; set; }

    public List<OrderItem> Items { get; set; } = new List<OrderItem>();

    public decimal CalculateTotal()
    {
        return Items.Sum(x => x.Quantity * x.UnitPrice);
    }

    public void AddItem(
        int productId,
        int quantity,
        decimal unitPrice)
    {
        if (quantity <= 0)
            throw new ArgumentException(
                "Quantity must be greater than zero.");

        Items.Add(new OrderItem
        {
            ProductId = productId,
            Quantity = quantity,
            UnitPrice = unitPrice
        });
    }
}