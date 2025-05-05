
using FieldExpenseTracker.Business.Messaging;
using FieldExpenseTracker.Core.Events;

namespace FieldExpenseTracker.Business.Interfaces;
public interface IEventPublisher
{
    void PublishExpenseCreated(ExpenseCreatedEvent expenseEvent);
}
