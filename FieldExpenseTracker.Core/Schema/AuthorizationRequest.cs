namespace FieldExpenseTracker.Core.Schema;

public class AuthorizationRequest : BaseRequest
{
    public string UserName { get; set; }
    public string Password { get; set; }
}

public class AuthorizationResponse 
{
    public string Token { get; set; }
    public string UserName { get; set; }
    public DateTime Expiration { get; set; }
}

public class ChangePasswordRequest : BaseRequest
{
    public string UserName { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
public class ForgotPasswordRequest : BaseRequest
{
    public string UserName { get; set; }
}
