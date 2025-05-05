namespace FieldExpenseTracker.Core.Schema;

public class UserRequest : BaseRequest
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string EmployeeNumber { get; set; }
}

public class UserResponse : BaseResponse
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime OpenDate { get; set; }
    public string EmployeeId { get; set; }
    public DateTime? LastLoginDate { get; set; }
}
public class UserRegisterResponse : BaseResponse
{
    public string UserName { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeNumber { get; set; }
    public DateTime OpenDate { get; set; }
    public DateTime? LastLoginDate { get; set; }
}