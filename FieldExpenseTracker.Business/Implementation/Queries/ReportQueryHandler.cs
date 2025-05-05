using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using FieldExpenseTracker.Data.Reports;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;

public class ReportQueryHandler :
    IRequestHandler<GetEmployeeExpensesQuery, ApiResponse<IEnumerable<EmployeeExpenseDto>>>,
    IRequestHandler<GetCompanyExpenseSummaryQuery, ApiResponse<IEnumerable<ExpenseSummaryDto>>>,
    IRequestHandler<GetEmployeeExpenseStatsQuery, ApiResponse<IEnumerable<EmployeeExpenseStatDto>>>,
    IRequestHandler<GetApprovalStatsQuery, ApiResponse<IEnumerable<ApprovalStatDto>>>
{
    private readonly IReportRepository reportRepository;

    public ReportQueryHandler(IReportRepository reportRepository)
    {
        this.reportRepository = reportRepository;
    }

    public async Task<ApiResponse<IEnumerable<EmployeeExpenseDto>>> Handle(GetEmployeeExpensesQuery request, CancellationToken cancellationToken)
    {
        var result = await reportRepository.GetEmployeeExpensesAsync(request.EmployeeId);
        if (result == null || !result.Any())
            return new ApiResponse<IEnumerable<EmployeeExpenseDto>>(ErrorMessages.noDataFound);

        return new ApiResponse<IEnumerable<EmployeeExpenseDto>>(result);
    }
    public async Task<ApiResponse<IEnumerable<ExpenseSummaryDto>>> Handle(GetCompanyExpenseSummaryQuery request, CancellationToken cancellationToken)
    {
        var result = await reportRepository.GetCompanyExpenseSummaryAsync(request.From, request.To);
        if (result == null || !result.Any())
            return new ApiResponse<IEnumerable<ExpenseSummaryDto>>(ErrorMessages.noDataFound);

        return new ApiResponse<IEnumerable<ExpenseSummaryDto>>(result);
    }

    public async Task<ApiResponse<IEnumerable<EmployeeExpenseStatDto>>> Handle(GetEmployeeExpenseStatsQuery request, CancellationToken cancellationToken)
    {
        var result = await reportRepository.GetEmployeeExpenseStatsAsync(request.From, request.To);
        if (result == null || !result.Any())
            return new ApiResponse<IEnumerable<EmployeeExpenseStatDto>>(ErrorMessages.noDataFound);

        return new ApiResponse<IEnumerable<EmployeeExpenseStatDto>>(result);
    }

    public async Task<ApiResponse<IEnumerable<ApprovalStatDto>>> Handle(GetApprovalStatsQuery request, CancellationToken cancellationToken)
    {
        var result = await reportRepository.GetApprovalStatsAsync(request.From, request.To);
        if (result == null || !result.Any())
            return new ApiResponse<IEnumerable<ApprovalStatDto>>(ErrorMessages.noDataFound);

        return new ApiResponse<IEnumerable<ApprovalStatDto>>(result);
    }
}