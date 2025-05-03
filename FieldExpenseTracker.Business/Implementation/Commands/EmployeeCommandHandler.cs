using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class EmployeeCommandHandler :
IRequestHandler<CreateEmployeeCommand, ApiResponse<EmployeeResponse>>,
IRequestHandler<UpdateEmployeeCommand, ApiResponse>,
IRequestHandler<DeleteEmployeeCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.employeeIsNotActive);

        entity.IsActive = false;
        unitOfWork.EmployeeRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.employeeIsNotActive);

        var mapped = mapper.Map<Employee>(request.Employee);
        entity.FirstName = mapped.FirstName;
        entity.LastName = mapped.LastName;
        entity.Email = mapped.Email;
        entity.EmployeeNumber = mapped.EmployeeNumber;
        entity.PhoneNumbers = mapped.PhoneNumbers;
        entity.Addresses = mapped.Addresses;
        entity.IBANs = mapped.IBANs;
        entity.Position = mapped.Position;
        entity.Salary = mapped.Salary;

        unitOfWork.EmployeeRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<EmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Employee>(request.Employee);
        await unitOfWork.EmployeeRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<EmployeeResponse>(entity);
        return new ApiResponse<EmployeeResponse>(mapped);
    }
}