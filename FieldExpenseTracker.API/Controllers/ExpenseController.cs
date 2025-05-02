using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase
{
    private readonly IMediator mediator;
    public ExpenseController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<ExpenseResponse>>> GetAllByParameter()
    {
        var operation = new GetAllExpensesByParameterQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<ExpenseResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetExpenseByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<ExpenseResponse>> Post([FromBody] ExpenseRequest Expense)
    {
        var operation = new CreateExpenseCommand(Expense);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] ExpenseRequest Expense)
    {
        var operation = new UpdateExpenseCommand(id, Expense);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteExpenseCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}