using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeeQueryHandler :
IRequestHandler<GetAllEmployeesByParameterQuery, ApiResponse<List<EmployeeResponse>>>,
IRequestHandler<GetEmployeeByIdQuery, ApiResponse<EmployeeResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeeResponse>>> Handle(GetAllEmployeesByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeResponse>>(ErrorMessages.noEmployeeFound);

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<EmployeeResponse>>(entities);
        return new ApiResponse<List<EmployeeResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id,"PhoneNumbers", "Addresses", "IBANs");
        if (entity == null)
            return new ApiResponse<EmployeeResponse>(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse<EmployeeResponse>(ErrorMessages.employeeIsNotActive);

        var mappedEntity = mapper.Map<EmployeeResponse>(entity);
        return new ApiResponse<EmployeeResponse>(mappedEntity);
    }
}
