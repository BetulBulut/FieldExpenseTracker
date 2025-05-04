
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllExpenseCategorysQuery() : IRequest<ApiResponse<List<ExpenseCategoryResponse>>>;
public record GetExpenseCategoryByIdQuery(int Id) : IRequest<ApiResponse<ExpenseCategoryResponse>>;
public record CreateExpenseCategoryCommand(ExpenseCategoryRequest ExpenseCategory) : IRequest<ApiResponse<ExpenseCategoryResponse>>;
public record UpdateExpenseCategoryCommand(int Id, ExpenseCategoryRequest ExpenseCategory) : IRequest<ApiResponse>;
public record DeleteExpenseCategoryCommand(int Id) : IRequest<ApiResponse>;