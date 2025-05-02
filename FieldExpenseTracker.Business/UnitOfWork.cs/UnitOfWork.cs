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

    public IGenericRepository<Employee> EmployeeRepository => throw new NotImplementedException();

    public IGenericRepository<EmployeeAddress> EmployeeAddressRepository => throw new NotImplementedException();

    public IGenericRepository<EmployeePhone> EmployeePhoneRepository => throw new NotImplementedException();

    public IGenericRepository<EmployeeIBAN> EmployeeIBANRepository => throw new NotImplementedException();

    public IGenericRepository<Expense> ExpenseRepository => throw new NotImplementedException();

    public IGenericRepository<ExpenseCategory> ExpenseCategoryRepository => throw new NotImplementedException();

    public IGenericRepository<User> UserRepository => throw new NotImplementedException();

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