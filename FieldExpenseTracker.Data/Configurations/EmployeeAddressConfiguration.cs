using FieldExpenseTracker.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FieldExpenseTracker.Data.Configurations
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {
        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.ToTable("EmployeeAddresses");
            builder.HasKey(ea => ea.Id);
            builder.Property(ea => ea.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(ea => ea.Street)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(ea => ea.City)
                .IsRequired()
                .HasMaxLength(20);
            builder.Property(ea => ea.State)
                .HasMaxLength(50);
            builder.Property(ea => ea.ZipCode)
                .HasMaxLength(20);
            builder.Property(ea => ea.Country)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(ea => ea.IsDefault)
                .IsRequired();
        }
    }
}