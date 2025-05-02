using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeeAddressQueryHandler :
IRequestHandler<GetAllEmployeeAddressesByParameterQuery, ApiResponse<List<EmployeeAddressResponse>>>,
IRequestHandler<GetEmployeeAddressByIdQuery, ApiResponse<EmployeeAddressResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeAddressQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<EmployeeAddressResponse>>> Handle(GetAllEmployeeAddressesByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.EmployeeAddressRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeAddressResponse>>("No Employee IAddress found");

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<EmployeeAddressResponse>>(entities);
        return new ApiResponse<List<EmployeeAddressResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeeAddressResponse>> Handle(GetEmployeeAddressByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeAddressRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<EmployeeAddressResponse>("Employee Address not found");

        if (!entity.IsActive)
            return new ApiResponse<EmployeeAddressResponse>("Employee Address is not active");

        var mappedEntity = mapper.Map<EmployeeAddressResponse>(entity);
        return new ApiResponse<EmployeeAddressResponse>(mappedEntity);
    }
}
