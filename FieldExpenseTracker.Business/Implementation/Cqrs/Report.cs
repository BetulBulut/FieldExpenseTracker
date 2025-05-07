using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using System.Collections.Generic;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;


public record GetEmployeeExpensesQuery(int EmployeeId) : IRequest<ApiResponse<IEnumerable<EmployeeExpenseDto>>>;
public record GetCompanyExpenseSummaryQuery(int FromYear, int ToYear) : IRequest<ApiResponse<IEnumerable<ExpenseSummaryDto>>>;
public record GetEmployeeExpenseStatsQuery(int FromYear, int ToYear) : IRequest<ApiResponse<IEnumerable<EmployeeExpenseStatDto>>>;
public record GetApprovalStatsQuery(int FromYear, int ToYear) : IRequest<ApiResponse<IEnumerable<ApprovalStatDto>>>;

