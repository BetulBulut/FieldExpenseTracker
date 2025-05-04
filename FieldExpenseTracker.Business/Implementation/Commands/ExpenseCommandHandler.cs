using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Helpers.Expense;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using FieldExpenseTracker.Core.Session;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class ExpenseCommandHandler :
IRequestHandler<CreateExpenseCommand, ApiResponse<ExpenseResponse>>,
IRequestHandler<UpdateExpenseCommand, ApiResponse>,
IRequestHandler<DeleteExpenseCommand, ApiResponse>,
IRequestHandler<RespondExpenseCommand, ApiResponse<ExpenseResponse>>,
IRequestHandler<CreateMultipleExpenseCommand, ApiResponse<CreateMultipleExpenseResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IAppSession appSession;
    private readonly IEventPublisher eventPublisher;

    public ExpenseCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IAppSession appSession, IEventPublisher eventPublisher)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.appSession = appSession;
        this.eventPublisher = eventPublisher;
    }

    public async Task<ApiResponse> Handle(DeleteExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.expenseNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.expenseIsNotActive);

        entity.IsActive = false;
        unitOfWork.ExpenseRepository.Update(entity);
        await unitOfWork.Complete();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.expenseNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.expenseIsNotActive);

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
        entity.ExpenseNumber=ExpenseNumberGenerator.GenerateExpenseNumber();
        entity.EmployeeId = appSession.EmployeeId;
        entity.Status = StatusEnum.Pending;
        await unitOfWork.ExpenseRepository.AddAsync(entity);
        await unitOfWork.Complete();
        eventPublisher.PublishExpenseCreated(new ExpenseCreatedEvent
        {
            EmployeeName = appSession.UserName,
            Amount = entity.Amount,
            Description = entity.Description,
            CreatedAt = DateTime.Now
        });
        var mapped = mapper.Map<ExpenseResponse>(entity);
        return new ApiResponse<ExpenseResponse>(mapped);
    }

    public async Task<ApiResponse<ExpenseResponse>> Handle(RespondExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = unitOfWork.ExpenseRepository.GetByIdAsync(request.id).Result;
        if (entity == null)
            return new ApiResponse<ExpenseResponse>(ErrorMessages.expenseNotFound);

        if (!entity.IsActive)
            return new ApiResponse<ExpenseResponse>(ErrorMessages.expenseIsNotActive);

        entity.Status = request.Expense.Approve==true? StatusEnum.Approved : StatusEnum.Rejected;
        //approve ise ödeme yap
        entity.ResponsedByUserId = int.Parse(appSession.UserId);
        entity.ResponsedByUserName = appSession.UserName;
        entity.ResponseDate = DateTime.Now;
        entity.ResponseDescription = request.Expense.ResponseDescription;
        unitOfWork.ExpenseRepository.Update(entity);
        unitOfWork.Complete();

        var mapped = mapper.Map<ExpenseResponse>(entity);
        mapped.StatusName = entity.Status.ToString();
        return new ApiResponse<ExpenseResponse>(mapped);
    }

    public async Task<ApiResponse<CreateMultipleExpenseResponse>> Handle(CreateMultipleExpenseCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<List<Expense>>(request.Expenses);
        if (entity == null || entity.Count == 0)
            return new ApiResponse<CreateMultipleExpenseResponse>(ErrorMessages.expenseNotFound);
        foreach (var item in entity)
        {
            item.EmployeeId = appSession.EmployeeId;
            item.Status = StatusEnum.Pending;
            item.ExpenseNumber = ExpenseNumberGenerator.GenerateExpenseNumber();
            await unitOfWork.ExpenseRepository.AddAsync(item);
        }
        unitOfWork.Complete();
        var mapped = mapper.Map<CreateMultipleExpenseResponse>(entity);
        return new ApiResponse<CreateMultipleExpenseResponse>(mapped);
    }
}