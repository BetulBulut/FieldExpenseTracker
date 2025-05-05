using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FieldExpenseTracker.Data.Seeds;

public static class PaymentMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PaymentMethod>().HasData(
            new PaymentMethod
            {
                Id = 1,
                Name = "Credit Card",
                Description = "Credit card payment method",
                InsertedDate = new DateTime(2023, 1, 1),
                InsertedUser = "system",
                UpdatedDate = new DateTime(2023, 1, 1),
                UpdatedUser = "system"
            },
            new PaymentMethod
            {
                Id = 2,
                Name = "Debit Card",
                Description = "Debit card payment method",
                InsertedDate = new DateTime(2023, 1, 1),
                InsertedUser = "system",
                UpdatedDate = new DateTime(2023, 1, 1),
                UpdatedUser = "system"
            },
            new PaymentMethod
            {
                Id = 3,
                Name = "Cash",
                Description = "Cash payment method",
                InsertedDate = new DateTime(2023, 1, 1),
                InsertedUser = "system",
                UpdatedDate = new DateTime(2023, 1, 1),
                UpdatedUser = "system"
            },
            new PaymentMethod
            {
                Id = 4,
                Name = "Bank Transfer",
                Description = "Bank transfer payment method",
                InsertedDate = new DateTime(2023, 1, 1),
                InsertedUser = "system",
                UpdatedDate = new DateTime(2023, 1, 1),
                UpdatedUser = "system"
            },
            new PaymentMethod
            {
                Id = 5,
                Name = "Other",
                Description = "Other payment method",
                InsertedDate = new DateTime(2023, 1, 1),
                InsertedUser = "system",
                UpdatedDate = new DateTime(2023, 1, 1),
                UpdatedUser = "system"
            }
        );
    }
}
