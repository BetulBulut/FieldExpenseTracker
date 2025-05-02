namespace FieldExpenseTracker.Core.Schema
{
    public class EmployeeAddressRequest : BaseRequest
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int EmployeeId { get; set; }
        public bool IsDefault { get; set; }
    }

    public class EmployeeAddressResponse : BaseResponse
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public int EmployeeId { get; set; }
        public string FullAddress { get; set; }
        public bool IsDefault { get; set; }
    }
}