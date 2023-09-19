using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModels.Carts
{
    public class CartItemViewModel
    {
        public int CartId { set; get; }
        public int ProductId { set; get; }
        public Guid UserId { get; set; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime DateCreated { get; set; }

    }
}
