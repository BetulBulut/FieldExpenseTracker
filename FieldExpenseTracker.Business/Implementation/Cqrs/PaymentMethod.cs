
using FieldExpenseTracker.Core.ApiResponse;
using FieldExpenseTracker.Core.Schema;
using MediatR;

namespace FieldExpenseTracker.Business.Implementation.Cqrs;

public record GetAllPaymentMethodsQuery() : IRequest<ApiResponse<List<PaymentMethodResponse>>>;
public record GetPaymentMethodByIdQuery(int Id) : IRequest<ApiResponse<PaymentMethodResponse>>;
public record CreatePaymentMethodCommand(PaymentMethodRequest PaymentMethod) : IRequest<ApiResponse<PaymentMethodResponse>>;
public record UpdatePaymentMethodCommand(int Id, PaymentMethodRequest PaymentMethod) : IRequest<ApiResponse>;
public record DeletePaymentMethodCommand(int Id) : IRequest<ApiResponse>;