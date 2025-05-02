using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeIBANController : ControllerBase
{
    private readonly IMediator mediator;
    public EmployeeIBANController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<EmployeeIBANResponse>>> GetAllByParameter()
    {
        var operation = new GetAllEmployeeIBANsByParameterQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<EmployeeIBANResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetEmployeeIBANByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<EmployeeIBANResponse>> Post([FromBody] EmployeeIBANRequest EmployeeIBAN)
    {
        var operation = new CreateEmployeeIBANCommand(EmployeeIBAN);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] EmployeeIBANRequest EmployeeIBAN)
    {
        var operation = new UpdateEmployeeIBANCommand(id, EmployeeIBAN);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteEmployeeIBANCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}