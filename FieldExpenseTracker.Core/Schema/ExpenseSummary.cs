namespace FieldExpenseTracker.Core.Schema;
public class ExpenseSummaryDto
{
    public DateTime ReportDate { get; set; }
    public decimal TotalAmount { get; set; }
}
public class EmployeeExpenseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public decimal Amount { get; set; }
    public string Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public string Category { get; set; }
    public string PaymentMethod { get; set; }
}

public class CompanyExpenseSummaryDto
{
    public DateTime Date { get; set; }
    public int TotalRequests { get; set; }
    public decimal TotalAmount { get; set; }
}

public class EmployeeExpenseStatDto
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public int TotalExpenses { get; set; }
    public decimal TotalAmount { get; set; }
}

public class ApprovalStatDto
{
    public string Status { get; set; } // Approved / Rejected
    public int RequestCount { get; set; }
    public decimal TotalAmount { get; set; }
}
