
using FieldExpenseTracker.Business.Interfaces;
using FieldExpenseTracker.Core.Models;

namespace FieldExpenseTracker.Business.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task Complete();
    IGenericRepository<Employee> EmployeeRepository { get; }
    IGenericRepository<EmployeeAddress> EmployeeAddressRepository { get; }
    IGenericRepository<EmployeePhone> EmployeePhoneRepository { get; }
    IGenericRepository<EmployeeIBAN> EmployeeIBANRepository { get; }
    IGenericRepository<Expense> ExpenseRepository { get; }
    IGenericRepository<ExpenseCategory> ExpenseCategoryRepository { get; }
    IGenericRepository<User> UserRepository { get; }
}