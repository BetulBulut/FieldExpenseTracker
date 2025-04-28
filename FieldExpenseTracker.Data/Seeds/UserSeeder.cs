using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldExpenseTracker.Data.Seeds;

public static class UserSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                UserName = "admin",
                PasswordHash = "admin123", 
                Secret = "admin-secret",
                Role = RoleEnum.Admin,
                FirstName = "System",
                LastName = "Administrator",
                OpenDate = DateTime.Now,
                LastLoginDate = null
            },
            new User
            {
                Id = 2,
                UserName = "user1",
                PasswordHash = "user123",
                Secret = "user1-secret",
                Role = RoleEnum.Admin,
                FirstName = "System",
                LastName = "Administrator",
                OpenDate = DateTime.Now,
                LastLoginDate = null
            }
        );
    }
}
