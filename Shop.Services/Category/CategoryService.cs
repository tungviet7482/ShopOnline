using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shop.Data.EntityF;
using Shop.ViewModels.Categorys;
using Shop.ViewModels.Comom;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ShopDbContext _dbContext;
        private readonly IMapper _mapper;
        public CategoryService(ShopDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Result<PageResult<CategoryViewModel>>> GetAll()
        {
            var list = await _dbContext.Categories.Select(x => _mapper.Map<CategoryViewModel>(x)).ToListAsync();
            
            var total = list.Count;
            return new Result<PageResult<CategoryViewModel>>("", true, new PageResult<CategoryViewModel>(list, total));
        }
    }
}
