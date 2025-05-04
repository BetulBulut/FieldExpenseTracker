using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeeIBANQueryHandler :
IRequestHandler<GetAllEmployeeIBANsQuery, ApiResponse<List<EmployeeIBANResponse>>>,
IRequestHandler<GetEmployeeIBANByIdQuery, ApiResponse<EmployeeIBANResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeIBANQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeeIBANResponse>>> Handle(GetAllEmployeeIBANsQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeIBANRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeIBANResponse>>(ErrorMessages.noIBANFound);

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<EmployeeIBANResponse>>(entities);
        return new ApiResponse<List<EmployeeIBANResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeeIBANResponse>> Handle(GetEmployeeIBANByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeIBANRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<EmployeeIBANResponse>(ErrorMessages.IBANnotFound);

        if (!entity.IsActive)
            return new ApiResponse<EmployeeIBANResponse>(ErrorMessages.IBANisNotActive);

        var mappedEntity = mapper.Map<EmployeeIBANResponse>(entity);
        return new ApiResponse<EmployeeIBANResponse>(mappedEntity);
    }
}
