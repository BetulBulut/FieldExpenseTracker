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
                PasswordHash = "76c6f58ea9461f1ba60e9b85c0ef5848", //admin123
                Secret = "bc5b9c39e2771571a6eaf9cd2a56508cd5130bf076d414aa42111136f770cb62",
                Role = RoleEnum.Admin,
                FirstName = "System",
                LastName = "Administrator",
                OpenDate = DateTime.Now,
                LastLoginDate = null,
                EmployeeId =1,
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true,
            },
            new User
            {
                Id = 2,
                UserName = "user1",
                PasswordHash = "791782c17b595f2a44490c5430370eb5",//user123
                Secret = "9c0cabb913d2a6a6451f4ffbdb900bd68426b5fef1e19f859d6d1bce35c768f9",
                Role = RoleEnum.Employee,
                FirstName = "System",
                LastName = "Administrator",
                OpenDate = DateTime.Now,
                LastLoginDate = null,
                EmployeeId = 2,
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true,
            }
        );
    }
}
