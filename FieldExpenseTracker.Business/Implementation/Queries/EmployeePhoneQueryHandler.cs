using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeePhoneQueryHandler :
IRequestHandler<GetAllEmployeePhonesByParameterQuery, ApiResponse<List<EmployeePhoneResponse>>>,
IRequestHandler<GetEmployeePhoneByIdQuery, ApiResponse<EmployeePhoneResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeePhoneQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeePhoneResponse>>> Handle(GetAllEmployeePhonesByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeePhoneRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeePhoneResponse>>("No Employee Phones found");

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<EmployeePhoneResponse>>(entities);
        return new ApiResponse<List<EmployeePhoneResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeePhoneResponse>> Handle(GetEmployeePhoneByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeePhoneRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<EmployeePhoneResponse>("Employee Phone not found");

        if (!entity.IsActive)
            return new ApiResponse<EmployeePhoneResponse>("Employee Phone is not active");

        var mappedEntity = mapper.Map<EmployeePhoneResponse>(entity);
        return new ApiResponse<EmployeePhoneResponse>(mappedEntity);
    }
}
