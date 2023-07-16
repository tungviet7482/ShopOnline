using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }
        public virtual Product Product { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
