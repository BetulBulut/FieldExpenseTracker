namespace FieldExpenseTracker.Core.Schema
{
    public class EmployeePhoneRequest : BaseRequest
    {
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }

    public class EmployeePhoneResponse : BaseResponse
    {
        public string PhoneNumber { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }
}