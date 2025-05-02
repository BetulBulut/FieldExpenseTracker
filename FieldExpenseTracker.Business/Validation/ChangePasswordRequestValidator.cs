using FieldExpenseTracker.Core.Schema;
using FluentValidation;

namespace FieldExpenseTracker.Business.Validation
{
    public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(50).WithMessage("UserName cannot exceed 50 characters.");

            RuleFor(x => x.OldPassword)
                .NotEmpty().WithMessage("OldPassword is required.")
                .MinimumLength(6).WithMessage("OldPassword must be at least 6 characters long.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("NewPassword is required.")
                .MinimumLength(6).WithMessage("NewPassword must be at least 6 characters long.")
                .NotEqual(x => x.OldPassword).WithMessage("NewPassword cannot be the same as OldPassword.");
        }
    }
}