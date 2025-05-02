
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record LoginUserCommand(string Username, string Password) : IRequest<ApiResponse<UserResponse>>;
public record LogoutUserCommand(string Username) : IRequest<ApiResponse>;
public record RegisterUserCommand(UserRequest User) : IRequest<ApiResponse<UserResponse>>;
public record UpdateUserCommand(int Id, UserRequest User) : IRequest<ApiResponse>;
public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;
public record GetAllUsersByParameterQuery() : IRequest<ApiResponse<List<UserResponse>>>; //parametre eklenecek
public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;