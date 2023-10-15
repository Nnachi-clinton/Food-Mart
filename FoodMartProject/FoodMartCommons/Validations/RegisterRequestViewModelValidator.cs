using FluentValidation;
using FoodMartDomain.ViewModels.RequestModel;

namespace FoodMartCommons.Validations
{
    public class RegisterRequestViewModelValidator : AbstractValidator<RegisterRequestViewModel>
    {
        public RegisterRequestViewModelValidator()
        {
            RuleFor(vm => vm.Email)
             .NotEmpty().WithMessage("Email is required")
             .EmailAddress().WithMessage("Invalid email format");

            RuleFor(vm => vm.Password)
                .NotEmpty().WithMessage("Password is required")
                .Matches("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*\\W).{8,}$")
                .WithMessage("Password must meet industry-standard requirements");

            RuleFor(vm => vm.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required")
                .Equal(vm => vm.Password).WithMessage("Password and confirm password must match");
        }
    }
}
