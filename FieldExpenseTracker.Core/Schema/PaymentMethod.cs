namespace FieldExpenseTracker.Core.Schema
{
    public class PaymentMethodRequest : BaseRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class PaymentMethodResponse : BaseResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}