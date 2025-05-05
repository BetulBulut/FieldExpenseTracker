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
public class PaymentMethodQueryHandler :
IRequestHandler<GetAllPaymentMethodsQuery, ApiResponse<List<PaymentMethodResponse>>>,
IRequestHandler<GetPaymentMethodByIdQuery, ApiResponse<PaymentMethodResponse>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IDistributedCache distributedCache;
    private readonly string cacheKey = "PaymentMethodCacheKey";

    public PaymentMethodQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

    public async Task<ApiResponse<List<PaymentMethodResponse>>> Handle(GetAllPaymentMethodsQuery request, CancellationToken cancellationToken)
    {
        var cashResult = await distributedCache.GetAsync(cacheKey);
        if (cashResult != null)
        {
            string json = Encoding.UTF8.GetString(cashResult);
            var cachedResponse = System.Text.Json.JsonSerializer.Deserialize<List<PaymentMethodResponse>>(json);
            return new ApiResponse<List<PaymentMethodResponse>>(cachedResponse);
        }
        return await SetRedisCache();
    }

    public async Task<ApiResponse<PaymentMethodResponse>> Handle(GetPaymentMethodByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.PaymentMethodRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse<PaymentMethodResponse>(ErrorMessages.paymentMethodNotFound);

        if (!entity.IsActive)
            return new ApiResponse<PaymentMethodResponse>(ErrorMessages.paymentMethodIsNotActive);

        var mappedEntity = mapper.Map<PaymentMethodResponse>(entity);
        return new ApiResponse<PaymentMethodResponse>(mappedEntity);
    }

    private async Task<ApiResponse<List<PaymentMethodResponse>>> SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var categories = await unitOfWork.PaymentMethodRepository.GetAllAsync(x => x.IsActive == true);
        if (categories == null || !categories.Any())
            return new ApiResponse<List<PaymentMethodResponse>>(ErrorMessages.noPaymentMethodFound);

        var mapped = mapper.Map<List<PaymentMethodResponse>>(categories);

        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(60),
            AbsoluteExpiration = DateTime.UtcNow.AddHours(12)
        };

        string model = System.Text.Json.JsonSerializer.Serialize(mapped);
        byte[] data = Encoding.UTF8.GetBytes(model);
        await distributedCache.SetAsync(cacheKey, data, options);

        return new ApiResponse<List<PaymentMethodResponse>>(mapped);
    }
}
