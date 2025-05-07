using FieldExpenseTracker.Core.Models;

namespace FieldExpenseTracker.Business.Services;

public interface IPaymentService
{
    bool SimulatePayment(Expense expense);
}

public class PaymentService : IPaymentService
{
    public bool SimulatePayment(Expense expense)
    {
        
        switch (expense.PaymentMethod.Name)
        {
            case "Credit Card":
                return SimulateCreditCardPayment(expense);

            case "Cash":
                return SimulateCashPayment(expense);

            case "Bank Transfer":
                return SimulateBankTransferPayment(expense);

            default:
                return false;
        }
    }
    private bool SimulateCreditCardPayment(Expense expense)
    {
        
        if (expense.Amount <= 1000)
        {
            
            return true;
        }

        return false;
    }

    private bool SimulateCashPayment(Expense expense)
    {
        // Nakit ödeme için simülasyon
        return true;
    }

    private bool SimulateBankTransferPayment(Expense expense)
    {
        if (expense == null)
            //throw new ArgumentNullException(nameof(expense), "Expense cannot be null.");


    
        if (expense.Amount >= 500)
        {
            return true;
        }
        return false;
    }
}
