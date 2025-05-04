
namespace FieldExpenseTracker.Core.Helpers.Expense;

public static class ExpenseNumberGenerator
{
    public static string GenerateExpenseNumber()
    {
        const string chars = "0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 10)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
