using FieldExpenseTracker.Core.Enums;
using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldExpenseTracker.Data.Seeds;

public static class EmployeeSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(
            new Employee
            {
                Id = 1,
                FirstName = "First",
                LastName = "Admin",
                Email = "first.admin@example.com",
                Position = "Manager",
                Salary = 75000,
                DateOfJoining = new DateTime(2020, 1, 15),
                EmployeeNumber = "EMP001",
                IsManager = true,
                Department = "Management",
                IsActive = true,
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
            },
            new Employee
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@example.com",
                Position = "Employee",
                Salary = 90000,
                DateOfJoining = new DateTime(2018, 5, 10),
                EmployeeNumber = "EMP002",
                IsManager = false,
                Department = "IT",
                IsActive = true,
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
            }
        );
    }
}
