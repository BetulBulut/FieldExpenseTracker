using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class UserQueryHandler :
IRequestHandler<GetAllUsersByParameterQuery, ApiResponse<List<UserResponse>>>,
IRequestHandler<GetUserByIdQuery, ApiResponse<UserResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<UserResponse>>> Handle(GetAllUsersByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.UserRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<UserResponse>>("No users found");

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<UserResponse>>(entities);
        return new ApiResponse<List<UserResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.UserRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<UserResponse>("User not found");

        if (!entity.IsActive)
            return new ApiResponse<UserResponse>("User is not active");

        var mappedEntity = mapper.Map<UserResponse>(entity);
        return new ApiResponse<UserResponse>(mappedEntity);
    }
}
