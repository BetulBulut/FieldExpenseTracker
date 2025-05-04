namespace FieldExpenseTracker.Core.Messages;

public class ErrorMessages
{
    public const string incorrectUserNameOrPassword = "User name or password is incorrect";
    public const string userNotFound = "User not found";
    public const string noUsersFound = "No users found";
    public const string userIsNotActive = "User is not active";
    public const string userNameTaken = "Username taken";
    public const string oldPasswordIsIncorrect = "Old password is incorrect";
    public const string IBANnotFound = "IBAN not found";
    public const string noIBANFound = "No IBANs found";
    public const string IBANisNotActive = "IBAN is not active";
    public const string addressnotFound = "Address not found";
    public const string noAddressFound = "No addresses found";
    public const string addressisNotActive = "Address is not active";
    public const string phoneNumbernotFound = "Phone number not found";
    public const string noPhoneNumberFound = "No phone numbers found";
    public const string phoneNumberisNotActive = "Phone number is not active";
    public const string employeeNotFound = "Employee not found";
    public const string noEmployeeFound = "No employees found";
    public const string employeeIsNotActive = "Employee is not active";
    public const string expenseCategoryNotFound = "Expense category not found";
    public const string noExpenseCategoryFound = "No categories found";
    public const string expenseCategoryIsNotActive = "Expense category is not active";
    public const string expenseNotFound = "Expense not found";
    public const string noExpenseFound = "No expenses found";
    public const string expenseIsNotActive = "Expense is not active";
    public const string employeeHasDependencies = "Employee has dependencies";
    public const string expenseCategoryHasDependencies = "Expense category has dependencies";
}
public class SuccessMessages
{
    public const string userLoggedOutSuccessfully = "User logged out successfully";
    public const string passwordChangedSuccessfully = "Password changed successfully";
    public const string passwordResetLinkSent = "Password reset link sent to your email address";
}

