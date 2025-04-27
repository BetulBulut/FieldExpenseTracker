namespace FieldExpenseTracker.Core.Models
{
    public class Employee : BaseModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string IBAN { get; set; }
        public string EmployeeNumber { get; set; }
    }
}