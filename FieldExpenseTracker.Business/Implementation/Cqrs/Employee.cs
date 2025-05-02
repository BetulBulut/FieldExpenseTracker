
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllEmployeesByParameterQuery() : IRequest<ApiResponse<List<EmployeeResponse>>>;//parametre eklenecek
public record GetEmployeeByIdQuery(int Id) : IRequest<ApiResponse<EmployeeResponse>>;
public record CreateEmployeeCommand(EmployeeRequest Employee) : IRequest<ApiResponse<EmployeeResponse>>;
public record UpdateEmployeeCommand(int Id, EmployeeRequest Employee) : IRequest<ApiResponse>;
public record DeleteEmployeeCommand(int Id) : IRequest<ApiResponse>;