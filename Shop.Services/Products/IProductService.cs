using Shop.ViewModels.Comom;
using Shop.ViewModels.Products;
using System.Threading.Tasks;


namespace Shop.Services.Products
{
    public interface IProductService
    {
        Task AddViewcount(int productId);
        Task<Result<int>> Create(ProductCreateRequest request);
        Task<Result<int>> Delete(int productId);
        Task<Result<PageResult<ProductViewModel>>> GetAll();
        Task<Result<PageResult<ProductViewModel>>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<Result<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request);
        Task<Result<ProductViewModel>> GetById(int productId);
        Task<Result<int>> Update(ProductUpdateRequest request);
        Task<Result<bool>> UpdatePrice(int productId, decimal newPrice);
        Task<Result<bool>> UpdateStock(int ProductId, int Quantity);
    }
}
