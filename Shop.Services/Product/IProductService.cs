using Shop.ViewModels.Comom;
using Shop.ViewModels.Product;
using System.Threading.Tasks;


namespace Shop.Services.Product
{
    public interface IProductService
    {
        Task AddViewcount(int ProductId);
        Task<Result<int>> Create(ProductCreateRequest request);
        Task<Result<int>> Delete(int productId);
        Task<Result<PageResult<ProductViewModel>>> GetAll();
        Task<Result<PageResult<ProductViewModel>>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<Result<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request);
        Task<Result<ProductViewModel>> GetById(int productId);
        Task<Result<int>> Update(ProductUpdateRequest request);
        Task<Result<bool>> UpdatePrice(int ProductId, decimal NewPrice);
        Task<Result<bool>> UpdateStock(int ProductId, int Quantity);
    }
}
