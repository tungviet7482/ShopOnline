using Shop.ViewModels.Carts;
using Shop.ViewModels.Comom;
using System;
using System.Threading.Tasks;

namespace Shop.Services.Carts
{
    public interface ICartService
    {
        Task<Result<int>> AddToCart(AddCartRequest request);
        Task<Result<int>> Delete(int cartId);
        Task<Result<PageResult<CartItemViewModel>>> GetAll(Guid userId);
        Task<Result<int>> UpdateQuanity(int cartId, int newQuantity);
    }
}
