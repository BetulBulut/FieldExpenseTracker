using FieldExpenseTracker.Core.Schema;
using FluentValidation;

namespace FieldExpenseTracker.Business.Validation
{
    public class EmployeeIBANRequestValidator : AbstractValidator<EmployeeIBANRequest>
    {
        public EmployeeIBANRequestValidator()
        {
            RuleFor(x => x.IBAN)
                .NotEmpty().WithMessage("IBAN is required.")
                .MaximumLength(34).WithMessage("IBAN cannot exceed 34 characters.");

            RuleFor(x => x.EmployeeId)
                .GreaterThan(0).WithMessage("EmployeeId must be greater than 0.");
        }
    }
}