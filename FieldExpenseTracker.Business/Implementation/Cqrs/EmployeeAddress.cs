
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllEmployeeAddressesByParameterQuery() : IRequest<ApiResponse<List<EmployeeAddressResponse>>>;//parametre eklenecek
public record GetEmployeeAddressByIdQuery(int Id) : IRequest<ApiResponse<EmployeeAddressResponse>>;
public record CreateEmployeeAddressCommand(EmployeeAddressRequest EmployeeAddress) : IRequest<ApiResponse<EmployeeAddressResponse>>;
public record UpdateEmployeeAddressCommand(int Id, EmployeeAddressRequest EmployeeAddress) : IRequest<ApiResponse>;
public record DeleteEmployeeAddressCommand(int Id) : IRequest<ApiResponse>;