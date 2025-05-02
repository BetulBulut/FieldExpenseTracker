using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class UserCommandHandler :
IRequestHandler<UpdateUserCommand, ApiResponse>,
IRequestHandler<DeleteUserCommand, ApiResponse>,
IRequestHandler<RegisterUserCommand, ApiResponse<UserResponse>>,
IRequestHandler<LoginUserCommand, ApiResponse<UserResponse>>,
IRequestHandler<LogoutUserCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("User not found");

        if (!entity.IsActive)
            return new ApiResponse("User is not active");

        entity.IsActive = false;
        unitOfWork.UserRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

 
    public async Task<ApiResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.UserRepository.GetAllAsync(x => x.UserName == request.Username);
        var entity = users.FirstOrDefault();
        if (entity == null)
            return new ApiResponse("User not found");

        if (!entity.IsActive)
            return new ApiResponse("User is not active");

        //logout işlemleri
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async  Task<ApiResponse<UserResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        
        var users = await unitOfWork.UserRepository.GetAllAsync(x => x.UserName == request.Username);
        var entity = users.FirstOrDefault();
        if (entity == null)
            return new ApiResponse<UserResponse>("User not found");

        if (!entity.IsActive)
            return new ApiResponse<UserResponse>("User is not active");

        //login işlemleri
        await unitOfWork.Complete();
        var mapped = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mapped);
    }

    public async Task<ApiResponse<UserResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<User>(request.User);
        //secret ve password üreitimi
        await unitOfWork.UserRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mapped);
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("User not found");

        if (!entity.IsActive)
            return new ApiResponse("User is not active");

        var mapped = mapper.Map<User>(request.User);
        entity.FirstName = mapped.FirstName;
        entity.LastName = mapped.LastName;
        entity.UserName = mapped.UserName;
        entity.Role = mapped.Role;
        
        unitOfWork.UserRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }
}