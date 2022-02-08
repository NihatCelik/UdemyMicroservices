using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order : Entity, IAggregateRoot
    {
        public string BuyerId { get; private set; }
        public Address Address { get; private set; }
        public DateTime CreatedDate { get; private set; }

        private readonly List<OrderItem> _orderItems;
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

        public Order()
        {

        }

        public Order(string buyerId, Address address)
        {
            BuyerId = buyerId;
            Address = address;
            _orderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
        }

        public decimal GetTotalPrice => _orderItems.Sum(u => u.Price);

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItems.Any(u => u.ProductId == productId);
            if (!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItems.Add(newOrderItem);
            }
        }
    }
}
