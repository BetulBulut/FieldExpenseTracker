namespace FieldExpenseTracker.Core.Schema
{
    public class ExpenseRequest : BaseRequest
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public int ExpenseCategoryId { get; set; }
        public DateTime Date { get; set; }
        public string ReceiptImagePath { get; set; }
        public string Currency { get; set; }
    }

    public class ExpenseResponse : BaseResponse
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseCategoryId { get; set; }
        public string ExpenseCategoryName { get; set; } 
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } 
        public string ReceiptImagePath { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; } 
        public int Currency { get; set; }
        public string CurrencyName { get; set; } 
        public string ExpenseNumber { get; set; }
        public int ResponsedByUserId { get; set; }
        public string ResponsedByUserName { get; set; }
        public string ResponseDescription { get; set; }
        public DateTime? ResponseDate { get; set; }
    }

    public class ExpenseResponseRequest : BaseRequest
    {
        public string ResponseDescription { get; set; }
        public bool Approve { get; set; }
    }

    public class CreateMultipleExpenseRequest : BaseRequest
    {
        public List<ExpenseRequest> Expenses { get; set; }
    }
    public class CreateMultipleExpenseResponse : BaseResponse
    {
        public List<ExpenseResponse> Expenses { get; set; }
    }
}