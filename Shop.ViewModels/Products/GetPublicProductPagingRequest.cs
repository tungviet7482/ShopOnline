using Shop.ViewModels.Comom;


namespace Shop.ViewModels.Products
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { set; get; }
    }
}
