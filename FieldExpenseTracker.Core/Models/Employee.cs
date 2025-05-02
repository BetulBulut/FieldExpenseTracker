namespace FieldExpenseTracker.Core.Models
{
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string EmployeeNumber { get; set; }
        public List<EmployeePhone> PhoneNumbers { get; set; }
        public List<EmployeeAddress> Addresses { get; set; }
        public List<EmployeeIBAN> IBANs { get; set; }
        public List<Expense> Expenses { get; set; } 
    }
}