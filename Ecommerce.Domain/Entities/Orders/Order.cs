using Ecommerce.Domain.Entities.Users;
using System;
using System.Collections.Generic;

namespace Ecommerce.Domain.Entities.Orders
{
    public class Order
    {
        public int Id { get; set; }
        public CustomUser UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public string DeliveryAddress { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal ShippingCost { get; set; }
        public string TrackingNumber { get; set; }
        public List<StatusHistory> StatusHistory { get; set; }
        public string Carrier { get; set; }
        public DateTime ShippingDate { get; set; }
    }

    public class StatusHistory
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
