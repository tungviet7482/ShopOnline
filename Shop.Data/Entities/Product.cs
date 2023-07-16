using System;
using System.Collections.Generic;


namespace Shop.Data.Entities
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }

        public virtual List<ProductInCategory> ProductInCategories { set; get; }
        public virtual List<OrderDetail> OrderDetails { set; get; }
        public virtual List<Cart> Carts { set; get; }
        // public List<ProductImage> ProductImages { set; get; }

    }
}
