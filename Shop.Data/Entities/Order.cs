using Shop.Data.Enums;
using System;
using System.Collections.Generic;

namespace Shop.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string shipName { set; get; }
        public string shipAddress { set; get; }
        public string shipEmail { set; get; }
        public string shipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { set; get; }
        public AppUser AppUser { set; get; }
    }
}
