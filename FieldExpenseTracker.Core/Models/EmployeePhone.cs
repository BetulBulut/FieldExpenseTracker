namespace FieldExpenseTracker.Core.Models;

public class EmployeePhone : BaseModel
{
    public string PhoneNumber { get; set; }
    public int EmployeeId { get; set; } // Foreign key to Employee
    public Employee Employee { get; set; } // Navigation property to Employee
}