using Microsoft.EntityFrameworkCore;
using Shop.Data.Entities;
using Shop.Data.EntityF;
using Shop.ViewModels.Comom;
using Shop.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services.Product
{
    public class ProdcutService : IProductService
    {
        private ShopDbContext dbcontext;
        public ProdcutService(ShopDbContext context)
        {
            dbcontext = context;
        }

        public async Task AddViewcount(int productId)
        {
            var product = await dbcontext.Products.FindAsync(productId);
            product.ViewCount++;
            dbcontext.Update(product);
            await dbcontext.SaveChangesAsync();
        }

        public async Task<Result<int>> Create(ProductCreateRequest request)
        {
            var query = dbcontext.Categories.SingleOrDefault(x => x.Id == request.CategoryId);
            if (query == null)
                return new Result<int>("Loại sản phẩm không tồn tại",false, 0);
            var product = new Shop.Data.Entities.Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                Name = request.Name,
                Description = request.Description,
                Details = request.Details,
            };
            dbcontext.Products.Add(product);
            await dbcontext.SaveChangesAsync();
            var productInCategory = new ProductInCategory()
            {
                CategoryId = request.CategoryId,
                ProductId = product.Id
            };
            dbcontext.Add(productInCategory);
            await dbcontext.SaveChangesAsync();
            return new Result<int>("", true, product.Id); ;
        }


        public async Task<Result<int>> Delete(int productId)
        {
            var product = await dbcontext.Products.FindAsync(productId);
            if (product == null) return new Result<int>("Sản phẩm không tồn tại", false, 0);

            dbcontext.Remove(product);
            var res = await dbcontext.SaveChangesAsync();
            return new Result<int>("", true, res);
        }


        public async Task<Result<PageResult<ProductViewModel>>> GetAllPaging(GetManageProductPagingRequest request)
        {
            var query = from p in dbcontext.Products
                        join pic in dbcontext.ProductInCategories on p.Id equals pic.ProductId
                        select new { p, pic };
            //lọc
            if (request.CategoryIds.Count > 0)
                query = query.Where(x => request.CategoryIds.Contains(x.pic.CategoryId));

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new ProductViewModel()
                            {
                                Id = x.p.Id,
                                Name = x.p.Name,
                                Stock = x.p.Stock,
                                DateCreated = x.p.DateCreated,
                                Description = x.p.Description,
                                Details = x.p.Details,
                                OriginalPrice = x.p.OriginalPrice,
                                Price = x.p.Price,
                                ViewCount = x.p.ViewCount
                            }).ToListAsync();

            var pageResult = new PageResult<ProductViewModel>(data, totalRow);
            return new Result<PageResult<ProductViewModel>> ("", true, pageResult); ;
        }

        public async Task<Result<ProductViewModel>> GetById(int productId)
        {
            var product = await dbcontext.Products.FindAsync(productId);
            if (product == null)
                return new Result<ProductViewModel>("Sản phẩm không tồn tại", false, null);
            var productVM = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                Price = product.Price,
                OriginalPrice = product.OriginalPrice,
                DateCreated = product.DateCreated,
                ViewCount = product.ViewCount,
                Description = product.Description,
                Details = product.Details
            };
            return new Result<ProductViewModel>("", true, productVM); ;
        }

        public async Task<Result<int>> Update(ProductUpdateRequest request)
        {
            var product = await dbcontext.Products.FindAsync(request.Id);
            if (product == null )
                return new Result<int>("Sản phẩm không tồn tại", false, 0);
            product.Name = request.Name;
            product.Details = request.Details;
            product.Description = request.Description;
            dbcontext.Update(product);
            var res =  await dbcontext.SaveChangesAsync();
            return new Result<int>("", true, res);
        }


        public async Task<Result<bool>> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await dbcontext.Products.FindAsync(productId);
            if (product == null) return new Result<bool>("Sản phẩm không tồn tại", false, false);
            product.Price = newPrice;
            var res = await  dbcontext.SaveChangesAsync() > 0;
            return new Result<bool>("", res, res);
        }

        public async Task<Result<bool>> UpdateStock(int ProductId, int Quantity)
        {
            var product = await dbcontext.Products.FindAsync(ProductId);
            if (product == null) return new Result<bool>("Sản phẩm không tồn tại", false, false);
            product.Stock = Quantity;
            var res = await dbcontext.SaveChangesAsync() > 0;
            return new Result<bool>("", res, res);
        }
        public async Task<Result<PageResult<ProductViewModel>>> GetAll()
        {
            var query = from p in dbcontext.Products
                        join pic in dbcontext.ProductInCategories on p.Id equals pic.ProductId
                        select new { p, pic };


            int totalRow = await query.CountAsync();
            var data = await query.Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                Stock = x.p.Stock,
                DateCreated = x.p.DateCreated,
                Description = x.p.Description,
                Details = x.p.Details,
                OriginalPrice = x.p.OriginalPrice,
                Price = x.p.Price,
                ViewCount = x.p.ViewCount
            }).ToListAsync();

            var pageResult = new PageResult<ProductViewModel>(data, totalRow);
            return new Result<PageResult<ProductViewModel>>("", true, pageResult);
        }

        public async Task<Result<PageResult<ProductViewModel>>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            var query = from p in dbcontext.Products
                        join pic in dbcontext.ProductInCategories on p.Id equals pic.ProductId
                        select new { p, pic };
            //lọc
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                query = query.Where(x => x.pic.CategoryId == request.CategoryId);

            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new ProductViewModel()
                            {
                                Id = x.p.Id,
                                Name = x.p.Name,
                                Stock = x.p.Stock,
                                DateCreated = x.p.DateCreated,
                                Description = x.p.Description,
                                Details = x.p.Details,
                                OriginalPrice = x.p.OriginalPrice,
                                Price = x.p.Price,
                                ViewCount = x.p.ViewCount
                            }).ToListAsync();

            var pageResult = new PageResult<ProductViewModel>(data, totalRow);
            return new Result<PageResult<ProductViewModel>>("", true, pageResult);
        }
    }
}
