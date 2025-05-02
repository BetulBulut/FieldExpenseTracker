using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class EmployeePhoneCommandHandler :
IRequestHandler<CreateEmployeePhoneCommand, ApiResponse<EmployeePhoneResponse>>,
IRequestHandler<UpdateEmployeePhoneCommand, ApiResponse>,
IRequestHandler<DeleteEmployeePhoneCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeePhoneCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteEmployeePhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeePhoneRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("EmployeePhone not found");

        if (!entity.IsActive)
            return new ApiResponse("EmployeePhone is not active");

        entity.IsActive = false;
        unitOfWork.EmployeePhoneRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateEmployeePhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeePhoneRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("EmployeePhone not found");

        if (!entity.IsActive)
            return new ApiResponse("EmployeePhone is not active");

        var mapped = mapper.Map<EmployeePhone>(request.EmployeePhone);
        entity.PhoneNumber = mapped.PhoneNumber;
        entity.EmployeeId = mapped.EmployeeId;
        entity.IsDefault = mapped.IsDefault;
        unitOfWork.EmployeePhoneRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<EmployeePhoneResponse>> Handle(CreateEmployeePhoneCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<EmployeePhone>(request.EmployeePhone);
        await unitOfWork.EmployeePhoneRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<EmployeePhoneResponse>(entity);
        return new ApiResponse<EmployeePhoneResponse>(mapped);
    }
}