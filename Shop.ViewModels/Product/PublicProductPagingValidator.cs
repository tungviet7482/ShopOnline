using FluentValidation;
using Shop.ViewModels.Comom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.ViewModels.Product
{
    public class PublicProductPagingValidator: AbstractValidator<GetPublicProductPagingRequest>
    {
        public PublicProductPagingValidator()
        {
            RuleFor(x => x.PageIndex).NotEmpty().WithMessage("Bắt buộc")
                .Must(x => x > 0).WithMessage("Lỗi số thứ tự trang");
            RuleFor(x => x.PageSize).NotEmpty().WithMessage("Bắt buộc")
                .Must(x => x > 0).WithMessage("Lỗi số bản ghi");
        }
    }
}
