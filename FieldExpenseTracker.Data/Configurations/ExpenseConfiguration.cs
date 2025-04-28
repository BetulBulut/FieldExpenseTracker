using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(e => e.Amount)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(e => e.Date)
                .IsRequired();
            builder.Property(e => e.ReceiptImagePath)
                .HasMaxLength(255);
            builder.Property(e => e.Currency)
                .IsRequired()
                .HasConversion<int>();
            builder.Property(e => e.ExpenseNumber)
                .IsRequired()
                .HasMaxLength(10);
            builder.Property(e => e.ResponsedByUserName)
                .HasMaxLength(100);
            builder.Property(e => e.Status)
                .IsRequired()
                .HasConversion<int>();
            
        }
    }
}