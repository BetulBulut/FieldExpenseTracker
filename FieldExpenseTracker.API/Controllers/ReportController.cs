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
    public async Task<IActionResult> GetEmployeeExpenses(int employeeId)
    {
        var operation =new GetEmployeeExpensesQuery(employeeId );
        var result = await mediator.Send(operation);
        return Ok(result);
    }

    [HttpGet("company-expense-summary")]
    public async Task<IActionResult> GetCompanyExpenseSummary([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var query = new GetCompanyExpenseSummaryQuery (from, to);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("employee-expense-stats")]
    public async Task<IActionResult> GetEmployeeExpenseStats([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var query = new GetEmployeeExpenseStatsQuery (from, to);
        var result = await mediator.Send(query);
        return Ok(result);
    }
    
    [HttpGet("approval-stats")]
    public async Task<IActionResult> GetApprovalStats([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var query = new GetApprovalStatsQuery (from, to);
        var result = await mediator.Send(query);
        return Ok(result);
    }
}