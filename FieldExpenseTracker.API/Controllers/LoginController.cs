using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Ots.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly IMediator mediator;
    public LoginController(IMediator mediator)
    {
        this.mediator = mediator;
    }

   /*
    [HttpPost("Login")]
    public async Task<ApiResponse<LoginResponse>> Login([FromBody] LoginRequest loginRequest)
    {
        var operation = new LoginCommand(loginRequest);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("Register")]
    public async Task<ApiResponse<LoginResponse>> Register([FromBody] RegisterRequest registerRequest)
    {
        var operation = new RegisterCommand(registerRequest);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("ChangePassword")]
    public async Task<ApiResponse<LoginResponse>> ChangePassword([FromBody] ChangePasswordRequest changePasswordRequest)
    {
        var operation = new ChangePasswordCommand(changePasswordRequest);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("ForgotPassword")]
    public async Task<ApiResponse<LoginResponse>> ForgotPassword([FromBody] ForgotPasswordRequest forgotPasswordRequest)
    {
        var operation = new ForgotPasswordCommand(forgotPasswordRequest);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost("Logout")]
    [Authorize]
    public async Task<ApiResponse> Logout()
    {
        var operation = new LogoutUserCommand();
        var result = await mediator.Send(operation);
        return result;
    }*/

}