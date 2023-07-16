using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime Dob { set; get; }

        public virtual List<Cart> Carts { set; get; }
        public virtual List<Order> Orders { set; get; }
        public virtual List<Transaction> Transactions { set; get; }
    }
}
