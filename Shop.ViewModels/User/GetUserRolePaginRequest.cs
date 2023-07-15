using Shop.ViewModels.Comom;

namespace Shop.ViewModels.User
{
    public class GetUserRolePaginRequest : PagingRequestBase
    {
        public string keyword { set; get; }
    }
}
