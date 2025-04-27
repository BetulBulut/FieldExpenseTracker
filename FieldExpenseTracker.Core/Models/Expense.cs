using FieldExpenseTracker.Core.Enums;

namespace FieldExpenseTracker.Core.Models
{
    public class Expense : BaseModel
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public string ReceiptImagePath { get; set; }
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; } 
        public StatusEnum Status { get; set; } 
        public string Currency { get; set; } // gerek var mı?
        public string ExpenseNumber { get; set; }
        public int ResponsedByUserId { get; set; } 
        public string ResponsedByUserName { get; set; } 
    }
    
}