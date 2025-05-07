using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IMediator mediator;

    public ReportController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpGet("employee-expenses/{employeeId}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetEmployeeExpenses(int employeeId)
    {
        var operation =new GetEmployeeExpensesQuery(employeeId );
        var result = await mediator.Send(operation);
        return Ok(result);
    }

    [HttpGet("company-expense-summary")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetCompanyExpenseSummary([FromQuery] int fromYear, [FromQuery] int toYear)
    {
        var query = new GetCompanyExpenseSummaryQuery (fromYear, toYear);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("employee-expense-stats")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetEmployeeExpenseStats([FromQuery] int fromYear, [FromQuery] int toYear)
    {
        var query = new GetEmployeeExpenseStatsQuery (fromYear, toYear);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("approval-stats")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetApprovalStats([FromQuery] int fromYear, [FromQuery] int toYear)
    {
        var query = new GetApprovalStatsQuery (fromYear, toYear);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}