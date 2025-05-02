using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Business.Services;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Helpers;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using FieldExpenseTracker.Core.Token;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class AuthorizationCommandHandler :
    IRequestHandler<CreateAuthorizationTokenCommand, ApiResponse<AuthorizationResponse>>,
    IRequestHandler<LogoutUserCommand, ApiResponse>,
    IRequestHandler<ChangePasswordCommand, ApiResponse>,
    IRequestHandler<ForgotPasswordCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly ITokenService tokenService;
    private readonly JwtConfig jwtConfig;

    public AuthorizationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService, JwtConfig jwtConfig)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.tokenService = tokenService;
        this.jwtConfig = jwtConfig;
    }
     public async Task<ApiResponse<AuthorizationResponse>> Handle(CreateAuthorizationTokenCommand request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.UserRepository.Where(x => x.UserName == request.Request.UserName && x.IsActive == true);
        var user=users.FirstOrDefault();
        if (user == null)
            return new ApiResponse<AuthorizationResponse>("User name or password is incorrect");

        var hashedPassword = PasswordGenerator.CreateMD5(request.Request.Password, user.Secret);
        if (hashedPassword != user.PasswordHash)
            return new ApiResponse<AuthorizationResponse>("User name or password is incorrect");

        var token = tokenService.GenerateToken(user);
        var entity = new AuthorizationResponse
        {
            UserName = user.UserName,
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(jwtConfig.AccessTokenExpiration)
        };

        return new ApiResponse<AuthorizationResponse>(entity);
    }

    public async Task<ApiResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByParameterAsync(x=> x.UserName == request.Username && x.IsActive == true);
        if (user == null)
            return new ApiResponse("User not found");

        //logout işlemi yapılacak
        await unitOfWork.Complete();
        return new ApiResponse("User logged out successfully");
    }

    public async Task<ApiResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByParameterAsync(x => x.UserName == request.Request.UserName && x.IsActive == true);
        if (user == null)
            return new ApiResponse("User not found");

        var hashedPassword = PasswordGenerator.CreateMD5(request.Request.OldPassword, user.Secret);
        if (hashedPassword != user.PasswordHash)
            return new ApiResponse("Old password is incorrect");

        var newHashedPassword = PasswordGenerator.CreateMD5(request.Request.NewPassword, user.Secret);
        user.PasswordHash = newHashedPassword;
        unitOfWork.UserRepository.Update(user);
        await unitOfWork.Complete();
        return new ApiResponse("Password changed successfully");
    }

    public async Task<ApiResponse> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByParameterAsync(x => x.UserName == request.Request.UserName && x.IsActive == true);
        if (user == null)
            return new ApiResponse("User not found");

        var newPassword = PasswordGenerator.GeneratePassword(6);
        var hashedPassword = PasswordGenerator.CreateMD5(newPassword, user.Secret);
        user.PasswordHash = hashedPassword;
        unitOfWork.UserRepository.Update(user);
        await unitOfWork.Complete();

        // Send email with new password (not implemented here)
        return new ApiResponse("New password sent to email");
    }
}