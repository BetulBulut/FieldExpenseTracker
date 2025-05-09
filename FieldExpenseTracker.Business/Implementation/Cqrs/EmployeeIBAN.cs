
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllEmployeeIBANsQuery() : IRequest<ApiResponse<List<EmployeeIBANResponse>>>;
public record GetEmployeeIBANByIdQuery(int Id) : IRequest<ApiResponse<EmployeeIBANResponse>>;
public record CreateEmployeeIBANCommand(EmployeeIBANRequest EmployeeIBAN) : IRequest<ApiResponse<EmployeeIBANResponse>>;
public record UpdateEmployeeIBANCommand(int Id, EmployeeIBANRequest EmployeeIBAN) : IRequest<ApiResponse>;
public record DeleteEmployeeIBANCommand(int Id) : IRequest<ApiResponse>;