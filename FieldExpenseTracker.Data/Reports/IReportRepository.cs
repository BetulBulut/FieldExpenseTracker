using FieldExpenseTracker.Core.Schema;

namespace FieldExpenseTracker.Data.Reports;
public interface IReportRepository
{
    Task<IEnumerable<EmployeeExpenseDto>> GetEmployeeExpensesAsync(int employeeId);
    Task<IEnumerable<ExpenseSummaryDto>> GetCompanyExpenseSummaryAsync(DateTime from, DateTime to);
    Task<IEnumerable<EmployeeExpenseStatDto>> GetEmployeeExpenseStatsAsync(DateTime from, DateTime to);
    Task<IEnumerable<ApprovalStatDto>> GetApprovalStatsAsync(DateTime from, DateTime to);
}