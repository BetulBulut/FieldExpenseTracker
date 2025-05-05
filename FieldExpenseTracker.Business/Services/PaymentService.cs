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
        if (expense == null)
            throw new ArgumentNullException(nameof(expense), "Expense cannot be null.");

        if (expense.PaymentMethod == null)
            throw new ArgumentNullException(nameof(expense.PaymentMethod), "Payment method cannot be null.");

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
            Console.WriteLine("Credit card payment simulation successful.");
            return true;
        }

        Console.WriteLine("Credit card payment simulation failed. Amount exceeds limit.");
        return false;
    }

    private bool SimulateCashPayment(Expense expense)
    {
        // Nakit ödeme için simülasyon
        Console.WriteLine("Cash payment simulation successful.");
        return true;
    }

    private bool SimulateBankTransferPayment(Expense expense)
    {
        // Banka havalesi için simülasyon
        if (expense.Amount >= 500)
        {
            Console.WriteLine("Bank transfer payment simulation successful.");
            return true;
        }

        Console.WriteLine("Bank transfer payment simulation failed. Amount is below the minimum limit.");
        return false;
    }
}
