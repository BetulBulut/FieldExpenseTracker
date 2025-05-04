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

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class ExpenseCategoryQueryHandler :
IRequestHandler<GetAllExpenseCategorysQuery, ApiResponse<List<ExpenseCategoryResponse>>>,
IRequestHandler<GetExpenseCategoryByIdQuery, ApiResponse<ExpenseCategoryResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IDistributedCache distributedCache;
    private readonly string cacheKey = "ExpenseCategoryCacheKey";

    public ExpenseCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

    public async Task<ApiResponse<List<ExpenseCategoryResponse>>> Handle(GetAllExpenseCategorysQuery request, CancellationToken cancellationToken)
    {
        var cashResult = await distributedCache.GetAsync(cacheKey);
        if (cashResult != null)
        {
            string json = Encoding.UTF8.GetString(cashResult);
            var cachedResponse = System.Text.Json.JsonSerializer.Deserialize<List<ExpenseCategoryResponse>>(json);
            return new ApiResponse<List<ExpenseCategoryResponse>>(cachedResponse);
        }
        return await SetRedisCache();
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

    private async Task<ApiResponse<List<ExpenseCategoryResponse>>> SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var categories = await unitOfWork.ExpenseCategoryRepository.GetAllAsync(x => x.IsActive == true);
        if (categories == null || !categories.Any())
            return new ApiResponse<List<ExpenseCategoryResponse>>(ErrorMessages.noExpenseCategoryFound);

        var mapped = mapper.Map<List<ExpenseCategoryResponse>>(categories);

        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(60),
            AbsoluteExpiration = DateTime.UtcNow.AddHours(12)
        };

        string model = System.Text.Json.JsonSerializer.Serialize(mapped);
        byte[] data = Encoding.UTF8.GetBytes(model);
        await distributedCache.SetAsync(cacheKey, data, options);

        return new ApiResponse<List<ExpenseCategoryResponse>>(mapped);
    }
}
