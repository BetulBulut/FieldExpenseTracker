
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllExpensesByParameterQuery() : IRequest<ApiResponse<List<ExpenseResponse>>>;//parametre eklenecek
public record GetExpenseByIdQuery(int Id) : IRequest<ApiResponse<ExpenseResponse>>;
public record CreateExpenseCommand(ExpenseRequest Expense) : IRequest<ApiResponse<ExpenseResponse>>;
public record UpdateExpenseCommand(int Id, ExpenseRequest Expense) : IRequest<ApiResponse>;
public record DeleteExpenseCommand(int Id) : IRequest<ApiResponse>;