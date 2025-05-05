
namespace FieldExpenseTracker.Core.Models;
public class PaymentMethod: BaseModel
{
    public string Description { get; set; }
    public string Name { get; set; }
    public List<Expense> Expenses { get; set; }
}