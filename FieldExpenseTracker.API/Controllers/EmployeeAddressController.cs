using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FieldExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeAddressController : ControllerBase
{
    private readonly IMediator mediator;
    public EmployeeAddressController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    public async Task<ApiResponse<List<EmployeeAddressResponse>>> GetAll()
    {
        var operation = new GetAllEmployeeAddressesQuery();
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetAllByParameter")]
    public async Task<ApiResponse<List<EmployeeAddressResponse>>> GetAllByParameter([FromQuery] string? street, [FromQuery] string? city, [FromQuery] string? state, [FromQuery] string? country)
    {
        var operation = new GetAllEmployeeAddressesByParameterQuery(street, city, country, state);
        var result = await mediator.Send(operation);
        return result;
    }
    
    [HttpGet("GetById/{id}")]
    public async Task<ApiResponse<EmployeeAddressResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetEmployeeAddressByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    public async Task<ApiResponse<EmployeeAddressResponse>> Post([FromBody] EmployeeAddressRequest EmployeeAddress)
    {
        var operation = new CreateEmployeeAddressCommand(EmployeeAddress);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] EmployeeAddressRequest EmployeeAddress)
    {
        var operation = new UpdateEmployeeAddressCommand(id, EmployeeAddress);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteEmployeeAddressCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}