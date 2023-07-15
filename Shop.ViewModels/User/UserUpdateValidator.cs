using FluentValidation;
using System;

namespace Shop.ViewModels.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateRequest>
    {
        public UserUpdateValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Bắt buộc")
                .MaximumLength(200).WithMessage("Tối đa 200 ký tự");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Bắt buộc")
                .MaximumLength(200).WithMessage("Tối đa 200 ký tự");
            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Ngày sinh không hợp lệ");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bắt buộc")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").WithMessage("Email không hợp lệ");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Bắt buộc");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bắt buộc");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bắt buộc").Length(5, 30).WithMessage("Từ 5 đến 30");
            RuleFor(x => x).Must(x => x.ConfirmPassword == x.Password).WithMessage("Mật khẩu không khớp");
        }
    }
}
