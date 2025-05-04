namespace FieldExpenseTracker.Business.Messaging;
public class UserCreatedOrPasswordResetEvent
{
    public string Email { get; set; }
    public string FullName { get; set; }
    public string Password { get; set; }
    public string Subject { get; set; } = "Your New Account Information";
}
