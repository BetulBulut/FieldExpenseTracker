namespace FieldExpenseTracker.Core.Models;

public class EmployeeIBAN : BaseModel
{
    public string IBAN { get; set; }
    public int EmployeeId { get; set; } // Foreign key to Employee
    public Employee Employee { get; set; } // Navigation property to Employee
}