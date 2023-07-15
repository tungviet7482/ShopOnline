using Shop.ViewModels.Comom;
using System.Collections.Generic;


namespace Shop.ViewModels.Product
{
    public class GetManageProductPagingRequest : PagingRequestBase
    {
        public string KeyWord { set; get; }
        public List<int> CategoryIds { set; get; }
    }
}
