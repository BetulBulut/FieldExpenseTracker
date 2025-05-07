using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace FieldExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator mediator;
    public UserController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("GetAll")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<List<UserResponse>>> GetAll()
    {
        var operation = new GetAllUsersQuery();
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpGet("GetById/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<UserResponse>> GetById([FromRoute] int id)
    {
        var operation = new GetUserByIdQuery(id);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpGet("GetByEmployeeNumber")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<UserResponse>> GetByEmployeeNumber([FromQuery] string employeeNumber)
    {
        var operation = new GetUserByEmployeeNumberQuery(employeeNumber);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse<UserRegisterResponse>> Post([FromBody] UserRequest User)
    {
        var operation = new CreateUserCommand(User);
        var result = await mediator.Send(operation);
        return result;
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<ApiResponse> Put([FromRoute] int id, [FromBody] UserRequest User)
    {
        var operation = new UpdateUserCommand(id, User);
        var result = await mediator.Send(operation);
        return result;
    }
    [HttpDelete("{id}")]   
    [Authorize(Roles = "Admin")] 
    public async Task<ApiResponse> Delete([FromRoute] int id)
    {
        var operation = new DeleteUserCommand(id);
        var result = await mediator.Send(operation);
        return result;
    }

}