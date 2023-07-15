using Microsoft.EntityFrameworkCore;
using Shop.Data.EntityF;
using Shop.ViewModels.Category;
using Shop.ViewModels.Comom;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext _dbContext;
        public CategoryService(ShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<PageResult<CategoryViewModel>>> GetAll()
        {
            var list = await _dbContext.Categories.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                IsShowOnHome = x.IsShowOnHome,
                ParentId = x.ParentId,
                Status = x.Status
            }
            ).ToListAsync();
            
            var total = list.Count;
            return new Result<PageResult<CategoryViewModel>>("", true, new PageResult<CategoryViewModel>(list, total));
        }
    }
}
