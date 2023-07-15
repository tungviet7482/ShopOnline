

namespace Shop.ViewModels.Product
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public int CategoryId { set; get; }

        //public IFormFile ThumbnailImage { set; get; }
    }
}
