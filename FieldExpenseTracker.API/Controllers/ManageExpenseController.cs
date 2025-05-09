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
public class ManageExpenseController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IAppSession appSession;

    public ManageExpenseController(IMediator mediator, IAppSession appSession)
    {
        this.mediator = mediator;
        this.appSession = appSession;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetAll()
    {
        var operation = new GetAllExpensesQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpGet("GetAllByParameter")]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetAllByParameter([FromQuery] int? EmployeeId, [FromQuery] string? ExpenseNumber, [FromQuery] string? Description, [FromQuery] string? ExpenseCategory, [FromQuery] int? Amount, [FromQuery] string? ResponsedByUserName)
    {
        var operation = new GetAllExpensesByParameterQuery(EmployeeId,ExpenseNumber, Description, ExpenseCategory, Amount, ResponsedByUserName);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<ExpenseResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetExpenseByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetByEmployeeId/{employeeId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetByEmployeeId([FromRoute] int employeeId)
    {
        var operation = new GetExpenseByEmployeeIdQuery(employeeId);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetPendingExpenses")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetPendingExpenses()
    {
        var operation = new GetPendingExpenses();
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("ResponseExpense/{expenseId}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<ExpenseResponse>> ResponseExpense([FromRoute] int expenseId, [FromBody] ExpenseResponseRequest Expense)
    {
        var operation = new RespondExpenseCommand(Expense, expenseId);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] ExpenseRequest Expense)
    {
        var operation = new UpdateExpenseCommand(id, Expense);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteExpenseCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}