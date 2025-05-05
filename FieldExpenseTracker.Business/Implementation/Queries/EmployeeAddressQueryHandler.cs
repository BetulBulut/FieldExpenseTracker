using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using LinqKit;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeeAddressQueryHandler :
IRequestHandler<GetAllEmployeeAddressesByParameterQuery, ApiResponse<List<EmployeeAddressResponse>>>,
IRequestHandler<GetEmployeeAddressByIdQuery, ApiResponse<EmployeeAddressResponse>>,
IRequestHandler<GetAllEmployeeAddressesQuery, ApiResponse<List<EmployeeAddressResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeAddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeeAddressResponse>>> Handle(GetAllEmployeeAddressesQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeAddressRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeAddressResponse>>(ErrorMessages.noAddressFound);

        var mappedEntities = mapper.Map<List<EmployeeAddressResponse>>(entities);
        return new ApiResponse<List<EmployeeAddressResponse>>(mappedEntities);
    }
    public async Task<ApiResponse<List<EmployeeAddressResponse>>> Handle(GetAllEmployeeAddressesByParameterQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<EmployeeAddress>(true);
        if (!string.IsNullOrEmpty(request.Street))
            predicate = predicate.And(x => x.Street.Contains(request.Street));
        if (!string.IsNullOrEmpty(request.City))
            predicate = predicate.And(x => x.City.Contains(request.City));
        if (!string.IsNullOrEmpty(request.State))
            predicate = predicate.And(x => x.State.Contains(request.State));
        if (!string.IsNullOrEmpty(request.Country))
            predicate = predicate.And(x => x.Country.Contains(request.Country));

        var entities = await unitOfWork.EmployeeAddressRepository.GetAllAsync(predicate);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeAddressResponse>>(ErrorMessages.noAddressFound);

        var mappedEntities = mapper.Map<List<EmployeeAddressResponse>>(entities);
        return new ApiResponse<List<EmployeeAddressResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeeAddressResponse>> Handle(GetEmployeeAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeAddressRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<EmployeeAddressResponse>(ErrorMessages.addressnotFound);

        if (!entity.IsActive)
            return new ApiResponse<EmployeeAddressResponse>(ErrorMessages.addressisNotActive);

        var mappedEntity = mapper.Map<EmployeeAddressResponse>(entity);
        return new ApiResponse<EmployeeAddressResponse>(mappedEntity);
    }
}
