
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record UpdateUserCommand(int Id, UserRequest User) : IRequest<ApiResponse>;
public record DeleteUserCommand(int Id) : IRequest<ApiResponse>;
public record CreateUserCommand(UserRequest User) : IRequest<ApiResponse<UserRegisterResponse>>;
public record GetAllUsersQuery() : IRequest<ApiResponse<List<UserResponse>>>;
public record GetUserByIdQuery(int Id) : IRequest<ApiResponse<UserResponse>>;
public record GetUserByEmployeeNumberQuery(string EmployeeNumber) : IRequest<ApiResponse<UserResponse>>;