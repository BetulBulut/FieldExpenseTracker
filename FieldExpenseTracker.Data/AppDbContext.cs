using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Session;
using FieldExpenseTracker.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace FieldExpenseTracker.Data;

public class AppDbContext : DbContext
{
     private readonly IAppSession appSession;

    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider serviceProvider) : base(options)
    {
        this.appSession = serviceProvider.GetService<IAppSession>();
    }

    DbSet<Employee> Employees { get; set; }
    DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    DbSet<EmployeePhone> EmployeePhones { get; set; }
    DbSet<EmployeeIBAN> EmployeeIBANs { get; set; }
    DbSet<Expense> Expenses { get; set; }
    DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public virtual Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entyList = ChangeTracker.Entries().Where(e => e.Entity is BaseModel
         && (e.State == EntityState.Deleted || e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entyList)
        {
            var baseEntity = (BaseModel)entry.Entity;
            if (entry.State == EntityState.Added)
            {
                baseEntity.InsertedDate = DateTime.Now;
                baseEntity.InsertedUser = appSession?.UserName ?? "anonymous";
                baseEntity.IsActive = true;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser =  appSession?.UserName ?? "anonymous";
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.IsActive = false;
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser =   appSession?.UserName ?? "anonymous";
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}