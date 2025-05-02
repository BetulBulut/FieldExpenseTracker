using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FieldExpenseTracker.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthorizationController : ControllerBase
{
    private readonly IMediator mediator;
    public AuthorizationController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    
    [HttpPost("Token")]
    public async Task<ApiResponse<AuthorizationResponse>> GetToken([FromBody] AuthorizationRequest request)
    {
        var operation = new CreateAuthorizationTokenCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("Logout")]
    public async Task<ApiResponse> Logout([FromBody] string username)
    {
        var operation = new LogoutUserCommand(username);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("ChangePassword")]
    public async Task<ApiResponse> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var operation = new ChangePasswordCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("ForgotPassword")]
    public async Task<ApiResponse> ForgotPassword([FromBody] ForgotPasswordRequest request)
    {
        var operation = new ForgotPasswordCommand(request);
        var result = await mediator.Send(operation);
        return result;
    }

}