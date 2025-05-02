using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IMediator mediator;
    public EmployeeController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<EmployeeResponse>>> GetAllByParameter()
    {
        var operation = new GetAllEmployeesByParameterQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<EmployeeResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetEmployeeByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<EmployeeResponse>> Post([FromBody] EmployeeRequest Employee)
    {
        var operation = new CreateEmployeeCommand(Employee);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] EmployeeRequest Employee)
    {
        var operation = new UpdateEmployeeCommand(id, Employee);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteEmployeeCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}