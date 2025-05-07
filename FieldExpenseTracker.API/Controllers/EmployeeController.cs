using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldExpenseTracker.API.Controllers;

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
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<EmployeeResponse>>> GetAll()
    {
        var operation = new GetAllEmployeesQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetAllByParameter")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<EmployeeResponse>>> GetAllByParameter([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? position, [FromQuery] string? department)
    {
        var operation = new GetAllEmployeesByParameterQuery(firstName, lastName, position, department);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<EmployeeResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetEmployeeByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<EmployeeResponse>> Post([FromBody] EmployeeRequest Employee)
    {
        var operation = new CreateEmployeeCommand(Employee);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] EmployeeRequest Employee)
    {
        var operation = new UpdateEmployeeCommand(id, Employee);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteEmployeeCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}