
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record CreateAuthorizationTokenCommand(AuthorizationRequest Request) : IRequest<ApiResponse<AuthorizationResponse>>;
public record LogoutUserCommand(string Username) : IRequest<ApiResponse>;
public record ChangePasswordCommand(ChangePasswordRequest Request) : IRequest<ApiResponse>;
public record ForgotPasswordCommand(ForgotPasswordRequest Request) : IRequest<ApiResponse>;
