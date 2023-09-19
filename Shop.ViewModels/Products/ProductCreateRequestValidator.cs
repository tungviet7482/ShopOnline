using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModels.Products
{
    public class ProductCreateRequestValidator : AbstractValidator<ProductCreateRequest>
    {
        public ProductCreateRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bắt buộc")
                                .MaximumLength(50).WithMessage("Tối đa 50 ký tự");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bắt buộc")
                                 .Must(x => x > 0).WithMessage("Lỗi giá bán");
            RuleFor(x => x.OriginalPrice).NotEmpty().WithMessage("Bắt buộc")
                                 .Must(x => x > 0).WithMessage("Lỗi giá gốc");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Bắt buộc");
            RuleFor(x => x.Stock).NotEmpty().WithMessage("Băt buộc")
                                 .Must(x => x > -1).WithMessage("Lỗi số lượng");
        }
    }
}
