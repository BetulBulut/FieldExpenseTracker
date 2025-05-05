using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FieldExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentMethodController : ControllerBase
{
    private readonly IMediator mediator;
    public PaymentMethodController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "Admin,Employee")]
    public async Task<ApiResponse<List<PaymentMethodResponse>>> GetAll()
    {
        var operation = new GetAllPaymentMethodsQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<PaymentMethodResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetPaymentMethodByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<PaymentMethodResponse>> Post([FromBody] PaymentMethodRequest PaymentMethod)
    {
        var operation = new CreatePaymentMethodCommand(PaymentMethod);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] PaymentMethodRequest PaymentMethod)
    {
        var operation = new UpdatePaymentMethodCommand(id, PaymentMethod);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]    
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeletePaymentMethodCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}