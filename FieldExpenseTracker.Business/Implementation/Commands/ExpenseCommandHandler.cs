using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class ExpenseCommandHandler :
IRequestHandler<CreateExpenseCommand, ApiResponse<ExpenseResponse>>,
IRequestHandler<UpdateExpenseCommand, ApiResponse>,
IRequestHandler<DeleteExpenseCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("Expense not found");

        if (!entity.IsActive)
            return new ApiResponse("Expense is not active");

        entity.IsActive = false;
        unitOfWork.ExpenseRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse("Expense not found");

        if (!entity.IsActive)
            return new ApiResponse("Expense is not active");

        var mapped = mapper.Map<Expense>(request.Expense);
        entity.Amount = mapped.Amount;
        entity.Description = mapped.Description;
        entity.ExpenseCategoryId = mapped.ExpenseCategoryId;
        entity.Currency = mapped.Currency;
        entity.Date = mapped.Date;
        entity.IsActive = mapped.IsActive;
        entity.ResponsedByUserName = mapped.ResponsedByUserName;
        entity.ResponsedByUserId = mapped.ResponsedByUserId;
        entity.ReceiptImagePath = mapped.ReceiptImagePath;
        entity.Status = mapped.Status;
        entity.EmployeeId = mapped.EmployeeId;
        unitOfWork.ExpenseRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<ExpenseResponse>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Expense>(request.Expense);
        await unitOfWork.ExpenseRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<ExpenseResponse>(entity);
        return new ApiResponse<ExpenseResponse>(mapped);
    }
}