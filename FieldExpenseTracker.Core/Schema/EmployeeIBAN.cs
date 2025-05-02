namespace FieldExpenseTracker.Core.Schema
{
    public class EmployeeIBANRequest : BaseRequest
    {
        public string IBAN { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }

    public class EmployeeIBANResponse : BaseResponse
    {
        public string IBAN { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }
}