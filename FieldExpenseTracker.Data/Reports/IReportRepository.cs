using FieldExpenseTracker.Core.Schema;

namespace FieldExpenseTracker.Data.Reports;
public interface IReportRepository
{
    Task<IEnumerable<EmployeeExpenseDto>> GetEmployeeExpensesAsync(int employeeId);
    Task<IEnumerable<ExpenseSummaryDto>> GetCompanyExpenseSummaryAsync(int fromYear, int toYear);
    Task<IEnumerable<EmployeeExpenseStatDto>> GetEmployeeExpenseStatsAsync(int fromYear, int toYear);
    Task<IEnumerable<ApprovalStatDto>> GetApprovalStatsAsync(int fromYear, int toYear);
}