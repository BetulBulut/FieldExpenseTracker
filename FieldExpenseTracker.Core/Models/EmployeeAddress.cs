namespace FieldExpenseTracker.Core.Models;

public class EmployeeAddress : BaseModel
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public int EmployeeId { get; set; } // Foreign key to Employee
    public Employee Employee { get; set; } // Navigation property to Employee
}