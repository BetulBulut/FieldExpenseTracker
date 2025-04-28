using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Data.Configurations;
using Microsoft.EntityFrameworkCore;


namespace FieldExpenseTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
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
                baseEntity.InsertedUser ="anonymous";
                baseEntity.IsActive = true;
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser = "anonymous";
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.IsActive = false;
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser =  "anonymous";
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}