using Shop.ViewModels.Comom;

namespace Shop.ViewModels.User
{
    public class GetUserPagingRequest : PagingRequestBase
    {
        public string keyword { set; get; }
    }
}
