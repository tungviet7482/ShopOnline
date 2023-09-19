using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModels.Carts
{
    public class AddCartRequest
    {
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public DateTime DateCreated { get; set; }
        public Guid UserId { get; set; }
    }
}
