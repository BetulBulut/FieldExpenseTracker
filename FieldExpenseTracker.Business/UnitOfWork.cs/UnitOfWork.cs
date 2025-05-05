using FieldExpenseTracker.Business.GenericRepository;
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Data;
using Serilog;

namespace FieldExpenseTracker.Business.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext context;

    public UnitOfWork(AppDbContext context)
    {
        this.context = context;
    }

    public IGenericRepository<Employee> EmployeeRepository => new GenericRepository<Employee>(context);

    public IGenericRepository<EmployeeAddress> EmployeeAddressRepository => new GenericRepository<EmployeeAddress>(context);

    public IGenericRepository<EmployeePhone> EmployeePhoneRepository => new GenericRepository<EmployeePhone>(context);

    public IGenericRepository<EmployeeIBAN> EmployeeIBANRepository => new GenericRepository<EmployeeIBAN>(context);

    public IGenericRepository<Expense> ExpenseRepository => new GenericRepository<Expense>(context);

    public IGenericRepository<ExpenseCategory> ExpenseCategoryRepository => new GenericRepository<ExpenseCategory>(context);

    public IGenericRepository<User> UserRepository => new GenericRepository<User>(context);
    public IGenericRepository<PaymentMethod> PaymentMethodRepository => new GenericRepository<PaymentMethod>(context);

    public async Task Complete()
    {
        using (var transaction = await context.Database.BeginTransactionAsync())
        {
            try
            {
                await context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while saving changes to the database.");
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    private bool _disposed = false;

}