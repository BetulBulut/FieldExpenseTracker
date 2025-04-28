namespace FieldExpenseTracker.Core.Models;

public class EmployeeIBAN : BaseModel
{
    public string IBAN { get; set; }
    public int EmployeeId { get; set; } 
    public Employee Employee { get; set; }
    public bool IsDefault { get; set; }
}