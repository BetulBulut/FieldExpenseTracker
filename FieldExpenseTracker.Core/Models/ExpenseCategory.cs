namespace FieldExpenseTracker.Core.Models;

public class ExpenseCategory : BaseModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Expense> Expenses { get; set; }
}