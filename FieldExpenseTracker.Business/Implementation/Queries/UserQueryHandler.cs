using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class UserQueryHandler :
IRequestHandler<GetAllUsersQuery, ApiResponse<List<UserResponse>>>,
IRequestHandler<GetUserByEmployeeNumberQuery, ApiResponse<UserResponse>>,
IRequestHandler<GetUserByIdQuery, ApiResponse<UserResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.UserRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<UserResponse>>(ErrorMessages.noUsersFound);

        var mappedEntities = mapper.Map<List<UserResponse>>(entities);
        return new ApiResponse<List<UserResponse>>(mappedEntities);
    }
    
    public async Task<ApiResponse<UserResponse>> Handle(GetUserByEmployeeNumberQuery request, CancellationToken cancellationToken)
    {
        var employee = await unitOfWork.EmployeeRepository.GetByParameterAsync(x => x.EmployeeNumber == request.EmployeeNumber);
        if (employee == null)
            return new ApiResponse<UserResponse>(ErrorMessages.employeeNotFound);

        var entity = await unitOfWork.UserRepository.GetByParameterAsync(x => x.EmployeeId == employee.Id);
        if (entity == null)
            return new ApiResponse<UserResponse>(ErrorMessages.userNotFound);

        if (!entity.IsActive)
            return new ApiResponse<UserResponse>(ErrorMessages.userIsNotActive);

        var mappedEntity = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mappedEntity);
    }

    public async Task<ApiResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<UserResponse>(ErrorMessages.userNotFound);

        if (!entity.IsActive)
            return new ApiResponse<UserResponse>(ErrorMessages.userIsNotActive);

        var mappedEntity = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mappedEntity);
    }
}
