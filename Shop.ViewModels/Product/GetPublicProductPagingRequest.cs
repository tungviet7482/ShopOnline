using Shop.ViewModels.Comom;


namespace Shop.ViewModels.Product
{
    public class GetPublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { set; get; }
    }
}
