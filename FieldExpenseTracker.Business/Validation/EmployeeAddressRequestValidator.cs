using FieldExpenseTracker.Core.Schema;
using FluentValidation;

namespace FieldExpenseTracker.Business.Validation
{
    public class EmployeeAddressRequestValidator : AbstractValidator<EmployeeAddressRequest>
    {
        public EmployeeAddressRequestValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street is required.")
                .MaximumLength(250).WithMessage("Street cannot exceed 250 characters.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(100).WithMessage("Country cannot exceed 100 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("EmployeeId must be greater than 0.");
        }
    }
}