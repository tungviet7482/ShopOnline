using FluentValidation;

namespace Shop.ViewModels.User
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Bắt buộc");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Tối thiểu 5 kí tự").Length(5, 30).WithMessage("Từ 5 đến 30");
        }
    }
}
