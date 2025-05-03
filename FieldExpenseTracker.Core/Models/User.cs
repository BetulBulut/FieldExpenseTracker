using FieldExpenseTracker.Core.Enums;

namespace FieldExpenseTracker.Core.Models;

public class User : BaseModel
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Secret { get; set; }
    public RoleEnum Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
}