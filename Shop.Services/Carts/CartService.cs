using Microsoft.EntityFrameworkCore;
using Shop.Data.EntityF;
using Shop.ViewModels.Cart;
using Shop.ViewModels.Comom;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace Shop.Services.Carts
{
    public class CartService : ICartService
    {
        private readonly ShopDbContext _dbContext;
        public CartService(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Result<PageResult<CartItemViewModel>>> GetAll(Guid userId)
        {
            var query = from c in _dbContext.Carts
                       join p in _dbContext.Products on c.ProductId equals p.Id
                       select new {c, p};
            var total = await query.CountAsync();
            var list = await query.Select(x => new CartItemViewModel()
            {
                CartId = x.c.Id,
                ProductId = x.c.ProductId,
                UserId = x.c.UserId,
                Name = x.p.Name,
                Quantity = x.c.Quantity,
                Price = x.p.Price * x.c.Quantity,
                DateCreated = x.c.DateCreated
            }).ToListAsync();

            var res = new PageResult<CartItemViewModel>(list, total);

            return new Result<PageResult<CartItemViewModel>>("", true, res);
        }

        public async Task<Result<int>> AddToCart(AddCartRequest request)
        {
            var query = _dbContext.Carts.SingleOrDefault(x => x.ProductId == request.ProductId && x.UserId == request.UserId);
            if (query != null)
            {
                query.Quantity++;
                _dbContext.Update(query);
                await _dbContext.SaveChangesAsync();
                return new Result<int>("", true, 0);
            }
            var newCartItem = new Shop.Data.Entities.Cart() 
            {
                ProductId = request.ProductId,
                UserId = request.UserId,
                Quantity = request.Quantity
            };
            _dbContext.Carts.Update(newCartItem);
            var res = await _dbContext.SaveChangesAsync();
            return new Result<int>("", true, res);
        }

        public async Task<Result<int>> Delete(int cartId)
        {
            var query = _dbContext.Carts.SingleOrDefault(x => x.Id == cartId);
            if (query == null)
                return new Result<int>("Sản phẩm không tồn tại trong giỏ hàng", false, 0);
            _dbContext.Remove(query);
            var res = await _dbContext.SaveChangesAsync();
            return new Result<int>("", true, res);
        }

        public async Task<Result<int>> UpdateQuanity(int cartId, int newQuantity)
        {
            var query = _dbContext.Carts.SingleOrDefault(x => x.Id == cartId);
            if (query == null)
                return new Result<int>("Sản phẩm không tồn tại trong giỏ hàng", false, 0);
            query.Quantity = newQuantity;
            var res = await _dbContext.SaveChangesAsync();
            return new Result<int>("", true, res);
        }
    }
}
