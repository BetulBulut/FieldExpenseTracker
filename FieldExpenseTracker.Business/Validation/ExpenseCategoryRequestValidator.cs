using FieldExpenseTracker.Core.Schema;
using FluentValidation;

namespace FieldExpenseTracker.Business.Validation
{
    public class ExpenseCategoryRequestValidator : AbstractValidator<ExpenseCategoryRequest>
    {
        public ExpenseCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}