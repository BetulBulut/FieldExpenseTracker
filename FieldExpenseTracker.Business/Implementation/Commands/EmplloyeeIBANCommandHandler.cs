using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class EmployeeIBANCommandHandler :
IRequestHandler<CreateEmployeeIBANCommand, ApiResponse<EmployeeIBANResponse>>,
IRequestHandler<UpdateEmployeeIBANCommand, ApiResponse>,
IRequestHandler<DeleteEmployeeIBANCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeIBANCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteEmployeeIBANCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeIBANRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.IBANnotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.IBANisNotActive);

        entity.IsActive = false;
        unitOfWork.EmployeeIBANRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateEmployeeIBANCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeIBANRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.IBANnotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.IBANisNotActive);

        var mapped = mapper.Map<EmployeeIBAN>(request.EmployeeIBAN);
        entity.IBAN = mapped.IBAN;
        entity.EmployeeId = mapped.EmployeeId;
        entity.IsDefault = mapped.IsDefault;
        unitOfWork.EmployeeIBANRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<EmployeeIBANResponse>> Handle(CreateEmployeeIBANCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeeIBAN>(request.EmployeeIBAN);
        await unitOfWork.EmployeeIBANRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<EmployeeIBANResponse>(entity);
        return new ApiResponse<EmployeeIBANResponse>(mapped);
    }
}