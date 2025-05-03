using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Helpers;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class UserCommandHandler :
IRequestHandler<UpdateUserCommand, ApiResponse>,
IRequestHandler<DeleteUserCommand, ApiResponse>,
IRequestHandler<CreateUserCommand, ApiResponse<UserResponse>>
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
            return new ApiResponse(ErrorMessages.userNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.userIsNotActive);

        entity.IsActive = false;
        unitOfWork.UserRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.userNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.userIsNotActive);

        var mapped = mapper.Map<User>(request.User);
        entity.FirstName = mapped.FirstName;
        entity.LastName = mapped.LastName;
        entity.UserName = mapped.UserName;
        entity.Role = mapped.Role;

        unitOfWork.UserRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByParameterAsync(x => x.UserName == request.User.UserName && x.IsActive == true);
        if (user != null)
            return new ApiResponse<UserResponse>(ErrorMessages.userNameTaken);

        var employee = await unitOfWork.EmployeeRepository.GetByParameterAsync(x => x.EmployeeNumber == request.User.EmployeeNumber && x.IsActive == true);
        if (employee == null)
            return new ApiResponse<UserResponse>(ErrorMessages.employeeNotFound);
        var mapped = mapper.Map<User>(request.User);
        mapped.OpenDate = DateTime.Now;
        mapped.IsActive = true;
        mapped.Secret = PasswordGenerator.GeneratePassword(30);
        mapped.EmployeeId = employee.Id;
        mapped.LastLoginDate = null;
        var password = PasswordGenerator.GeneratePassword(6);
        mapped.PasswordHash = PasswordGenerator.CreateMD5(password, mapped.Secret);

        var entity = await unitOfWork.UserRepository.AddAsync(mapped);
        await unitOfWork.Complete();
        var response = mapper.Map<UserResponse>(entity);

        return new ApiResponse<UserResponse>(response);
    }
}