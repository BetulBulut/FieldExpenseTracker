
using FieldExpenseTracker.Business.Messaging;

namespace FieldExpenseTracker.Business.Interfaces;
public interface IEventPublisher
{
    void PublishExpenseCreated(ExpenseCreatedEvent expenseEvent);
    Task PublishUserCreatedOrPasswordReset(UserCreatedOrPasswordResetEvent userEvent);
}
