using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using System.Collections.Generic;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;


public record GetEmployeeExpensesQuery(int EmployeeId) : IRequest<ApiResponse<IEnumerable<EmployeeExpenseDto>>>;
public record GetCompanyExpenseSummaryQuery(DateTime From, DateTime To) : IRequest<ApiResponse<IEnumerable<ExpenseSummaryDto>>>;
public record GetEmployeeExpenseStatsQuery(DateTime From, DateTime To) : IRequest<ApiResponse<IEnumerable<EmployeeExpenseStatDto>>>;
public record GetApprovalStatsQuery(DateTime From, DateTime To) : IRequest<ApiResponse<IEnumerable<ApprovalStatDto>>>;

