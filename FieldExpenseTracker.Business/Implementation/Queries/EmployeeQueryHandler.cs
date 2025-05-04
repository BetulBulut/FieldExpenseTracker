using System.Text;
using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Messages;
using LinqKit;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using FieldExpenseTracker.Core.Models;

namespace FieldExpenseTracker.Business.Implementation.Queries;
public class EmployeeQueryHandler :
IRequestHandler<GetAllEmployeesByParameterQuery, ApiResponse<List<EmployeeResponse>>>,
IRequestHandler<GetEmployeeByIdQuery, ApiResponse<EmployeeResponse>>,
IRequestHandler<GetAllEmployeesQuery, ApiResponse<List<EmployeeResponse>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly IDistributedCache distributedCache;
    private readonly string cacheKey = "EmployeeCacheKey";

    public EmployeeQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

     public async Task<ApiResponse<List<EmployeeResponse>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
         var cashResult = await distributedCache.GetAsync(cacheKey);
        if (cashResult != null)
        {
            string json = Encoding.UTF8.GetString(cashResult);
            var cachedResponse = System.Text.Json.JsonSerializer.Deserialize<List<EmployeeResponse>>(json);
            return new ApiResponse<List<EmployeeResponse>>(cachedResponse);
        }
        return await SetRedisCache();
    }

    public async Task<ApiResponse<List<EmployeeResponse>>> Handle(GetAllEmployeesByParameterQuery request, CancellationToken cancellationToken)
    {
        var predicate = PredicateBuilder.New<Employee>(true);
        if (!string.IsNullOrEmpty(request.FirstName))
            predicate = predicate.And(x => x.FirstName.Contains(request.FirstName));
        if (!string.IsNullOrEmpty(request.LastName))
            predicate = predicate.And(x => x.LastName.Contains(request.LastName));
        if (!string.IsNullOrEmpty(request.Position))
            predicate = predicate.And(x => x.Position.Contains(request.Position));
        if (!string.IsNullOrEmpty(request.Department))
            predicate = predicate.And(x => x.Department.Contains(request.Department));

        var entities = await unitOfWork.EmployeeRepository.GetAllAsync(predicate, "PhoneNumbers", "Addresses", "IBANs");
        if (entities == null || !entities.Any())
            return new ApiResponse<List<EmployeeResponse>>(ErrorMessages.noEmployeeFound);

        var mappedEntities = mapper.Map<List<EmployeeResponse>>(entities);
        return new ApiResponse<List<EmployeeResponse>>(mappedEntities);
    }

    public async Task<ApiResponse<EmployeeResponse>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id,"PhoneNumbers", "Addresses", "IBANs");
        if (entity == null)
            return new ApiResponse<EmployeeResponse>(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse<EmployeeResponse>(ErrorMessages.employeeIsNotActive);

        var mappedEntity = mapper.Map<EmployeeResponse>(entity);
        return new ApiResponse<EmployeeResponse>(mappedEntity);
    }

    private async Task<ApiResponse<List<EmployeeResponse>>> SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var employees = await unitOfWork.EmployeeRepository.GetAllAsync(x => x.IsActive == true);
        if (employees == null || !employees.Any())
            return new ApiResponse<List<EmployeeResponse>>(ErrorMessages.noEmployeeFound);

        var mapped = mapper.Map<List<EmployeeResponse>>(employees);

        var options = new DistributedCacheEntryOptions
        {
            SlidingExpiration = TimeSpan.FromMinutes(60),
            AbsoluteExpiration = DateTime.UtcNow.AddHours(12)
        };

        string model = System.Text.Json.JsonSerializer.Serialize(mapped);
        byte[] data = Encoding.UTF8.GetBytes(model);
        await distributedCache.SetAsync(cacheKey, data, options);

        return new ApiResponse<List<EmployeeResponse>>(mapped);
    }
}
