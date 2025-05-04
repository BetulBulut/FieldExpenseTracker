using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.UnitOfWork;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using FieldExpenseTracker.Core.Session;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FieldExpenseTracker.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IAppSession appSession;

    public ExpenseController(IMediator mediator, IAppSession appSession)
    {
        this.mediator = mediator;
        this.appSession = appSession;
    }

    [HttpGet("GetMyExpenses")]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetMyExpenses()
    {
        var employeeId= appSession.EmployeeId;
        var operation = new GetExpenseByEmployeeIdQuery(employeeId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<ApiResponse<ExpenseResponse>> Post([FromBody] ExpenseRequest Expense)
    {
        var operation = new CreateExpenseCommand(Expense);
        var result = await mediator.Send(operation);
        return result;
    }
}