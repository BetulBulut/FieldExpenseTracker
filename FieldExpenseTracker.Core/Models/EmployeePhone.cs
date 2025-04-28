namespace FieldExpenseTracker.Core.Models;

public class EmployeePhone : BaseModel
{
    public string PhoneNumber { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } 
    public bool IsDefault { get; set; } 
}