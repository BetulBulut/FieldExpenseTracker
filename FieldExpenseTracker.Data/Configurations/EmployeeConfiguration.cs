using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.Position)
                .HasMaxLength(50);
            builder.Property(e => e.Salary)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(e => e.DateOfJoining)
                .IsRequired();
            builder.Property(e => e.IsManager)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(e => e.Department)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(e => e.EmployeeNumber)
                .IsRequired()
                .HasMaxLength(11);

            builder.HasIndex(e => e.EmployeeNumber)
                    .IsUnique();
        }
    }
}