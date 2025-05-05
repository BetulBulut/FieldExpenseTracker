using FieldExpenseTracker.Core.Models;
using FieldExpenseTracker.Core.Session;
using FieldExpenseTracker.Data.Configurations;
using FieldExpenseTracker.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace FieldExpenseTracker.Data;

public class AppDbContext : DbContext
{
    private readonly IAppSession? appSession;

    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider? serviceProvider = null) : base(options)
    {
        this.appSession = serviceProvider?.GetService<IAppSession>();
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAddress> EmployeeAddresses { get; set; }
    public DbSet<EmployeePhone> EmployeePhones { get; set; }
    public DbSet<EmployeeIBAN> EmployeeIBANs { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmployeeConfiguration).Assembly);
        EmployeeSeeder.Seed(modelBuilder);
        ExpenseCategorySeeder.Seed(modelBuilder);
        UserSeeder.Seed(modelBuilder);
        PaymentMethodSeeder.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
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
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser = appSession?.UserName ?? "anonymous";
            }
            else if (entry.State == EntityState.Modified)
            {
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser = appSession?.UserName ?? "anonymous";
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                baseEntity.IsActive = false;
                baseEntity.UpdatedDate = DateTime.Now;
                baseEntity.UpdatedUser = appSession?.UserName ?? "anonymous";
            }
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
