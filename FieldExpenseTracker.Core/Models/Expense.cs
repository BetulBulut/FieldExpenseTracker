using FieldExpenseTracker.Core.Enums;

namespace FieldExpenseTracker.Core.Models
{
    public class Expense : BaseModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string ReceiptImagePath { get; set; }
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; } 
        public StatusEnum Status { get; set; } 
        public CurrencyEnum Currency { get; set; } 
        public string ExpenseNumber { get; set; }
        public int ResponsedByUserId { get; set; } 
        public string ResponsedByUserName { get; set; } 
        public string ResponseDescription { get; set; }
        public DateTime? ResponseDate { get; set; }
    }
    
}