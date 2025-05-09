using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldExpenseTracker.Data.Seeds;

public static class ExpenseCategorySeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseCategory>().HasData(
            new ExpenseCategory
            {
                Id = 1,
                Name = "Travel",
                Description = "Expenses related to travel and transportation.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 2,
                Name = "Food",
                Description = "Expenses related to meals and dining.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 3,
                Name = "Office Supplies",
                Description = "Expenses for office-related supplies and equipment.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 4,
                Name = "Entertainment",
                Description = "Expenses for entertainment and team-building activities.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 5,
                Name = "Utilities",
                Description = "Expenses for utilities such as electricity and water.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 6,
                Name = "Miscellaneous",
                Description = "Other expenses that do not fit into the above categories.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 7,
                Name = "Training",
                Description = "Expenses related to training and development.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 8,
                Name = "Marketing",
                Description = "Expenses related to marketing and advertising.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 9,
                Name = "Client Entertainment",
                Description = "Expenses for entertaining clients or customers.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 10,
                Name = "Health & Safety",
                Description = "Expenses related to health and safety measures.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 11,
                Name = "Repairs & Maintenance",
                Description = "Expenses for repairs and maintenance of equipment.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 12,
                Name = "Insurance",
                Description = "Expenses related to insurance premiums.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 13,
                Name = "Shipping & Delivery",
                Description = "Expenses for shipping and delivery services.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 14,
                Name = "Subscriptions",
                Description = "Expenses for subscriptions to services or publications.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 15,
                Name = "Professional Fees",
                Description = "Expenses for professional services such as consulting.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 16,
                Name = "Research & Development",
                Description = "Expenses related to research and development activities.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 17,
                Name = "Legal",
                Description = "Expenses related to legal services and consultations.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            },
            new ExpenseCategory
            {
                Id = 18,
                Name = "Telecommunications",
                Description = "Expenses for telecommunications services.",
                InsertedDate = DateTime.Now,
                InsertedUser = "system",
                UpdatedDate = DateTime.Now,
                UpdatedUser = "system",
                IsActive = true
            }
        );
    }
}
