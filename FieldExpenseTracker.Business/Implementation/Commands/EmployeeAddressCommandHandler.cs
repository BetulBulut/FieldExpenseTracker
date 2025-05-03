using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class EmployeeAddressCommandHandler :
IRequestHandler<CreateEmployeeAddressCommand, ApiResponse<EmployeeAddressResponse>>,
IRequestHandler<UpdateEmployeeAddressCommand, ApiResponse>,
IRequestHandler<DeleteEmployeeAddressCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeAddressCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteEmployeeAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeAddressRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.addressnotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.addressisNotActive);

        entity.IsActive = false;
        unitOfWork.EmployeeAddressRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateEmployeeAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeAddressRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.addressnotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.addressisNotActive);

        var mapped = mapper.Map<EmployeeAddress>(request.EmployeeAddress);
        entity.EmployeeId = mapped.EmployeeId;
        entity.IsDefault = mapped.IsDefault;
        entity.City = mapped.City;
        entity.Country = mapped.Country;
        entity.State = mapped.State;
        entity.Street = mapped.Street;
        unitOfWork.EmployeeAddressRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<EmployeeAddressResponse>> Handle(CreateEmployeeAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeeAddress>(request.EmployeeAddress);
        await unitOfWork.EmployeeAddressRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<EmployeeAddressResponse>(entity);
        return new ApiResponse<EmployeeAddressResponse>(mapped);
    }
}