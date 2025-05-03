using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class ExpenseCategoryQueryHandler :
IRequestHandler<GetAllExpenseCategorysByParameterQuery, ApiResponse<List<ExpenseCategoryResponse>>>,
IRequestHandler<GetExpenseCategoryByIdQuery, ApiResponse<ExpenseCategoryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ExpenseCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<ApiResponse<List<ExpenseCategoryResponse>>> Handle(GetAllExpenseCategorysByParameterQuery request, CancellationToken cancellationToken)
    {
        var entities = await unitOfWork.ExpenseCategoryRepository.GetAllAsync(x => x.IsActive == true);
        if (entities == null || !entities.Any())
            return new ApiResponse<List<ExpenseCategoryResponse>>(ErrorMessages.noExpenseCategoryFound);

        //parametre eklenecek
        var mappedEntities = mapper.Map<List<ExpenseCategoryResponse>>(entities);
        return new ApiResponse<List<ExpenseCategoryResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<ExpenseCategoryResponse>> Handle(GetExpenseCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseCategoryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<ExpenseCategoryResponse>(ErrorMessages.expenseCategoryNotFound);

        if (!entity.IsActive)
            return new ApiResponse<ExpenseCategoryResponse>(ErrorMessages.expenseCategoryIsNotActive);

        var mappedEntity = mapper.Map<ExpenseCategoryResponse>(entity);
        return new ApiResponse<ExpenseCategoryResponse>(mappedEntity);
    }
}
