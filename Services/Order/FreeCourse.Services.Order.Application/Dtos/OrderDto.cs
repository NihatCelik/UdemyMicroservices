using System;
using System.Collections.Generic;

namespace FreeCourse.Services.Order.Application.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public AddressDto Address { get; set; }
        public DateTime CreatedDate { get; set; }
        private List<OrderItemDto> OrderItems { get; set; }
    }
}
