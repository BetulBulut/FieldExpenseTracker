using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class ExpenseQueryHandler :
IRequestHandler<GetAllExpensesByParameterQuery, ApiResponse<List<ExpenseResponse>>>,
IRequestHandler<GetExpenseByIdQuery, ApiResponse<ExpenseResponse>>,
IRequestHandler<GetExpenseByEmployeeIdQuery, ApiResponse<List<ExpenseResponse>>>,
IRequestHandler<GetPendingExpenses, ApiResponse<List<ExpenseResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ExpenseQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetAllExpensesByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.ExpenseRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<ExpenseResponse>>(ErrorMessages.noExpenseFound);

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<ExpenseResponse>>(entities);
        return new ApiResponse<List<ExpenseResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<ExpenseResponse>> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<ExpenseResponse>(ErrorMessages.expenseNotFound);

        if (!entity.IsActive)
            return new ApiResponse<ExpenseResponse>(ErrorMessages.expenseIsNotActive);

        var mappedEntity = mapper.Map<ExpenseResponse>(entity);
        return new ApiResponse<ExpenseResponse>(mappedEntity);
    }

    public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetExpenseByEmployeeIdQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.ExpenseRepository.GetAllAsync(x => x.EmployeeId == request.EmployeeId && x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<ExpenseResponse>>(ErrorMessages.noExpenseFound);

        var mappedEntities = mapper.Map<List<ExpenseResponse>>(entities);
        return new ApiResponse<List<ExpenseResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<List<ExpenseResponse>>> Handle(GetPendingExpenses request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.ExpenseRepository.GetAllAsync(x => x.Status == StatusEnum.Pending && x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<ExpenseResponse>>(ErrorMessages.noExpenseFound);

        var mappedEntities = mapper.Map<List<ExpenseResponse>>(entities);
        return new ApiResponse<List<ExpenseResponse>>(mappedEntities);
    }
}
