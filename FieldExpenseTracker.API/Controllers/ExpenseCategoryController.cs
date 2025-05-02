using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpenseCategoryController : ControllerBase
{
    private readonly IMediator mediator;
    public ExpenseCategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<ExpenseCategoryResponse>>> GetAllByParameter()
    {
        var operation = new GetAllExpenseCategorysByParameterQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<ExpenseCategoryResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetExpenseCategoryByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<ExpenseCategoryResponse>> Post([FromBody] ExpenseCategoryRequest ExpenseCategory)
    {
        var operation = new CreateExpenseCategoryCommand(ExpenseCategory);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] ExpenseCategoryRequest ExpenseCategory)
    {
        var operation = new UpdateExpenseCategoryCommand(id, ExpenseCategory);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteExpenseCategoryCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}