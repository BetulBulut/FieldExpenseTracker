using System.Text;
using AutoMapper;
using FieldExpenseTracker.Business.Implementation.Cqrs;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Helpers.Employee;
using FieldExpenseTracker.Core.Messages;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Schema;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace FieldExpenseTracker.Business.Implementation.Commands;

public class EmployeeCommandHandler :
IRequestHandler<CreateEmployeeCommand, ApiResponse<EmployeeResponse>>,
IRequestHandler<UpdateEmployeeCommand, ApiResponse>,
IRequestHandler<DeleteEmployeeCommand, ApiResponse>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    private readonly string cacheKey = "EmployeeCacheKey";
    private readonly IDistributedCache distributedCache;

    public EmployeeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IDistributedCache distributedCache)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.distributedCache = distributedCache;
    }

    public async Task<ApiResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.employeeIsNotActive);

        var hasDependencies = await unitOfWork.ExpenseRepository.AnyAsync(e => e.EmployeeId == request.Id);
        if (hasDependencies)
        return new ApiResponse(ErrorMessages.employeeHasDependencies);

        entity.IsActive = false;
        unitOfWork.EmployeeRepository.Update(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        return new ApiResponse();
    }

    public async Task<ApiResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.EmployeeRepository.GetByIdAsync(request.Id);
        if (entity == null)
            return new ApiResponse(ErrorMessages.employeeNotFound);

        if (!entity.IsActive)
            return new ApiResponse(ErrorMessages.employeeIsNotActive);

        var mapped = mapper.Map<Employee>(request.Employee);
        entity.FirstName = mapped.FirstName;
        entity.LastName = mapped.LastName;
        entity.Email = mapped.Email;
        entity.Department = mapped.Department;
        entity.IsManager = mapped.IsManager;
        entity.Position = mapped.Position;
        entity.Salary = mapped.Salary;

        unitOfWork.EmployeeRepository.Update(entity);
        await unitOfWork.Complete();
        await SetRedisCache();
        return new ApiResponse();
    }

    public async Task<ApiResponse<EmployeeResponse>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entity = mapper.Map<Employee>(request.Employee);
        entity.EmployeeNumber = EmployeeNumberGenerator.GenerateEmployeeNumber();

        await unitOfWork.EmployeeRepository.AddAsync(entity);
        await unitOfWork.Complete();   
        await SetRedisCache();
        var mapped = mapper.Map<EmployeeResponse>(entity);
        return new ApiResponse<EmployeeResponse>(mapped);
    }

    private Task SetRedisCache()
    {
        distributedCache.Remove(cacheKey);

        var employees = unitOfWork.EmployeeRepository.GetAllAsync(x=> x.IsActive == true).Result;
        if (employees == null)
            return Task.CompletedTask;

        var mapped = mapper.Map<List<EmployeeResponse>>(employees);

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
