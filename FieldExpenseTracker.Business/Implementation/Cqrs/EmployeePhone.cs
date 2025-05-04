
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllEmployeePhonesQuery() : IRequest<ApiResponse<List<EmployeePhoneResponse>>>;
public record GetEmployeePhoneByIdQuery(int Id) : IRequest<ApiResponse<EmployeePhoneResponse>>;
public record CreateEmployeePhoneCommand(EmployeePhoneRequest EmployeePhone) : IRequest<ApiResponse<EmployeePhoneResponse>>;
public record UpdateEmployeePhoneCommand(int Id, EmployeePhoneRequest EmployeePhone) : IRequest<ApiResponse>;
public record DeleteEmployeePhoneCommand(int Id) : IRequest<ApiResponse>;