
namespace FieldExpenseTracker.Core.Helpers.Employee;

public static class EmployeeNumberGenerator
{
    public static string GenerateEmployeeNumber()
    {
        const string chars = "0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, 11)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
