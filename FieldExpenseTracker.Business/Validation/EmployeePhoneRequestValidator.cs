using FieldExpenseTracker.Core.Schema;
using FluentValidation;

namespace FieldExpenseTracker.Business.Validation
{
    public class EmployeePhoneRequestValidator : AbstractValidator<EmployeePhoneRequest>
    {
        public EmployeePhoneRequestValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber is required.")
                .MaximumLength(15).WithMessage("PhoneNumber cannot exceed 15 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("EmployeeId must be greater than 0.");
        }
    }
}