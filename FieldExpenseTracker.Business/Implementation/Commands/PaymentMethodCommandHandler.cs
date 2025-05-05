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

public class PaymentMethodCommandHandler :
IRequestHandler<CreatePaymentMethodCommand, ApiResponse<PaymentMethodResponse>>,
IRequestHandler<UpdatePaymentMethodCommand, ApiResponse>,
IRequestHandler<DeletePaymentMethodCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IDistributedCache distributedCache;
    private readonly string cacheKey = "PaymentMethodCacheKey";

    public PaymentMethodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

    public async Task<ApiResponse> Handle(DeletePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.PaymentMethodRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.paymentMethodNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.paymentMethodIsNotActive);

        var hasDependencies = await unitOfWork.ExpenseRepository.AnyAsync(e => e.EmployeeId == request.Id);
        if (hasDependencies)
        return new ApiResponse(ErrorMessages.paymentMethodHasDependencies);

        entity.IsActive = false;
        unitOfWork.PaymentMethodRepository.Update(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.PaymentMethodRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.paymentMethodNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.paymentMethodIsNotActive);

        var mapped = mapper.Map<PaymentMethod>(request.PaymentMethod);
        entity.Name = mapped.Name;
        entity.Description = mapped.Description;
        unitOfWork.PaymentMethodRepository.Update(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        return new ApiResponse();
    }

    public async Task<ApiResponse<PaymentMethodResponse>> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<PaymentMethod>(request.PaymentMethod);
        await unitOfWork.PaymentMethodRepository.AddAsync(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        var mapped = mapper.Map<PaymentMethodResponse>(entity);
        return new ApiResponse<PaymentMethodResponse>(mapped);
    }
    private Task SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var categories = unitOfWork.PaymentMethodRepository.GetAllAsync(x=> x.IsActive == true).Result;
        if (categories == null)
            return Task.CompletedTask;

        var mapped = mapper.Map<List<PaymentMethodResponse>>(categories);

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