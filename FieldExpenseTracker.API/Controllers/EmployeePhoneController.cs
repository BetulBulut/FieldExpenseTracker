using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FieldExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeePhoneController : ControllerBase
{
    private readonly IMediator mediator;
    public EmployeePhoneController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<EmployeePhoneResponse>>> GetAllByParameter()
    {
        var operation = new GetAllEmployeePhonesQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<EmployeePhoneResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetEmployeePhoneByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<EmployeePhoneResponse>> Post([FromBody] EmployeePhoneRequest EmployeePhone)
    {
        var operation = new CreateEmployeePhoneCommand(EmployeePhone);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] EmployeePhoneRequest EmployeePhone)
    {
        var operation = new UpdateEmployeePhoneCommand(id, EmployeePhone);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteEmployeePhoneCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }
}