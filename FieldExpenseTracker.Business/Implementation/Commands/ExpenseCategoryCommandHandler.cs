using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class ExpenseCategoryCommandHandler :
IRequestHandler<CreateExpenseCategoryCommand, ApiResponse<ExpenseCategoryResponse>>,
IRequestHandler<UpdateExpenseCategoryCommand, ApiResponse>,
IRequestHandler<DeleteExpenseCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ExpenseCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseCategoryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.expenseCategoryNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.expenseCategoryIsNotActive);

        entity.IsActive = false;
        unitOfWork.ExpenseCategoryRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseCategoryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.expenseCategoryNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.expenseCategoryIsNotActive);

        var mapped = mapper.Map<ExpenseCategory>(request.ExpenseCategory);
        entity.Name = mapped.Name;
        entity.Description = mapped.Description;
        unitOfWork.ExpenseCategoryRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse<ExpenseCategoryResponse>> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ExpenseCategory>(request.ExpenseCategory);
        await unitOfWork.ExpenseCategoryRepository.AddAsync(entity);
        await unitOfWork.Complete();
        var mapped = mapper.Map<ExpenseCategoryResponse>(entity);
        return new ApiResponse<ExpenseCategoryResponse>(mapped);
    }
}