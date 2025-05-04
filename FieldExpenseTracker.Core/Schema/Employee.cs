namespace FieldExpenseTracker.Core.Schema
{
    public class EmployeeRequest : BaseRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public string IsManager { get; set; }
        public DateTime DateOfJoining { get; set; }
    }
    
    public class EmployeeResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string Department { get; set; }
        public string EmployeeNumber { get; set; }
        public string IsManager { get; set; }
        public List<EmployeePhoneResponse> PhoneNumbers { get; set; }
        public List<EmployeeAddressResponse> Addresses { get; set; }
        public List<EmployeeIBANResponse> IBANs { get; set; }
    }
}