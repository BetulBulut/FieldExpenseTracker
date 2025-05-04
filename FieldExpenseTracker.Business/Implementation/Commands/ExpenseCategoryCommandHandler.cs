using System.Net.Http.Json;
using System.Text;
using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class ExpenseCategoryCommandHandler :
IRequestHandler<CreateExpenseCategoryCommand, ApiResponse<ExpenseCategoryResponse>>,
IRequestHandler<UpdateExpenseCategoryCommand, ApiResponse>,
IRequestHandler<DeleteExpenseCategoryCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IDistributedCache distributedCache;
    private readonly string cacheKey = "ExpenseCategoryCacheKey";

    public ExpenseCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

    public async Task<ApiResponse> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ExpenseCategoryRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.expenseCategoryNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.expenseCategoryIsNotActive);

        var hasDependencies = await unitOfWork.ExpenseRepository.AnyAsync(e => e.EmployeeId == request.Id);
        if (hasDependencies)
        return new ApiResponse(ErrorMessages.expenseCategoryHasDependencies);

        entity.IsActive = false;
        unitOfWork.ExpenseCategoryRepository.Update(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
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
        await SetRedisCache();
        return new ApiResponse();
    }

    public async Task<ApiResponse<ExpenseCategoryResponse>> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<ExpenseCategory>(request.ExpenseCategory);
        await unitOfWork.ExpenseCategoryRepository.AddAsync(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        var mapped = mapper.Map<ExpenseCategoryResponse>(entity);
        return new ApiResponse<ExpenseCategoryResponse>(mapped);
    }
    private Task SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var categories = unitOfWork.ExpenseCategoryRepository.GetAllAsync(x=> x.IsActive == true).Result;
        if (categories == null)
            return Task.CompletedTask;

        var mapped = mapper.Map<List<ExpenseCategoryResponse>>(categories);

        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(60),
            AbsoluteExpiration = DateTime.UtcNow.AddHours(12)
        };

        string model = System.Text.Json.JsonSerializer.Serialize(mapped);
        byte[] data = Encoding.UTF8.GetBytes(model);
        return distributedCache.SetAsync(cacheKey, data, options);
    }
}