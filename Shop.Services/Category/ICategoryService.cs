using Shop.ViewModels.Category;
using Shop.ViewModels.Comom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Services.Category
{
    public interface ICategoryService
    {
        Task<Result<PageResult<CategoryViewModel>>> GetAll();
    }
}
